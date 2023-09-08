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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConnectMenu));
            messageTextBox = new TextBox();
            consoleTextBox = new TextBox();
            connectButton = new Button();
            disconnectButton = new Button();
            pictureBox1 = new PictureBox();
            checkBox1 = new CheckBox();
            checkBox2 = new CheckBox();
            checkBox3 = new CheckBox();
            checkBox4 = new CheckBox();
            checkBox5 = new CheckBox();
            checkBox6 = new CheckBox();
            checkBox7 = new CheckBox();
            panel1 = new Panel();
            stopGoose = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // messageTextBox
            // 
            messageTextBox.Location = new Point(63, 256);
            messageTextBox.Name = "messageTextBox";
            messageTextBox.Size = new Size(165, 23);
            messageTextBox.TabIndex = 0;
            messageTextBox.TextChanged += messageTextBox_TextChanged;
            // 
            // consoleTextBox
            // 
            consoleTextBox.Location = new Point(63, 28);
            consoleTextBox.Multiline = true;
            consoleTextBox.Name = "consoleTextBox";
            consoleTextBox.ReadOnly = true;
            consoleTextBox.Size = new Size(391, 222);
            consoleTextBox.TabIndex = 1;
            // 
            // connectButton
            // 
            connectButton.Location = new Point(234, 256);
            connectButton.Name = "connectButton";
            connectButton.Size = new Size(75, 23);
            connectButton.TabIndex = 2;
            connectButton.Text = "Connect";
            connectButton.UseVisualStyleBackColor = true;
            connectButton.Click += connectButton_Click;
            // 
            // disconnectButton
            // 
            disconnectButton.Location = new Point(315, 256);
            disconnectButton.Name = "disconnectButton";
            disconnectButton.Size = new Size(75, 23);
            disconnectButton.TabIndex = 3;
            disconnectButton.Text = "Disconnect";
            disconnectButton.UseVisualStyleBackColor = true;
            disconnectButton.Click += disconnectButton_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(3, 25);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(261, 206);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.BackColor = Color.FromArgb(162, 123, 92);
            checkBox1.Location = new Point(31, 31);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(83, 19);
            checkBox1.TabIndex = 5;
            checkBox1.Text = "checkBox1";
            checkBox1.UseVisualStyleBackColor = false;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.BackColor = Color.FromArgb(162, 123, 92);
            checkBox2.Location = new Point(31, 56);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(83, 19);
            checkBox2.TabIndex = 6;
            checkBox2.Text = "checkBox2";
            checkBox2.UseVisualStyleBackColor = false;
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.BackColor = Color.FromArgb(162, 123, 92);
            checkBox3.Location = new Point(31, 81);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(83, 19);
            checkBox3.TabIndex = 7;
            checkBox3.Text = "checkBox3";
            checkBox3.UseVisualStyleBackColor = false;
            // 
            // checkBox4
            // 
            checkBox4.AutoSize = true;
            checkBox4.BackColor = Color.FromArgb(162, 123, 92);
            checkBox4.Location = new Point(31, 106);
            checkBox4.Name = "checkBox4";
            checkBox4.Size = new Size(83, 19);
            checkBox4.TabIndex = 8;
            checkBox4.Text = "checkBox4";
            checkBox4.UseVisualStyleBackColor = false;
            // 
            // checkBox5
            // 
            checkBox5.AutoSize = true;
            checkBox5.BackColor = Color.FromArgb(162, 123, 92);
            checkBox5.Location = new Point(31, 131);
            checkBox5.Name = "checkBox5";
            checkBox5.Size = new Size(83, 19);
            checkBox5.TabIndex = 9;
            checkBox5.Text = "checkBox5";
            checkBox5.UseVisualStyleBackColor = false;
            // 
            // checkBox6
            // 
            checkBox6.AutoSize = true;
            checkBox6.BackColor = Color.FromArgb(162, 123, 92);
            checkBox6.Location = new Point(31, 156);
            checkBox6.Name = "checkBox6";
            checkBox6.Size = new Size(83, 19);
            checkBox6.TabIndex = 10;
            checkBox6.Text = "checkBox6";
            checkBox6.UseVisualStyleBackColor = false;
            // 
            // checkBox7
            // 
            checkBox7.AutoSize = true;
            checkBox7.BackColor = Color.FromArgb(162, 123, 92);
            checkBox7.Location = new Point(31, 181);
            checkBox7.Name = "checkBox7";
            checkBox7.Size = new Size(83, 19);
            checkBox7.TabIndex = 11;
            checkBox7.Text = "checkBox7";
            checkBox7.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.Controls.Add(stopGoose);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(checkBox7);
            panel1.Controls.Add(checkBox1);
            panel1.Controls.Add(checkBox5);
            panel1.Controls.Add(checkBox3);
            panel1.Controls.Add(checkBox4);
            panel1.Controls.Add(checkBox2);
            panel1.Controls.Add(checkBox6);
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(456, 19);
            panel1.Name = "panel1";
            panel1.Size = new Size(301, 262);
            panel1.TabIndex = 12;
            // 
            // stopGoose
            // 
            stopGoose.Location = new Point(140, 178);
            stopGoose.Name = "stopGoose";
            stopGoose.Size = new Size(75, 23);
            stopGoose.TabIndex = 13;
            stopGoose.Text = "Kill Goose";
            stopGoose.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 7);
            label1.Name = "label1";
            label1.Size = new Size(107, 15);
            label1.TabIndex = 12;
            label1.Text = "Command Toggles";
            // 
            // ConnectMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(220, 215, 201);
            ClientSize = new Size(800, 450);
            ControlBox = false;
            Controls.Add(panel1);
            Controls.Add(disconnectButton);
            Controls.Add(connectButton);
            Controls.Add(consoleTextBox);
            Controls.Add(messageTextBox);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ConnectMenu";
            Text = "ConnectMenu";
            Load += ConnectMenu_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox messageTextBox;
        private TextBox consoleTextBox;
        private Button connectButton;
        private Button disconnectButton;
        private PictureBox pictureBox1;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private CheckBox checkBox3;
        private CheckBox checkBox4;
        private CheckBox checkBox5;
        private CheckBox checkBox6;
        private CheckBox checkBox7;
        private Panel panel1;
        private Label label1;
        private Button stopGoose;
    }
}