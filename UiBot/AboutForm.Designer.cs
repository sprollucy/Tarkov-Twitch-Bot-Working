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
            label1 = new Label();
            linkLabel1 = new LinkLabel();
            groupBox1 = new GroupBox();
            label3 = new Label();
            label2 = new Label();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            richTextBox1 = new RichTextBox();
            tabPage2 = new TabPage();
            richTextBox2 = new RichTextBox();
            tabPage3 = new TabPage();
            richTextBox3 = new RichTextBox();
            groupBox1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage3.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(90, 71);
            label1.Name = "label1";
            label1.Size = new Size(214, 15);
            label1.TabIndex = 0;
            label1.Text = "Version: \" + Application.ProductVersion\r\n";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(117, 52);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(43, 15);
            linkLabel1.TabIndex = 2;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Github";
            linkLabel1.TextAlign = ContentAlignment.MiddleCenter;
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(linkLabel1);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(0, 330);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(304, 132);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Enter += groupBox1_Enter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(23, 95);
            label3.Name = "label3";
            label3.Size = new Size(251, 15);
            label3.TabIndex = 5;
            label3.Text = "Created by Sprollucy with the help of ChatGPT";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(33, 13);
            label2.Name = "label2";
            label2.Size = new Size(241, 34);
            label2.TabIndex = 4;
            label2.Text = "Don't forget to check for updates here\r\nand report any bug you find";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Location = new Point(-4, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(313, 339);
            tabControl1.TabIndex = 20;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(richTextBox1);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(305, 311);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "How to use";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(0, 0);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ReadOnly = true;
            richTextBox1.Size = new Size(309, 315);
            richTextBox1.TabIndex = 0;
            richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(richTextBox2);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(305, 311);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Command List";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // richTextBox2
            // 
            richTextBox2.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            richTextBox2.Location = new Point(-2, -2);
            richTextBox2.Name = "richTextBox2";
            richTextBox2.ReadOnly = true;
            richTextBox2.Size = new Size(309, 315);
            richTextBox2.TabIndex = 1;
            richTextBox2.Text = resources.GetString("richTextBox2.Text");
            richTextBox2.TextChanged += richTextBox2_TextChanged;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(richTextBox3);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(305, 311);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Changelog";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // richTextBox3
            // 
            richTextBox3.Location = new Point(-2, -2);
            richTextBox3.Name = "richTextBox3";
            richTextBox3.ReadOnly = true;
            richTextBox3.Size = new Size(309, 315);
            richTextBox3.TabIndex = 1;
            richTextBox3.Text = resources.GetString("richTextBox3.Text");
            // 
            // AboutForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(304, 448);
            Controls.Add(groupBox1);
            Controls.Add(tabControl1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "AboutForm";
            Text = "About";
            Load += AboutForm_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            tabPage3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private LinkLabel linkLabel1;
        private GroupBox groupBox1;
        private Label label2;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private RichTextBox richTextBox1;
        private RichTextBox richTextBox2;
        private TabPage tabPage3;
        private RichTextBox richTextBox3;
        private Label label3;
    }
}