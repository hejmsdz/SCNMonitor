namespace SCNMonitor
{
    partial class MainWindow
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
            this.components = new System.ComponentModel.Container();
            this.check = new System.Windows.Forms.Button();
            this.usageBar = new System.Windows.Forms.ProgressBar();
            this.downloadLabel = new System.Windows.Forms.Label();
            this.download = new System.Windows.Forms.Label();
            this.upload = new System.Windows.Forms.Label();
            this.uploadLabel = new System.Windows.Forms.Label();
            this.total = new System.Windows.Forms.Label();
            this.totalLabel = new System.Windows.Forms.Label();
            this.usage = new System.Windows.Forms.Label();
            this.usageLabel = new System.Windows.Forms.Label();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.downloadedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uploadedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.totalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.startup = new System.Windows.Forms.CheckBox();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // check
            // 
            this.check.Location = new System.Drawing.Point(201, 47);
            this.check.Name = "check";
            this.check.Size = new System.Drawing.Size(83, 26);
            this.check.TabIndex = 2;
            this.check.Text = "Check";
            this.check.UseVisualStyleBackColor = true;
            this.check.Click += new System.EventHandler(this.login_Click);
            // 
            // usageBar
            // 
            this.usageBar.AccessibleName = "";
            this.usageBar.Location = new System.Drawing.Point(12, 183);
            this.usageBar.Name = "usageBar";
            this.usageBar.Size = new System.Drawing.Size(321, 34);
            this.usageBar.TabIndex = 3;
            // 
            // downloadLabel
            // 
            this.downloadLabel.AutoSize = true;
            this.downloadLabel.Location = new System.Drawing.Point(12, 37);
            this.downloadLabel.Name = "downloadLabel";
            this.downloadLabel.Size = new System.Drawing.Size(70, 13);
            this.downloadLabel.TabIndex = 5;
            this.downloadLabel.Text = "Downloaded:";
            // 
            // download
            // 
            this.download.AutoSize = true;
            this.download.Location = new System.Drawing.Point(107, 37);
            this.download.Name = "download";
            this.download.Size = new System.Drawing.Size(13, 13);
            this.download.TabIndex = 6;
            this.download.Text = "?";
            // 
            // upload
            // 
            this.upload.AutoSize = true;
            this.upload.Location = new System.Drawing.Point(107, 69);
            this.upload.Name = "upload";
            this.upload.Size = new System.Drawing.Size(13, 13);
            this.upload.TabIndex = 8;
            this.upload.Text = "?";
            // 
            // uploadLabel
            // 
            this.uploadLabel.AutoSize = true;
            this.uploadLabel.Location = new System.Drawing.Point(12, 69);
            this.uploadLabel.Name = "uploadLabel";
            this.uploadLabel.Size = new System.Drawing.Size(56, 13);
            this.uploadLabel.TabIndex = 7;
            this.uploadLabel.Text = "Uploaded:";
            // 
            // total
            // 
            this.total.AutoSize = true;
            this.total.Location = new System.Drawing.Point(107, 102);
            this.total.Name = "total";
            this.total.Size = new System.Drawing.Size(13, 13);
            this.total.TabIndex = 10;
            this.total.Text = "?";
            // 
            // totalLabel
            // 
            this.totalLabel.AutoSize = true;
            this.totalLabel.Location = new System.Drawing.Point(12, 102);
            this.totalLabel.Name = "totalLabel";
            this.totalLabel.Size = new System.Drawing.Size(34, 13);
            this.totalLabel.TabIndex = 9;
            this.totalLabel.Text = "Total:";
            // 
            // usage
            // 
            this.usage.AutoSize = true;
            this.usage.Location = new System.Drawing.Point(107, 133);
            this.usage.Name = "usage";
            this.usage.Size = new System.Drawing.Size(13, 13);
            this.usage.TabIndex = 12;
            this.usage.Text = "?";
            // 
            // usageLabel
            // 
            this.usageLabel.AutoSize = true;
            this.usageLabel.Location = new System.Drawing.Point(12, 133);
            this.usageLabel.Name = "usageLabel";
            this.usageLabel.Size = new System.Drawing.Size(41, 13);
            this.usageLabel.TabIndex = 11;
            this.usageLabel.Text = "Usage:";
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Warning;
            this.notifyIcon.ContextMenuStrip = this.menu;
            this.notifyIcon.Text = "SCN Monitor";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseClick);
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.downloadedToolStripMenuItem,
            this.uploadedToolStripMenuItem,
            this.totalToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(153, 98);
            // 
            // downloadedToolStripMenuItem
            // 
            this.downloadedToolStripMenuItem.Enabled = false;
            this.downloadedToolStripMenuItem.Name = "downloadedToolStripMenuItem";
            this.downloadedToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.downloadedToolStripMenuItem.Text = "Downloaded: ?";
            // 
            // uploadedToolStripMenuItem
            // 
            this.uploadedToolStripMenuItem.Enabled = false;
            this.uploadedToolStripMenuItem.Name = "uploadedToolStripMenuItem";
            this.uploadedToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.uploadedToolStripMenuItem.Text = "Uploaded: ?";
            // 
            // totalToolStripMenuItem
            // 
            this.totalToolStripMenuItem.Enabled = false;
            this.totalToolStripMenuItem.Name = "totalToolStripMenuItem";
            this.totalToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.totalToolStripMenuItem.Text = "Total: ?";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // startup
            // 
            this.startup.AutoSize = true;
            this.startup.Location = new System.Drawing.Point(177, 111);
            this.startup.Name = "startup";
            this.startup.Size = new System.Drawing.Size(143, 17);
            this.startup.TabIndex = 13;
            this.startup.Text = "Run on Windows startup";
            this.startup.UseVisualStyleBackColor = true;
            this.startup.Click += new System.EventHandler(this.startup_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 231);
            this.Controls.Add(this.startup);
            this.Controls.Add(this.usage);
            this.Controls.Add(this.usageLabel);
            this.Controls.Add(this.total);
            this.Controls.Add(this.totalLabel);
            this.Controls.Add(this.upload);
            this.Controls.Add(this.uploadLabel);
            this.Controls.Add(this.download);
            this.Controls.Add(this.downloadLabel);
            this.Controls.Add(this.usageBar);
            this.Controls.Add(this.check);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MainWindow";
            this.ShowInTaskbar = false;
            this.Text = "SCN Monitor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Shown += new System.EventHandler(this.MainWindow_Shown);
            this.menu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button check;
        private System.Windows.Forms.ProgressBar usageBar;
        private System.Windows.Forms.Label downloadLabel;
        private System.Windows.Forms.Label download;
        private System.Windows.Forms.Label upload;
        private System.Windows.Forms.Label uploadLabel;
        private System.Windows.Forms.Label total;
        private System.Windows.Forms.Label totalLabel;
        private System.Windows.Forms.Label usage;
        private System.Windows.Forms.Label usageLabel;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem downloadedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uploadedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem totalToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.CheckBox startup;
    }
}

