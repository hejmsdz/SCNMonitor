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
        private SCNClient scn;
        public MainWindow()
        {
            InitializeComponent();
            scn = new SCNClient("http://www.scn.put.poznan.pl/main.php");
        }

        private async Task CheckTransfer()
        {
            try
            {
                await scn.Transfer();
            }
            catch (TransferCheckException e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            download.Text = scn.Download.ToString() + " GB";
            upload.Text = scn.Upload.ToString() + " GB";
            total.Text = scn.Total.ToString() + " GB";
            usage.Text = scn.Percentage.ToString() + "%";
            usageBar.Value = scn.Percentage;
        }

        private async void login_Click(object sender, EventArgs e)
        {
            string text = check.Text;
            check.Text = "Checking...";
            check.Enabled = false;
            await CheckTransfer();
            check.Text = text;
            check.Enabled = true;    
        }
    }
}
