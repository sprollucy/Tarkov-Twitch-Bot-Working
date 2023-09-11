using Newtonsoft.Json;
using System;
using System.Linq;
using System.Windows.Forms;

namespace UiBot
{
    public partial class TraderMenu : Form
    {

        public TraderMenu()
        {
            InitializeComponent();
            StartTraderResetTimer();
            this.TopLevel = false;

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
            System.Threading.Timer timer = new System.Threading.Timer(CheckTraderResetTimes, null, TimeSpan.Zero, TimeSpan.FromSeconds(1));
            System.Threading.Timer timer2 = new System.Threading.Timer(CheckStart, null, TimeSpan.Zero, TimeSpan.FromMinutes(5));
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
            });
        }

    }
}
