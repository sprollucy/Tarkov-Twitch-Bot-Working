namespace UiBot
{
    partial class ConnectMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            messageTextBox = new TextBox();
            consoleTextBox = new TextBox();
            connectButton = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // messageTextBox
            // 
            messageTextBox.Location = new Point(78, 277);
            messageTextBox.Name = "messageTextBox";
            messageTextBox.Size = new Size(165, 23);
            messageTextBox.TabIndex = 0;
            // 
            // consoleTextBox
            // 
            consoleTextBox.Location = new Point(78, 49);
            consoleTextBox.Multiline = true;
            consoleTextBox.Name = "consoleTextBox";
            consoleTextBox.ReadOnly = true;
            consoleTextBox.Size = new Size(391, 222);
            consoleTextBox.TabIndex = 1;
            // 
            // connectButton
            // 
            connectButton.Location = new Point(249, 277);
            connectButton.Name = "connectButton";
            connectButton.Size = new Size(75, 23);
            connectButton.TabIndex = 2;
            connectButton.Text = "Connect";
            connectButton.UseVisualStyleBackColor = true;
            connectButton.Click += connectButton_Click;
            // 
            // button2
            // 
            button2.Location = new Point(330, 277);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 3;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
            // 
            // ConnectMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            ControlBox = false;
            Controls.Add(button2);
            Controls.Add(connectButton);
            Controls.Add(consoleTextBox);
            Controls.Add(messageTextBox);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ConnectMenu";
            Text = "ConnectMenu";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox messageTextBox;
        private TextBox consoleTextBox;
        private Button connectButton;
        private Button button2;
    }
}