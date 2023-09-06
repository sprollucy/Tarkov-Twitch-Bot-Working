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

namespace UiBot
{
    internal class Bot : IDisposable
    {
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

        // Handles connection
        private ConnectionCredentials creds;
        TwitchClient client;
        private bool isBotConnected = false;


        private static TwitchPubSub pubSub;
        private static string channelId;

        //wiggle
        private Random random = new Random();
        private DateTime lastWiggleTime = DateTime.MinValue;

        //random key press
        private DateTime lastRandomKeyPressesTime = DateTime.MinValue;

        //drop
        private DateTime lastDropCommandTime = DateTime.MinValue;
        private TimeSpan dropCommandCooldown = TimeSpan.FromMinutes(20);


        char nl = Convert.ToChar(11);
        private int deathCount = 0;
        Counter counter = new Counter();

        private DateTime lastPopCommandTime = DateTime.MinValue;
        private TimeSpan popCommandCooldown;

        private DateTime lastGooseCommandTime = DateTime.MinValue;
        private TimeSpan gooseCommandCooldown = TimeSpan.FromMinutes(10); // Declare a DateTime variable to store the cooldown time of the "goose" command.
        private Process gooseProcess; // Declare a Process variable to store the Goose process.

        internal Bot()
        {
            LoadCredentialsFromJSON();

        }

        public void Dispose()
        {
            // Dispose of any resources here
            Disconnect(); // Ensure the bot is disconnected
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
                // Unsubscribe from other events

                // Unsubscribe from PubSub events
                pubSub.OnFollow -= PubSub_OnFollow;
                // Unsubscribe from other PubSub events

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

            }
        }

        // Rest of your methods go here

        private void InitializeTwitchClient()
        {
            if (!isBotConnected)
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



        //Chat Commands
        private async void Client_OnChatCommandReceived(object sender, OnChatCommandReceivedArgs e)
        {
            var traderResetInfoService = new TraderResetInfoService();

            Process[] pname = Process.GetProcessesByName("notepad");
            Process[] gname = Process.GetProcessesByName("GooseDesktop");

            //Normal Commands
            switch (e.Command.CommandText.ToLower())
            {

                case "roll":
                    string msg = $"{e.Command.ChatMessage.DisplayName} Rolled {RndInt(1, 6)}";
                    client.SendMessage(channelId, msg);
                    Console.WriteLine($"[Bot]: {msg}");
                    break;
                case "help":
                    client.SendMessage(channelId, "!traders, !drop, !goose, !help, !killgoose, !randomkeys, !roll, !stats, !turn, !wiggle, !pop\nMost of these commands have random length cooldowns so use them wisely");
                    break;
                case "stats":
                    client.SendMessage(channelId, $"Sprollucy has died {deathCount} times today, and has escaped {counter.SurvivalCount} times");
                    client.SendMessage(channelId, $"Deaths this wipe: {counter.AllDeath}");
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




                case "goose":
                    if (!Properties.Settings.Default.IsGooseEnabled)
                    {
                        client.SendMessage(channelId, "Goose command is currently disabled.");
                    }
                    else if (gname.Length > 0)
                    {
                        client.SendMessage(channelId, "Goose is already running!");
                    }
                    else if (DateTime.Now - lastGooseCommandTime < gooseCommandCooldown)
                    {
                        TimeSpan remainingCooldown = gooseCommandCooldown - (DateTime.Now - lastGooseCommandTime);
                        client.SendMessage(channelId, $"Goose command is on cooldown. You can use it again in {remainingCooldown.TotalMinutes} minutes.");
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
                        TimeSpan remainingCooldown = GetRemainingWiggleCooldown();
                        if (remainingCooldown.TotalSeconds > 0)
                        {
                            client.SendMessage(channelId, $"Wiggle command is on cooldown. Remaining time: {remainingCooldown.TotalSeconds} seconds.");
                        }
                        else
                        {
                            lastWiggleTime = DateTime.Now; // Record the start time before wiggling
                            //format is turns, distance in px, delay between move
                            WiggleMouse(3, 10, 50);
                            remainingCooldown = GetRemainingWiggleCooldown(); // Recalculate remaining cooldown
                            client.SendMessage(channelId, $"Mouse wiggle!");
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
                        TimeSpan remainingCooldown = GetRemainingWiggleCooldown();
                        if (remainingCooldown.TotalSeconds > 0)
                        {
                            client.SendMessage(channelId, $"Turn command is on cooldown. Remaining time: {remainingCooldown.TotalSeconds} seconds.");
                        }
                        else
                        {
                            lastWiggleTime = DateTime.Now; // Record the start time before wiggling

                            // Randomly decide whether to move the mouse to the right or left
                            bool moveRight = (new Random()).Next(2) == 0;

                            TurnRandom(2000);

                            remainingCooldown = GetRemainingWiggleCooldown(); // Recalculate remaining cooldown
                            client.SendMessage(channelId, $"Turn is on cooldown for {remainingCooldown.TotalSeconds} seconds");
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
                        // Check if the command is on cooldown
                        if (IsRandomKeyPressesCommandOnCooldown())
                        {
                            TimeSpan remainingCooldown = GetRemainingRandomKeyPressesCooldown();
                            client.SendMessage(channelId, $"Random keypresses command is on cooldown. Remaining time: {remainingCooldown.TotalMinutes} minutes.");
                        }
                        else
                        {
                            // Perform the action if not on cooldown
                            SendRandomKeyPresses();
                            client.SendMessage(channelId, "Hold that key!");
                            lastRandomKeyPressesTime = DateTime.Now;
                        }
                    }
                    else
                    {
                        // Command is disabled, notify the user or take appropriate action
                        client.SendMessage(channelId, "The random keypresse command is currently disabled.");
                    }
                    break;


                case "drop":
                    if (Properties.Settings.Default.IsDropEnabled)
                    {
                        SimulateButtonPressAndMouseMovement();
                        client.SendMessage(channelId, "Simulated button press and mouse movement.");
                        lastDropCommandTime = DateTime.Now; // Update the last command time
                    }
                    else if (DateTime.Now - lastDropCommandTime < dropCommandCooldown)
                    {
                        TimeSpan remainingCooldown = dropCommandCooldown - (DateTime.Now - lastDropCommandTime);
                        client.SendMessage(channelId, $"Drop command is on cooldown. You can use it again in {remainingCooldown.TotalMinutes} minutes.");
                    }
                    else
                    {
                        client.SendMessage(channelId, "The drop command is currently disabled.");
                    }
                    break;

                case "pop":
                    if (Properties.Settings.Default.IsPopEnabled)
                    {
                        if (DateTime.Now - lastPopCommandTime < popCommandCooldown)
                        {
                            TimeSpan remainingCooldown = popCommandCooldown - (DateTime.Now - lastPopCommandTime);
                            client.SendMessage(channelId, $"Pop command is on cooldown. You can use it again in {remainingCooldown.TotalMinutes} minutes.");
                        }
                        else
                        {
                            PopShot();
                            client.SendMessage(channelId, $"Oops misclick!.");
                            lastPopCommandTime = DateTime.Now;
                            // Set a random cooldown between 1 and 15 minutes (60,000 milliseconds per minute).
                            int cooldownMinutes = random.Next(1, 16);
                            int cooldownMilliseconds = cooldownMinutes * 60 * 1000; // Convert to milliseconds.
                            popCommandCooldown = TimeSpan.FromMilliseconds(cooldownMilliseconds);
                        }
                    }
                    else
                    {
                        client.SendMessage(channelId, "The pop command is currently disabled.");
                    }
                    break;

            }

            //Mod Commands
            if(e.Command.ChatMessage.IsModerator)
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

        private void SendRandomKeyPresses()
        {
            string[] keysToSend = { "W", "A", "S", "D", "E", "Q", "C", "{TAB}", "G", "2", "3" };
            Random random = new Random();

            foreach (string key in keysToSend)
            {
                SendKeys.SendWait(key);

                // Apply a random hold duration between 250ms and 1000ms
                int holdDuration = random.Next(250, 1001);
                System.Threading.Thread.Sleep(holdDuration);
            }
        }

        private TimeSpan GetRemainingWiggleCooldown()
        {
            TimeSpan cooldownDuration = TimeSpan.FromSeconds(random.Next(30, 301)); // Random cooldown between 30 seconds and 5 minutes
            DateTime cooldownEndTime = lastWiggleTime.Add(cooldownDuration);
            TimeSpan remainingCooldown = cooldownEndTime - DateTime.Now;

            return (remainingCooldown.TotalSeconds > 0) ? remainingCooldown : TimeSpan.Zero;
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

            System.Threading.Timer timer = new System.Threading.Timer(state =>
            {
                // Enable keyboard and mouse inputs after 5 seconds
                BlockInput(false);
                Console.WriteLine("Input is now unblocked.");
            }, null, 5000, Timeout.Infinite);

            try
            {
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

                // Define mouse positions and simulate mouse movements
                Point[] mousePositions = new Point[]
                {
            new Point(880, 314),
            new Point(878, 527),
            new Point(648, 311),
            new Point(1110, 294),
            new Point(787, 748),
            new Point(1125, 745),
            new Point(777, 979),
            new Point(1437, 298),
            new Point(1439, 872)
                };

                foreach (Point newPosition in mousePositions)
                {
                    // Store the original mouse position
                    Point originalMousePosition = Cursor.Position;

                    // Move the mouse to the new position
                    Cursor.Position = newPosition;

                    // Simulate a mouse click (DELETE key in this case)
                    SendKeys.SendWait("{DELETE}");

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

        public static void PopShot()
        {
            // Simulate a left mouse button click
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
        }

        private int RndInt(int min, int max)
        {
            int value;

            Random rnd = new Random();

            value = rnd.Next(min, max + 1);

            return value;
        }

        public void StartTraderResetTimer()
        {
            // Create a Timer object to run the method every 5 minutes
            System.Threading.Timer timer = new System.Threading.Timer(CheckTraderResetTimes, null, TimeSpan.Zero, TimeSpan.FromMinutes(5));
        }

        private void CheckTraderResetTimes(object state)
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

}
