using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UiBot
{
    public partial class TraderMenuConfig : Form
    {
        private bool isDragging = false;
        private Point offset;


        public TraderMenuConfig()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            // Create a GraphicsPath with rounded corners
            GraphicsPath path = new GraphicsPath();
            int radius = 10; // Adjust the radius as needed
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

            enablePrapor.Checked = Properties.Settings.Default.isTraderPraporEnabled;
            enableTherapist.Checked = Properties.Settings.Default.isTraderTherapistEnabled;
            enablePeacekeeper.Checked = Properties.Settings.Default.isTraderPeacekeeperEnabled;
            enableMechanic.Checked = Properties.Settings.Default.isTraderMechanicEnabled;
            enableFence.Checked = Properties.Settings.Default.isTraderFenceEnabled;
            enableRagman.Checked = Properties.Settings.Default.isTraderRagmanEnabled;
            enableSkier.Checked = Properties.Settings.Default.isTraderSkierEnabled;
            enableJaeger.Checked = Properties.Settings.Default.isTraderJaegerEnabled;
            enableLightkeeper.Checked = Properties.Settings.Default.isTraderLightkeeperEnabled;
            enableCustomTraders.Checked = Properties.Settings.Default.isTwitchTradersEnabled;

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void enableCustomTraders_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.isTwitchTradersEnabled = enableCustomTraders.Checked;
            Properties.Settings.Default.Save();
        }

        private void enableLightkeeper_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.isTraderLightkeeperEnabled = enableLightkeeper.Checked;
            Properties.Settings.Default.Save();
        }

        private void enableJaeger_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.isTraderJaegerEnabled = enableJaeger.Checked;
            Properties.Settings.Default.Save();
        }

        private void enableSkier_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.isTraderSkierEnabled = enableSkier.Checked;
            Properties.Settings.Default.Save();
        }

        private void enableRagman_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.isTraderRagmanEnabled = enableRagman.Checked;
            Properties.Settings.Default.Save();
        }

        private void enableFence_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.isTraderFenceEnabled = enableFence.Checked;
            Properties.Settings.Default.Save();
        }

        private void enableMechanic_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.isTraderMechanicEnabled = enableMechanic.Checked;
            Properties.Settings.Default.Save();
        }

        private void enablePeacekeeper_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.isTraderPeacekeeperEnabled = enablePeacekeeper.Checked;
            Properties.Settings.Default.Save();
        }

        private void enableTherapist_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.isTraderTherapistEnabled = enableTherapist.Checked;
            Properties.Settings.Default.Save();
        }

        private void enablePrapor_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.isTraderPraporEnabled = enablePrapor.Checked;
            Properties.Settings.Default.Save();
        }
    }
}
