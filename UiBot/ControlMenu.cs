using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace UiBot
{
    public partial class ControlMenu : Form
    {
        private Dictionary<string, TextBox> textBoxes = new Dictionary<string, TextBox>();


        public ControlMenu()
        {
            InitializeComponent();

            // Initialize TextBoxes dictionary
            InitializeTextBoxes();

            // Load the settings from JSON on application startup
            LoadSettings();

            this.TopLevel = false;
            chkEnableGoose.Checked = Properties.Settings.Default.IsGooseEnabled;
            enableWiggle.Checked = Properties.Settings.Default.IsWiggleEnabled;
            enableRandomKey.Checked = Properties.Settings.Default.IsKeyEnabled;
            enableKitDrop.Checked = Properties.Settings.Default.IsDropEnabled;
            randomTurn.Checked = Properties.Settings.Default.IsTurnEnabled;
            oneClickCheck.Checked = Properties.Settings.Default.IsPopEnabled;
            enableBits.Checked = Properties.Settings.Default.isBitEnabled;
            enableAutoMessageCheck.Checked = Properties.Settings.Default.isAutoMessageEnabled;
            enableTraderCheck.Checked = Properties.Settings.Default.isAutoTraderEnabled;
        }

        private void ControlMenu_load(object sender, EventArgs e)
        {

        }

        // ... rest of your code ...

        public void InitializeTextBoxes()
        {
            // Add your TextBox controls to the dictionary with unique keys
            textBoxes["wiggleCooldown"] = wiggleCooldownTextBox;
            textBoxes["dropCooldown"] = dropCooldownTextBox;
            textBoxes["turnCooldown"] = turnCooldownTextBox;
            textBoxes["gooseCooldown"] = gooseCooldownTextBox;
            textBoxes["randomKeyCooldown"] = randomKeyCooldownTextBox;
            textBoxes["oneClickCooldown"] = oneClickCooldownTextBox;
            textBoxes["randomKeyInputs"] = randomKeyInputs;
            textBoxes["autoMessageBox"] = autoMessageBox;
            textBoxes["autoSendMessageCD"] = autoSendMessageCD;

            // Add cost text boxes to the dictionary with unique keys
            textBoxes["wiggleCost"] = wiggleCostBox;
            textBoxes["dropCost"] = dropCostBox;
            textBoxes["turnCost"] = turnCostBox;
            textBoxes["gooseCost"] = gooseCostBox;
            textBoxes["randomKeyCost"] = randomKeyCostBox;
            textBoxes["oneClickCost"] = oneClickCostBox;
        }
        public TextBox WiggleCooldownTextBox
        {
            get { return wiggleCooldownTextBox; }
            set { wiggleCooldownTextBox = value; }
        }
        public TextBox DropCooldownTextBox
        {
            get { return dropCooldownTextBox; }
            set { dropCooldownTextBox = value; }
        }
        public TextBox TurnCooldownTextBox
        {
            get { return turnCooldownTextBox; }
            set { turnCooldownTextBox = value; }
        }
        public TextBox GooseCooldownTextBox
        {
            get { return gooseCooldownTextBox; }
            set { gooseCooldownTextBox = value; }
        }
        public TextBox RandomKeyCooldownTextBox
        {
            get { return randomKeyCooldownTextBox; }
            set { randomKeyCooldownTextBox = value; }
        }
        public TextBox OneClickCooldownTextBox
        {
            get { return oneClickCooldownTextBox; }
            set { oneClickCooldownTextBox = value; }
        }
        public TextBox RandomKeyInputs
        {
            get { return randomKeyInputs; }
            set { randomKeyInputs = value; }
        }

        // Bit Cost Boxes
        public TextBox WiggleCostBox
        {
            get { return wiggleCostBox; }
            set { wiggleCostBox = value; }
        }
        public TextBox DropCostBox
        {
            get { return dropCostBox; }
            set { dropCostBox = value; }
        }
        public TextBox TurnCostBox
        {
            get { return turnCostBox; }
            set { turnCooldownTextBox = value; }
        }
        public TextBox GooseCostBox
        {
            get { return gooseCostBox; }
            set { gooseCostBox = value; }
        }
        public TextBox RandomKeyCostBox
        {
            get { return randomKeyCostBox; }
            set { randomKeyCostBox = value; }
        }
        public TextBox OneClickCostBox
        {
            get { return oneClickCostBox; }
            set { oneClickCostBox = value; }
        }
        public TextBox AutoMessageBox
        {
            get { return autoMessageBox; }
            set { autoMessageBox = value; }
        }
        public TextBox AutoSendMessageCD
        {
            get { return autoSendMessageCD; }
            set { autoSendMessageCD = value; }
        }

        //TODO make save reload on save so app doesnt have to restart
        private void saveButton_Click(object sender, EventArgs e)
        {
            // Create a dictionary to store the text from all TextBox controls
            Dictionary<string, string> textData = new Dictionary<string, string>();

            // Iterate through the TextBoxes dictionary and save the text from each TextBox
            foreach (var textBoxEntry in textBoxes)
            {
                string textBoxKey = textBoxEntry.Key;
                TextBox textBox = textBoxEntry.Value;
                string textBoxText = textBox.Text;

                // Add the TextBox key and text to the dictionary
                textData[textBoxKey] = textBoxText;
            }

            // Serialize and save the dictionary to a JSON file
            string json = JsonConvert.SerializeObject(textData);
            File.WriteAllText("CommandConfigData.json", json);

        }

        // Load settings from JSON on startup
        public void LoadSettings()
        {
            // Check if the JSON file exists
            if (File.Exists("CommandConfigData.json"))
            {
                // Deserialize and load the data from the JSON file into a dictionary
                string json = File.ReadAllText("CommandConfigData.json");
                Dictionary<string, string> textData = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);

                // Iterate through the dictionary and set the text for each TextBox
                foreach (var textBoxEntry in textData)
                {
                    string textBoxKey = textBoxEntry.Key;
                    string textBoxText = textBoxEntry.Value;

                    // Check if the key exists in the TextBoxes dictionary
                    if (textBoxes.ContainsKey(textBoxKey))
                    {
                        TextBox textBox = textBoxes[textBoxKey];
                        textBox.Text = textBoxText;
                    }
                }
            }
        }

        public void chkEnableGoose_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.IsGooseEnabled = chkEnableGoose.Checked;
            Properties.Settings.Default.Save();
        }

        private void enableWiggle_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.IsWiggleEnabled = enableWiggle.Checked;
            Properties.Settings.Default.Save();
        }


        private void enableRandomKey_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.IsKeyEnabled = enableRandomKey.Checked;
            Properties.Settings.Default.Save();

        }

        private void enableKitDrop_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.IsDropEnabled = enableKitDrop.Checked;
            Properties.Settings.Default.Save();
        }

        private void randomTurn_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.IsTurnEnabled = randomTurn.Checked;
            Properties.Settings.Default.Save();
        }



        private void oneClickCheck_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.IsPopEnabled = oneClickCheck.Checked;
            Properties.Settings.Default.Save();
        }


        private void enableBits_CheckedChanged(object sender, EventArgs e)
        {

            // Update the isBitEnabled setting
            Properties.Settings.Default.isBitEnabled = enableBits.Checked;

            // Save the updated settings
            Properties.Settings.Default.Save();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void wiggleCooldownTextBox_TextChanged(object sender, EventArgs e)
        {
        }

        private void dropCooldownTextBox_TextChanged(object sender, EventArgs e)
        {
        }

        private void gooseCooldownTextBox_TextChanged(object sender, EventArgs e)
        {
        }

        private void enableAutoMessageCheck_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.isAutoMessageEnabled = enableAutoMessageCheck.Checked;
            Properties.Settings.Default.Save();
        }

        private void enableTraderCheck_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.isAutoTraderEnabled = enableTraderCheck.Checked;
            Properties.Settings.Default.Save();
        }

        private void wiggleConfig_Click(object sender, EventArgs e)
        {

        }

        private void dropConfig_Click(object sender, EventArgs e)
        {

        }

        private void gooseConfig_Click(object sender, EventArgs e)
        {

        }

        private void randomKeyConfig_Click(object sender, EventArgs e)
        {

        }

        private void turnConfig_Click(object sender, EventArgs e)
        {

        }

        private void oneClickConfig_Click(object sender, EventArgs e)
        {

        }

        private void randomKeyInputs_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
