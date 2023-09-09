using Newtonsoft.Json;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
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
        private SettingMenu settingMenu;
        private ControlMenu controlMenu;
        private bool isConnectMenuVisible = false;
        private bool isSettingMenuVisible = false;
        private bool isControlMenuVisible = false;
        private bool isLabelsSlidOut = false;
        private int labelsOriginalLeft;
        private int labelsTargetLeft;
        private Timer labelsSlideTimer;

        public ModernMenu()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            // Create a GraphicsPath with rounded corners
            GraphicsPath path = new GraphicsPath();
            int radius = 20; // Adjust the radius as needed
            Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);
            path.AddArc(rect.Left, rect.Top, radius * 2, radius * 2, 180, 90);
            path.AddArc(rect.Right - (radius * 2), rect.Top, radius * 2, radius * 2, 270, 90);
            path.AddArc(rect.Right - (radius * 2), rect.Bottom - (radius * 2), radius * 2, radius * 2, 0, 90);
            path.AddArc(rect.Left, rect.Bottom - (radius * 2), radius * 2, radius * 2, 90, 90);
            path.CloseFigure();

            // Set the form's region to the rounded shape
            this.Region = new Region(path);
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
            enlargedWidth = originalWidth + 130; // Adjust the enlarged width as needed
            transitionTimer = new Timer { Interval = 5 }; // Adjust the interval for smoother transition
            transitionTimer.Tick += TransitionTimer_Tick;
            originalPictureBox2BackColor = pictureBox2.BackColor; // Store the original background color
            labelsOriginalLeft = label1.Left;
            labelsTargetLeft = label1.Left + 130; // Adjust this value as needed
            labelsSlideTimer = new Timer { Interval = 1 }; // Adjust the interval for smoother animation
            labelsSlideTimer.Tick += LabelsSlideTimer_Tick;

            // Mouse events for pictureBox2 and pictureBox3 to pictureBox8
            Action<PictureBox> setMouseEvents = pictureBox =>
            {
                pictureBox.MouseEnter += (s, e) =>
                {
                    pictureBox.BackColor = Color.FromArgb(162, 123, 92); // Change this ARGB color to your desired color
                };

                pictureBox.MouseLeave += (s, e) =>
                {
                    pictureBox.BackColor = originalPictureBox2BackColor;
                };
            };

            setMouseEvents(pictureBox2);
            setMouseEvents(connectButton);
            setMouseEvents(commandMenu);
            setMouseEvents(pictureBox5);
            setMouseEvents(pictureBox6);
            setMouseEvents(pictureBox7);
            setMouseEvents(pictureBox8);
            setMouseEvents(settingsButton);
        }


        private CounterData LoadCounterData()
        {
            string jsonFilePath = "Logon.json";
            CounterData existingData = new CounterData();

            if (File.Exists(jsonFilePath))
            {
                string json = File.ReadAllText(jsonFilePath);
                existingData = JsonConvert.DeserializeObject<CounterData>(json) ?? new CounterData();
            }

            return existingData;
        }

        public class CounterData
        {
            public string ChannelName { get; set; }
            public string BotToken { get; set; }
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

        private void LabelsSlideTimer_Tick(object sender, EventArgs e)
        {
            TimeSpan elapsed = DateTime.Now - transitionStartTime;
            double progress = elapsed.TotalMilliseconds / transitionDuration.TotalMilliseconds;
            int newLeft = isLabelsSlidOut
                ? (int)(labelsOriginalLeft + (labelsTargetLeft - labelsOriginalLeft) * progress)
                : (int)(labelsTargetLeft - (labelsTargetLeft - labelsOriginalLeft) * progress);

            foreach (Control control in Controls)
            {
                if (control is Label label)
                {
                    label.Left = newLeft;
                }
            }

            if (progress >= 1.0)
            {
                labelsSlideTimer.Stop();
            }
        }

        private void menuButton_Click(object sender, EventArgs e)
        {
            if (!transitionTimer.Enabled)
            {
                transitionStartTime = DateTime.Now;
                transitionTimer.Start();
                isEnlarged = !isEnlarged;
            }
            if (!labelsSlideTimer.Enabled)
            {
                transitionStartTime = DateTime.Now;
                labelsSlideTimer.Start();
                isLabelsSlidOut = !isLabelsSlidOut;
            }
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void connectMenu_Click(object sender, EventArgs e)
        {
            HideOpenMenu(); // Hide the current open menu, if any
            ShowConnectMenu();
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            HideOpenMenu(); // Hide the current open menu, if any
            ShowSettingMenu();
        }

        // Define methods to show/hide ConnectMenu and SettingMenu
        private void ShowConnectMenu()
        {
            if (!isConnectMenuVisible)
            {
                if (connectMenu == null || connectMenu.IsDisposed)
                {
                    connectMenu = new ConnectMenu();
                    connectMenu.Dock = DockStyle.Fill;
                    connectMenu.Location = new Point(-connectMenu.Width, 0);
                }
                this.Controls.Add(connectMenu);
                connectMenu.Show();
                isConnectMenuVisible = true;
            }
        }

        private void HideConnectMenu()
        {
            if (isConnectMenuVisible)
            {
                this.Controls.Remove(connectMenu);
                connectMenu.Hide();
                isConnectMenuVisible = false;
            }
        }

        private void ShowSettingMenu()
        {
            if (!isSettingMenuVisible)
            {
                if (settingMenu == null || settingMenu.IsDisposed)
                {
                    settingMenu = new SettingMenu();
                    settingMenu.Dock = DockStyle.Fill;
                    settingMenu.Location = new Point(-settingMenu.Width, 0);
                }
                this.Controls.Add(settingMenu);
                settingMenu.Show();
                isSettingMenuVisible = true;
            }
        }

        private void HideSettingMenu()
        {
            if (isSettingMenuVisible)
            {
                this.Controls.Remove(settingMenu);
                settingMenu.Hide();
                isSettingMenuVisible = false;
            }
        }
        private void ShowControlMenu()
        {
            if (!isControlMenuVisible)
            {
                if (controlMenu == null || controlMenu.IsDisposed)
                {
                    controlMenu = new ControlMenu();
                    controlMenu.Dock = DockStyle.Fill;
                    controlMenu.Location = new Point(-controlMenu.Width, 0);
                }
                this.Controls.Add(controlMenu);
                controlMenu.Show();
                isControlMenuVisible = true;
            }
        }

        private void HideControlMenu()
        {
            if (isControlMenuVisible)
            {
                this.Controls.Remove(controlMenu); // Change 'commandMenu' to 'controlMenu'
                controlMenu.Hide(); // Change 'commandMenu' to 'controlMenu'
                isControlMenuVisible = false;
            }
        }

        // Method to hide the currently open menu
        private void HideOpenMenu()
        {
            if (isConnectMenuVisible)
            {
                HideConnectMenu();
            }
            else if (isSettingMenuVisible)
            {
                HideSettingMenu();
            }
            else if (isControlMenuVisible)
            {
                HideControlMenu();
            }
        }

        private void commandMenu_Click(object sender, EventArgs e)
        {
            HideOpenMenu(); // Hide the current open menu, if any
            ShowControlMenu();
        }

        private void ModernMenu_Load(object sender, EventArgs e)
        {

        }
    }
}

