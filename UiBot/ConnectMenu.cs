using System;
using System.Windows.Forms;
using TwitchLib.Client.Models;

namespace UiBot
{
    public partial class ConnectMenu : Form
    {
        private Bot bot;

        public ConnectMenu()
        {
            bot = new Bot();
            InitializeComponent();
            InitializeConsole();
            this.TopLevel = false;

            // Hook up the KeyPress event for the messageTextBox
            messageTextBox.KeyPress += MessageTextBox_KeyPress;
        }

        private void InitializeConsole()
        {
            // Redirect standard output to the consoleTextBox
            Console.SetOut(new TextBoxWriter(consoleTextBox));
            Console.WriteLine("Console initialized.");
        }

        // Custom TextWriter to redirect Console output to a TextBox
        private class TextBoxWriter : System.IO.TextWriter
        {
            private TextBox textBox;

            public TextBoxWriter(TextBox textBox)
            {
                this.textBox = textBox;
            }

            public override void Write(char value)
            {
                if (textBox.IsHandleCreated)
                {
                    textBox.Invoke(new Action(() => textBox.AppendText(value.ToString())));
                }
                else
                {
                    // Handle not created yet; consider deferring the operation.
                }
            }

            public override void Write(string value)
            {
                if (textBox.IsHandleCreated)
                {
                    textBox.Invoke(new Action(() => textBox.AppendText(value)));
                }
                else
                {
                    // Handle not created yet; consider deferring the operation.
                }
            }

            public override void WriteLine(string value)
            {
                if (textBox.IsHandleCreated)
                {
                    textBox.Invoke(new Action(() => textBox.AppendText(value + Environment.NewLine)));
                }
                else
                {
                    // Handle not created yet; consider deferring the operation.
                }
            }

            public override System.Text.Encoding Encoding => System.Text.Encoding.UTF8;
        }


        private void MessageTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Send the message when Enter key is pressed
                SendMessage();
                e.Handled = true; // Prevent the Enter key from being added to the TextBox
            }
        }

        private void SendMessage()
        {
            string message = messageTextBox.Text.Trim();

            if (!string.IsNullOrEmpty(message))
            {
                bot.SendMessage(message);
                Console.WriteLine($"Message: {message}"); // Print the message to the console
                messageTextBox.Clear(); // Clear the TextBox after sending the message
            }
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            bot.Connect();
        }

        // Rest of your code
    }
}
