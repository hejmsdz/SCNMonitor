using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SCNMonitor
{
    public partial class MainWindow : Form
    {
        const int RELOAD_INTERVAL = 60;
        const int WARNING_THRESHOLD = 80;

        private SCNClient scn;
        private int timeToReload = 0;
        private bool warned = false;
        private bool exit = false;

        public MainWindow()
        {
            InitializeComponent();
            scn = new SCNClient("http://www.scn.put.poznan.pl/main.php");
            notifyIcon.Icon = DrawIcon();
            timer.Start();
        }

        private void MainWindow_Shown(object sender, EventArgs e)
        {
            string[] args = Environment.GetCommandLineArgs();
            if (args.Length >= 2 && args[1] == "-hide")
            {
                Hide();
            }
        }

        private Icon DrawIcon(int percentage = -1)
        {
            int size = 0;
            string text = "?";

            if (percentage >= 0)
            {
                size = (percentage * 16) / 100;
                text = percentage.ToString();
            }

            using (Bitmap bmp = new Bitmap(16, 16))
            {
                Graphics g = Graphics.FromImage(bmp);
                Font font = new Font(FontFamily.GenericSansSerif, 8);
                Brush textBrush = Brushes.White;
                Brush lineBrush = warned ? Brushes.Red : Brushes.White;

                g.DrawString(text, font, textBrush, 0, 0);
                g.FillRectangle(lineBrush, 0, 14, size, 2);

                return Icon.FromHandle(bmp.GetHicon());
            }
        }

        private async Task CheckTransfer()
        {
            timer.Stop();

            string buttonText = check.Text;
            check.Text = "Checking...";
            check.Enabled = false;

            try
            {
                await scn.Transfer();
            }
            catch (TransferCheckException e)
            {
                // MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            finally
            {
                check.Text = buttonText;
                check.Enabled = true;
                timeToReload = RELOAD_INTERVAL;
                timer.Start();
            }

            download.Text = scn.Download.ToString() + " GB";
            upload.Text = scn.Upload.ToString() + " GB";
            total.Text = scn.Total.ToString() + " GB";
            usage.Text = scn.Percentage.ToString() + "%";
            usageBar.Value = scn.Percentage;

            downloadedToolStripMenuItem.Text = "Downloaded: " + scn.Download.ToString() + " GB";
            uploadedToolStripMenuItem.Text = "Uploaded: " + scn.Upload.ToString() + " GB";
            totalToolStripMenuItem.Text = "Total: " + scn.Total.ToString() + " GB";

            if (scn.Percentage >= WARNING_THRESHOLD && !warned)
            {
                notifyIcon.BalloonTipText = "You've reached " + scn.Percentage.ToString() + "% of data usage.";
                notifyIcon.ShowBalloonTip(5000);
                warned = true;
            }

            notifyIcon.Icon.Dispose();
            notifyIcon.Icon = DrawIcon(scn.Percentage);
        }

        private async void login_Click(object sender, EventArgs e)
        {
            await CheckTransfer();
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (exit)
            {
                notifyIcon.Visible = false;
            }
            else
            {
                Hide();
                e.Cancel = true;
            }
            
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            exit = true;
            Close();
        }

        private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (Visible)
                {
                    Hide();
                }
                else
                {
                    Show();
                    Activate();
                }
            }
        }

        private async void timer_Tick(object sender, EventArgs e)
        {
            timeToReload--;
            if (timeToReload <= 0)
            {
                await CheckTransfer();
            }
        }
    }
}
