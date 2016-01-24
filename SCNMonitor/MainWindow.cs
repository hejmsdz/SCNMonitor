using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SCNMonitor
{
    public partial class MainWindow : Form
    {
        private SCNClient scn;
        private NetworkChecker netCheck;
        private int timeToReload = 0;
        private bool ready = false;
        private bool warned = false;
        private bool exit = false;

        delegate void UpdateUICallback();

        public MainWindow()
        {
            InitializeComponent();
            scn = new SCNClient("http://www.scn.put.poznan.pl/main.php");
            netCheck = new NetworkChecker();
            if (Properties.Settings.Default.AutodetectNetwork)
            {
                netCheck.StateChanged += Netcheck_StateChanged;
            }
            else
            {
                timer.Start();
            }
            notifyIcon.Icon = DrawIcon();

            PopulateSettings();
        }

        private void UpdateUI()
        {
            if (netCheck.State)
            {
                timer.Start();
                Text = "SCN Monitor";
                check.Enabled = true;
                if (ready && Properties.Settings.Default.NotifyOnNetworkChange)
                {
                    Notify(ToolTipIcon.Info, "You are now connected to the SCN.");
                }
            }
            else
            {
                timer.Stop();
                Text = "SCN Monitor (disconnected)";
                check.Enabled = false;
                notifyIcon.Icon.Dispose();
                notifyIcon.Icon = DrawIcon();
                if (ready && Properties.Settings.Default.NotifyOnNetworkChange)
                {
                    Notify(ToolTipIcon.Info, "You are disconnected from the SCN.");
                }
            }
            ready = true;
        }

        private void Netcheck_StateChanged(object sender, EventArgs e)
        {
            UpdateUICallback d = new UpdateUICallback(UpdateUI);
            Invoke(d);
        }

        private void MainWindow_Shown(object sender, EventArgs e)
        {
            netCheck.Check();

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

            Brush normalBrush = new SolidBrush(Properties.Settings.Default.TrayIconColor);
            Brush warnBrush = new SolidBrush(Properties.Settings.Default.TrayIconWarningColor);
            Font font = new Font(FontFamily.GenericSansSerif, 8);

            if (percentage >= 0)
            {
                size = (percentage * 16) / 100;
                text = percentage.ToString();
            }

            using (Bitmap bmp = new Bitmap(16, 16))
            {
                Graphics g = Graphics.FromImage(bmp);
                
                Brush textBrush = normalBrush;
                Brush lineBrush = warned ? warnBrush : normalBrush;

                g.DrawString(text, font, textBrush, 0, 0);
                g.FillRectangle(lineBrush, 0, 14, size, 2);

                return Icon.FromHandle(bmp.GetHicon());
            }
        }

        private void Notify(ToolTipIcon icon, string message, int duration = 5000)
        {
            notifyIcon.BalloonTipIcon = icon;
            notifyIcon.BalloonTipText = message;
            notifyIcon.ShowBalloonTip(duration);
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
                timeToReload = 60*Properties.Settings.Default.CheckInterval;
                timer.Start();
            }

            download.Text = "Download: " + scn.Download.ToString() + " GB";
            upload.Text = "Upload: " + scn.Upload.ToString() + " GB";
            total.Text = "Total: " + scn.Total.ToString() + " GB";
            usage.Text = scn.Percentage.ToString() + "%";
            usageBar.Value = scn.Percentage;

            downloadedToolStripMenuItem.Text = "Downloaded: " + scn.Download.ToString() + " GB";
            uploadedToolStripMenuItem.Text = "Uploaded: " + scn.Upload.ToString() + " GB";
            totalToolStripMenuItem.Text = "Total: " + scn.Total.ToString() + " GB";

            if (scn.Percentage >= Properties.Settings.Default.WarningThreshold && !warned)
            {
                Notify(ToolTipIcon.Warning, "You've reached " + scn.Percentage.ToString() + "% of data usage.");
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

        private void SetStartup()
        {
            string exec = '"'+Application.ExecutablePath + '"' + " -hide";
            RegistryKey rkApp = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
            rkApp.SetValue("SCNMonitor", exec);
        }

        private void UnsetStartup()
        {
            RegistryKey rkApp = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
            if (CheckStartup()) rkApp.DeleteValue("SCNMonitor");
        }

        private bool CheckStartup()
        {
            RegistryKey rkApp = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
            return rkApp.GetValue("SCNMonitor") != null;
        }

        private void saveSettings_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.CheckInterval = (int)checkIntervalField.Value;
            Properties.Settings.Default.WarningThreshold = (int)warningThresholdField.Value;
            Properties.Settings.Default.AutodetectNetwork = autodetectCheckbox.Checked;
            Properties.Settings.Default.NotifyOnNetworkChange = notifyCheckbox.Checked;
            Properties.Settings.Default.Save();

            if (startupCheckbox.Checked)
            {
                SetStartup();
            }
            else
            {
                UnsetStartup();
            }
        }

        private void PopulateSettings()
        {
            checkIntervalField.Value = Properties.Settings.Default.CheckInterval;
            warningThresholdField.Value = Properties.Settings.Default.WarningThreshold;
            autodetectCheckbox.Checked = Properties.Settings.Default.AutodetectNetwork;
            notifyCheckbox.Checked = Properties.Settings.Default.NotifyOnNetworkChange;
            startupCheckbox.Checked = CheckStartup();

            notifyCheckbox.Enabled = autodetectCheckbox.Checked;
        }

        private void autodetectCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            notifyCheckbox.Enabled = autodetectCheckbox.Checked;
        }

        private void defaultSettings_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reset();
            UnsetStartup();
            PopulateSettings();
        }
    }
}
