namespace UiBot
{
    partial class AboutForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            tabControl1 = new TabControl();
            tabPage3 = new TabPage();
            textBox3 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            linkLabel1 = new LinkLabel();
            label3 = new Label();
            label4 = new Label();
            tabControl1.SuspendLayout();
            tabPage3.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Location = new Point(-2, -2);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(313, 358);
            tabControl1.TabIndex = 0;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(textBox3);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(305, 330);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Changelog";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(-2, -2);
            textBox3.Multiline = true;
            textBox3.Name = "textBox3";
            textBox3.ReadOnly = true;
            textBox3.Size = new Size(309, 334);
            textBox3.TabIndex = 1;
            textBox3.Text = resources.GetString("textBox3.Text");
            textBox3.TextChanged += textBox3_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(5, 359);
            label1.Name = "label1";
            label1.Size = new Size(302, 25);
            label1.TabIndex = 1;
            label1.Text = "Don't forget to check for updates ";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(127, 443);
            label2.Name = "label2";
            label2.Size = new Size(38, 15);
            label2.TabIndex = 2;
            label2.Text = "label2";
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(127, 419);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(43, 15);
            linkLabel1.TabIndex = 3;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Github";
            linkLabel1.TextAlign = ContentAlignment.MiddleCenter;
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(30, 458);
            label3.Name = "label3";
            label3.Size = new Size(251, 15);
            label3.TabIndex = 4;
            label3.Text = "Created by Sprollucy with the help of ChatGPT";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(25, 385);
            label4.Name = "label4";
            label4.Size = new Size(261, 25);
            label4.TabIndex = 5;
            label4.Text = "and report any bugs you find";
            // 
            // AboutForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(304, 482);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(linkLabel1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(tabControl1);
            Name = "AboutForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AboutForm1";
            tabControl1.ResumeLayout(false);
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage3;
        private TextBox textBox3;
        private Label label1;
        private Label label2;
        private LinkLabel linkLabel1;
        private Label label3;
        private Label label4;
    }
}