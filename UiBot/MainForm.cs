using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Diagnostics;
using Microsoft.Win32;

namespace UiBot
{
    public partial class MainForm : Form
    {
        private bool isConsoleOpen = false;

        Process[] gname = Process.GetProcessesByName("GooseDesktop");
        [DllImport("kernel32.dll")]
        public static extern bool AllocConsole();
        private Bot bot;

        public MainForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle; // or FormBorderStyle.FixedDialog


            bot = new Bot(); // Initialize the bot instance
            chkEnableGoose.Checked = Properties.Settings.Default.IsGooseEnabled;
            EnableWiggle.Checked = Properties.Settings.Default.IsWiggleEnabled;
            enableRandomKey.Checked = Properties.Settings.Default.IsKeyEnabled;
            enableKitDrop.Checked = Properties.Settings.Default.IsDropEnabled;
            ranTurn.Checked = Properties.Settings.Default.IsTurnEnabled;
            popCheck.Checked = Properties.Settings.Default.IsPopEnabled;


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.TextBox1Text = textBox1.Text;
            Properties.Settings.Default.Save();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.TextBox2Text = textBox2.Text;
            Properties.Settings.Default.Save();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string userInput1 = textBox1.Text;

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
            string userInput2 = textBox2.Text;

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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        //connect bot
        private void Start_Click(object sender, EventArgs e)
        {
            if (!isConsoleOpen)
            {
                ConsoleWindow.Create();
                isConsoleOpen = true;
            }

            // Use the existing 'bot' instance
            bot.Connect();
        }




        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.UseSystemPasswordChar = true;
            textBox2.UseSystemPasswordChar = true;
            textBox1.Text = Properties.Settings.Default.TextBox1Text;
            textBox2.Text = Properties.Settings.Default.TextBox2Text;

            chkEnableGoose.Checked = Properties.Settings.Default.IsGooseEnabled;
            EnableWiggle.Checked = Properties.Settings.Default.IsWiggleEnabled;
            enableRandomKey.Checked = Properties.Settings.Default.IsKeyEnabled;
            enableKitDrop.Checked = Properties.Settings.Default.IsDropEnabled;
            ranTurn.Checked = Properties.Settings.Default.IsTurnEnabled;
            popCheck.Checked = Properties.Settings.Default.IsPopEnabled;



        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (isConsoleOpen)
            {
                ConsoleWindow.Close();
                isConsoleOpen = false;
            }

            // Dispose of the bot instance properly
            using (Bot bot = new Bot())
            {
                bot.Disconnect();

            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox1.UseSystemPasswordChar = false;
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                textBox1.UseSystemPasswordChar = true;
                textBox2.UseSystemPasswordChar = true;
            }
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void StopGoose_Click(object sender, EventArgs e)
        {
            foreach (Process process in Process.GetProcessesByName("GooseDesktop"))
            {
                process.Kill();
            }
        }

        public void chkEnableGoose_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.IsGooseEnabled = chkEnableGoose.Checked;
            Properties.Settings.Default.Save();
        }

        private void EnableWiggle_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.IsWiggleEnabled = EnableWiggle.Checked;
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

        private void ranTurn_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.IsTurnEnabled = ranTurn.Checked;
            Properties.Settings.Default.Save();
        }

        private void helpButton_Click(object sender, EventArgs e)
        {
            // Create an instance of the AboutForm
            AboutForm aboutForm = new AboutForm();

            // Show the AboutForm as a dialog (modal)
            aboutForm.ShowDialog();
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void popCheck_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.IsPopEnabled = popCheck.Checked;
            Properties.Settings.Default.Save();
        }
    }

}