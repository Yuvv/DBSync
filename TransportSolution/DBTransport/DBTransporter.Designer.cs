namespace DBTransport
{
	partial class DBTransporter
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DBTransporter));
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.showWinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.myNotify = new System.Windows.Forms.NotifyIcon(this.components);
			this.timer = new System.Windows.Forms.Timer(this.components);
			this.tips = new System.Windows.Forms.ToolTip(this.components);
			this.ldbIP = new System.Windows.Forms.TextBox();
			this.ldbPort = new System.Windows.Forms.NumericUpDown();
			this.lPassword = new System.Windows.Forms.TextBox();
			this.lUserName = new System.Windows.Forms.TextBox();
			this.ldbServerName = new System.Windows.Forms.TextBox();
			this.ldbName = new System.Windows.Forms.TextBox();
			this.rdbIP = new System.Windows.Forms.TextBox();
			this.rdbPort = new System.Windows.Forms.NumericUpDown();
			this.rPassword = new System.Windows.Forms.TextBox();
			this.rUserName = new System.Windows.Forms.TextBox();
			this.rdbName = new System.Windows.Forms.TextBox();
			this.rdbServerName = new System.Windows.Forms.TextBox();
			this.infoLog = new System.Windows.Forms.TextBox();
			this.labelLogInfo = new System.Windows.Forms.Label();
			this.btnStart = new System.Windows.Forms.Button();
			this.btnSaveConfig = new System.Windows.Forms.Button();
			this.btnClose = new System.Windows.Forms.Button();
			this.localModeGroupBox = new System.Windows.Forms.GroupBox();
			this.lModeWin = new System.Windows.Forms.RadioButton();
			this.lModeSql = new System.Windows.Forms.RadioButton();
			this.ldbGroupBox = new System.Windows.Forms.GroupBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.syncCycle = new System.Windows.Forms.NumericUpDown();
			this.label13 = new System.Windows.Forms.Label();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.rModeWin = new System.Windows.Forms.RadioButton();
			this.rModeSql = new System.Windows.Forms.RadioButton();
			this.label6 = new System.Windows.Forms.Label();
			this.rdbGroupBox = new System.Windows.Forms.GroupBox();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.contextMenuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ldbPort)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.rdbPort)).BeginInit();
			this.localModeGroupBox.SuspendLayout();
			this.ldbGroupBox.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.syncCycle)).BeginInit();
			this.tabPage2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.rdbGroupBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showWinToolStripMenuItem,
            this.exitToolStripMenuItem});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(125, 48);
			// 
			// showWinToolStripMenuItem
			// 
			this.showWinToolStripMenuItem.Name = "showWinToolStripMenuItem";
			this.showWinToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
			this.showWinToolStripMenuItem.Text = "显示窗口";
			this.showWinToolStripMenuItem.Click += new System.EventHandler(this.showWinToolStripMenuItem_Click);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
			this.exitToolStripMenuItem.Text = "退出";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// myNotify
			// 
			this.myNotify.BalloonTipText = "DBTransport将在后台运行！";
			this.myNotify.BalloonTipTitle = "注意";
			this.myNotify.ContextMenuStrip = this.contextMenuStrip1;
			this.myNotify.Icon = ((System.Drawing.Icon)(resources.GetObject("myNotify.Icon")));
			this.myNotify.Text = "DBTransport";
			this.myNotify.DoubleClick += new System.EventHandler(this.myNotify_DoubleClick);
			// 
			// timer
			// 
			this.timer.Interval = 5000;
			this.timer.Tick += new System.EventHandler(this.timer_Tick);
			// 
			// ldbIP
			// 
			this.ldbIP.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
			this.ldbIP.Location = new System.Drawing.Point(80, 20);
			this.ldbIP.Name = "ldbIP";
			this.ldbIP.Size = new System.Drawing.Size(100, 21);
			this.ldbIP.TabIndex = 20;
			this.tips.SetToolTip(this.ldbIP, "数据库监听IP，可写成主机名或点分十进制方式");
			// 
			// ldbPort
			// 
			this.ldbPort.Location = new System.Drawing.Point(80, 47);
			this.ldbPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
			this.ldbPort.Minimum = new decimal(new int[] {
            1025,
            0,
            0,
            0});
			this.ldbPort.Name = "ldbPort";
			this.ldbPort.Size = new System.Drawing.Size(100, 21);
			this.ldbPort.TabIndex = 4;
			this.tips.SetToolTip(this.ldbPort, "数据库监听端口");
			this.ldbPort.Value = new decimal(new int[] {
            1433,
            0,
            0,
            0});
			// 
			// lPassword
			// 
			this.lPassword.Location = new System.Drawing.Point(80, 101);
			this.lPassword.Name = "lPassword";
			this.lPassword.PasswordChar = '*';
			this.lPassword.Size = new System.Drawing.Size(100, 21);
			this.lPassword.TabIndex = 19;
			this.tips.SetToolTip(this.lPassword, "数据库登录密码");
			// 
			// lUserName
			// 
			this.lUserName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
			this.lUserName.Location = new System.Drawing.Point(80, 74);
			this.lUserName.Name = "lUserName";
			this.lUserName.Size = new System.Drawing.Size(100, 21);
			this.lUserName.TabIndex = 18;
			this.tips.SetToolTip(this.lUserName, "数据库登录用户名");
			// 
			// ldbServerName
			// 
			this.ldbServerName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
			this.ldbServerName.Location = new System.Drawing.Point(98, 99);
			this.ldbServerName.Name = "ldbServerName";
			this.ldbServerName.Size = new System.Drawing.Size(100, 21);
			this.ldbServerName.TabIndex = 49;
			this.ldbServerName.Text = ".";
			this.tips.SetToolTip(this.ldbServerName, "数据库实例名称，默认实例为MSSQL（此时可写成 .），否则写成<主机名>\\<实例名>形式");
			// 
			// ldbName
			// 
			this.ldbName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
			this.ldbName.Location = new System.Drawing.Point(98, 127);
			this.ldbName.Name = "ldbName";
			this.ldbName.Size = new System.Drawing.Size(100, 21);
			this.ldbName.TabIndex = 48;
			this.tips.SetToolTip(this.ldbName, "要连接到的数据库");
			// 
			// rdbIP
			// 
			this.rdbIP.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
			this.rdbIP.Location = new System.Drawing.Point(80, 20);
			this.rdbIP.Name = "rdbIP";
			this.rdbIP.Size = new System.Drawing.Size(100, 21);
			this.rdbIP.TabIndex = 20;
			this.tips.SetToolTip(this.rdbIP, "数据库监听IP，可写成主机名或点分十进制方式");
			// 
			// rdbPort
			// 
			this.rdbPort.Location = new System.Drawing.Point(80, 47);
			this.rdbPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
			this.rdbPort.Minimum = new decimal(new int[] {
            1025,
            0,
            0,
            0});
			this.rdbPort.Name = "rdbPort";
			this.rdbPort.Size = new System.Drawing.Size(100, 21);
			this.rdbPort.TabIndex = 4;
			this.tips.SetToolTip(this.rdbPort, "数据库监听端口");
			this.rdbPort.Value = new decimal(new int[] {
            1433,
            0,
            0,
            0});
			// 
			// rPassword
			// 
			this.rPassword.Location = new System.Drawing.Point(80, 101);
			this.rPassword.Name = "rPassword";
			this.rPassword.PasswordChar = '*';
			this.rPassword.Size = new System.Drawing.Size(100, 21);
			this.rPassword.TabIndex = 19;
			this.tips.SetToolTip(this.rPassword, "数据库登录密码");
			// 
			// rUserName
			// 
			this.rUserName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
			this.rUserName.Location = new System.Drawing.Point(80, 74);
			this.rUserName.Name = "rUserName";
			this.rUserName.Size = new System.Drawing.Size(100, 21);
			this.rUserName.TabIndex = 18;
			this.tips.SetToolTip(this.rUserName, "数据库登录用户名");
			// 
			// rdbName
			// 
			this.rdbName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
			this.rdbName.Location = new System.Drawing.Point(98, 127);
			this.rdbName.Name = "rdbName";
			this.rdbName.Size = new System.Drawing.Size(100, 21);
			this.rdbName.TabIndex = 54;
			this.tips.SetToolTip(this.rdbName, "要连接到的数据库");
			// 
			// rdbServerName
			// 
			this.rdbServerName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
			this.rdbServerName.Location = new System.Drawing.Point(98, 99);
			this.rdbServerName.Name = "rdbServerName";
			this.rdbServerName.Size = new System.Drawing.Size(100, 21);
			this.rdbServerName.TabIndex = 55;
			this.rdbServerName.Text = ".";
			this.tips.SetToolTip(this.rdbServerName, "数据库实例名称，默认实例为MSSQL（此时可写成 .），否则写成<主机名>\\<实例名>形式");
			// 
			// infoLog
			// 
			this.infoLog.BackColor = System.Drawing.SystemColors.WindowText;
			this.infoLog.ForeColor = System.Drawing.Color.LimeGreen;
			this.infoLog.Location = new System.Drawing.Point(12, 265);
			this.infoLog.Multiline = true;
			this.infoLog.Name = "infoLog";
			this.infoLog.ReadOnly = true;
			this.infoLog.Size = new System.Drawing.Size(557, 108);
			this.infoLog.TabIndex = 13;
			// 
			// labelLogInfo
			// 
			this.labelLogInfo.AutoSize = true;
			this.labelLogInfo.Location = new System.Drawing.Point(14, 242);
			this.labelLogInfo.Name = "labelLogInfo";
			this.labelLogInfo.Size = new System.Drawing.Size(53, 12);
			this.labelLogInfo.TabIndex = 14;
			this.labelLogInfo.Text = "日志信息";
			// 
			// btnStart
			// 
			this.btnStart.Location = new System.Drawing.Point(494, 152);
			this.btnStart.Name = "btnStart";
			this.btnStart.Size = new System.Drawing.Size(75, 23);
			this.btnStart.TabIndex = 15;
			this.btnStart.Text = "启动";
			this.btnStart.UseVisualStyleBackColor = true;
			this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
			// 
			// btnSaveConfig
			// 
			this.btnSaveConfig.Location = new System.Drawing.Point(494, 181);
			this.btnSaveConfig.Name = "btnSaveConfig";
			this.btnSaveConfig.Size = new System.Drawing.Size(75, 23);
			this.btnSaveConfig.TabIndex = 16;
			this.btnSaveConfig.Text = "保存配置";
			this.btnSaveConfig.UseVisualStyleBackColor = true;
			this.btnSaveConfig.Click += new System.EventHandler(this.btnSaveConfig_Click);
			// 
			// btnClose
			// 
			this.btnClose.Enabled = false;
			this.btnClose.Location = new System.Drawing.Point(494, 210);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(75, 23);
			this.btnClose.TabIndex = 17;
			this.btnClose.Text = "关闭";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// localModeGroupBox
			// 
			this.localModeGroupBox.Controls.Add(this.lModeWin);
			this.localModeGroupBox.Controls.Add(this.lModeSql);
			this.localModeGroupBox.Location = new System.Drawing.Point(17, 25);
			this.localModeGroupBox.Name = "localModeGroupBox";
			this.localModeGroupBox.Size = new System.Drawing.Size(201, 64);
			this.localModeGroupBox.TabIndex = 47;
			this.localModeGroupBox.TabStop = false;
			this.localModeGroupBox.Text = "数据库连接验证方式";
			// 
			// lModeWin
			// 
			this.lModeWin.AutoSize = true;
			this.lModeWin.Location = new System.Drawing.Point(32, 20);
			this.lModeWin.Name = "lModeWin";
			this.lModeWin.Size = new System.Drawing.Size(113, 16);
			this.lModeWin.TabIndex = 37;
			this.lModeWin.Text = "Windows身份验证";
			this.lModeWin.UseVisualStyleBackColor = true;
			this.lModeWin.CheckedChanged += new System.EventHandler(this.lModeWin_CheckedChanged);
			// 
			// lModeSql
			// 
			this.lModeSql.AutoSize = true;
			this.lModeSql.Checked = true;
			this.lModeSql.Location = new System.Drawing.Point(32, 42);
			this.lModeSql.Name = "lModeSql";
			this.lModeSql.Size = new System.Drawing.Size(125, 16);
			this.lModeSql.TabIndex = 38;
			this.lModeSql.TabStop = true;
			this.lModeSql.Text = "SqlServer身份验证";
			this.lModeSql.UseVisualStyleBackColor = true;
			// 
			// ldbGroupBox
			// 
			this.ldbGroupBox.Controls.Add(this.ldbIP);
			this.ldbGroupBox.Controls.Add(this.label4);
			this.ldbGroupBox.Controls.Add(this.label5);
			this.ldbGroupBox.Controls.Add(this.ldbPort);
			this.ldbGroupBox.Controls.Add(this.lPassword);
			this.ldbGroupBox.Controls.Add(this.label8);
			this.ldbGroupBox.Controls.Add(this.lUserName);
			this.ldbGroupBox.Controls.Add(this.label7);
			this.ldbGroupBox.Location = new System.Drawing.Point(244, 25);
			this.ldbGroupBox.Name = "ldbGroupBox";
			this.ldbGroupBox.Size = new System.Drawing.Size(200, 129);
			this.ldbGroupBox.TabIndex = 46;
			this.ldbGroupBox.TabStop = false;
			this.ldbGroupBox.Text = "数据库服务器";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(11, 23);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(53, 12);
			this.label4.TabIndex = 10;
			this.label4.Text = "数据库IP";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(10, 49);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(53, 12);
			this.label5.TabIndex = 11;
			this.label5.Text = "监听端口";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(34, 104);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(29, 12);
			this.label8.TabIndex = 16;
			this.label8.Text = "密码";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(22, 77);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(41, 12);
			this.label7.TabIndex = 15;
			this.label7.Text = "用户名";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(27, 130);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(65, 12);
			this.label3.TabIndex = 51;
			this.label3.Text = "数据库名称";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(27, 102);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(65, 12);
			this.label2.TabIndex = 50;
			this.label2.Text = "服务器名称";
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Location = new System.Drawing.Point(12, 12);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(476, 225);
			this.tabControl1.TabIndex = 52;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.syncCycle);
			this.tabPage1.Controls.Add(this.label13);
			this.tabPage1.Controls.Add(this.label2);
			this.tabPage1.Controls.Add(this.localModeGroupBox);
			this.tabPage1.Controls.Add(this.label3);
			this.tabPage1.Controls.Add(this.ldbGroupBox);
			this.tabPage1.Controls.Add(this.ldbName);
			this.tabPage1.Controls.Add(this.ldbServerName);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(468, 199);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "本地连接";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// syncCycle
			// 
			this.syncCycle.Location = new System.Drawing.Point(98, 157);
			this.syncCycle.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
			this.syncCycle.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.syncCycle.Name = "syncCycle";
			this.syncCycle.Size = new System.Drawing.Size(100, 21);
			this.syncCycle.TabIndex = 54;
			this.syncCycle.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(27, 159);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(53, 12);
			this.label13.TabIndex = 53;
			this.label13.Text = "同步周期";
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.label1);
			this.tabPage2.Controls.Add(this.groupBox1);
			this.tabPage2.Controls.Add(this.label6);
			this.tabPage2.Controls.Add(this.rdbGroupBox);
			this.tabPage2.Controls.Add(this.rdbName);
			this.tabPage2.Controls.Add(this.rdbServerName);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(468, 199);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "远程连接";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(27, 102);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(65, 12);
			this.label1.TabIndex = 56;
			this.label1.Text = "服务器名称";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.rModeWin);
			this.groupBox1.Controls.Add(this.rModeSql);
			this.groupBox1.Location = new System.Drawing.Point(17, 25);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(200, 64);
			this.groupBox1.TabIndex = 53;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "数据库连接验证方式";
			// 
			// rModeWin
			// 
			this.rModeWin.AutoSize = true;
			this.rModeWin.Location = new System.Drawing.Point(32, 20);
			this.rModeWin.Name = "rModeWin";
			this.rModeWin.Size = new System.Drawing.Size(113, 16);
			this.rModeWin.TabIndex = 37;
			this.rModeWin.Text = "Windows身份验证";
			this.rModeWin.UseVisualStyleBackColor = true;
			this.rModeWin.CheckedChanged += new System.EventHandler(this.rModeWin_CheckedChanged);
			// 
			// rModeSql
			// 
			this.rModeSql.AutoSize = true;
			this.rModeSql.Checked = true;
			this.rModeSql.Location = new System.Drawing.Point(32, 42);
			this.rModeSql.Name = "rModeSql";
			this.rModeSql.Size = new System.Drawing.Size(125, 16);
			this.rModeSql.TabIndex = 38;
			this.rModeSql.TabStop = true;
			this.rModeSql.Text = "SqlServer身份验证";
			this.rModeSql.UseVisualStyleBackColor = true;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(27, 130);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(65, 12);
			this.label6.TabIndex = 57;
			this.label6.Text = "数据库名称";
			// 
			// rdbGroupBox
			// 
			this.rdbGroupBox.Controls.Add(this.rdbIP);
			this.rdbGroupBox.Controls.Add(this.label9);
			this.rdbGroupBox.Controls.Add(this.label10);
			this.rdbGroupBox.Controls.Add(this.rdbPort);
			this.rdbGroupBox.Controls.Add(this.rPassword);
			this.rdbGroupBox.Controls.Add(this.label11);
			this.rdbGroupBox.Controls.Add(this.rUserName);
			this.rdbGroupBox.Controls.Add(this.label12);
			this.rdbGroupBox.Location = new System.Drawing.Point(244, 25);
			this.rdbGroupBox.Name = "rdbGroupBox";
			this.rdbGroupBox.Size = new System.Drawing.Size(200, 129);
			this.rdbGroupBox.TabIndex = 52;
			this.rdbGroupBox.TabStop = false;
			this.rdbGroupBox.Text = "数据库服务器";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(11, 23);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(53, 12);
			this.label9.TabIndex = 10;
			this.label9.Text = "数据库IP";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(10, 49);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(53, 12);
			this.label10.TabIndex = 11;
			this.label10.Text = "监听端口";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(34, 104);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(29, 12);
			this.label11.TabIndex = 16;
			this.label11.Text = "密码";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(22, 77);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(41, 12);
			this.label12.TabIndex = 15;
			this.label12.Text = "用户名";
			// 
			// DBTransporter
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(581, 384);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.btnSaveConfig);
			this.Controls.Add(this.btnStart);
			this.Controls.Add(this.labelLogInfo);
			this.Controls.Add(this.infoLog);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "DBTransporter";
			this.Text = "DBTransport";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DBTransport_FormClosing);
			this.Load += new System.EventHandler(this.DBTransport_Load);
			this.Resize += new System.EventHandler(this.DBTransport_Resize);
			this.contextMenuStrip1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.ldbPort)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.rdbPort)).EndInit();
			this.localModeGroupBox.ResumeLayout(false);
			this.localModeGroupBox.PerformLayout();
			this.ldbGroupBox.ResumeLayout(false);
			this.ldbGroupBox.PerformLayout();
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.syncCycle)).EndInit();
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.rdbGroupBox.ResumeLayout(false);
			this.rdbGroupBox.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem showWinToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.NotifyIcon myNotify;
		private System.Windows.Forms.Timer timer;
		private System.Windows.Forms.ToolTip tips;
		private System.Windows.Forms.TextBox infoLog;
		private System.Windows.Forms.Label labelLogInfo;
		private System.Windows.Forms.Button btnStart;
		private System.Windows.Forms.Button btnSaveConfig;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.GroupBox localModeGroupBox;
		private System.Windows.Forms.RadioButton lModeWin;
		private System.Windows.Forms.RadioButton lModeSql;
		private System.Windows.Forms.GroupBox ldbGroupBox;
		private System.Windows.Forms.TextBox ldbIP;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.NumericUpDown ldbPort;
		private System.Windows.Forms.TextBox lPassword;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox lUserName;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox ldbServerName;
		private System.Windows.Forms.TextBox ldbName;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton rModeWin;
		private System.Windows.Forms.RadioButton rModeSql;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.GroupBox rdbGroupBox;
		private System.Windows.Forms.TextBox rdbIP;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.NumericUpDown rdbPort;
		private System.Windows.Forms.TextBox rPassword;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox rUserName;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox rdbName;
		private System.Windows.Forms.TextBox rdbServerName;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.NumericUpDown syncCycle;
	}
}

