using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using Newtonsoft.Json;
using TwitchLib.Client.Events;
using TwitchLib.PubSub;
using TwitchLib.PubSub.Events;
using TwitchLib.Client;
using TwitchLib.Client.Models;
using TwitchLib.Communication.Events;
using System.Diagnostics;
using TwitchLib.Client.Extensions;
using System.Windows.Forms;
using System.Media;

/* TODO **
 * Change bit commands to read saved cost data from controlmenu
 * Move commands to seperate script. Its slightly overwhelming
 * Add bitgrenade sound and volume control
 * update help
 * 
 */

namespace UiBot
{
    public class ConfigData
    {
        public string RandomKeyInputs { get; set; }
        public string DropKey { get; set; }
        public Point[] MouseCursorPositions { get; set; }
    }
    internal class MainBot : IDisposable
    {
        //bit dictionary 
        private static Dictionary<string, int> userBits = new Dictionary<string, int>();
        //command dictionary
        private Dictionary<string, string> commandConfigData;

        public int autoSendMessageCD;

        [DllImport("user32.dll", SetLastError = true)]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

        [DllImport("kernel32.dll")]
        private static extern bool FreeConsole();


        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        [DllImport("user32.dll", SetLastError = true)]

        [return: MarshalAs(UnmanagedType.Bool)]

        private static extern bool BlockInput([MarshalAs(UnmanagedType.Bool)] bool fBlockIt);

        // Mouse event constants
        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_MOVE = 0x0001;
        ControlMenu controlMenu = new ControlMenu();

        // Handles connection
        private ConnectionCredentials creds;
        TwitchClient client;
        private bool isBotConnected = false;
        private static TwitchPubSub pubSub;
        private static string channelId;


        //wiggle
        private Random random = new Random();
        private DateTime lastWiggleTime = DateTime.MinValue;
        private DateTime lastTurnTime = DateTime.MinValue;

        //random key press
        private DateTime lastRandomKeyPressesTime = DateTime.MinValue;

        //drop
        private DateTime lastDropCommandTime = DateTime.MinValue;
        private TimeSpan dropCommandCooldown;

        private TimeSpan randomKeyCooldown;


        private int deathCount = 0;
        Counter counter = new Counter();

        private DateTime lastPopCommandTime = DateTime.MinValue;
        private TimeSpan popCommandCooldown;

        private DateTime lastGooseCommandTime = DateTime.MinValue;
        private Process gooseProcess; // Declare a Process variable to store the Goose process.

        private DateTime lastnadeCommandTime = DateTime.MinValue;
        private TimeSpan grenadeCommandCooldown;
        string appDirectory = AppDomain.CurrentDomain.BaseDirectory;
        string soundFileName = Path.Combine("Sounds", "grenade.wav");

        private DateTime lastdropbagTime = DateTime.MinValue;


        internal MainBot()
        {
            LoadCredentialsFromJSON();
        }

        public void Dispose()
        {
            // Dispose of any resources here
            Disconnect();
        }

        public void LoadCredentialsFromJSON()
        {
            string jsonFilePath = "Logon.json";

            if (File.Exists(jsonFilePath))
            {
                string json = File.ReadAllText(jsonFilePath);
                CounterData data = JsonConvert.DeserializeObject<CounterData>(json);

                if (data != null && !string.IsNullOrEmpty(data.ChannelName))
                {
                    creds = new ConnectionCredentials(data.ChannelName, data.BotToken);
                    channelId = data.ChannelName;
                }
                else
                {
                    // Handle the case where the ChannelName is empty or invalid.
                    // You can show a message to the user or take appropriate action.
                }
            }
            else
            {
                // Handle the absence of the JSON file as needed.
            }
        }
        private class CounterData
        {
            public string ChannelName { get; set; }
            public string BotToken { get; set; }
        }

        public void Disconnect()
        {
            if (isBotConnected)
            {
                // Disconnect and clean up resources here
                client.Disconnect();
                pubSub.Disconnect();

                // Unsubscribe from events
                client.OnConnected -= Client_OnConnected;
                client.OnError -= Client_OnError;
                pubSub.OnFollow -= PubSub_OnFollow;

                isBotConnected = false;
            }
        }

        internal void Connect()
        {
            if (!isBotConnected)
            {
                Console.WriteLine("[Bot]: Connecting...");
                InitializeTwitchClient();
                InitializePubSub();
                StartTraderResetTimer();
                StartAutoMessage();

            }
        }


        private void InitializeTwitchClient()
        {
            if (!isBotConnected)
            {
                if (string.IsNullOrEmpty(Properties.Settings.Default.AccessToken) || string.IsNullOrEmpty(Properties.Settings.Default.ChannelName))
                {
                    MessageBox.Show("Please enter token access and channel name in the Settings Menu");
                    Console.WriteLine("[Bot]: Disconnected");
                    return; // Don't proceed further
                }

                try
                {
                    client = new TwitchClient();
                    client.Initialize(creds, channelId);
                    client.OnConnected += Client_OnConnected;
                    client.OnError += Client_OnError;
                    client.OnMessageReceived += Client_OnMessageReceived;
                    client.OnChatCommandReceived += Client_OnChatCommandReceived;
                    client.AddChatCommandIdentifier('$');
                    client.OnConnected += (sender, e) => isBotConnected = true;
                    client.Connect();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred during Twitch client initialization: {ex.Message}");
                }
            }
        }


        private void InitializePubSub()
        {
            pubSub = new TwitchPubSub();
            pubSub.OnFollow += PubSub_OnFollow;
            pubSub.ListenToFollows(channelId);
            pubSub.Connect();
        }

        private void Client_OnMessageReceived(object sender, OnMessageReceivedArgs e)
        {
            Console.WriteLine($"[{e.ChatMessage.DisplayName}]: {e.ChatMessage.Message}");
            if (e.ChatMessage.Bits > 0)
            {
                string username = e.ChatMessage.DisplayName;
                int bits = e.ChatMessage.Bits;

                // Log the cheer to a general log file (append)
                string logMessage = $"{DateTime.Now}: {username} cheered {bits} bits.";
                File.AppendAllText("cheer_log.txt", logMessage + Environment.NewLine);
                Console.WriteLine(logMessage);

                // Update the user's total bits in the dictionary
                if (userBits.ContainsKey(username))
                {
                    userBits[username] += bits;
                }
                else
                {
                    userBits[username] = bits;
                }

                // Log the user's total bits to a separate file (overwrite)
                foreach (var kvp in userBits)
                {
                    File.WriteAllText($"{kvp.Key}_bits.txt", $"{kvp.Key}: {kvp.Value} bits");
                }
            }


        }

        private void PubSub_OnFollow(object sender, OnFollowArgs e)
        {
            string followerUsername = e.DisplayName;
            Console.WriteLine($"New follower: {followerUsername}");
            client.SendMessage(channelId, $"{followerUsername} Thank you for following. Sprollucy look!");
        }


        private void Client_OnError(object sender, OnErrorEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Client_OnConnected(object sender, OnConnectedArgs e)
        {
            Console.WriteLine("[Bot]: Connected");
        }

        public void SendMessage(string message)
        {
            if (client.IsConnected)
            {
                string channelName = channelId;

                // Send the message to the specified channel
                client.SendMessage(channelName, message);
            }
            else
            {
                Console.WriteLine("Bot is not connected to Twitch. Cannot send message.");
            }
        }


        //Chat 
        private async void Client_OnChatCommandReceived(object sender, OnChatCommandReceivedArgs e)
        {
            var traderResetInfoService = new TraderResetInfoService();

            Process[] pname = Process.GetProcessesByName("notepad");
            Process[] gname = Process.GetProcessesByName("GooseDesktop");



            //Normal Commands
            switch (e.Command.CommandText.ToLower())
            {
                // to ad "mybits"

                case "roll":
                    string msg = $"{e.Command.ChatMessage.DisplayName} Rolled {RndInt(1, 6)}";
                    client.SendMessage(channelId, msg);
                    Console.WriteLine($"[Bot]: {msg}");
                    break;
                case "help":
                    client.SendMessage(channelId, "!traders, !drop, !goose, !help, !killgoose, !randomkeys, !roll, !stats, !turn, !wiggle, !pop, !grenade, !dropbag\n Some commands may be broken!");
                    break;
                case "stats":
                    client.SendMessage(channelId, $"Sprollucy has died {deathCount} times today, and has escaped {counter.SurvivalCount} times");
                    client.SendMessage(channelId, $"Deaths this wipe: {counter.AllDeath}");
                    break;

                case "mybits":
                    string requester = e.Command.ChatMessage.DisplayName;
                    if (userBits.ContainsKey(requester))
                    {
                        // Send a message to the user indicating their total bits
                        client.SendMessage(channelId, $"{requester}, you have {userBits[requester]} bits.");
                    }
                    else
                    {
                        // Send a message if the user has no bits recorded
                        client.SendMessage(channelId, $"{requester}, you have no bits recorded.");
                    }
                    break;

                case "traders":
                    // Update the resetTime.json file with the latest reset info
                    await traderResetInfoService.GetAndSaveTraderResetInfoWithLatest();

                    // Read the reset time data from resetTime.json
                    var resetTimeData = traderResetInfoService.ReadJsonDataFromFile("resetTime.json");

                    if (!string.IsNullOrEmpty(resetTimeData))
                    {
                        // Deserialize the JSON data
                        var traderResetResponse = JsonConvert.DeserializeObject<TraderResetInfoService.TraderResetResponse>(resetTimeData);

                        if (traderResetResponse != null && traderResetResponse.Data != null && traderResetResponse.Data.Traders != null)
                        {
                            foreach (var trader in traderResetResponse.Data.Traders)
                            {
                                string traderName = trader.Name;
                                string resetTime = trader.ResetTime;

                                // Parse the reset time as a DateTime
                                if (DateTime.TryParse(resetTime, null, System.Globalization.DateTimeStyles.RoundtripKind, out DateTime resetDateTime))
                                {
                                    // Get the local time zone
                                    TimeZoneInfo localTimeZone = TimeZoneInfo.Local;

                                    // Convert the reset time from UTC to local time
                                    DateTime localResetTime = TimeZoneInfo.ConvertTimeFromUtc(resetDateTime, localTimeZone);

                                    // Calculate the time remaining until the reset time
                                    TimeSpan timeRemaining = localResetTime - DateTime.Now;

                                    // Check if the time remaining is negative
                                    if (timeRemaining < TimeSpan.Zero)
                                    {
                                        // The reset time has passed; set the time remaining to zero
                                        timeRemaining = TimeSpan.Zero;
                                    }

                                    // Debugging: Print resetTime and timeRemaining
                                    Console.WriteLine($"Trader Name: {traderName}, Reset Time: {resetTime}");
                                    Console.WriteLine($"Time Remaining: {timeRemaining}");

                                    // Format the time difference as hours and minutes
                                    string formattedTimeRemaining = $"{(int)timeRemaining.TotalHours} hours {timeRemaining.Minutes} minutes";

                                    // Send a separate alert if there are 5 minutes or less remaining
                                    if (timeRemaining <= TimeSpan.FromMinutes(5))
                                    {
                                        client.SendMessage(channelId, $"@{channelId} {traderName} has 5 minutes or less remaining! Countdown: {formattedTimeRemaining}");
                                    }
                                    else
                                    {
                                        // Send the regular countdown message
                                        client.SendMessage(channelId, $"Trader Name: {traderName}, Countdown: {formattedTimeRemaining}");
                                    }
                                }
                                else
                                {
                                    // Handle the case where the reset time cannot be parsed
                                    client.SendMessage(channelId, $"Failed to parse reset time for trader '{traderName}'.");
                                }
                            }
                        }
                        else
                        {
                            // Handle the case where the JSON data is not as expected
                            client.SendMessage(channelId, "Failed to fetch trader reset info.");
                        }
                    }
                    else
                    {
                        // Handle the case where resetTime.json is empty or not found
                        client.SendMessage(channelId, "Reset time data not available.");
                    }
                    break;

                case "dropbag":
                    if (Properties.Settings.Default.isDropBagEnabled)
                    {
                        TimeSpan remainingCooldown = GetRemainingDropBagCooldown();
                        if (remainingCooldown.TotalSeconds > 0)
                        {
                            client.SendMessage(channelId, $"Drop Bag command is on cooldown. Remaining time: {remainingCooldown.TotalSeconds:F0} seconds.");
                        }
                        else
                        {

                            lastdropbagTime = DateTime.Now; 
                            BagDrop();
                            client.SendMessage(channelId, $"Bag dropped! Remaining time: {remainingCooldown.TotalSeconds:F0} seconds.");
                            remainingCooldown = GetRemainingDropBagCooldown();
                        }
                    }
                    else
                    {
                        client.SendMessage(channelId, "Drop Bag command is currently disabled.");
                    }
                    break;

                case "goose":
                    if (!Properties.Settings.Default.IsGooseEnabled)
                    {
                        client.SendMessage(channelId, "Goose command is currently disabled.");
                    }
                    else if (gname.Length > 0)
                    {
                        client.SendMessage(channelId, "Goose is already running!");
                    }
                    else
                    {
                        // Parse the cooldown time from the gooseCooldownTextBox
                        if (int.TryParse(controlMenu.GooseCooldownTextBox.Text, out int cooldownSeconds))
                        {
                            TimeSpan gooseCooldown = TimeSpan.FromSeconds(cooldownSeconds);

                            if (DateTime.Now - lastGooseCommandTime < gooseCooldown)
                            {
                                TimeSpan remainingCooldown = gooseCooldown - (DateTime.Now - lastGooseCommandTime);
                                client.SendMessage(channelId, $"Goose command is on cooldown. You can use it again in {remainingCooldown.TotalSeconds:F0} minutes.");
                            }
                            else
                            {
                                // Get the directory where the executable is located
                                string exeDirectory = AppDomain.CurrentDomain.BaseDirectory;

                                // Combine the directory with the "Goose" folder and the filename to get the full path to GooseDesktop.exe
                                string gooseExePath = Path.Combine(exeDirectory, "Goose", "GooseDesktop.exe");

                                if (File.Exists(gooseExePath))
                                {
                                    // Generate a random runtime between 2 and 5 minutes.
                                    Random random = new Random();
                                    int runtimeMinutes = random.Next(2, 6); // Adjust the range as needed
                                    TimeSpan runtime = TimeSpan.FromMinutes(runtimeMinutes);

                                    // Start the Goose process and store it in the gooseProcess variable.
                                    gooseProcess = Process.Start(gooseExePath);
                                    lastGooseCommandTime = DateTime.Now;

                                    // Send a message indicating how long the Goose will run
                                    client.SendMessage(channelId, $"Goose is running for {runtimeMinutes} minutes!");

                                    // Schedule a task to stop the Goose process after the random runtime.
                                    Task.Run(() =>
                                    {
                                        Thread.Sleep(runtime);
                                        if (!gooseProcess.HasExited)
                                        {
                                            gooseProcess.Kill(); // Terminate the Goose process.
                                            client.SendMessage(channelId, "Goose has been terminated.");
                                        }
                                    });
                                }
                                else
                                {
                                    client.SendMessage(channelId, "GooseDesktop.exe not found in the 'Goose' folder. Please make sure it's in the correct location.");
                                }
                            }
                        }
                        else
                        {
                            client.SendMessage(channelId, "Invalid cooldown time. Please enter a valid number of minutes in the Goose cooldown textbox.");
                        }
                    }
                    break;


                case "killgoose":
                    if (gname.Length > 0)
                    {
                        client.SendMessage(channelId, "Goose is DEAD");
                        foreach (Process process in Process.GetProcessesByName("GooseDesktop"))
                        {
                            process.Kill();
                        }
                        break;
                    }
                    else
                    {
                        client.SendMessage(channelId, "Goose is already DEAD");
                    }

                    break;

                case "wiggle":
                    if (Properties.Settings.Default.IsWiggleEnabled)
                    {
                        // Continue with the Wiggle command execution
                        TimeSpan remainingCooldown = GetRemainingWiggleCooldown();
                        if (remainingCooldown.TotalSeconds > 0)
                        {
                            client.SendMessage(channelId, $"Wiggle command is on cooldown. Remaining time: {remainingCooldown.TotalSeconds:F0} seconds.");
                        }
                        else
                        {
                            lastWiggleTime = DateTime.Now; // Record the start time before wiggling
                            WiggleMouse(4, 30, 50); //format is turns, distance in px, delay between move
                            remainingCooldown = GetRemainingWiggleCooldown(); // Recalculate remaining cooldown
                            client.SendMessage(channelId, $"Wiggle command is now on cooldown. Remaining time: {remainingCooldown.TotalSeconds:F0} seconds.");

                        }
                    }
                    else
                    {
                        client.SendMessage(channelId, "Wiggle command is currently disabled.");
                    }
                    break;


                case "turn":
                    if (Properties.Settings.Default.IsTurnEnabled)
                    {
                        TimeSpan remainingCooldown = GetRemainingTurnCooldown();
                        if (remainingCooldown.TotalSeconds > 0)
                        {
                            client.SendMessage(channelId, $"Turn command is on cooldown. Remaining time: {remainingCooldown.TotalSeconds:F0} seconds.");
                        }
                        else
                        {
                            lastTurnTime = DateTime.Now; // Record the start time before wiggling

                            // Randomly decide whether to move the mouse to the right or left
                            bool moveRight = (new Random()).Next(2) == 0;

                            TurnRandom(2000);

                            remainingCooldown = GetRemainingTurnCooldown(); // Recalculate remaining cooldown
                            client.SendMessage(channelId, $"Turn is on cooldown for {remainingCooldown.TotalSeconds:F0} seconds");
                        }
                    }
                    else
                    {
                        client.SendMessage(channelId, "Wiggle command is currently disabled.");
                    }
                    break;



                case "randomkeys":
                    // Check if the command is enabled
                    if (Properties.Settings.Default.IsKeyEnabled)
                    {
                        if (int.TryParse(controlMenu.RandomKeyCooldownTextBox.Text, out int cooldownSeconds))
                        {
                            TimeSpan remainingCooldown = GetRemainingRandomKeyPressesCooldown();

                            if (cooldownSeconds <= 0)
                            {
                                lastRandomKeyPressesTime = DateTime.Now;
                                SendRandomKeyPresses();
                                client.SendMessage(channelId, $"Random keypresses command is now on cooldown. Remaining time: {remainingCooldown.TotalSeconds:F0} seconds.");
                            }
                            else if (IsRandomKeyPressesCommandOnCooldown())
                            {
                                client.SendMessage(channelId, $"Random keypresses command is on cooldown. Remaining time: {remainingCooldown.TotalSeconds:F0} seconds.");
                            }
                            else
                            {
                                lastRandomKeyPressesTime = DateTime.Now;
                                SendRandomKeyPresses();

                                // Set the cooldown duration based on the TextBox value in seconds
                                int cooldownMilliseconds = cooldownSeconds * 1000; // Convert seconds to milliseconds.
                                randomKeyCooldown = TimeSpan.FromMilliseconds(cooldownMilliseconds);
                                client.SendMessage(channelId, $"Random keypresses command is now on cooldown. Remaining time: {remainingCooldown.TotalSeconds:F0} seconds.");

                            }
                        }
                        else
                        {
                            client.SendMessage(channelId, "Invalid cooldown time format. Please enter a positive number in seconds.");
                        }
                    }
                    else
                    {
                        client.SendMessage(channelId, "The random keypresses command is currently disabled.");
                    }
                    break;




                case "drop":
                    if (Properties.Settings.Default.IsDropEnabled)
                    {
                        if (int.TryParse(controlMenu.DropCooldownTextBox.Text, out int cooldownSeconds))
                        {
                            TimeSpan remainingCooldown = dropCommandCooldown - (DateTime.Now - lastDropCommandTime);

                            if (cooldownSeconds <= 0)
                            {
                                // If cooldown is 0 or negative, there's no cooldown
                                SimulateButtonPressAndMouseMovement();
                                lastDropCommandTime = DateTime.Now; // Update the last command time
                                client.SendMessage(channelId, $"Kit dropped! You can use it again in {remainingCooldown.TotalSeconds:F0} seconds.");

                            }
                            else if (DateTime.Now - lastDropCommandTime < dropCommandCooldown)
                            {
                                client.SendMessage(channelId, $"Drop command is on cooldown. You can use it again in {remainingCooldown.TotalSeconds:F0} seconds.");
                            }
                            else
                            {
                                SimulateButtonPressAndMouseMovement();
                                lastDropCommandTime = DateTime.Now;

                                // Set the cooldown duration based on the TextBox value in seconds
                                int cooldownMilliseconds = cooldownSeconds * 1000; // Convert seconds to milliseconds.
                                dropCommandCooldown = TimeSpan.FromMilliseconds(cooldownMilliseconds);
                                client.SendMessage(channelId, $"Drop command is now on cooldown. You can use it again in {remainingCooldown.TotalSeconds:F0} seconds.");

                            }
                        }
                        else
                        {
                            client.SendMessage(channelId, "Invalid cooldown time format. Please enter a positive number in seconds.");
                        }
                    }
                    else
                    {
                        client.SendMessage(channelId, "The drop command is currently disabled.");
                    }
                    break;


                case "pop":
                    if (Properties.Settings.Default.IsPopEnabled)
                    {
                        if (int.TryParse(controlMenu.OneClickCooldownTextBox.Text, out int cooldownSeconds))
                        {
                            TimeSpan remainingCooldown = popCommandCooldown - (DateTime.Now - lastPopCommandTime);

                            if (cooldownSeconds <= 0)
                            {

                                // If cooldown is 0 or negative, there's no cooldown
                                PopShot();
                                lastPopCommandTime = DateTime.Now;
                                client.SendMessage(channelId, $"Pop! You can use it again in {remainingCooldown.TotalSeconds:F0} seconds.");

                            }
                            else if (DateTime.Now - lastPopCommandTime < popCommandCooldown)
                            {
                                client.SendMessage(channelId, $"Pop command is on cooldown. You can use it again in {remainingCooldown.TotalSeconds:F0} seconds.");
                            }
                            else
                            {
                                PopShot();
                                lastPopCommandTime = DateTime.Now;

                                // Set the cooldown duration based on the TextBox value in seconds
                                int cooldownMilliseconds = cooldownSeconds * 1000; // Convert seconds to milliseconds.
                                popCommandCooldown = TimeSpan.FromMilliseconds(cooldownMilliseconds);
                                client.SendMessage(channelId, $"Pop! You can use it again in {remainingCooldown.TotalSeconds:F0} seconds.");

                            }
                        }
                        else
                        {
                            client.SendMessage(channelId, "Invalid cooldown time format. Please enter a positive number in seconds.");
                        }
                    }
                    else
                    {
                        client.SendMessage(channelId, "The pop command is currently disabled.");
                    }
                    break;

                case "grenade":
                    if (Properties.Settings.Default.isGrenadeEnabled)
                    {
                        if (int.TryParse(controlMenu.GrenadeCooldownTextBox.Text, out int cooldownSeconds))
                        {
                            TimeSpan remainingCooldown = grenadeCommandCooldown - (DateTime.Now - lastPopCommandTime);

                            if (cooldownSeconds <= 0)
                            {
                                // If cooldown is 0 or negative, there's no cooldown
                                GrenadeSound();
                                lastnadeCommandTime = DateTime.Now; 
                                client.SendMessage(channelId, $"Grenade command is on cooldown. You can use it again in {remainingCooldown.TotalSeconds:F0} seconds.");

                            }
                            else if (DateTime.Now - lastnadeCommandTime < grenadeCommandCooldown)
                            {
                                client.SendMessage(channelId, $"Grenade command is on cooldown. You can use it again in {remainingCooldown.TotalSeconds:F0} seconds.");
                            }
                            else
                            {    
                                GrenadeSound();
                                lastnadeCommandTime = DateTime.Now;

                                // Set the cooldown duration based on the TextBox value in seconds
                                int cooldownMilliseconds = cooldownSeconds * 1000; // Convert seconds to milliseconds.
                                grenadeCommandCooldown = TimeSpan.FromMilliseconds(cooldownMilliseconds);
                                client.SendMessage(channelId, $"Grenade command is on cooldown. You can use it again in {remainingCooldown.TotalSeconds:F0} seconds.");

                            }
                        }
                        else
                        {
                            client.SendMessage(channelId, "Invalid cooldown time format. Please enter a positive number in seconds.");
                        }
                    }
                    else
                    {
                        client.SendMessage(channelId, "The Grenade command is currently disabled.");
                    }
                    break;

                //bitcommands

                case "bitgoose":
                    if (!Properties.Settings.Default.IsGooseEnabled && Properties.Settings.Default.isBitEnabled)
                    {
                        client.SendMessage(channelId, "Goose command is currently disabled.");
                    }
                    else if (gname.Length > 0)
                    {
                        client.SendMessage(channelId, "Goose is already running!");
                    }
                    else
                    {

                        // Get the directory where the executable is located
                        string exeDirectory = AppDomain.CurrentDomain.BaseDirectory;

                        // Combine the directory with the "Goose" folder and the filename to get the full path to GooseDesktop.exe
                        string gooseExePath = Path.Combine(exeDirectory, "Goose", "GooseDesktop.exe");

                        if (File.Exists(gooseExePath))
                        {
                            // Generate a random runtime between 2 and 5 minutes.
                            Random random = new Random();
                            int runtimeMinutes = random.Next(2, 6); // Adjust the range as needed
                            TimeSpan runtime = TimeSpan.FromMinutes(runtimeMinutes);

                            // Start the Goose process and store it in the gooseProcess variable.
                            gooseProcess = Process.Start(gooseExePath);
                            lastGooseCommandTime = DateTime.Now;

                            // Send a message indicating how long the Goose will run
                            client.SendMessage(channelId, $"Goose is running for {runtimeMinutes} minutes!");

                            // Schedule a task to stop the Goose process after the random runtime.
                            Task.Run(() =>
                            {
                                Thread.Sleep(runtime);
                                if (!gooseProcess.HasExited)
                                {
                                    gooseProcess.Kill(); // Terminate the Goose process.
                                    client.SendMessage(channelId, "Goose has been terminated.");
                                }
                            });
                        }

                        client.SendMessage(channelId, "GooseDesktop.exe not found in the 'Goose' folder. Please make sure it's in the correct location.");

                    }
                    break;

                case "bitwiggle":
                    if (Properties.Settings.Default.IsWiggleEnabled && Properties.Settings.Default.isBitEnabled)
                    {
                        // Check if the user has enough bits (at least the required amount from wigglecostbox)
                        requester = e.Command.ChatMessage.DisplayName;

                        int requiredBits;

                        if (int.TryParse(controlMenu.WiggleCostBox.Text, out requiredBits))
                        {
                            if (userBits.ContainsKey(requester) && userBits[requester] >= requiredBits)
                            {
                                // Deduct the bits from the user
                                userBits[requester] -= requiredBits;

                                lastWiggleTime = DateTime.Now; // Record the start time before wiggling
                                                               // format is turns, distance in px, delay between move
                                WiggleMouse(4, 30, 50);
                                client.SendMessage(channelId, $"Mouse wiggle!");
                            }
                            else
                            {
                                // User doesn't have enough bits
                                client.SendMessage(channelId, $"{requester}, you need at least {requiredBits} bits to use the Wiggle command.");
                            }
                        }
                        else
                        {
                            // Failed to parse requiredBits from the textbox
                            client.SendMessage(channelId, "Invalid bit cost entered.");
                        }
                    }
                    else
                    {
                        client.SendMessage(channelId, "Wiggle command is currently disabled.");
                    }
                    break;

                case "bitturn":
                    if (Properties.Settings.Default.IsTurnEnabled && Properties.Settings.Default.isBitEnabled)
                    {

                        // If cooldown is 0 or negative, there's no cooldown
                        requester = e.Command.ChatMessage.DisplayName;

                        // Define the required number of bits
                        int requiredBits = 50;

                        // Check if the user has enough bits
                        if (userBits.ContainsKey(requester) && userBits[requester] >= requiredBits)
                        {
                            // Deduct the bits from the user
                            userBits[requester] -= requiredBits;

                            // Send a message indicating the deduction
                            client.SendMessage(channelId, $"{requester} spent {requiredBits} bits on the turn command.");

                            lastTurnTime = DateTime.Now; // Record the start time before wiggling

                            // Randomly decide whether to move the mouse to the right or left
                            bool moveRight = (new Random()).Next(2) == 0;

                            TurnRandom(2000);

                            client.SendMessage(channelId, "Turn executed.");
                        }
                        else
                        {
                            // User doesn't have enough bits
                            client.SendMessage(channelId, $"{requester}, you need at least {requiredBits} bits to use the turn command.");
                        }
                    }
                    else
                    {
                        client.SendMessage(channelId, "Turn command is currently disabled.");
                    }
                    break;


                case "bitrandomkeys":
                    // Check if the command is enabled
                    if (Properties.Settings.Default.IsKeyEnabled && Properties.Settings.Default.isBitEnabled)
                    {
                        // Check if the user has enough bits (at least 50)
                        requester = e.Command.ChatMessage.DisplayName;
                        int requiredBits = 50;

                        if (userBits.ContainsKey(requester) && userBits[requester] >= requiredBits)
                        {
                            // Deduct the bits from the user
                            userBits[requester] -= requiredBits;


                            SendRandomKeyPresses();
                            client.SendMessage(channelId, "Hold that key!");
                            lastRandomKeyPressesTime = DateTime.Now;

                        }

                        else
                        {
                            // User doesn't have enough bits
                            client.SendMessage(channelId, $"{requester}, you need at least {requiredBits} bits to use the Randomkeys command.");
                        }
                    }
                    else
                    {
                        client.SendMessage(channelId, "The random keypresses command is currently disabled.");
                    }
                    break;



                case "bitdrop":
                    if (Properties.Settings.Default.IsDropEnabled && Properties.Settings.Default.isBitEnabled)
                    {
                        // Check if the user has enough bits (at least 50)
                        requester = e.Command.ChatMessage.DisplayName;
                        int requiredBits = 50;

                        if (userBits.ContainsKey(requester) && userBits[requester] >= requiredBits)
                        {
                            // Deduct the bits from the user
                            userBits[requester] -= requiredBits;


                            // If cooldown is 0 or negative, there's no cooldown
                            SimulateButtonPressAndMouseMovement();
                            client.SendMessage(channelId, "Simulated button press and mouse movement.");
                            lastDropCommandTime = DateTime.Now; // Update the last command time
                        }


                        else
                        {
                            // User doesn't have enough bits
                            client.SendMessage(channelId, $"{requester}, you need at least {requiredBits} bits to use the Drop command.");
                        }
                    }
                    else
                    {
                        client.SendMessage(channelId, "The drop command is currently disabled.");
                    }
                    break;

                case "bitpop":
                    if (Properties.Settings.Default.IsPopEnabled && Properties.Settings.Default.isBitEnabled)
                    {
                        // Check if the user has enough bits (at least 50)
                        requester = e.Command.ChatMessage.DisplayName;
                        int requiredBits = 50;

                        if (userBits.ContainsKey(requester) && userBits[requester] >= requiredBits)
                        {
                            // Deduct the bits from the user
                            userBits[requester] -= requiredBits;

                            PopShot();
                            client.SendMessage(channelId, $"Oops misclick!");
                            lastPopCommandTime = DateTime.Now;

                        }
                        else
                        {
                            // User doesn't have enough bits
                            client.SendMessage(channelId, $"{requester}, you need at least {requiredBits} bits to use the Pop command.");
                        }
                    }
                    else
                    {
                        client.SendMessage(channelId, "The pop command is currently disabled.");
                    }
                    break;
            }


            //Mod Commands
            if (e.Command.ChatMessage.IsModerator)
            {

                switch (e.Command.CommandText.ToLower())
                {
                    case "help":
                        client.SendMessage(channelId, "!death, !escape, !resetdeath");
                        break;

                    //start windows proccesses 
                    case "note":
                        if (pname.Length > 0)
                        {
                            break;
                        }
                        else
                        {
                            Process notePad = new Process();
                            notePad.StartInfo.FileName = "notepad.exe";
                            notePad.Start();
                        }

                        break;

                    case "death":
                        deathCount = deathCount + 1;
                        counter.IncrementAllDeath();
                        client.SendMessage(channelId, $"Sprollucy has died {deathCount} times");
                        client.SendMessage(channelId, $"Deaths this wipe: {counter.AllDeath}");
                        break;

                    case "escape":
                        counter.IncrementSurvivalCount();
                        client.SendMessage(channelId, $"Sprollucy has escaped {counter.SurvivalCount} times");
                        break;

                    case "resetdeath":
                        deathCount = 0;
                        client.SendMessage(channelId, "Deaths have been cleared!");
                        break;

                }
            }

            //Channel owner chat
            if (e.Command.ChatMessage.IsBroadcaster)
            {


                switch (e.Command.CommandText.ToLower())
                {
                    case "help":
                        client.SendMessage(channelId, "!hi, !goose, !killgoose, !death, !escape, !resetdeath, !resetallstats");
                        break;
                    case "hi":
                        client.SendMessage(channelId, "Hi Boss");
                        break;
                    //start windows proccesses 
                    case "note":
                        if (pname.Length > 0)
                        {
                            break;
                        }
                        else
                        {
                            Process notePad = new Process();
                            notePad.StartInfo.FileName = "notepad.exe";
                            notePad.Start();
                        }

                        break;

                    case "death":
                        deathCount = deathCount + 1;
                        counter.IncrementAllDeath();
                        client.SendMessage(channelId, $"Sprollucy has died {deathCount} times");
                        client.SendMessage(channelId, $"Deaths this wipe: {counter.AllDeath}");
                        break;

                    case "resetdeath":
                        client.SendMessage(channelId, $"Deaths Reset");
                        deathCount = 0;
                        break;

                    case "escape":
                        counter.IncrementSurvivalCount();
                        client.SendMessage(channelId, $"Sprollucy has escaped {counter.SurvivalCount} times");
                        break;

                    case "resetallstats":
                        client.SendMessage(channelId, "All stats reset!");
                        counter.ResetAllDeath();
                        counter.ResetSurvivalCount();
                        deathCount = 0;
                        break;


                }
            }
        }




        private bool IsRandomKeyPressesCommandOnCooldown()
        {
            TimeSpan cooldownDuration = TimeSpan.FromMinutes(random.Next(2, 15)); // Random cooldown between 1 and 10 minutes
            DateTime cooldownEndTime = lastRandomKeyPressesTime.Add(cooldownDuration);

            return DateTime.Now < cooldownEndTime;
        }

        private TimeSpan GetRemainingRandomKeyPressesCooldown()
        {
            TimeSpan cooldownDuration = TimeSpan.FromMinutes(random.Next(2, 15)); // Random cooldown between 2 and 15 minutes
            DateTime cooldownEndTime = lastRandomKeyPressesTime.Add(cooldownDuration);
            TimeSpan remainingCooldown = cooldownEndTime - DateTime.Now;

            return (remainingCooldown.TotalSeconds > 0) ? remainingCooldown : TimeSpan.Zero;
        }

        private static void SendRandomKeyPresses()
        {
            // Load the keys from CommandConfigData.json
            string configFilePath = "CommandConfigData.json"; // Adjust the file path as needed
            string keysInput;

            try
            {
                // Read the JSON file and parse it to extract the keys
                string json = File.ReadAllText(configFilePath);
                var configData = JsonConvert.DeserializeObject<ConfigData>(json);
                keysInput = configData?.RandomKeyInputs;
            }
            catch (Exception ex)
            {
                // Handle any errors, such as file not found or JSON parsing issues
                Console.WriteLine($"Error reading JSON file: {ex.Message}");
                return;
            }

            if (string.IsNullOrEmpty(keysInput))
            {
                Console.WriteLine("No keys to send.");
                return;
            }

            Random random = new Random();
            string[] keys = keysInput.Split(',');

            foreach (string key in keys)
            {
                string cleanedKey = key.Trim(); // Remove any leading/trailing spaces
                SendKeys.SendWait(cleanedKey);

                // Apply a random hold duration between 250ms and 1000ms
                int holdDuration = random.Next(250, 1001);
                Thread.Sleep(holdDuration);
            }
        }


        public static void WiggleMouse(int numWiggles, int wiggleDistance, int delayBetweenWiggles)
        {
            for (int i = 0; i < numWiggles; i++)
            {
                // Move the mouse to the right
                mouse_event(MOUSEEVENTF_MOVE, wiggleDistance, 0, 0, 0);
                Thread.Sleep(delayBetweenWiggles);

                // Move the mouse back to the left (negative distance)
                mouse_event(MOUSEEVENTF_MOVE, -wiggleDistance, 0, 0, 0);
                Thread.Sleep(delayBetweenWiggles);
            }
        }

        public static void TurnRandom(int durationMilliseconds)
        {
            Random random = new Random();
            int direction = random.Next(2) * 2 - 1; // -1 for left, 1 for right
            DateTime endTime = DateTime.Now.AddMilliseconds(durationMilliseconds);

            while (DateTime.Now < endTime)
            {
                // Generate a random distance to move (e.g., between 5 and 20 pixels)
                int distance = random.Next(5, 21) * direction;

                // Move the mouse
                mouse_event(MOUSEEVENTF_MOVE, distance, 0, 0, 0);

                // Sleep for a short duration before the next movement (e.g., 100-300ms)
                Thread.Sleep(random.Next(10));
            }
        }




        private void SimulateButtonPressAndMouseMovement()
        {
            // Disable keyboard and mouse inputs
            BlockInput(true);

            string configFilePath = "DropPositionData.json"; // Adjust the file path as needed
            string dropKey;

            System.Threading.Timer timer = new System.Threading.Timer(state =>
            {
                // Enable keyboard and mouse inputs after 5 seconds
                BlockInput(false);
                Console.WriteLine("Input is now unblocked.");
            }, null, 5000, Timeout.Infinite);

            try
            {
                // Read the JSON file and parse it to extract the keys and mouse positions
                string json = File.ReadAllText(configFilePath);
                var configData = JsonConvert.DeserializeObject<ConfigData>(json);
                dropKey = configData?.DropKey;

                // Load the recorded mouse positions
                Point[] mousePositions = configData?.MouseCursorPositions;

                if (mousePositions == null)
                {
                    Console.WriteLine("Invalid or missing mouse positions data in the configuration.");
                    return;
                }

                // Simulate button presses
                string[] keyPresses = new string[] { "{Z}", "{Z}", "{TAB}", "{DELETE}" };
                int[] sleepDurations = new int[] { 150, 200, 0, 300 }; // Corresponding sleep durations in milliseconds

                for (int i = 0; i < keyPresses.Length; i++)
                {
                    SendKeys.SendWait(keyPresses[i]);

                    // Sleep only if necessary
                    if (sleepDurations[i] > 0)
                        Thread.Sleep(sleepDurations[i]);
                }

                foreach (Point newPosition in mousePositions)
                {
                    // Store the original mouse position
                    Point originalMousePosition = Cursor.Position;

                    // Move the mouse to the new position
                    Cursor.Position = newPosition;

                    // Simulate a mouse click (DELETE key in this case)
                    SendKeys.SendWait(dropKey);

                    // Sleep for a short duration
                    Thread.Sleep(300);

                    // Restore the original mouse position
                    Cursor.Position = originalMousePosition;
                }
            }
            finally
            {
                // Ensure that input is re-enabled in case of exceptions
                BlockInput(false);
            }
        }


        private void BagDrop()
        {
            // Simulate button presses
            string[] keyPresses = new string[] { "{Z}", "{Z}" };
            int[] sleepDurations = new int[] { 150, 150 }; // Corresponding sleep durations in milliseconds

            for (int i = 0; i < keyPresses.Length; i++)
            {
                SendKeys.SendWait(keyPresses[i]);

                // Sleep only if necessary
                if (sleepDurations[i] > 0)
                    Thread.Sleep(sleepDurations[i]);
            }
        }

        public static void PopShot()
        {
            // Simulate a left mouse button click
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
        }

        public void GrenadeSound()
        {
            // Create a SoundPlayer and specify the notification sound file path
            string notificationSoundFilePath = Path.Combine(appDirectory, soundFileName);
            SoundPlayer player = new SoundPlayer(notificationSoundFilePath);

            // Play the notification sound
            Thread.Sleep(1000);        
                player.Play();

        }

        private int RndInt(int min, int max)
        {
            int value;

            Random rnd = new Random();

            value = rnd.Next(min, max + 1);

            return value;
        }

        private TimeSpan GetRemainingWiggleCooldown()
        {

            // Instantiate ControlMenu class to access the text box's text
            TextBox wiggleCooldownTextBox = controlMenu.WiggleCooldownTextBox;


            if (int.TryParse(wiggleCooldownTextBox.Text, out int cooldownSeconds))
            {
                TimeSpan cooldownDuration = TimeSpan.FromSeconds(cooldownSeconds);
                DateTime cooldownEndTime = lastWiggleTime.Add(cooldownDuration);
                TimeSpan remainingCooldown = cooldownEndTime - DateTime.Now;

                return (remainingCooldown.TotalSeconds > 0) ? remainingCooldown : TimeSpan.Zero;
            }
            else
            {
                // Invalid input from the text box, use a default value or handle the error
                return TimeSpan.Zero; // You can return a default value or handle the error as needed
            }
        }

        private TimeSpan GetRemainingDropBagCooldown()
        {

            // Instantiate ControlMenu class to access the text box's text
            TextBox dropbagCooldownTextBox = controlMenu.DropBagCooldownTextBox;


            if (int.TryParse(dropbagCooldownTextBox.Text, out int cooldownSeconds))
            {
                TimeSpan cooldownDuration = TimeSpan.FromSeconds(cooldownSeconds);
                DateTime cooldownEndTime = lastdropbagTime.Add(cooldownDuration);
                TimeSpan remainingCooldown = cooldownEndTime - DateTime.Now;

                return (remainingCooldown.TotalSeconds > 0) ? remainingCooldown : TimeSpan.Zero;
            }
            else
            {
                // Invalid input from the text box, use a default value or handle the error
                return TimeSpan.Zero; // You can return a default value or handle the error as needed
            }
        }

        private TimeSpan GetRemainingTurnCooldown()
        {

            // Instantiate ControlMenu class to access the text box's text
            ControlMenu controlMenu = new ControlMenu(); // You may need to initialize it accordingly
            TextBox turnCooldownTextBox = controlMenu.TurnCooldownTextBox;


            if (int.TryParse(turnCooldownTextBox.Text, out int cooldownSeconds))
            {
                TimeSpan cooldownDuration = TimeSpan.FromSeconds(cooldownSeconds);
                DateTime cooldownEndTime = lastTurnTime.Add(cooldownDuration);
                TimeSpan remainingCooldown = cooldownEndTime - DateTime.Now;

                return (remainingCooldown.TotalSeconds > 0) ? remainingCooldown : TimeSpan.Zero;
            }
            else
            {
                // Invalid input from the text box, use a default value or handle the error
                return TimeSpan.Zero; // You can return a default value or handle the error as needed
            }
        }

        public void StartTraderResetTimer()
        {
            if (Properties.Settings.Default.isAutoTraderEnabled)
            {
                // Create a Timer object to run the method every 5 minutes
                System.Threading.Timer timer = new System.Threading.Timer(CheckTraderResetTimes, null, TimeSpan.Zero, TimeSpan.FromMinutes(5));
            }
        }

        public void CheckTraderResetTimes(object state)
        {
            var traderResetInfoService = new TraderResetInfoService();

            // Update the resetTime.json file with the latest reset info
            traderResetInfoService.GetAndSaveTraderResetInfoWithLatest();

            // Read the reset time data from resetTime.json
            var resetTimeData = traderResetInfoService.ReadJsonDataFromFile("resetTime.json");

            if (!string.IsNullOrEmpty(resetTimeData))
            {
                // Deserialize the JSON data
                var traderResetResponse = JsonConvert.DeserializeObject<TraderResetInfoService.TraderResetResponse>(resetTimeData);

                if (traderResetResponse != null && traderResetResponse.Data != null && traderResetResponse.Data.Traders != null)
                {
                    foreach (var trader in traderResetResponse.Data.Traders)
                    {
                        string traderName = trader.Name;

                        // Check if the trader is enabled in the settings
                        bool isTraderEnabled = false;

                        switch (traderName)
                        {
                            case "Prapor":
                                isTraderEnabled = Properties.Settings.Default.isTraderPraporEnabled;
                                break;
                            case "Therapist":
                                isTraderEnabled = Properties.Settings.Default.isTraderTherapistEnabled;
                                break;
                            case "Peacekeeper":
                                isTraderEnabled = Properties.Settings.Default.isTraderPeacekeeperEnabled;
                                break;
                            case "Mechanic":
                                isTraderEnabled = Properties.Settings.Default.isTraderMechanicEnabled;
                                break;
                            case "Fence":
                                isTraderEnabled = Properties.Settings.Default.isTraderFenceEnabled;
                                break;
                            case "Ragman":
                                isTraderEnabled = Properties.Settings.Default.isTraderRagmanEnabled;
                                break;
                            case "Skier":
                                isTraderEnabled = Properties.Settings.Default.isTraderSkierEnabled;
                                break;
                            case "Jaeger":
                                isTraderEnabled = Properties.Settings.Default.isTraderJaegerEnabled;
                                break;
                            case "Lightkeeper":
                                isTraderEnabled = Properties.Settings.Default.isTraderLightkeeperEnabled;
                                break;
                                // Add more cases for other traders here...
                        }
                        // Process the trader if isTwitchTradersEnabled is off or if the trader is enabled individually
                        if (Properties.Settings.Default.isTwitchTradersEnabled || isTraderEnabled)
                        {
                            string resetTime = trader.ResetTime;

                            // Parse the reset time as a DateTime
                            if (DateTime.TryParse(resetTime, null, System.Globalization.DateTimeStyles.RoundtripKind, out DateTime resetDateTime))
                            {
                                // Get the local time zone
                                TimeZoneInfo localTimeZone = TimeZoneInfo.Local;

                                // Convert the reset time from UTC to local time
                                DateTime localResetTime = TimeZoneInfo.ConvertTimeFromUtc(resetDateTime, localTimeZone);

                                // Calculate the time remaining until the reset time
                                TimeSpan timeRemaining = localResetTime - DateTime.Now;

                                // Check if the time remaining is negative
                                if (timeRemaining < TimeSpan.Zero)
                                {
                                    // The reset time has passed; set the time remaining to zero
                                    timeRemaining = TimeSpan.Zero;
                                }

                                // Check if the time remaining is less than 5 minutes
                                if (timeRemaining <= TimeSpan.FromMinutes(5) && timeRemaining > TimeSpan.Zero)
                                {
                                    // Format the time difference as hours and minutes
                                    string formattedTimeRemaining = $"{(int)timeRemaining.TotalHours} hours {timeRemaining.Minutes} minutes";

                                    // Send a message indicating less than 5 minutes remaining
                                    client.SendMessage(channelId, $"@{channelId} {traderName} has 5 minutes or less remaining! Countdown: {formattedTimeRemaining}");
                                    Console.WriteLine($"{traderName} has 5 minutes or less remaining! Countdown: {formattedTimeRemaining}");
                                }
                            }
                        }
                    }
                }
            }
        }



        public void LoadCommandConfigData()
        {
            try
            {
                string jsonFilePath = "CommandConfigData.json";

                if (File.Exists(jsonFilePath))
                {
                    string jsonData = File.ReadAllText(jsonFilePath);
                    commandConfigData = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonData);

                    if (commandConfigData.ContainsKey("autoSendMessageCD") && int.TryParse(commandConfigData["autoSendMessageCD"], out int cd))
                    {
                        autoSendMessageCD = cd;
                    }
                    else
                    {
                        Console.WriteLine("Invalid or missing 'autoSendMessageCD' value in CommandConfigData.json.");
                    }
                }
                else
                {
                    Console.WriteLine("CommandConfigData.json not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading CommandConfigData: {ex.Message}");
            }
        }

        private System.Threading.Timer timer;

        public void StartAutoMessage()
        {
            // Convert the interval to milliseconds
            int intervalMilliseconds = autoSendMessageCD * 1000;

            // Create a Timer object to run the method immediately and then reschedule it
            timer = new System.Threading.Timer(AutoMessageSender, null, 0, intervalMilliseconds);
        }


        public void AutoMessageSender(object state)
        {
            try
            {
                if (Properties.Settings.Default.isAutoMessageEnabled)
                {
                    // Ensure that commandConfigData is loaded
                    if (commandConfigData == null)
                    {
                        LoadCommandConfigData();
                    }

                    if (commandConfigData != null && commandConfigData.ContainsKey("autoMessageBox"))
                    {
                        string autoMessageBox = commandConfigData["autoMessageBox"];

                        // Split the message by '\\'
                        string[] messageParts = autoMessageBox.Split(new string[] { "\\\\" }, StringSplitOptions.None);

                        // Send each part as a separate message
                        foreach (string messagePart in messageParts)
                        {
                            if (!string.IsNullOrEmpty(messagePart.Trim()))
                            {
                                client.SendMessage(channelId, messagePart);
                                Console.WriteLine(messagePart);
                            }
                        }
                    }
                    timer.Change(autoSendMessageCD * 1000, Timeout.Infinite);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in AutoMessageSender: {ex.Message}");
            }
        }



    }

}
