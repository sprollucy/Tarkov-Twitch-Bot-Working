namespace UiBot
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            textBox1 = new TextBox();
            button1 = new Button();
            textBox2 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            Start = new Button();
            button3 = new Button();
            button4 = new Button();
            groupBox1 = new GroupBox();
            checkBox1 = new CheckBox();
            StopGoose = new Button();
            chkEnableGoose = new CheckBox();
            toolTip1 = new ToolTip(components);
            EnableWiggle = new CheckBox();
            enableRandomKey = new CheckBox();
            enableKitDrop = new CheckBox();
            ranTurn = new CheckBox();
            helpButton = new Button();
            groupBox2 = new GroupBox();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            popCheck = new CheckBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(101, 22);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 0;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // button1
            // 
            button1.Location = new Point(207, 22);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 1;
            button1.Text = "Save";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(101, 52);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(100, 23);
            textBox2.TabIndex = 2;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Light", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(23, 108);
            label1.Name = "label1";
            label1.Size = new Size(228, 15);
            label1.TabIndex = 3;
            label1.Text = "Information will automatically reload on start";
            label1.Click += label1_Click_1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(18, 25);
            label2.Name = "label2";
            label2.Size = new Size(77, 15);
            label2.TabIndex = 4;
            label2.Text = "Access Token";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(9, 55);
            label3.Name = "label3";
            label3.Size = new Size(86, 15);
            label3.TabIndex = 5;
            label3.Text = "Channel Name";
            // 
            // Start
            // 
            Start.Location = new Point(112, 338);
            Start.Name = "Start";
            Start.Size = new Size(75, 23);
            Start.TabIndex = 7;
            Start.Text = "Start";
            toolTip1.SetToolTip(Start, "Stopping and starting the app will cause it to hard crash!");
            Start.UseVisualStyleBackColor = true;
            Start.Click += Start_Click;
            // 
            // button3
            // 
            button3.Location = new Point(207, 51);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 8;
            button3.Text = "Save";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(220, 338);
            button4.Name = "button4";
            button4.Size = new Size(75, 23);
            button4.TabIndex = 9;
            button4.Text = "Stop";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(button3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(checkBox1);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(textBox2);
            groupBox1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox1.Location = new Point(4, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(293, 140);
            groupBox1.TabIndex = 10;
            groupBox1.TabStop = false;
            groupBox1.Text = "Login Info";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            checkBox1.Location = new Point(101, 81);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(121, 19);
            checkBox1.TabIndex = 11;
            checkBox1.Text = "Show information";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // StopGoose
            // 
            StopGoose.Location = new Point(11, 150);
            StopGoose.Name = "StopGoose";
            StopGoose.Size = new Size(75, 23);
            StopGoose.TabIndex = 11;
            StopGoose.Text = "Stop Goose";
            StopGoose.UseVisualStyleBackColor = true;
            StopGoose.Click += StopGoose_Click;
            // 
            // chkEnableGoose
            // 
            chkEnableGoose.AutoSize = true;
            chkEnableGoose.Location = new Point(12, 21);
            chkEnableGoose.Name = "chkEnableGoose";
            chkEnableGoose.Size = new Size(97, 19);
            chkEnableGoose.TabIndex = 12;
            chkEnableGoose.Text = "Enable Goose";
            chkEnableGoose.UseVisualStyleBackColor = true;
            chkEnableGoose.CheckedChanged += chkEnableGoose_CheckedChanged;
            // 
            // toolTip1
            // 
            toolTip1.Popup += toolTip1_Popup;
            // 
            // EnableWiggle
            // 
            EnableWiggle.AutoSize = true;
            EnableWiggle.Location = new Point(12, 46);
            EnableWiggle.Name = "EnableWiggle";
            EnableWiggle.Size = new Size(101, 19);
            EnableWiggle.TabIndex = 13;
            EnableWiggle.Text = "Enable Wiggle";
            EnableWiggle.UseVisualStyleBackColor = true;
            EnableWiggle.CheckedChanged += EnableWiggle_CheckedChanged;
            // 
            // enableRandomKey
            // 
            enableRandomKey.AutoSize = true;
            enableRandomKey.Location = new Point(12, 71);
            enableRandomKey.Name = "enableRandomKey";
            enableRandomKey.Size = new Size(162, 19);
            enableRandomKey.TabIndex = 14;
            enableRandomKey.Text = "Enable Random Key Input";
            enableRandomKey.UseVisualStyleBackColor = true;
            enableRandomKey.CheckedChanged += enableRandomKey_CheckedChanged;
            // 
            // enableKitDrop
            // 
            enableKitDrop.AutoSize = true;
            enableKitDrop.Location = new Point(12, 96);
            enableKitDrop.Name = "enableKitDrop";
            enableKitDrop.Size = new Size(107, 19);
            enableKitDrop.TabIndex = 15;
            enableKitDrop.Text = "Enable Kit Drop";
            enableKitDrop.UseVisualStyleBackColor = true;
            enableKitDrop.CheckedChanged += enableKitDrop_CheckedChanged;
            // 
            // ranTurn
            // 
            ranTurn.AutoSize = true;
            ranTurn.Location = new Point(12, 121);
            ranTurn.Name = "ranTurn";
            ranTurn.Size = new Size(153, 19);
            ranTurn.TabIndex = 16;
            ranTurn.Text = "Enable Random Turning";
            ranTurn.UseVisualStyleBackColor = true;
            ranTurn.CheckedChanged += ranTurn_CheckedChanged;
            // 
            // helpButton
            // 
            helpButton.Location = new Point(10, 338);
            helpButton.Name = "helpButton";
            helpButton.Size = new Size(75, 23);
            helpButton.TabIndex = 17;
            helpButton.Text = "Help";
            helpButton.UseVisualStyleBackColor = true;
            helpButton.Click += helpButton_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(popCheck);
            groupBox2.Controls.Add(enableKitDrop);
            groupBox2.Controls.Add(ranTurn);
            groupBox2.Controls.Add(chkEnableGoose);
            groupBox2.Controls.Add(EnableWiggle);
            groupBox2.Controls.Add(enableRandomKey);
            groupBox2.Location = new Point(112, 150);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(185, 170);
            groupBox2.TabIndex = 18;
            groupBox2.TabStop = false;
            groupBox2.Text = "Fun Commands";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(-3, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(313, 398);
            tabControl1.TabIndex = 19;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(button4);
            tabPage1.Controls.Add(helpButton);
            tabPage1.Controls.Add(groupBox2);
            tabPage1.Controls.Add(StopGoose);
            tabPage1.Controls.Add(Start);
            tabPage1.Controls.Add(groupBox1);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(305, 370);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Bot Page";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(305, 370);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Options";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // popCheck
            // 
            popCheck.AutoSize = true;
            popCheck.Location = new Point(12, 146);
            popCheck.Name = "popCheck";
            popCheck.Size = new Size(58, 19);
            popCheck.TabIndex = 19;
            popCheck.Text = "1 shot";
            popCheck.UseVisualStyleBackColor = true;
            popCheck.CheckedChanged += popCheck_CheckedChanged;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(304, 391);
            Controls.Add(tabControl1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            Text = "Tarkov Sweat Bot";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TextBox textBox1;
        private Button button1;
        private TextBox textBox2;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button Start;
        private Button button3;
        private Button button4;
        private GroupBox groupBox1;
        private CheckBox checkBox1;
        private Button StopGoose;
        private CheckBox chkEnableGoose;
        private ToolTip toolTip1;
        private CheckBox EnableWiggle;
        private CheckBox enableRandomKey;
        private CheckBox enableKitDrop;
        private CheckBox ranTurn;
        private Button helpButton;
        private GroupBox groupBox2;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private CheckBox popCheck;
    }
}