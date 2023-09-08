using System;
using System.Drawing;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace UiBot
{
    public partial class ModernMenu : Form
    {
        private bool isEnlarged = false;
        private int originalWidth;
        private int enlargedWidth;
        private TimeSpan transitionDuration = TimeSpan.FromMilliseconds(250); // Adjust the duration as needed
        private DateTime transitionStartTime;
        private Timer transitionTimer;
        private Color originalPictureBox2BackColor; // Store the original background color
        private bool isDragging = false;
        private Point offset;
        private ConnectMenu connectMenu;

        public ModernMenu()
        {
            InitializeComponent();
            InitializeConsole();
            this.FormBorderStyle = FormBorderStyle.None;
            //temp load of menu - replace with start screen
            connectMenu ??= new ConnectMenu();
            this.Controls.Add(connectMenu);
            connectMenu.Dock = DockStyle.Fill;
            connectMenu.Location = new Point(-connectMenu.Width, 0);
            connectMenu.Show();

            // Mouse events for pictureBox10
            pictureBox10.MouseDown += (s, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    isDragging = true;
                    offset = e.Location;
                }
            };

            pictureBox10.MouseMove += (s, e) =>
            {
                if (isDragging)
                {
                    Point newLocation = this.PointToScreen(new Point(e.X - offset.X, e.Y - offset.Y));
                    this.Location = newLocation;
                }
            };

            pictureBox10.MouseUp += (s, e) =>
            {
                isDragging = false;
            };

            originalWidth = pictureBox1.Width;
            enlargedWidth = originalWidth + 200; // Adjust the enlarged width as needed
            transitionTimer = new Timer { Interval = 5 }; // Adjust the interval for smoother transition
            transitionTimer.Tick += TransitionTimer_Tick;
            originalPictureBox2BackColor = pictureBox2.BackColor; // Store the original background color

            // Mouse events for pictureBox2 and pictureBox3 to pictureBox8
            Action<PictureBox> setMouseEvents = pictureBox =>
            {
                pictureBox.MouseEnter += (s, e) =>
                {
                    pictureBox.BackColor = Color.FromArgb(44, 54, 57); // Change this ARGB color to your desired color
                };

                pictureBox.MouseLeave += (s, e) =>
                {
                    pictureBox.BackColor = originalPictureBox2BackColor;
                };
            };

            setMouseEvents(pictureBox2);
            setMouseEvents(pictureBox3);
            setMouseEvents(pictureBox4);
            setMouseEvents(pictureBox5);
            setMouseEvents(pictureBox6);
            setMouseEvents(pictureBox7);
            setMouseEvents(pictureBox8);
        }

        private void InitializeConsole()
        {
            // Redirect standard output to the consoleTextBox
            // Console.SetOut(new TextBoxWriter(consoleTextBox));
            Console.WriteLine("Console initialized.");
        }

        private class TextBoxWriter : System.IO.TextWriter
        {
            private TextBox textBox;

            public TextBoxWriter(TextBox textBox)
            {
                this.textBox = textBox;
            }

            public override void Write(char value)
            {
                textBox.AppendText(value.ToString());
            }

            public override void Write(string value)
            {
                textBox.AppendText(value);
            }

            public override void WriteLine(string value)
            {
                textBox.AppendText(value + Environment.NewLine);
            }

            public override System.Text.Encoding Encoding => System.Text.Encoding.UTF8;
        }

        private void TransitionTimer_Tick(object sender, EventArgs e)
        {
            TimeSpan elapsed = DateTime.Now - transitionStartTime;
            double progress = elapsed.TotalMilliseconds / transitionDuration.TotalMilliseconds;
            int newWidth = isEnlarged
                ? (int)(originalWidth + (enlargedWidth - originalWidth) * progress)
                : (int)(enlargedWidth - (enlargedWidth - originalWidth) * progress);

            newWidth = Math.Min(Math.Max(newWidth, originalWidth), enlargedWidth);
            pictureBox1.Width = newWidth;

            if (progress >= 1.0)
            {
                transitionTimer.Stop();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (!transitionTimer.Enabled)
            {
                transitionStartTime = DateTime.Now;
                transitionTimer.Start();
                isEnlarged = !isEnlarged;
            }
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            connectMenu ??= new ConnectMenu();
            this.Controls.Add(connectMenu);
            connectMenu.Dock = DockStyle.Fill;
            connectMenu.Location = new Point(-connectMenu.Width, 0);
            connectMenu.Show();
        }

    }
}

