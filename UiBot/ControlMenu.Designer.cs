namespace UiBot
{
    partial class ControlMenu
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlMenu));
            wiggleCooldownTextBox = new TextBox();
            dropCooldownTextBox = new TextBox();
            gooseCooldownTextBox = new TextBox();
            randomKeyCooldownTextBox = new TextBox();
            turnCooldownTextBox = new TextBox();
            oneClickCooldownTextBox = new TextBox();
            saveButton = new Button();
            enableBits = new CheckBox();
            wiggleCostBox = new TextBox();
            dropCostBox = new TextBox();
            gooseCostBox = new TextBox();
            randomKeyCostBox = new TextBox();
            turnCostBox = new TextBox();
            oneClickCostBox = new TextBox();
            oneClickCheck = new CheckBox();
            randomTurn = new CheckBox();
            enableRandomKey = new CheckBox();
            chkEnableGoose = new CheckBox();
            enableKitDrop = new CheckBox();
            enableWiggle = new CheckBox();
            panel1 = new Panel();
            checkBox1 = new CheckBox();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            pictureBox10 = new PictureBox();
            imageList1 = new ImageList(components);
            autoMessageBox = new TextBox();
            autoSendMessageCD = new TextBox();
            autoMessageLabel = new Label();
            enableAutoMessageCheck = new CheckBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox10).BeginInit();
            SuspendLayout();
            // 
            // wiggleCooldownTextBox
            // 
            wiggleCooldownTextBox.Location = new Point(144, 72);
            wiggleCooldownTextBox.Name = "wiggleCooldownTextBox";
            wiggleCooldownTextBox.Size = new Size(100, 23);
            wiggleCooldownTextBox.TabIndex = 0;
            wiggleCooldownTextBox.Text = "50";
            wiggleCooldownTextBox.TextChanged += wiggleCooldownTextBox_TextChanged;
            // 
            // dropCooldownTextBox
            // 
            dropCooldownTextBox.Location = new Point(144, 101);
            dropCooldownTextBox.Name = "dropCooldownTextBox";
            dropCooldownTextBox.Size = new Size(100, 23);
            dropCooldownTextBox.TabIndex = 1;
            dropCooldownTextBox.TextChanged += dropCooldownTextBox_TextChanged;
            // 
            // gooseCooldownTextBox
            // 
            gooseCooldownTextBox.Location = new Point(144, 130);
            gooseCooldownTextBox.Name = "gooseCooldownTextBox";
            gooseCooldownTextBox.Size = new Size(100, 23);
            gooseCooldownTextBox.TabIndex = 2;
            gooseCooldownTextBox.TextChanged += gooseCooldownTextBox_TextChanged;
            // 
            // randomKeyCooldownTextBox
            // 
            randomKeyCooldownTextBox.Location = new Point(144, 159);
            randomKeyCooldownTextBox.Name = "randomKeyCooldownTextBox";
            randomKeyCooldownTextBox.Size = new Size(100, 23);
            randomKeyCooldownTextBox.TabIndex = 3;
            // 
            // turnCooldownTextBox
            // 
            turnCooldownTextBox.Location = new Point(144, 188);
            turnCooldownTextBox.Name = "turnCooldownTextBox";
            turnCooldownTextBox.Size = new Size(100, 23);
            turnCooldownTextBox.TabIndex = 4;
            // 
            // oneClickCooldownTextBox
            // 
            oneClickCooldownTextBox.Location = new Point(144, 217);
            oneClickCooldownTextBox.Name = "oneClickCooldownTextBox";
            oneClickCooldownTextBox.Size = new Size(100, 23);
            oneClickCooldownTextBox.TabIndex = 5;
            // 
            // saveButton
            // 
            saveButton.Location = new Point(713, 415);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(75, 23);
            saveButton.TabIndex = 6;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // enableBits
            // 
            enableBits.AutoSize = true;
            enableBits.BackColor = Color.FromArgb(181, 176, 163);
            enableBits.Location = new Point(250, 47);
            enableBits.Name = "enableBits";
            enableBits.Size = new Size(83, 19);
            enableBits.TabIndex = 7;
            enableBits.Text = "Enable Bits";
            enableBits.UseVisualStyleBackColor = false;
            enableBits.CheckedChanged += enableBits_CheckedChanged;
            // 
            // wiggleCostBox
            // 
            wiggleCostBox.Location = new Point(250, 72);
            wiggleCostBox.Name = "wiggleCostBox";
            wiggleCostBox.Size = new Size(100, 23);
            wiggleCostBox.TabIndex = 8;
            // 
            // dropCostBox
            // 
            dropCostBox.Location = new Point(250, 101);
            dropCostBox.Name = "dropCostBox";
            dropCostBox.Size = new Size(100, 23);
            dropCostBox.TabIndex = 9;
            // 
            // gooseCostBox
            // 
            gooseCostBox.Location = new Point(250, 130);
            gooseCostBox.Name = "gooseCostBox";
            gooseCostBox.Size = new Size(100, 23);
            gooseCostBox.TabIndex = 10;
            // 
            // randomKeyCostBox
            // 
            randomKeyCostBox.Location = new Point(250, 159);
            randomKeyCostBox.Name = "randomKeyCostBox";
            randomKeyCostBox.Size = new Size(100, 23);
            randomKeyCostBox.TabIndex = 11;
            // 
            // turnCostBox
            // 
            turnCostBox.Location = new Point(250, 188);
            turnCostBox.Name = "turnCostBox";
            turnCostBox.Size = new Size(100, 23);
            turnCostBox.TabIndex = 12;
            // 
            // oneClickCostBox
            // 
            oneClickCostBox.Location = new Point(250, 217);
            oneClickCostBox.Name = "oneClickCostBox";
            oneClickCostBox.Size = new Size(100, 23);
            oneClickCostBox.TabIndex = 13;
            // 
            // oneClickCheck
            // 
            oneClickCheck.AutoSize = true;
            oneClickCheck.BackColor = Color.FromArgb(181, 176, 163);
            oneClickCheck.Location = new Point(15, 221);
            oneClickCheck.Name = "oneClickCheck";
            oneClickCheck.Size = new Size(105, 19);
            oneClickCheck.TabIndex = 14;
            oneClickCheck.Text = "oneClickCheck";
            oneClickCheck.UseVisualStyleBackColor = false;
            oneClickCheck.CheckedChanged += oneClickCheck_CheckedChanged;
            // 
            // randomTurn
            // 
            randomTurn.AutoSize = true;
            randomTurn.BackColor = Color.FromArgb(181, 176, 163);
            randomTurn.Location = new Point(15, 192);
            randomTurn.Name = "randomTurn";
            randomTurn.Size = new Size(85, 19);
            randomTurn.TabIndex = 15;
            randomTurn.Text = "EnableTurn";
            randomTurn.UseVisualStyleBackColor = false;
            randomTurn.CheckedChanged += randomTurn_CheckedChanged;
            // 
            // enableRandomKey
            // 
            enableRandomKey.AutoSize = true;
            enableRandomKey.BackColor = Color.FromArgb(181, 176, 163);
            enableRandomKey.Location = new Point(15, 161);
            enableRandomKey.Name = "enableRandomKey";
            enableRandomKey.Size = new Size(125, 19);
            enableRandomKey.TabIndex = 16;
            enableRandomKey.Text = "enableRandomKey";
            enableRandomKey.UseVisualStyleBackColor = false;
            enableRandomKey.CheckedChanged += enableRandomKey_CheckedChanged;
            // 
            // chkEnableGoose
            // 
            chkEnableGoose.AutoSize = true;
            chkEnableGoose.BackColor = Color.FromArgb(181, 176, 163);
            chkEnableGoose.Location = new Point(15, 134);
            chkEnableGoose.Name = "chkEnableGoose";
            chkEnableGoose.Size = new Size(113, 19);
            chkEnableGoose.TabIndex = 17;
            chkEnableGoose.Text = "chkEnableGoose";
            chkEnableGoose.UseVisualStyleBackColor = false;
            chkEnableGoose.CheckedChanged += chkEnableGoose_CheckedChanged;
            // 
            // enableKitDrop
            // 
            enableKitDrop.AutoSize = true;
            enableKitDrop.BackColor = Color.FromArgb(181, 176, 163);
            enableKitDrop.Location = new Point(15, 105);
            enableKitDrop.Name = "enableKitDrop";
            enableKitDrop.Size = new Size(101, 19);
            enableKitDrop.TabIndex = 18;
            enableKitDrop.Text = "enableKitDrop";
            enableKitDrop.UseVisualStyleBackColor = false;
            enableKitDrop.CheckedChanged += enableKitDrop_CheckedChanged;
            // 
            // enableWiggle
            // 
            enableWiggle.AutoSize = true;
            enableWiggle.BackColor = Color.FromArgb(181, 176, 163);
            enableWiggle.Location = new Point(15, 76);
            enableWiggle.Name = "enableWiggle";
            enableWiggle.Size = new Size(98, 19);
            enableWiggle.TabIndex = 19;
            enableWiggle.Text = "enableWiggle";
            enableWiggle.UseVisualStyleBackColor = false;
            enableWiggle.CheckedChanged += enableWiggle_CheckedChanged;
            // 
            // panel1
            // 
            panel1.Controls.Add(checkBox1);
            panel1.Controls.Add(oneClickCheck);
            panel1.Controls.Add(randomTurn);
            panel1.Controls.Add(enableRandomKey);
            panel1.Controls.Add(chkEnableGoose);
            panel1.Controls.Add(enableKitDrop);
            panel1.Controls.Add(enableWiggle);
            panel1.Controls.Add(wiggleCooldownTextBox);
            panel1.Controls.Add(dropCooldownTextBox);
            panel1.Controls.Add(oneClickCostBox);
            panel1.Controls.Add(gooseCooldownTextBox);
            panel1.Controls.Add(turnCostBox);
            panel1.Controls.Add(randomKeyCooldownTextBox);
            panel1.Controls.Add(randomKeyCostBox);
            panel1.Controls.Add(turnCooldownTextBox);
            panel1.Controls.Add(gooseCostBox);
            panel1.Controls.Add(oneClickCooldownTextBox);
            panel1.Controls.Add(dropCostBox);
            panel1.Controls.Add(enableBits);
            panel1.Controls.Add(wiggleCostBox);
            panel1.Controls.Add(pictureBox2);
            panel1.Location = new Point(51, 23);
            panel1.Name = "panel1";
            panel1.Size = new Size(409, 388);
            panel1.TabIndex = 20;
            panel1.Paint += panel1_Paint;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.BackColor = Color.FromArgb(181, 176, 163);
            checkBox1.Location = new Point(15, 246);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(175, 19);
            checkBox1.TabIndex = 20;
            checkBox1.Text = "Enable Trader Timer Updates";
            checkBox1.UseVisualStyleBackColor = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(0, 0);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(409, 385);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 21;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Red;
            pictureBox1.Location = new Point(-5, 8);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(47, 47);
            pictureBox1.TabIndex = 21;
            pictureBox1.TabStop = false;
            // 
            // pictureBox10
            // 
            pictureBox10.BackColor = Color.FromArgb(63, 78, 79);
            pictureBox10.Location = new Point(42, -3);
            pictureBox10.Name = "pictureBox10";
            pictureBox10.Size = new Size(757, 20);
            pictureBox10.TabIndex = 22;
            pictureBox10.TabStop = false;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth8Bit;
            imageList1.ImageSize = new Size(16, 16);
            imageList1.TransparentColor = Color.Transparent;
            // 
            // autoMessageBox
            // 
            autoMessageBox.Location = new Point(639, 58);
            autoMessageBox.Multiline = true;
            autoMessageBox.Name = "autoMessageBox";
            autoMessageBox.Size = new Size(140, 60);
            autoMessageBox.TabIndex = 23;
            autoMessageBox.Text = "Default";
            // 
            // autoSendMessageCD
            // 
            autoSendMessageCD.Location = new Point(579, 58);
            autoSendMessageCD.Name = "autoSendMessageCD";
            autoSendMessageCD.Size = new Size(54, 23);
            autoSendMessageCD.TabIndex = 24;
            autoSendMessageCD.Text = "0";
            // 
            // autoMessageLabel
            // 
            autoMessageLabel.AutoSize = true;
            autoMessageLabel.Location = new Point(522, 23);
            autoMessageLabel.Name = "autoMessageLabel";
            autoMessageLabel.Size = new Size(111, 15);
            autoMessageLabel.TabIndex = 25;
            autoMessageLabel.Text = "Auto Send Message";
            // 
            // enableAutoMessageCheck
            // 
            enableAutoMessageCheck.AutoSize = true;
            enableAutoMessageCheck.Location = new Point(641, 24);
            enableAutoMessageCheck.Name = "enableAutoMessageCheck";
            enableAutoMessageCheck.Size = new Size(139, 19);
            enableAutoMessageCheck.TabIndex = 26;
            enableAutoMessageCheck.Text = "Enable Auto Message";
            enableAutoMessageCheck.UseVisualStyleBackColor = true;
            enableAutoMessageCheck.CheckedChanged += enableAutoMessageCheck_CheckedChanged;
            // 
            // ControlMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(220, 215, 201);
            ClientSize = new Size(1058, 487);
            ControlBox = false;
            Controls.Add(enableAutoMessageCheck);
            Controls.Add(autoMessageLabel);
            Controls.Add(autoSendMessageCD);
            Controls.Add(autoMessageBox);
            Controls.Add(pictureBox10);
            Controls.Add(pictureBox1);
            Controls.Add(saveButton);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ControlMenu";
            Text = "ControlMenu";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox10).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox wiggleCooldownTextBox;
        private TextBox dropCooldownTextBox;
        private TextBox gooseCooldownTextBox;
        private TextBox randomKeyCooldownTextBox;
        private TextBox turnCooldownTextBox;
        private TextBox oneClickCooldownTextBox;
        private Button saveButton;
        private CheckBox enableBits;
        private TextBox wiggleCostBox;
        private TextBox dropCostBox;
        private TextBox gooseCostBox;
        private TextBox randomKeyCostBox;
        private TextBox turnCostBox;
        private TextBox oneClickCostBox;
        private CheckBox oneClickCheck;
        private CheckBox randomTurn;
        private CheckBox enableRandomKey;
        private CheckBox chkEnableGoose;
        private CheckBox enableKitDrop;
        private CheckBox enableWiggle;
        private Panel panel1;
        private PictureBox pictureBox1;
        private PictureBox pictureBox10;
        private CheckBox checkBox1;
        private ImageList imageList1;
        private PictureBox pictureBox2;
        private TextBox autoMessageBox;
        private TextBox autoSendMessageCD;
        private Label autoMessageLabel;
        private CheckBox enableAutoMessageCheck;
    }
}