namespace UiBot
{
    partial class SettingMenu
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
            groupBox1 = new GroupBox();
            accessBox = new TextBox();
            label1 = new Label();
            button3 = new Button();
            label2 = new Label();
            checkBox1 = new CheckBox();
            label3 = new Label();
            button1 = new Button();
            channelBox2 = new TextBox();
            pictureBox10 = new PictureBox();
            pictureBox1 = new PictureBox();
            helpButton = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox10).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(accessBox);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(button3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(checkBox1);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(channelBox2);
            groupBox1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox1.Location = new Point(54, 25);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(293, 140);
            groupBox1.TabIndex = 11;
            groupBox1.TabStop = false;
            groupBox1.Text = "Login Info";
            // 
            // accessBox
            // 
            accessBox.Location = new Point(101, 22);
            accessBox.Name = "accessBox";
            accessBox.Size = new Size(100, 23);
            accessBox.TabIndex = 12;
            accessBox.TextChanged += accessBox_TextChanged;
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
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(18, 25);
            label2.Name = "label2";
            label2.Size = new Size(77, 15);
            label2.TabIndex = 4;
            label2.Text = "Access Token";
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
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(9, 55);
            label3.Name = "label3";
            label3.Size = new Size(86, 15);
            label3.TabIndex = 5;
            label3.Text = "Channel Name";
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
            // channelBox2
            // 
            channelBox2.Location = new Point(101, 52);
            channelBox2.Name = "channelBox2";
            channelBox2.Size = new Size(100, 23);
            channelBox2.TabIndex = 2;
            channelBox2.TextChanged += channelBox2_TextChanged;
            // 
            // pictureBox10
            // 
            pictureBox10.BackColor = Color.FromArgb(63, 78, 79);
            pictureBox10.Location = new Point(43, -1);
            pictureBox10.Name = "pictureBox10";
            pictureBox10.Size = new Size(757, 20);
            pictureBox10.TabIndex = 24;
            pictureBox10.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Red;
            pictureBox1.Location = new Point(0, 10);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(47, 47);
            pictureBox1.TabIndex = 23;
            pictureBox1.TabStop = false;
            // 
            // helpButton
            // 
            helpButton.Location = new Point(155, 212);
            helpButton.Name = "helpButton";
            helpButton.Size = new Size(75, 23);
            helpButton.TabIndex = 25;
            helpButton.Text = "Help";
            helpButton.UseVisualStyleBackColor = true;
            helpButton.Click += helpButton_Click;
            // 
            // SettingMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(220, 215, 201);
            ClientSize = new Size(967, 487);
            ControlBox = false;
            Controls.Add(helpButton);
            Controls.Add(pictureBox10);
            Controls.Add(pictureBox1);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "SettingMenu";
            Text = "SettingMenu";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox10).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label1;
        private Button button3;
        private Label label2;
        private CheckBox checkBox1;
        private Label label3;
        private Button button1;
        private TextBox channelBox2;
        private PictureBox pictureBox10;
        private PictureBox pictureBox1;
        private Button helpButton;
        private TextBox accessBox;
    }
}