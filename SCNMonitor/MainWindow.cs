using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SCNMonitor
{
    public partial class MainWindow : Form
    {
        const int RELOAD_INTERVAL = 60;

        private SCNClient scn;
        private Timer timer;
        private int timeToReload;

        public MainWindow()
        {
            InitializeComponent();
            scn = new SCNClient("http://www.scn.put.poznan.pl/main.php");
            timer = new Timer();
            timer.Tick += new EventHandler(OnTimer);

            timer.Interval = 1000;
            timer.Start();
            timeToReload = 0;
        }

        private async void OnTimer(object sender, EventArgs e)
        {
            timeToReload--;
            if (timeToReload <= 0)
            {
                await CheckTransfer();
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
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        }

        private async void login_Click(object sender, EventArgs e)
        {
            await CheckTransfer();
        }
    }
}
