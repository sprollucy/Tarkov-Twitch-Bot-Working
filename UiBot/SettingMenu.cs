using Newtonsoft.Json;
using System.Diagnostics;


namespace UiBot
{
    public partial class SettingMenu : Form
    {
        Process[] gname = Process.GetProcessesByName("GooseDesktop");
        private MainBot bot;
        public SettingMenu()
        {
            bot = new MainBot(); // Initialize the bot instance

            InitializeComponent();
            this.TopLevel = false;
            accessBox.UseSystemPasswordChar = true;
            channelBox2.UseSystemPasswordChar = true;

            // Load existing data from the JSON file
            CounterData existingData = LoadCounterData();

            // Set the textBox1 and textBox2 controls with the loaded data
            accessBox.Text = existingData.BotToken;
            channelBox2.Text = existingData.ChannelName;
        }



        private void SettingMenu_Load(object sender, EventArgs e)
        {

        }

        private void accessBox_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.AccessToken = accessBox.Text;
            Properties.Settings.Default.Save();
        }

        private void channelBox2_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.ChannelName = channelBox2.Text;
            Properties.Settings.Default.Save();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string userInput1 = accessBox.Text;

            // Load existing data from the JSON file
            CounterData existingData = LoadCounterData();

            // Update the existing data with the new value
            existingData.BotToken = userInput1;

            // Specify the path to the JSON file
            string jsonFilePath = "Logon.json";

            // Serialize and save the updated data to the JSON file
            string jsonData = JsonConvert.SerializeObject(existingData, Formatting.Indented);
            File.WriteAllText(jsonFilePath, jsonData);

            label1.Text += "\nAccess Token saved to Logon.json";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string userInput2 = channelBox2.Text;

            // Load existing data from the JSON file
            CounterData existingData = LoadCounterData();

            // Update the existing data with the new value
            existingData.ChannelName = userInput2;

            // Specify the path to the JSON file
            string jsonFilePath = "Logon.json";

            // Serialize and save the updated data to the JSON file
            string jsonData = JsonConvert.SerializeObject(existingData, Formatting.Indented);
            File.WriteAllText(jsonFilePath, jsonData);

            label1.Text += "\nChannel saved to Logon.json";
        }

        // Load existing data from the JSON file
        private CounterData LoadCounterData()
        {
            string jsonFilePath = "Logon.json";
            CounterData existingData = new CounterData();

            if (File.Exists(jsonFilePath))
            {
                string json = File.ReadAllText(jsonFilePath);
                existingData = JsonConvert.DeserializeObject<CounterData>(json) ?? new CounterData();
            }

            return existingData;
        }

        public class CounterData
        {
            public string ChannelName { get; set; }
            public string BotToken { get; set; }
        }


        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                accessBox.UseSystemPasswordChar = false;
                channelBox2.UseSystemPasswordChar = false;
            }
            else
            {
                accessBox.UseSystemPasswordChar = true;
                channelBox2.UseSystemPasswordChar = true;
            }
        }


        private void helpButton_Click(object sender, EventArgs e)
        {
            // Create an instance of the AboutForm
            AboutForm aboutForm = new AboutForm();

            // Show the AboutForm as a dialog (modal)
            aboutForm.ShowDialog();
        }

    }
}
