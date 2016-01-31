using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
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
        private bool hidden = false;
        private short alarm = 0;
        private bool exit = false;

        delegate void UpdateUICallback();

        public MainWindow()
        {
            InitializeComponent();
            scn = new SCNClient("http://www.scn.put.poznan.pl/main.php");
            netCheck = new NetworkChecker();
            netCheck.StateChanged += Netcheck_StateChanged;
            if (!Properties.Settings.Default.AutodetectNetwork)
            {
                timer.Start();
            }
            notifyIcon.Icon = DrawIcon();

            PopulateSettings();

            string[] args = Environment.GetCommandLineArgs();
            hidden = (args.Length >= 2 && args[1] == "-hide");

            TranslateUI();
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr w, IntPtr l);

        private void TranslateUI()
        {
            Text = Properties.Resources.Title;
            statusTab.Text = Properties.Resources.Status;
            usageBox.Text = Properties.Resources.Usage;
            detailsBox.Text = Properties.Resources.Details;
            usageBox.Text = Properties.Resources.Usage;
            download.Text = string.Format(Properties.Resources.Download, "?");
            upload.Text = string.Format(Properties.Resources.Upload, "?");
            total.Text = string.Format(Properties.Resources.Total, "?");
            downloadedToolStripMenuItem.Text = download.Text;
            uploadedToolStripMenuItem.Text = upload.Text;
            totalToolStripMenuItem.Text = total.Text;
            check.Text = Properties.Resources.Check;
            exitButton.Text = Properties.Resources.Exit;
            exitToolStripMenuItem.Text = Properties.Resources.Exit;
            optionsTab.Text = Properties.Resources.Options;
            checkIntervalLabel.Text = Properties.Resources.CheckInterval;
            minute.Text = Properties.Resources.Minutes;
            warningThresholdLabel.Text = Properties.Resources.WarningThreshold;
            percent.Text = Properties.Resources.Percent;
            autodetectCheckbox.Text = Properties.Resources.Autodetect;
            notifyCheckbox.Text = Properties.Resources.Notify;
            startupCheckbox.Text = Properties.Resources.Startup;
            saveSettings.Text = Properties.Resources.Apply;
            defaultSettings.Text = Properties.Resources.Defaults;
            aboutTab.Text = Properties.Resources.About;
        }

        private void UpdateUI()
        {
            if (netCheck.State)
            {
                timer.Start();
                Text = Properties.Resources.Title;
                check.Enabled = true;
                if (ready && Properties.Settings.Default.NotifyOnNetworkChange)
                {
                    Notify(ToolTipIcon.Info, Properties.Resources.ConnectedMsg);
                }
            }
            else
            {
                timer.Stop();
                Text = Properties.Resources.Title+" "+Properties.Resources.Disconnected;
                check.Enabled = false;
                notifyIcon.Icon.Dispose();
                notifyIcon.Icon = DrawIcon();
                if (ready && Properties.Settings.Default.NotifyOnNetworkChange)
                {
                    Notify(ToolTipIcon.Info, Properties.Resources.DisconnectedMsg);
                }
            }
            ready = true;
        }

        private void Netcheck_StateChanged(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.AutodetectNetwork)
            {
                UpdateUICallback d = new UpdateUICallback(UpdateUI);
                Invoke(d);
            }                       
        }

        private void MainWindow_Shown(object sender, EventArgs e)
        {
            netCheck.Check(true);

            if (hidden)
            {
                Hide();
                Opacity = 1;
            }
        }

        private Icon DrawIcon(int percentage = -1)
        {
            int size = 0;
            string text = "?";

            Color line = Properties.Settings.Default.TrayIconColor;
            Brush bgBrush = new SolidBrush(Color.FromArgb(127, line.R, line.G, line.B));
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
                Brush lineBrush = (alarm > 0) ? warnBrush : normalBrush;

                SizeF textSize = g.MeasureString(text, font);

                g.DrawString(text, font, textBrush, (16-textSize.Width)/2, 1);
                g.FillRectangle(bgBrush, 0, 14, 16, 2);
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
            check.Text = Properties.Resources.Checking;
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

            download.Text = string.Format(Properties.Resources.Download, scn.Download);
            upload.Text = string.Format(Properties.Resources.Upload, scn.Upload);
            total.Text = string.Format(Properties.Resources.Total, scn.Total);
            usage.Text = scn.Percentage.ToString() + "%";
            usageBar.Value = Math.Min(100, scn.Percentage);

            downloadedToolStripMenuItem.Text = download.Text;
            uploadedToolStripMenuItem.Text = upload.Text;
            totalToolStripMenuItem.Text = total.Text;

            short newAlarm = 0;
            if (scn.Percentage >= 100)
            {
                newAlarm = 2;
            }
            else if (scn.Percentage >= Properties.Settings.Default.WarningThreshold)
            {
                newAlarm = 1;
            }

            if (newAlarm != alarm)
            {
                alarm = newAlarm;
                if (alarm == 1)
                {
                    Notify(ToolTipIcon.Warning, string.Format(Properties.Resources.Warning, scn.Percentage));
                    SendMessage(usageBar.Handle, 1040, (IntPtr)3, IntPtr.Zero); // yellow bar
                }
                else if (alarm == 2)
                {
                    Notify(ToolTipIcon.Error, string.Format(Properties.Resources.Warning, scn.Percentage));
                    SendMessage(usageBar.Handle, 1040, (IntPtr)2, IntPtr.Zero); // red bar
                }
                else
                {
                    SendMessage(usageBar.Handle, 1040, (IntPtr)1, IntPtr.Zero); // green bar
                }
            }

            notifyIcon.Icon.Dispose();
            notifyIcon.Icon = DrawIcon(scn.Percentage);
        }

        private async void check_Click(object sender, EventArgs e)
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
            // check.Text = string.Format("{0} [{1}]", Properties.Resources.Check, timeToReload);
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
            bool autodetectChange = autodetectCheckbox.Checked != Properties.Settings.Default.AutodetectNetwork;

            Properties.Settings.Default.CheckInterval = (int)checkIntervalField.Value;
            Properties.Settings.Default.WarningThreshold = (int)warningThresholdField.Value;
            Properties.Settings.Default.AutodetectNetwork = autodetectCheckbox.Checked;
            Properties.Settings.Default.NotifyOnNetworkChange = notifyCheckbox.Checked;
            Properties.Settings.Default.Save();
            saveSettings.Enabled = false;

            timeToReload = 0;

            if (autodetectChange)
            {
                if (Properties.Settings.Default.AutodetectNetwork)
                {
                    timer.Stop();
                    netCheck.Check(true);
                }
                else
                {
                    timer.Start();
                    Text = Properties.Resources.Title;
                }
            }

            if (startupCheckbox.Checked)
            {
                SetStartup();
            }
            else
            {
                UnsetStartup();
            }
        }

        private void settingsChanged(object sender, EventArgs e)
        {
            saveSettings.Enabled = true;
            defaultSettings.Enabled = true;
        }

        private void PopulateSettings()
        {
            checkIntervalField.Value = Properties.Settings.Default.CheckInterval;
            warningThresholdField.Value = Properties.Settings.Default.WarningThreshold;
            autodetectCheckbox.Checked = Properties.Settings.Default.AutodetectNetwork;
            notifyCheckbox.Checked = Properties.Settings.Default.NotifyOnNetworkChange;
            startupCheckbox.Checked = CheckStartup();

            saveSettings.Enabled = false;
        }

        private void autodetectCheckbox_CheckStateChanged(object sender, EventArgs e)
        {
            notifyCheckbox.Enabled = autodetectCheckbox.Checked;
        }

        private void defaultSettings_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reset();
            UnsetStartup();
            PopulateSettings();
            saveSettings.Enabled = false;
        }

        private void linkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LinkLabel ll = (LinkLabel)sender;
            string url = (string)ll.Tag;
            ProcessStartInfo sInfo = new ProcessStartInfo(url);
            Process.Start(sInfo);
        }
    }
}
