using Newtonsoft.Json;
using System.Media;
using System.IO;
using System.Numerics;


namespace UiBot
{
    public partial class TraderMenu : Form
    {
        private Dictionary<string, bool> traderSoundPlayed = new Dictionary<string, bool>(); // Add this dictionary

        string appDirectory = AppDomain.CurrentDomain.BaseDirectory;
        string soundFileName = Path.Combine("Sounds", "notification.wav");
        private bool isSoundEnabled = true;
        private System.Threading.Timer timer1; // Timer for CheckTraderResetTimes
        private System.Threading.Timer timer2; // Timer for CheckStart


        public TraderMenu()
        {
            // Combine the application directory and the sound file path
            string soundFilePath = Path.Combine(appDirectory, soundFileName);

            SoundPlayer player = new SoundPlayer(soundFilePath);

            InitializeComponent();
            StartTraderResetTimer();
            this.TopLevel = false;

            disableSound.Checked = Properties.Settings.Default.isTraderMuted;


        }


        private void TraderMenu_Load(object sender, EventArgs e)
        {
        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {
        }

        public void StartTraderResetTimer()
        {
            // Create a Timer object to run the method every 5 minutes
            timer1 = new System.Threading.Timer(CheckTraderResetTimes, null, TimeSpan.Zero, TimeSpan.FromSeconds(1));
            timer2 = new System.Threading.Timer(CheckStart, null, TimeSpan.Zero, TimeSpan.FromMinutes(5));
        }

        public void CheckStart(object state)
        {
            var traderResetInfoService = new TraderResetInfoService();
            traderResetInfoService.GetAndSaveTraderResetInfoWithLatest();

        }


        public void CheckTraderResetTimes(object state)
        {
            var traderResetInfoService = new TraderResetInfoService();
            var traderLabels = new Dictionary<string, (Label nameLabel, Label resetLabel, Label remainingLabel)>
    {
        {"Prapor", (praporLabel, praporResetLabel, praporRemainingTime)},
        {"Therapist", (therapistLabel, therapistResetLabel, therapistRemainingTime)},
        {"Mechanic", (mechanicLabel, mechanicResetLabel, mechanicRemainingTime)},
        {"Peacekeeper", (peacekeeperLabel, peacekeeperResetLabel, peacekeeperRemainingTime)},
        {"Fence", (fenceLabel, fenceResetLabel, fenceRemainingTime)},
        {"Ragman", (ragmanLabel, ragmanResetLabel, ragmanRemainingTime)},
        {"Skier", (skierLabel, skierResetLabel, skierRemainingTime)},
        {"Jaeger", (jaegerLabel, jaegerResetLabel, jaegerRemainingTime)},
        {"Lightkeeper", (lightkeeperLabel, lightkeeperResetLabel, lightkeeperRemainingTime)}
    };

            // Update the resetTime.json file with the latest reset info
            //traderResetInfoService.GetAndSaveTraderResetInfoWithLatest();

            var resetTimeData = traderResetInfoService.ReadJsonDataFromFile("resetTime.json");

            if (!string.IsNullOrEmpty(resetTimeData))
            {
                var traderResetResponse = JsonConvert.DeserializeObject<TraderResetInfoService.TraderResetResponse>(resetTimeData);

                if (traderResetResponse != null && traderResetResponse.Data != null)
                {
                    foreach (var traderName in traderLabels.Keys)
                    {
                        var trader = traderResetResponse.Data.Traders.FirstOrDefault(t => t.Name == traderName);

                        if (trader != null)
                        {
                            UpdateTraderLabel(traderLabels[traderName], trader);
                        }
                    }
                }
            }
        }

        private void UpdateTraderLabel((Label nameLabel, Label resetLabel, Label remainingLabel) labels, TraderResetInfoService.TraderResetInfo trader)
        {
            string traderName = trader.Name;
            DateTime localResetTime = trader.GetLocalResetTime();

            // Calculate the time remaining until the reset time
            TimeSpan timeRemaining = localResetTime - DateTime.Now;

            // Check if the time remaining is negative
            if (timeRemaining < TimeSpan.Zero)
            {
                // The reset time has passed; set the time remaining to zero
                timeRemaining = TimeSpan.Zero;
            }

            // Set the labels with the trader information
            labels.nameLabel.Invoke((MethodInvoker)delegate
            {
                labels.nameLabel.Text = traderName;
            });

            labels.resetLabel.Invoke((MethodInvoker)delegate
            {
                labels.resetLabel.Text = "Reset: " + localResetTime.ToString();
            });

            labels.remainingLabel.Invoke((MethodInvoker)delegate
            {
                labels.remainingLabel.Text = "Time Remaining: " + timeRemaining.ToString("hh\\:mm\\:ss");

                // Check if timeRemaining is less than 5 minutes (300 seconds), the sound is enabled, and the sound hasn't been played for this trader
                if (timeRemaining.TotalSeconds < 300 && isSoundEnabled && !traderSoundPlayed.ContainsKey(traderName))
                {
                    if (Properties.Settings.Default.isTraderPraporEnabled && traderName == "Prapor")
                    {
                        PlayNotificationSound();
                    }
                    if (Properties.Settings.Default.isTraderTherapistEnabled && traderName == "Therapist")
                    {
                        PlayNotificationSound();
                    }
                    if (Properties.Settings.Default.isTraderPeacekeeperEnabled && traderName == "Peacekeeper")
                    {
                        PlayNotificationSound();
                    }
                    if (Properties.Settings.Default.isTraderMechanicEnabled && traderName == "Mechanic")
                    {
                        PlayNotificationSound();
                    }
                    if (Properties.Settings.Default.isTraderFenceEnabled && traderName == "Fence")
                    {
                        PlayNotificationSound();
                    }
                    if (Properties.Settings.Default.isTraderRagmanEnabled && traderName == "Ragman")
                    {
                        PlayNotificationSound();
                    }
                    if (Properties.Settings.Default.isTraderSkierEnabled && traderName == "Skier")
                    {
                        PlayNotificationSound();
                    }
                    if (Properties.Settings.Default.isTraderJaegerEnabled && traderName == "Jaeger")
                    {
                        PlayNotificationSound();
                    }
                    if (Properties.Settings.Default.isTraderLightkeeperEnabled && traderName == "Lightkeeper")
                    {
                        PlayNotificationSound();
                    }
                    // Mark the sound as played for this trader
                    traderSoundPlayed[traderName] = true;
                }

                if (timeRemaining.TotalSeconds < 0)
                {
                    traderSoundPlayed[traderName] = false;
                }
            });
        }


        private void PlayNotificationSound()
        {
            // Create a SoundPlayer and specify the notification sound file path
            string notificationSoundFilePath = Path.Combine(appDirectory, soundFileName);
            SoundPlayer player = new SoundPlayer(notificationSoundFilePath);

            // Play the notification sound
            Thread.Sleep(1000);
            if (!Properties.Settings.Default.isTraderMuted)
            {
                player.Play();
            }
        }

        private void disableSound_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.isTraderMuted = disableSound.Checked;
            // Toggle the sound state
            isSoundEnabled = !isSoundEnabled;
            Properties.Settings.Default.Save();

        }

        private void configTraderButton_Click(object sender, EventArgs e)
        {
            TraderMenuConfig traderMenuConfig = new TraderMenuConfig();

            traderMenuConfig.Show();
        }
    }
}
