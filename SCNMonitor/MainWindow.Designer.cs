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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.download = new System.Windows.Forms.Label();
            this.upload = new System.Windows.Forms.Label();
            this.total = new System.Windows.Forms.Label();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.downloadedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uploadedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.totalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.startupCheckbox = new System.Windows.Forms.CheckBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.statusTab = new System.Windows.Forms.TabPage();
            this.statusTable = new System.Windows.Forms.TableLayoutPanel();
            this.usageBox = new System.Windows.Forms.GroupBox();
            this.usageTable = new System.Windows.Forms.TableLayoutPanel();
            this.usage = new System.Windows.Forms.Label();
            this.usageBar = new System.Windows.Forms.ProgressBar();
            this.detailsBox = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.check = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.optionsTab = new System.Windows.Forms.TabPage();
            this.optionsTable = new System.Windows.Forms.TableLayoutPanel();
            this.autodetectCheckbox = new System.Windows.Forms.CheckBox();
            this.notifyCheckbox = new System.Windows.Forms.CheckBox();
            this.optionsButtonsTable = new System.Windows.Forms.TableLayoutPanel();
            this.saveSettings = new System.Windows.Forms.Button();
            this.defaultSettings = new System.Windows.Forms.Button();
            this.checkIntervalTable = new System.Windows.Forms.TableLayoutPanel();
            this.checkIntervalField = new System.Windows.Forms.NumericUpDown();
            this.checkIntervalLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.warningThresholdField = new System.Windows.Forms.NumericUpDown();
            this.warningThresholdLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.menu.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.statusTab.SuspendLayout();
            this.statusTable.SuspendLayout();
            this.usageBox.SuspendLayout();
            this.usageTable.SuspendLayout();
            this.detailsBox.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.optionsTab.SuspendLayout();
            this.optionsTable.SuspendLayout();
            this.optionsButtonsTable.SuspendLayout();
            this.checkIntervalTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkIntervalField)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.warningThresholdField)).BeginInit();
            this.SuspendLayout();
            // 
            // download
            // 
            this.download.AutoSize = true;
            this.download.Dock = System.Windows.Forms.DockStyle.Fill;
            this.download.Location = new System.Drawing.Point(3, 0);
            this.download.Name = "download";
            this.download.Size = new System.Drawing.Size(127, 27);
            this.download.TabIndex = 6;
            this.download.Text = "Download: ?";
            this.download.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // upload
            // 
            this.upload.AutoSize = true;
            this.upload.Dock = System.Windows.Forms.DockStyle.Fill;
            this.upload.Location = new System.Drawing.Point(136, 0);
            this.upload.Name = "upload";
            this.upload.Size = new System.Drawing.Size(127, 27);
            this.upload.TabIndex = 8;
            this.upload.Text = "Upload: ?";
            this.upload.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // total
            // 
            this.total.AutoSize = true;
            this.total.Dock = System.Windows.Forms.DockStyle.Fill;
            this.total.Location = new System.Drawing.Point(269, 0);
            this.total.Name = "total";
            this.total.Size = new System.Drawing.Size(129, 27);
            this.total.TabIndex = 10;
            this.total.Text = "Total: ?";
            this.total.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            // startupCheckbox
            // 
            this.startupCheckbox.AutoSize = true;
            this.startupCheckbox.Location = new System.Drawing.Point(3, 101);
            this.startupCheckbox.Name = "startupCheckbox";
            this.startupCheckbox.Size = new System.Drawing.Size(143, 17);
            this.startupCheckbox.TabIndex = 13;
            this.startupCheckbox.Text = "Run on Windows startup";
            this.startupCheckbox.UseVisualStyleBackColor = true;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.statusTab);
            this.tabControl.Controls.Add(this.optionsTab);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(427, 207);
            this.tabControl.TabIndex = 14;
            // 
            // statusTab
            // 
            this.statusTab.Controls.Add(this.statusTable);
            this.statusTab.Location = new System.Drawing.Point(4, 22);
            this.statusTab.Name = "statusTab";
            this.statusTab.Padding = new System.Windows.Forms.Padding(3);
            this.statusTab.Size = new System.Drawing.Size(419, 181);
            this.statusTab.TabIndex = 0;
            this.statusTab.Text = "Status";
            this.statusTab.UseVisualStyleBackColor = true;
            // 
            // statusTable
            // 
            this.statusTable.ColumnCount = 1;
            this.statusTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.statusTable.Controls.Add(this.usageBox, 0, 0);
            this.statusTable.Controls.Add(this.detailsBox, 0, 1);
            this.statusTable.Controls.Add(this.tableLayoutPanel1, 0, 2);
            this.statusTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusTable.Location = new System.Drawing.Point(3, 3);
            this.statusTable.Name = "statusTable";
            this.statusTable.RowCount = 3;
            this.statusTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.statusTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.statusTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.statusTable.Size = new System.Drawing.Size(413, 175);
            this.statusTable.TabIndex = 14;
            // 
            // usageBox
            // 
            this.usageBox.Controls.Add(this.usageTable);
            this.usageBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.usageBox.Location = new System.Drawing.Point(3, 3);
            this.usageBox.Name = "usageBox";
            this.usageBox.Size = new System.Drawing.Size(407, 64);
            this.usageBox.TabIndex = 13;
            this.usageBox.TabStop = false;
            this.usageBox.Text = "Usage";
            // 
            // usageTable
            // 
            this.usageTable.ColumnCount = 2;
            this.usageTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.usageTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.usageTable.Controls.Add(this.usage, 0, 0);
            this.usageTable.Controls.Add(this.usageBar, 0, 0);
            this.usageTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.usageTable.Location = new System.Drawing.Point(3, 16);
            this.usageTable.Name = "usageTable";
            this.usageTable.RowCount = 1;
            this.usageTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.usageTable.Size = new System.Drawing.Size(401, 45);
            this.usageTable.TabIndex = 0;
            // 
            // usage
            // 
            this.usage.AutoSize = true;
            this.usage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.usage.Location = new System.Drawing.Point(363, 0);
            this.usage.Name = "usage";
            this.usage.Size = new System.Drawing.Size(35, 45);
            this.usage.TabIndex = 24;
            this.usage.Text = "?";
            this.usage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // usageBar
            // 
            this.usageBar.AccessibleName = "";
            this.usageBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.usageBar.Location = new System.Drawing.Point(3, 3);
            this.usageBar.Name = "usageBar";
            this.usageBar.Size = new System.Drawing.Size(354, 39);
            this.usageBar.TabIndex = 23;
            // 
            // detailsBox
            // 
            this.detailsBox.Controls.Add(this.tableLayoutPanel2);
            this.detailsBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.detailsBox.Location = new System.Drawing.Point(3, 73);
            this.detailsBox.Name = "detailsBox";
            this.detailsBox.Size = new System.Drawing.Size(407, 46);
            this.detailsBox.TabIndex = 14;
            this.detailsBox.TabStop = false;
            this.detailsBox.Text = "Details";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.34F));
            this.tableLayoutPanel2.Controls.Add(this.download, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.upload, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.total, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(401, 27);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.check, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.exitButton, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 125);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(407, 47);
            this.tableLayoutPanel1.TabIndex = 15;
            // 
            // check
            // 
            this.check.Dock = System.Windows.Forms.DockStyle.Fill;
            this.check.Image = ((System.Drawing.Image)(resources.GetObject("check.Image")));
            this.check.Location = new System.Drawing.Point(3, 3);
            this.check.Name = "check";
            this.check.Size = new System.Drawing.Size(197, 41);
            this.check.TabIndex = 23;
            this.check.Text = "Reload";
            this.check.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.check.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.check.UseVisualStyleBackColor = true;
            // 
            // exitButton
            // 
            this.exitButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.exitButton.Image = ((System.Drawing.Image)(resources.GetObject("exitButton.Image")));
            this.exitButton.Location = new System.Drawing.Point(206, 3);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(198, 41);
            this.exitButton.TabIndex = 24;
            this.exitButton.Text = "Exit";
            this.exitButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.exitButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // optionsTab
            // 
            this.optionsTab.Controls.Add(this.optionsTable);
            this.optionsTab.Location = new System.Drawing.Point(4, 22);
            this.optionsTab.Name = "optionsTab";
            this.optionsTab.Padding = new System.Windows.Forms.Padding(3);
            this.optionsTab.Size = new System.Drawing.Size(419, 181);
            this.optionsTab.TabIndex = 1;
            this.optionsTab.Text = "Options";
            this.optionsTab.UseVisualStyleBackColor = true;
            // 
            // optionsTable
            // 
            this.optionsTable.ColumnCount = 1;
            this.optionsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.optionsTable.Controls.Add(this.autodetectCheckbox, 0, 2);
            this.optionsTable.Controls.Add(this.notifyCheckbox, 0, 3);
            this.optionsTable.Controls.Add(this.startupCheckbox, 0, 4);
            this.optionsTable.Controls.Add(this.optionsButtonsTable, 0, 5);
            this.optionsTable.Controls.Add(this.checkIntervalTable, 0, 0);
            this.optionsTable.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.optionsTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.optionsTable.Location = new System.Drawing.Point(3, 3);
            this.optionsTable.Name = "optionsTable";
            this.optionsTable.RowCount = 6;
            this.optionsTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.optionsTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.optionsTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.optionsTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.optionsTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.optionsTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.optionsTable.Size = new System.Drawing.Size(413, 175);
            this.optionsTable.TabIndex = 22;
            // 
            // autodetectCheckbox
            // 
            this.autodetectCheckbox.AutoSize = true;
            this.autodetectCheckbox.Location = new System.Drawing.Point(3, 55);
            this.autodetectCheckbox.Name = "autodetectCheckbox";
            this.autodetectCheckbox.Size = new System.Drawing.Size(195, 17);
            this.autodetectCheckbox.TabIndex = 18;
            this.autodetectCheckbox.Text = "Autodetect if connected to the SCN";
            this.autodetectCheckbox.UseVisualStyleBackColor = true;
            this.autodetectCheckbox.CheckedChanged += new System.EventHandler(this.autodetectCheckbox_CheckedChanged);
            // 
            // notifyCheckbox
            // 
            this.notifyCheckbox.AutoSize = true;
            this.notifyCheckbox.Location = new System.Drawing.Point(3, 78);
            this.notifyCheckbox.Name = "notifyCheckbox";
            this.notifyCheckbox.Size = new System.Drawing.Size(205, 17);
            this.notifyCheckbox.TabIndex = 19;
            this.notifyCheckbox.Text = "Notify when connected/disconnected";
            this.notifyCheckbox.UseVisualStyleBackColor = true;
            // 
            // optionsButtonsTable
            // 
            this.optionsButtonsTable.ColumnCount = 2;
            this.optionsButtonsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.optionsButtonsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.optionsButtonsTable.Controls.Add(this.saveSettings, 1, 0);
            this.optionsButtonsTable.Controls.Add(this.defaultSettings, 0, 0);
            this.optionsButtonsTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.optionsButtonsTable.Location = new System.Drawing.Point(3, 124);
            this.optionsButtonsTable.Name = "optionsButtonsTable";
            this.optionsButtonsTable.RowCount = 1;
            this.optionsButtonsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.optionsButtonsTable.Size = new System.Drawing.Size(407, 48);
            this.optionsButtonsTable.TabIndex = 20;
            // 
            // saveSettings
            // 
            this.saveSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveSettings.Location = new System.Drawing.Point(329, 22);
            this.saveSettings.Name = "saveSettings";
            this.saveSettings.Size = new System.Drawing.Size(75, 23);
            this.saveSettings.TabIndex = 20;
            this.saveSettings.Text = "OK";
            this.saveSettings.UseVisualStyleBackColor = true;
            this.saveSettings.Click += new System.EventHandler(this.saveSettings_Click);
            // 
            // defaultSettings
            // 
            this.defaultSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.defaultSettings.Location = new System.Drawing.Point(3, 22);
            this.defaultSettings.Name = "defaultSettings";
            this.defaultSettings.Size = new System.Drawing.Size(101, 23);
            this.defaultSettings.TabIndex = 21;
            this.defaultSettings.Text = "Back to defaults";
            this.defaultSettings.UseVisualStyleBackColor = true;
            this.defaultSettings.Click += new System.EventHandler(this.defaultSettings_Click);
            // 
            // checkIntervalTable
            // 
            this.checkIntervalTable.ColumnCount = 3;
            this.checkIntervalTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.checkIntervalTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.checkIntervalTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.checkIntervalTable.Controls.Add(this.checkIntervalField, 0, 0);
            this.checkIntervalTable.Controls.Add(this.checkIntervalLabel, 0, 0);
            this.checkIntervalTable.Controls.Add(this.label1, 2, 0);
            this.checkIntervalTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkIntervalTable.Location = new System.Drawing.Point(3, 3);
            this.checkIntervalTable.Name = "checkIntervalTable";
            this.checkIntervalTable.RowCount = 1;
            this.checkIntervalTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.checkIntervalTable.Size = new System.Drawing.Size(407, 20);
            this.checkIntervalTable.TabIndex = 21;
            // 
            // checkIntervalField
            // 
            this.checkIntervalField.Location = new System.Drawing.Point(134, 3);
            this.checkIntervalField.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.checkIntervalField.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.checkIntervalField.Name = "checkIntervalField";
            this.checkIntervalField.Size = new System.Drawing.Size(67, 20);
            this.checkIntervalField.TabIndex = 20;
            this.checkIntervalField.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // checkIntervalLabel
            // 
            this.checkIntervalLabel.AutoSize = true;
            this.checkIntervalLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkIntervalLabel.Location = new System.Drawing.Point(3, 0);
            this.checkIntervalLabel.Name = "checkIntervalLabel";
            this.checkIntervalLabel.Size = new System.Drawing.Size(125, 20);
            this.checkIntervalLabel.TabIndex = 19;
            this.checkIntervalLabel.Text = "Check your usage every:";
            this.checkIntervalLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(207, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 20);
            this.label1.TabIndex = 21;
            this.label1.Text = "minutes";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.Controls.Add(this.warningThresholdField, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.warningThresholdLabel, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 29);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(407, 20);
            this.tableLayoutPanel3.TabIndex = 22;
            // 
            // warningThresholdField
            // 
            this.warningThresholdField.Location = new System.Drawing.Point(105, 3);
            this.warningThresholdField.Name = "warningThresholdField";
            this.warningThresholdField.Size = new System.Drawing.Size(67, 20);
            this.warningThresholdField.TabIndex = 23;
            // 
            // warningThresholdLabel
            // 
            this.warningThresholdLabel.AutoSize = true;
            this.warningThresholdLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.warningThresholdLabel.Location = new System.Drawing.Point(3, 0);
            this.warningThresholdLabel.Name = "warningThresholdLabel";
            this.warningThresholdLabel.Size = new System.Drawing.Size(96, 20);
            this.warningThresholdLabel.TabIndex = 22;
            this.warningThresholdLabel.Text = "Warning threshold:";
            this.warningThresholdLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(178, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "%";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 207);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MainWindow";
            this.ShowInTaskbar = false;
            this.Text = "SCN Monitor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Shown += new System.EventHandler(this.MainWindow_Shown);
            this.menu.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.statusTab.ResumeLayout(false);
            this.statusTable.ResumeLayout(false);
            this.usageBox.ResumeLayout(false);
            this.usageTable.ResumeLayout(false);
            this.usageTable.PerformLayout();
            this.detailsBox.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.optionsTab.ResumeLayout(false);
            this.optionsTable.ResumeLayout(false);
            this.optionsTable.PerformLayout();
            this.optionsButtonsTable.ResumeLayout(false);
            this.checkIntervalTable.ResumeLayout(false);
            this.checkIntervalTable.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkIntervalField)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.warningThresholdField)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label download;
        private System.Windows.Forms.Label upload;
        private System.Windows.Forms.Label total;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem downloadedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uploadedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem totalToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.CheckBox startupCheckbox;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage statusTab;
        private System.Windows.Forms.TabPage optionsTab;
        private System.Windows.Forms.CheckBox notifyCheckbox;
        private System.Windows.Forms.CheckBox autodetectCheckbox;
        private System.Windows.Forms.Button saveSettings;
        private System.Windows.Forms.Button defaultSettings;
        private System.Windows.Forms.GroupBox usageBox;
        private System.Windows.Forms.TableLayoutPanel statusTable;
        private System.Windows.Forms.GroupBox detailsBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel usageTable;
        private System.Windows.Forms.ProgressBar usageBar;
        private System.Windows.Forms.Label usage;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button check;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.TableLayoutPanel optionsTable;
        private System.Windows.Forms.TableLayoutPanel optionsButtonsTable;
        private System.Windows.Forms.TableLayoutPanel checkIntervalTable;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label warningThresholdLabel;
        private System.Windows.Forms.NumericUpDown warningThresholdField;
        private System.Windows.Forms.Label checkIntervalLabel;
        private System.Windows.Forms.NumericUpDown checkIntervalField;
    }
}

