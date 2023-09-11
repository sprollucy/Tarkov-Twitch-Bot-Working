using System.Diagnostics;
using System.Reflection;


namespace UiBot
{
    public partial class AboutForm : Form
    {
        string packageVersion = Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion;

        public AboutForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            label2.Text = "Version: " + packageVersion;


        }


        private void AboutForm_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Specify the URL you want to open
            string url = "https://github.com/sprollucy/Tarkov-Twitch-Bot-Working";

            // Open the URL in the default web browser
            System.Diagnostics.Process.Start(new ProcessStartInfo(url)
            {
                UseShellExecute = true
            });
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
