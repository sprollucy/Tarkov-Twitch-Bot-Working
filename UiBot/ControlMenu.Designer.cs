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
            textBox2 = new TextBox();
            dropKeyTextBox = new TextBox();
            textBox1 = new TextBox();
            label2 = new Label();
            pictureBox12 = new PictureBox();
            enableBagDrop = new CheckBox();
            dropbagCostBox = new TextBox();
            dropbagCooldownTextBox = new TextBox();
            pictureBox11 = new PictureBox();
            enableGrenade = new CheckBox();
            grenadeCostBox = new TextBox();
            grenadeCooldownTextBox = new TextBox();
            randomKeyInputs = new TextBox();
            pictureBox9 = new PictureBox();
            pictureBox8 = new PictureBox();
            pictureBox7 = new PictureBox();
            pictureBox6 = new PictureBox();
            pictureBox5 = new PictureBox();
            pictureBox4 = new PictureBox();
            enableTraderCheck = new CheckBox();
            pictureBox2 = new PictureBox();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            pictureBox10 = new PictureBox();
            imageList1 = new ImageList(components);
            autoMessageBox = new TextBox();
            autoSendMessageCD = new TextBox();
            autoMessageLabel = new Label();
            enableAutoMessageCheck = new CheckBox();
            pictureBox3 = new PictureBox();
            textBox3 = new TextBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox12).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox11).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox9).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox10).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // wiggleCooldownTextBox
            // 
            wiggleCooldownTextBox.Location = new Point(190, 72);
            wiggleCooldownTextBox.Name = "wiggleCooldownTextBox";
            wiggleCooldownTextBox.Size = new Size(100, 23);
            wiggleCooldownTextBox.TabIndex = 0;
            wiggleCooldownTextBox.Text = "300";
            // 
            // dropCooldownTextBox
            // 
            dropCooldownTextBox.Location = new Point(190, 101);
            dropCooldownTextBox.Name = "dropCooldownTextBox";
            dropCooldownTextBox.Size = new Size(100, 23);
            dropCooldownTextBox.TabIndex = 1;
            dropCooldownTextBox.Text = "300";
            // 
            // gooseCooldownTextBox
            // 
            gooseCooldownTextBox.Location = new Point(190, 159);
            gooseCooldownTextBox.Name = "gooseCooldownTextBox";
            gooseCooldownTextBox.Size = new Size(100, 23);
            gooseCooldownTextBox.TabIndex = 2;
            gooseCooldownTextBox.Text = "300";
            // 
            // randomKeyCooldownTextBox
            // 
            randomKeyCooldownTextBox.Location = new Point(190, 188);
            randomKeyCooldownTextBox.Name = "randomKeyCooldownTextBox";
            randomKeyCooldownTextBox.Size = new Size(100, 23);
            randomKeyCooldownTextBox.TabIndex = 3;
            randomKeyCooldownTextBox.Text = "300";
            // 
            // turnCooldownTextBox
            // 
            turnCooldownTextBox.Location = new Point(190, 247);
            turnCooldownTextBox.Name = "turnCooldownTextBox";
            turnCooldownTextBox.Size = new Size(100, 23);
            turnCooldownTextBox.TabIndex = 4;
            turnCooldownTextBox.Text = "300";
            // 
            // oneClickCooldownTextBox
            // 
            oneClickCooldownTextBox.Location = new Point(190, 276);
            oneClickCooldownTextBox.Name = "oneClickCooldownTextBox";
            oneClickCooldownTextBox.Size = new Size(100, 23);
            oneClickCooldownTextBox.TabIndex = 5;
            oneClickCooldownTextBox.Text = "300";
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
            enableBits.Location = new Point(296, 47);
            enableBits.Name = "enableBits";
            enableBits.Size = new Size(83, 19);
            enableBits.TabIndex = 7;
            enableBits.Text = "Enable Bits";
            enableBits.UseVisualStyleBackColor = false;
            enableBits.CheckedChanged += enableBits_CheckedChanged;
            // 
            // wiggleCostBox
            // 
            wiggleCostBox.Location = new Point(296, 72);
            wiggleCostBox.Name = "wiggleCostBox";
            wiggleCostBox.Size = new Size(100, 23);
            wiggleCostBox.TabIndex = 8;
            // 
            // dropCostBox
            // 
            dropCostBox.Location = new Point(296, 101);
            dropCostBox.Name = "dropCostBox";
            dropCostBox.Size = new Size(100, 23);
            dropCostBox.TabIndex = 9;
            // 
            // gooseCostBox
            // 
            gooseCostBox.Location = new Point(296, 159);
            gooseCostBox.Name = "gooseCostBox";
            gooseCostBox.Size = new Size(100, 23);
            gooseCostBox.TabIndex = 10;
            // 
            // randomKeyCostBox
            // 
            randomKeyCostBox.Location = new Point(296, 188);
            randomKeyCostBox.Name = "randomKeyCostBox";
            randomKeyCostBox.Size = new Size(100, 23);
            randomKeyCostBox.TabIndex = 11;
            // 
            // turnCostBox
            // 
            turnCostBox.Location = new Point(296, 247);
            turnCostBox.Name = "turnCostBox";
            turnCostBox.Size = new Size(100, 23);
            turnCostBox.TabIndex = 12;
            // 
            // oneClickCostBox
            // 
            oneClickCostBox.Location = new Point(296, 276);
            oneClickCostBox.Name = "oneClickCostBox";
            oneClickCostBox.Size = new Size(100, 23);
            oneClickCostBox.TabIndex = 13;
            // 
            // oneClickCheck
            // 
            oneClickCheck.AutoSize = true;
            oneClickCheck.BackColor = Color.FromArgb(181, 176, 163);
            oneClickCheck.Location = new Point(15, 276);
            oneClickCheck.Name = "oneClickCheck";
            oneClickCheck.Size = new Size(115, 19);
            oneClickCheck.TabIndex = 14;
            oneClickCheck.Text = "Enable One Click";
            oneClickCheck.UseVisualStyleBackColor = false;
            oneClickCheck.CheckedChanged += oneClickCheck_CheckedChanged;
            // 
            // randomTurn
            // 
            randomTurn.AutoSize = true;
            randomTurn.BackColor = Color.FromArgb(181, 176, 163);
            randomTurn.Location = new Point(15, 247);
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
            enableRandomKey.Location = new Point(15, 188);
            enableRandomKey.Name = "enableRandomKey";
            enableRandomKey.Size = new Size(136, 19);
            enableRandomKey.TabIndex = 16;
            enableRandomKey.Text = "Enable Random Keys";
            enableRandomKey.UseVisualStyleBackColor = false;
            enableRandomKey.CheckedChanged += enableRandomKey_CheckedChanged;
            // 
            // chkEnableGoose
            // 
            chkEnableGoose.AutoSize = true;
            chkEnableGoose.BackColor = Color.FromArgb(181, 176, 163);
            chkEnableGoose.Location = new Point(15, 159);
            chkEnableGoose.Name = "chkEnableGoose";
            chkEnableGoose.Size = new Size(97, 19);
            chkEnableGoose.TabIndex = 17;
            chkEnableGoose.Text = "Enable Goose";
            chkEnableGoose.UseVisualStyleBackColor = false;
            chkEnableGoose.CheckedChanged += chkEnableGoose_CheckedChanged;
            // 
            // enableKitDrop
            // 
            enableKitDrop.AutoSize = true;
            enableKitDrop.BackColor = Color.FromArgb(181, 176, 163);
            enableKitDrop.Location = new Point(15, 101);
            enableKitDrop.Name = "enableKitDrop";
            enableKitDrop.Size = new Size(107, 19);
            enableKitDrop.TabIndex = 18;
            enableKitDrop.Text = "Enable Kit Drop";
            enableKitDrop.UseVisualStyleBackColor = false;
            enableKitDrop.CheckedChanged += enableKitDrop_CheckedChanged;
            // 
            // enableWiggle
            // 
            enableWiggle.AutoSize = true;
            enableWiggle.BackColor = Color.FromArgb(181, 176, 163);
            enableWiggle.Location = new Point(15, 72);
            enableWiggle.Name = "enableWiggle";
            enableWiggle.Size = new Size(101, 19);
            enableWiggle.TabIndex = 19;
            enableWiggle.Text = "Enable Wiggle";
            enableWiggle.UseVisualStyleBackColor = false;
            enableWiggle.CheckedChanged += enableWiggle_CheckedChanged;
            // 
            // panel1
            // 
            panel1.Controls.Add(textBox3);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(dropKeyTextBox);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(pictureBox12);
            panel1.Controls.Add(enableBagDrop);
            panel1.Controls.Add(dropbagCostBox);
            panel1.Controls.Add(dropbagCooldownTextBox);
            panel1.Controls.Add(pictureBox11);
            panel1.Controls.Add(enableGrenade);
            panel1.Controls.Add(grenadeCostBox);
            panel1.Controls.Add(grenadeCooldownTextBox);
            panel1.Controls.Add(randomKeyInputs);
            panel1.Controls.Add(pictureBox9);
            panel1.Controls.Add(pictureBox8);
            panel1.Controls.Add(pictureBox7);
            panel1.Controls.Add(pictureBox6);
            panel1.Controls.Add(pictureBox5);
            panel1.Controls.Add(pictureBox4);
            panel1.Controls.Add(enableTraderCheck);
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
            panel1.Size = new Size(409, 415);
            panel1.TabIndex = 20;
            // 
            // textBox2
            // 
            textBox2.BackColor = Color.FromArgb(181, 176, 163);
            textBox2.BorderStyle = BorderStyle.None;
            textBox2.Location = new Point(84, 133);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(100, 16);
            textBox2.TabIndex = 46;
            textBox2.Text = "Drop Item Button";
            textBox2.TextAlign = HorizontalAlignment.Center;
            // 
            // dropKeyTextBox
            // 
            dropKeyTextBox.Location = new Point(189, 130);
            dropKeyTextBox.Name = "dropKeyTextBox";
            dropKeyTextBox.Size = new Size(100, 23);
            dropKeyTextBox.TabIndex = 45;
            dropKeyTextBox.Text = "/";
            dropKeyTextBox.TextChanged += dropKeyBox_TextChanged;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.FromArgb(181, 176, 163);
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Location = new Point(189, 49);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 16);
            textBox1.TabIndex = 44;
            textBox1.Text = "Cooldown Timer";
            textBox1.TextAlign = HorizontalAlignment.Center;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.FromArgb(162, 123, 92);
            label2.Font = new Font("Cambria", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(15, 8);
            label2.Name = "label2";
            label2.Size = new Size(174, 25);
            label2.TabIndex = 29;
            label2.Text = "Command Toggles";
            // 
            // pictureBox12
            // 
            pictureBox12.BackColor = Color.FromArgb(181, 176, 163);
            pictureBox12.Image = (Image)resources.GetObject("pictureBox12.Image");
            pictureBox12.Location = new Point(163, 333);
            pictureBox12.Name = "pictureBox12";
            pictureBox12.Size = new Size(20, 20);
            pictureBox12.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox12.TabIndex = 43;
            pictureBox12.TabStop = false;
            // 
            // enableBagDrop
            // 
            enableBagDrop.AutoSize = true;
            enableBagDrop.BackColor = Color.FromArgb(181, 176, 163);
            enableBagDrop.Location = new Point(14, 337);
            enableBagDrop.Name = "enableBagDrop";
            enableBagDrop.Size = new Size(113, 19);
            enableBagDrop.TabIndex = 42;
            enableBagDrop.Text = "Enable Bag Drop";
            enableBagDrop.UseVisualStyleBackColor = false;
            enableBagDrop.CheckedChanged += enableBagDrop_CheckedChanged;
            // 
            // dropbagCostBox
            // 
            dropbagCostBox.Location = new Point(295, 333);
            dropbagCostBox.Name = "dropbagCostBox";
            dropbagCostBox.Size = new Size(100, 23);
            dropbagCostBox.TabIndex = 41;
            // 
            // dropbagCooldownTextBox
            // 
            dropbagCooldownTextBox.Location = new Point(189, 333);
            dropbagCooldownTextBox.Name = "dropbagCooldownTextBox";
            dropbagCooldownTextBox.Size = new Size(100, 23);
            dropbagCooldownTextBox.TabIndex = 40;
            dropbagCooldownTextBox.Text = "300";
            // 
            // pictureBox11
            // 
            pictureBox11.BackColor = Color.FromArgb(181, 176, 163);
            pictureBox11.Image = (Image)resources.GetObject("pictureBox11.Image");
            pictureBox11.Location = new Point(164, 304);
            pictureBox11.Name = "pictureBox11";
            pictureBox11.Size = new Size(20, 20);
            pictureBox11.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox11.TabIndex = 39;
            pictureBox11.TabStop = false;
            // 
            // enableGrenade
            // 
            enableGrenade.AutoSize = true;
            enableGrenade.BackColor = Color.FromArgb(181, 176, 163);
            enableGrenade.Location = new Point(15, 308);
            enableGrenade.Name = "enableGrenade";
            enableGrenade.Size = new Size(108, 19);
            enableGrenade.TabIndex = 38;
            enableGrenade.Text = "Enable Grenade";
            enableGrenade.UseVisualStyleBackColor = false;
            enableGrenade.CheckedChanged += enableGrenade_CheckedChanged;
            // 
            // grenadeCostBox
            // 
            grenadeCostBox.Location = new Point(296, 304);
            grenadeCostBox.Name = "grenadeCostBox";
            grenadeCostBox.Size = new Size(100, 23);
            grenadeCostBox.TabIndex = 37;
            // 
            // grenadeCooldownTextBox
            // 
            grenadeCooldownTextBox.Location = new Point(190, 304);
            grenadeCooldownTextBox.Name = "grenadeCooldownTextBox";
            grenadeCooldownTextBox.Size = new Size(100, 23);
            grenadeCooldownTextBox.TabIndex = 36;
            grenadeCooldownTextBox.Text = "300";
            // 
            // randomKeyInputs
            // 
            randomKeyInputs.Location = new Point(190, 217);
            randomKeyInputs.Name = "randomKeyInputs";
            randomKeyInputs.Size = new Size(206, 23);
            randomKeyInputs.TabIndex = 35;
            randomKeyInputs.Text = "W,A,S,D,E,Q,C,{TAB},G,2,3";
            // 
            // pictureBox9
            // 
            pictureBox9.BackColor = Color.FromArgb(181, 176, 163);
            pictureBox9.Image = (Image)resources.GetObject("pictureBox9.Image");
            pictureBox9.Location = new Point(164, 275);
            pictureBox9.Name = "pictureBox9";
            pictureBox9.Size = new Size(20, 20);
            pictureBox9.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox9.TabIndex = 34;
            pictureBox9.TabStop = false;
            // 
            // pictureBox8
            // 
            pictureBox8.BackColor = Color.FromArgb(181, 176, 163);
            pictureBox8.Image = (Image)resources.GetObject("pictureBox8.Image");
            pictureBox8.Location = new Point(164, 247);
            pictureBox8.Name = "pictureBox8";
            pictureBox8.Size = new Size(20, 20);
            pictureBox8.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox8.TabIndex = 33;
            pictureBox8.TabStop = false;
            // 
            // pictureBox7
            // 
            pictureBox7.BackColor = Color.FromArgb(181, 176, 163);
            pictureBox7.Image = (Image)resources.GetObject("pictureBox7.Image");
            pictureBox7.Location = new Point(164, 188);
            pictureBox7.Name = "pictureBox7";
            pictureBox7.Size = new Size(20, 20);
            pictureBox7.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox7.TabIndex = 32;
            pictureBox7.TabStop = false;
            // 
            // pictureBox6
            // 
            pictureBox6.BackColor = Color.FromArgb(181, 176, 163);
            pictureBox6.Image = (Image)resources.GetObject("pictureBox6.Image");
            pictureBox6.Location = new Point(164, 159);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(20, 20);
            pictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox6.TabIndex = 31;
            pictureBox6.TabStop = false;
            // 
            // pictureBox5
            // 
            pictureBox5.BackColor = Color.FromArgb(181, 176, 163);
            pictureBox5.Image = (Image)resources.GetObject("pictureBox5.Image");
            pictureBox5.Location = new Point(164, 101);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(20, 20);
            pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox5.TabIndex = 30;
            pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            pictureBox4.BackColor = Color.FromArgb(181, 176, 163);
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(164, 72);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(20, 20);
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 29;
            pictureBox4.TabStop = false;
            // 
            // enableTraderCheck
            // 
            enableTraderCheck.AutoSize = true;
            enableTraderCheck.BackColor = Color.FromArgb(181, 176, 163);
            enableTraderCheck.Location = new Point(9, 369);
            enableTraderCheck.Name = "enableTraderCheck";
            enableTraderCheck.Size = new Size(175, 19);
            enableTraderCheck.TabIndex = 20;
            enableTraderCheck.Text = "Enable Trader Timer Updates";
            enableTraderCheck.UseVisualStyleBackColor = false;
            enableTraderCheck.CheckedChanged += enableTraderCheck_CheckedChanged;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(0, 0);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(409, 412);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 21;
            pictureBox2.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(479, 270);
            label1.Name = "label1";
            label1.Size = new Size(437, 90);
            label1.TabIndex = 28;
            label1.Text = resources.GetString("label1.Text");
            label1.TextAlign = ContentAlignment.MiddleCenter;
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
            autoMessageBox.Location = new Point(627, 99);
            autoMessageBox.Multiline = true;
            autoMessageBox.Name = "autoMessageBox";
            autoMessageBox.Size = new Size(228, 106);
            autoMessageBox.TabIndex = 23;
            autoMessageBox.Text = "Send auto messages to chat! use \\\\ to send seperate messages";
            // 
            // autoSendMessageCD
            // 
            autoSendMessageCD.Location = new Point(550, 70);
            autoSendMessageCD.Name = "autoSendMessageCD";
            autoSendMessageCD.Size = new Size(54, 23);
            autoSendMessageCD.TabIndex = 24;
            autoSendMessageCD.Text = "300";
            // 
            // autoMessageLabel
            // 
            autoMessageLabel.AutoSize = true;
            autoMessageLabel.BackColor = Color.FromArgb(162, 123, 92);
            autoMessageLabel.Font = new Font("Cambria", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            autoMessageLabel.Location = new Point(489, 31);
            autoMessageLabel.Name = "autoMessageLabel";
            autoMessageLabel.Size = new Size(135, 25);
            autoMessageLabel.TabIndex = 25;
            autoMessageLabel.Text = "Auto Message";
            // 
            // enableAutoMessageCheck
            // 
            enableAutoMessageCheck.AutoSize = true;
            enableAutoMessageCheck.BackColor = Color.FromArgb(181, 176, 163);
            enableAutoMessageCheck.Location = new Point(628, 70);
            enableAutoMessageCheck.Name = "enableAutoMessageCheck";
            enableAutoMessageCheck.Size = new Size(139, 19);
            enableAutoMessageCheck.TabIndex = 26;
            enableAutoMessageCheck.Text = "Enable Auto Message";
            enableAutoMessageCheck.UseVisualStyleBackColor = false;
            enableAutoMessageCheck.CheckedChanged += enableAutoMessageCheck_CheckedChanged;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(479, 23);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(402, 211);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 27;
            pictureBox3.TabStop = false;
            // 
            // textBox3
            // 
            textBox3.BackColor = Color.FromArgb(181, 176, 163);
            textBox3.BorderStyle = BorderStyle.None;
            textBox3.Location = new Point(51, 220);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(133, 16);
            textBox3.TabIndex = 47;
            textBox3.Text = "Random buttons to press";
            textBox3.TextAlign = HorizontalAlignment.Center;
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
            Controls.Add(pictureBox3);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ControlMenu";
            Text = "ControlMenu";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox12).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox11).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox9).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox10).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
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
        private CheckBox enableTraderCheck;
        private ImageList imageList1;
        private PictureBox pictureBox2;
        private TextBox autoMessageBox;
        private TextBox autoSendMessageCD;
        private Label autoMessageLabel;
        private CheckBox enableAutoMessageCheck;
        private PictureBox pictureBox3;
        private Label label1;
        private PictureBox pictureBox4;
        private PictureBox pictureBox9;
        private PictureBox pictureBox8;
        private PictureBox pictureBox7;
        private PictureBox pictureBox6;
        private PictureBox pictureBox5;
        private TextBox randomKeyInputs;
        private PictureBox pictureBox11;
        private CheckBox enableGrenade;
        private TextBox grenadeCostBox;
        private TextBox grenadeCooldownTextBox;
        private PictureBox pictureBox12;
        private CheckBox enableBagDrop;
        private TextBox dropbagCostBox;
        private TextBox dropbagCooldownTextBox;
        private Label label2;
        private TextBox textBox1;
        private TextBox dropKeyTextBox;
        private TextBox textBox2;
        private TextBox textBox3;
    }
}