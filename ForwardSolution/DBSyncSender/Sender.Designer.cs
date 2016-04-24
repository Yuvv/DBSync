namespace DBSyncSender
{
	partial class Sender
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sender));
			this.btnLink = new System.Windows.Forms.Button();
			this.btnExit = new System.Windows.Forms.Button();
			this.dbName = new System.Windows.Forms.TextBox();
			this.dbPort = new System.Windows.Forms.NumericUpDown();
			this.dbServerName = new System.Windows.Forms.TextBox();
			this.timer = new System.Windows.Forms.Timer(this.components);
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.tips = new System.Windows.Forms.ToolTip(this.components);
			this.tcpServerIP = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.logInfoBox = new System.Windows.Forms.TextBox();
			this.tcpServerPort = new System.Windows.Forms.NumericUpDown();
			this.btnSaveConfig = new System.Windows.Forms.Button();
			this.modeWin = new System.Windows.Forms.RadioButton();
			this.modeSql = new System.Windows.Forms.RadioButton();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.userName = new System.Windows.Forms.TextBox();
			this.password = new System.Windows.Forms.TextBox();
			this.dbGroupBox = new System.Windows.Forms.GroupBox();
			this.dbIP = new System.Windows.Forms.TextBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.syncCycle = new System.Windows.Forms.NumericUpDown();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.showWinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.myNotify = new System.Windows.Forms.NotifyIcon(this.components);
			this.modeGroup = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.timerForLog = new System.Windows.Forms.Timer(this.components);
			((System.ComponentModel.ISupportInitialize)(this.dbPort)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tcpServerPort)).BeginInit();
			this.dbGroupBox.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.syncCycle)).BeginInit();
			this.contextMenuStrip1.SuspendLayout();
			this.modeGroup.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnLink
			// 
			this.btnLink.Location = new System.Drawing.Point(456, 133);
			this.btnLink.Name = "btnLink";
			this.btnLink.Size = new System.Drawing.Size(75, 23);
			this.btnLink.TabIndex = 12;
			this.btnLink.Text = "开始";
			this.tips.SetToolTip(this.btnLink, "开始同步，需recver在线才能开始传输数据");
			this.btnLink.UseVisualStyleBackColor = true;
			this.btnLink.Click += new System.EventHandler(this.btnLink_Click);
			// 
			// btnExit
			// 
			this.btnExit.Enabled = false;
			this.btnExit.Location = new System.Drawing.Point(456, 196);
			this.btnExit.Name = "btnExit";
			this.btnExit.Size = new System.Drawing.Size(75, 23);
			this.btnExit.TabIndex = 14;
			this.btnExit.Text = "停止";
			this.tips.SetToolTip(this.btnExit, "停止同步，同时会使recver停止");
			this.btnExit.UseVisualStyleBackColor = true;
			this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
			// 
			// dbName
			// 
			this.dbName.Location = new System.Drawing.Point(321, 50);
			this.dbName.Name = "dbName";
			this.dbName.Size = new System.Drawing.Size(100, 21);
			this.dbName.TabIndex = 8;
			// 
			// dbPort
			// 
			this.dbPort.Location = new System.Drawing.Point(80, 54);
			this.dbPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
			this.dbPort.Minimum = new decimal(new int[] {
            1025,
            0,
            0,
            0});
			this.dbPort.Name = "dbPort";
			this.dbPort.Size = new System.Drawing.Size(100, 21);
			this.dbPort.TabIndex = 4;
			this.dbPort.Value = new decimal(new int[] {
            1433,
            0,
            0,
            0});
			// 
			// dbServerName
			// 
			this.dbServerName.Enabled = false;
			this.dbServerName.Location = new System.Drawing.Point(321, 23);
			this.dbServerName.Name = "dbServerName";
			this.dbServerName.Size = new System.Drawing.Size(100, 21);
			this.dbServerName.TabIndex = 7;
			this.dbServerName.Text = ".";
			// 
			// timer
			// 
			this.timer.Interval = 5000;
			this.timer.Tick += new System.EventHandler(this.timer_Tick);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(250, 26);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(65, 12);
			this.label2.TabIndex = 8;
			this.label2.Text = "服务器名称";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(250, 56);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(65, 12);
			this.label3.TabIndex = 9;
			this.label3.Text = "数据库名称";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(10, 30);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(53, 12);
			this.label4.TabIndex = 10;
			this.label4.Text = "数据库IP";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(10, 56);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(53, 12);
			this.label5.TabIndex = 11;
			this.label5.Text = "监听端口";
			// 
			// tcpServerIP
			// 
			this.tcpServerIP.Location = new System.Drawing.Point(65, 26);
			this.tcpServerIP.Name = "tcpServerIP";
			this.tcpServerIP.Size = new System.Drawing.Size(100, 21);
			this.tcpServerIP.TabIndex = 9;
			this.tips.SetToolTip(this.tcpServerIP, "除非你知道你在做什么，否则不要更改！");
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(257, 193);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(53, 12);
			this.label10.TabIndex = 24;
			this.label10.Text = "同步周期";
			this.tips.SetToolTip(this.label10, "与服务器同步周期，单位为秒");
			// 
			// logInfoBox
			// 
			this.logInfoBox.BackColor = System.Drawing.SystemColors.WindowText;
			this.logInfoBox.ForeColor = System.Drawing.Color.Lime;
			this.logInfoBox.Location = new System.Drawing.Point(12, 242);
			this.logInfoBox.Multiline = true;
			this.logInfoBox.Name = "logInfoBox";
			this.logInfoBox.ReadOnly = true;
			this.logInfoBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.logInfoBox.Size = new System.Drawing.Size(519, 141);
			this.logInfoBox.TabIndex = 15;
			this.logInfoBox.TabStop = false;
			this.tips.SetToolTip(this.logInfoBox, "日志信息");
			// 
			// tcpServerPort
			// 
			this.tcpServerPort.Location = new System.Drawing.Point(65, 56);
			this.tcpServerPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
			this.tcpServerPort.Minimum = new decimal(new int[] {
            1025,
            0,
            0,
            0});
			this.tcpServerPort.Name = "tcpServerPort";
			this.tcpServerPort.Size = new System.Drawing.Size(100, 21);
			this.tcpServerPort.TabIndex = 10;
			this.tips.SetToolTip(this.tcpServerPort, "除非你知道你在做什么，否则不要更改！");
			this.tcpServerPort.Value = new decimal(new int[] {
            54321,
            0,
            0,
            0});
			// 
			// btnSaveConfig
			// 
			this.btnSaveConfig.Location = new System.Drawing.Point(456, 167);
			this.btnSaveConfig.Name = "btnSaveConfig";
			this.btnSaveConfig.Size = new System.Drawing.Size(75, 23);
			this.btnSaveConfig.TabIndex = 13;
			this.btnSaveConfig.Text = "保存配置";
			this.tips.SetToolTip(this.btnSaveConfig, "保存配置到文件");
			this.btnSaveConfig.UseVisualStyleBackColor = true;
			this.btnSaveConfig.Click += new System.EventHandler(this.btnSaveConfig_Click);
			// 
			// modeWin
			// 
			this.modeWin.AutoSize = true;
			this.modeWin.Location = new System.Drawing.Point(31, 20);
			this.modeWin.Name = "modeWin";
			this.modeWin.Size = new System.Drawing.Size(113, 16);
			this.modeWin.TabIndex = 1;
			this.modeWin.Text = "Windows身份验证";
			this.modeWin.UseVisualStyleBackColor = true;
			// 
			// modeSql
			// 
			this.modeSql.AutoSize = true;
			this.modeSql.Checked = true;
			this.modeSql.Location = new System.Drawing.Point(31, 42);
			this.modeSql.Name = "modeSql";
			this.modeSql.Size = new System.Drawing.Size(125, 16);
			this.modeSql.TabIndex = 2;
			this.modeSql.TabStop = true;
			this.modeSql.Text = "SqlServer身份验证";
			this.modeSql.UseVisualStyleBackColor = true;
			this.modeSql.CheckedChanged += new System.EventHandler(this.modeSql_CheckedChanged);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(6, 29);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(53, 12);
			this.label6.TabIndex = 14;
			this.label6.Text = "服务器IP";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(10, 79);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(41, 12);
			this.label7.TabIndex = 15;
			this.label7.Text = "用户名";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(10, 102);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(29, 12);
			this.label8.TabIndex = 16;
			this.label8.Text = "密码";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(6, 58);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(53, 12);
			this.label9.TabIndex = 17;
			this.label9.Text = "监听端口";
			// 
			// userName
			// 
			this.userName.Location = new System.Drawing.Point(80, 76);
			this.userName.Name = "userName";
			this.userName.Size = new System.Drawing.Size(100, 21);
			this.userName.TabIndex = 5;
			// 
			// password
			// 
			this.password.Location = new System.Drawing.Point(80, 99);
			this.password.Name = "password";
			this.password.PasswordChar = '*';
			this.password.Size = new System.Drawing.Size(100, 21);
			this.password.TabIndex = 6;
			// 
			// dbGroupBox
			// 
			this.dbGroupBox.Controls.Add(this.dbIP);
			this.dbGroupBox.Controls.Add(this.label4);
			this.dbGroupBox.Controls.Add(this.label5);
			this.dbGroupBox.Controls.Add(this.dbPort);
			this.dbGroupBox.Controls.Add(this.password);
			this.dbGroupBox.Controls.Add(this.label8);
			this.dbGroupBox.Controls.Add(this.userName);
			this.dbGroupBox.Controls.Add(this.label7);
			this.dbGroupBox.Location = new System.Drawing.Point(26, 91);
			this.dbGroupBox.Name = "dbGroupBox";
			this.dbGroupBox.Size = new System.Drawing.Size(188, 129);
			this.dbGroupBox.TabIndex = 22;
			this.dbGroupBox.TabStop = false;
			this.dbGroupBox.Text = "数据库服务器";
			// 
			// dbIP
			// 
			this.dbIP.Location = new System.Drawing.Point(80, 30);
			this.dbIP.Name = "dbIP";
			this.dbIP.Size = new System.Drawing.Size(100, 21);
			this.dbIP.TabIndex = 3;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.tcpServerPort);
			this.groupBox2.Controls.Add(this.label9);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Controls.Add(this.tcpServerIP);
			this.groupBox2.Location = new System.Drawing.Point(251, 91);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(186, 91);
			this.groupBox2.TabIndex = 23;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "TCP服务器";
			// 
			// syncCycle
			// 
			this.syncCycle.Location = new System.Drawing.Point(316, 191);
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
			this.syncCycle.TabIndex = 11;
			this.syncCycle.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
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
			this.myNotify.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
			this.myNotify.BalloonTipText = "DBSender将在后台运行，你可以在这里找到它！";
			this.myNotify.BalloonTipTitle = "注意";
			this.myNotify.ContextMenuStrip = this.contextMenuStrip1;
			this.myNotify.Icon = ((System.Drawing.Icon)(resources.GetObject("myNotify.Icon")));
			this.myNotify.Text = "DBSyncSender";
			this.myNotify.DoubleClick += new System.EventHandler(this.myNotify_DoubleClick);
			// 
			// modeGroup
			// 
			this.modeGroup.Controls.Add(this.modeWin);
			this.modeGroup.Controls.Add(this.modeSql);
			this.modeGroup.Location = new System.Drawing.Point(26, 12);
			this.modeGroup.Name = "modeGroup";
			this.modeGroup.Size = new System.Drawing.Size(188, 69);
			this.modeGroup.TabIndex = 30;
			this.modeGroup.TabStop = false;
			this.modeGroup.Text = "登录数据库验证方式";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(24, 227);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(53, 12);
			this.label1.TabIndex = 31;
			this.label1.Text = "日志信息";
			// 
			// timerForLog
			// 
			this.timerForLog.Enabled = true;
			this.timerForLog.Interval = 600000;
			this.timerForLog.Tick += new System.EventHandler(this.timerForLog_Tick);
			// 
			// Sender
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(544, 393);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.modeGroup);
			this.Controls.Add(this.logInfoBox);
			this.Controls.Add(this.btnSaveConfig);
			this.Controls.Add(this.syncCycle);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.dbGroupBox);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.dbServerName);
			this.Controls.Add(this.dbName);
			this.Controls.Add(this.btnExit);
			this.Controls.Add(this.btnLink);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "Sender";
			this.Text = "DBSyncSender";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Client_FormClosing);
			this.Load += new System.EventHandler(this.Client_Load);
			this.Resize += new System.EventHandler(this.Client_Resize);
			((System.ComponentModel.ISupportInitialize)(this.dbPort)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tcpServerPort)).EndInit();
			this.dbGroupBox.ResumeLayout(false);
			this.dbGroupBox.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.syncCycle)).EndInit();
			this.contextMenuStrip1.ResumeLayout(false);
			this.modeGroup.ResumeLayout(false);
			this.modeGroup.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnLink;
		private System.Windows.Forms.Button btnExit;
		private System.Windows.Forms.TextBox dbName;
		private System.Windows.Forms.NumericUpDown dbPort;
		private System.Windows.Forms.TextBox dbServerName;
		private System.Windows.Forms.Timer timer;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ToolTip tips;
		private System.Windows.Forms.RadioButton modeWin;
		private System.Windows.Forms.RadioButton modeSql;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox userName;
		private System.Windows.Forms.TextBox password;
		private System.Windows.Forms.TextBox tcpServerIP;
		private System.Windows.Forms.GroupBox dbGroupBox;
		private System.Windows.Forms.TextBox dbIP;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.NumericUpDown tcpServerPort;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.NumericUpDown syncCycle;
		private System.Windows.Forms.Button btnSaveConfig;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.NotifyIcon myNotify;
		private System.Windows.Forms.TextBox logInfoBox;
		private System.Windows.Forms.ToolStripMenuItem showWinToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.GroupBox modeGroup;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Timer timerForLog;
	}
}

