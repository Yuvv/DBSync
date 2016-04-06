namespace DBSyncServer
{
	partial class Server
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Server));
			this.logInfoBox = new System.Windows.Forms.TextBox();
			this.btnSaveConfig = new System.Windows.Forms.Button();
			this.syncCycle = new System.Windows.Forms.NumericUpDown();
			this.label10 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.tcpServerPort = new System.Windows.Forms.NumericUpDown();
			this.label9 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.tcpServerIP = new System.Windows.Forms.TextBox();
			this.dbGroupBox = new System.Windows.Forms.GroupBox();
			this.dbIP = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.dbPort = new System.Windows.Forms.NumericUpDown();
			this.password = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.userName = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.modeSql = new System.Windows.Forms.RadioButton();
			this.modeWin = new System.Windows.Forms.RadioButton();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.dbServerName = new System.Windows.Forms.TextBox();
			this.dbName = new System.Windows.Forms.TextBox();
			this.btnExit = new System.Windows.Forms.Button();
			this.btnLink = new System.Windows.Forms.Button();
			this.tips = new System.Windows.Forms.ToolTip(this.components);
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.showWinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.myNotify = new System.Windows.Forms.NotifyIcon(this.components);
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.syncCycle)).BeginInit();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.tcpServerPort)).BeginInit();
			this.dbGroupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dbPort)).BeginInit();
			this.contextMenuStrip1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// logInfoBox
			// 
			this.logInfoBox.BackColor = System.Drawing.SystemColors.Desktop;
			this.logInfoBox.ForeColor = System.Drawing.Color.LimeGreen;
			this.logInfoBox.Location = new System.Drawing.Point(12, 255);
			this.logInfoBox.Multiline = true;
			this.logInfoBox.Name = "logInfoBox";
			this.logInfoBox.ReadOnly = true;
			this.logInfoBox.Size = new System.Drawing.Size(539, 131);
			this.logInfoBox.TabIndex = 44;
			this.tips.SetToolTip(this.logInfoBox, "Log Info");
			// 
			// btnSaveConfig
			// 
			this.btnSaveConfig.Location = new System.Drawing.Point(466, 141);
			this.btnSaveConfig.Name = "btnSaveConfig";
			this.btnSaveConfig.Size = new System.Drawing.Size(75, 23);
			this.btnSaveConfig.TabIndex = 43;
			this.btnSaveConfig.Text = "保存配置";
			this.btnSaveConfig.UseVisualStyleBackColor = true;
			this.btnSaveConfig.Click += new System.EventHandler(this.btnSaveConfig_Click);
			// 
			// syncCycle
			// 
			this.syncCycle.Location = new System.Drawing.Point(314, 208);
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
			this.syncCycle.TabIndex = 42;
			this.tips.SetToolTip(this.syncCycle, "与TCP服务器同步的周期，单位为秒");
			this.syncCycle.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(255, 210);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(53, 12);
			this.label10.TabIndex = 41;
			this.label10.Text = "同步周期";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.tcpServerPort);
			this.groupBox2.Controls.Add(this.label9);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Controls.Add(this.tcpServerIP);
			this.groupBox2.Location = new System.Drawing.Point(249, 100);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(200, 100);
			this.groupBox2.TabIndex = 40;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "TCP服务器";
			// 
			// tcpServerPort
			// 
			this.tcpServerPort.Location = new System.Drawing.Point(65, 62);
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
			this.tcpServerPort.TabIndex = 26;
			this.tips.SetToolTip(this.tcpServerPort, "TCP服务器监听端口");
			this.tcpServerPort.Value = new decimal(new int[] {
            54321,
            0,
            0,
            0});
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(6, 64);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(53, 12);
			this.label9.TabIndex = 17;
			this.label9.Text = "监听端口";
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
			// tcpServerIP
			// 
			this.tcpServerIP.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
			this.tcpServerIP.Location = new System.Drawing.Point(65, 26);
			this.tcpServerIP.Name = "tcpServerIP";
			this.tcpServerIP.Size = new System.Drawing.Size(100, 21);
			this.tcpServerIP.TabIndex = 21;
			this.tcpServerIP.Text = "0.0.0.0";
			this.tips.SetToolTip(this.tcpServerIP, "TCP服务器监听IP，可写成主机名或点分十进制方式");
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
			this.dbGroupBox.Location = new System.Drawing.Point(30, 100);
			this.dbGroupBox.Name = "dbGroupBox";
			this.dbGroupBox.Size = new System.Drawing.Size(200, 129);
			this.dbGroupBox.TabIndex = 39;
			this.dbGroupBox.TabStop = false;
			this.dbGroupBox.Text = "数据库服务器";
			// 
			// dbIP
			// 
			this.dbIP.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
			this.dbIP.Location = new System.Drawing.Point(80, 20);
			this.dbIP.Name = "dbIP";
			this.dbIP.Size = new System.Drawing.Size(100, 21);
			this.dbIP.TabIndex = 20;
			this.tips.SetToolTip(this.dbIP, "数据库监听IP，可写成主机名或点分十进制方式");
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
			// dbPort
			// 
			this.dbPort.Location = new System.Drawing.Point(80, 47);
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
			this.tips.SetToolTip(this.dbPort, "数据库监听端口");
			this.dbPort.Value = new decimal(new int[] {
            1043,
            0,
            0,
            0});
			// 
			// password
			// 
			this.password.Location = new System.Drawing.Point(80, 101);
			this.password.Name = "password";
			this.password.PasswordChar = '*';
			this.password.Size = new System.Drawing.Size(100, 21);
			this.password.TabIndex = 19;
			this.tips.SetToolTip(this.password, "数据库登录密码");
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
			// userName
			// 
			this.userName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
			this.userName.Location = new System.Drawing.Point(80, 74);
			this.userName.Name = "userName";
			this.userName.Size = new System.Drawing.Size(100, 21);
			this.userName.TabIndex = 18;
			this.tips.SetToolTip(this.userName, "数据库登录用户名");
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
			// modeSql
			// 
			this.modeSql.AutoSize = true;
			this.modeSql.Checked = true;
			this.modeSql.Location = new System.Drawing.Point(32, 42);
			this.modeSql.Name = "modeSql";
			this.modeSql.Size = new System.Drawing.Size(125, 16);
			this.modeSql.TabIndex = 38;
			this.modeSql.TabStop = true;
			this.modeSql.Text = "SqlServer身份验证";
			this.modeSql.UseVisualStyleBackColor = true;
			this.modeSql.CheckedChanged += new System.EventHandler(this.modeSql_CheckedChanged);
			// 
			// modeWin
			// 
			this.modeWin.AutoSize = true;
			this.modeWin.Location = new System.Drawing.Point(32, 20);
			this.modeWin.Name = "modeWin";
			this.modeWin.Size = new System.Drawing.Size(113, 16);
			this.modeWin.TabIndex = 37;
			this.modeWin.Text = "Windows身份验证";
			this.modeWin.UseVisualStyleBackColor = true;
			this.modeWin.CheckedChanged += new System.EventHandler(this.modeWin_CheckedChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(247, 65);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(65, 12);
			this.label3.TabIndex = 36;
			this.label3.Text = "数据库名称";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(247, 37);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(65, 12);
			this.label2.TabIndex = 35;
			this.label2.Text = "服务器名称";
			// 
			// dbServerName
			// 
			this.dbServerName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
			this.dbServerName.Location = new System.Drawing.Point(318, 34);
			this.dbServerName.Name = "dbServerName";
			this.dbServerName.Size = new System.Drawing.Size(100, 21);
			this.dbServerName.TabIndex = 34;
			this.dbServerName.Text = "MSSQL";
			this.tips.SetToolTip(this.dbServerName, "数据库实例名称，默认实例为MSSQL（此时可写成 .），否则写成<主机名>\\<实例名>形式");
			// 
			// dbName
			// 
			this.dbName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
			this.dbName.Location = new System.Drawing.Point(318, 62);
			this.dbName.Name = "dbName";
			this.dbName.Size = new System.Drawing.Size(100, 21);
			this.dbName.TabIndex = 33;
			this.tips.SetToolTip(this.dbName, "要连接到的数据库");
			// 
			// btnExit
			// 
			this.btnExit.Location = new System.Drawing.Point(466, 170);
			this.btnExit.Name = "btnExit";
			this.btnExit.Size = new System.Drawing.Size(75, 23);
			this.btnExit.TabIndex = 31;
			this.btnExit.Text = "关闭";
			this.btnExit.UseVisualStyleBackColor = true;
			this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
			// 
			// btnLink
			// 
			this.btnLink.Location = new System.Drawing.Point(466, 112);
			this.btnLink.Name = "btnLink";
			this.btnLink.Size = new System.Drawing.Size(75, 23);
			this.btnLink.TabIndex = 30;
			this.btnLink.Text = "连接";
			this.btnLink.UseVisualStyleBackColor = true;
			this.btnLink.Click += new System.EventHandler(this.btnLink_Click);
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showWinToolStripMenuItem,
            this.exitToolStripMenuItem});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(153, 70);
			// 
			// showWinToolStripMenuItem
			// 
			this.showWinToolStripMenuItem.Name = "showWinToolStripMenuItem";
			this.showWinToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.showWinToolStripMenuItem.Text = "显示窗口";
			this.showWinToolStripMenuItem.Click += new System.EventHandler(this.showWinToolStripMenuItem_Click);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.exitToolStripMenuItem.Text = "退出";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// myNotify
			// 
			this.myNotify.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
			this.myNotify.BalloonTipText = "我是内容";
			this.myNotify.BalloonTipTitle = "标题";
			this.myNotify.ContextMenuStrip = this.contextMenuStrip1;
			this.myNotify.Icon = ((System.Drawing.Icon)(resources.GetObject("myNotify.Icon")));
			this.myNotify.Text = "DBSyncServer";
			this.myNotify.DoubleClick += new System.EventHandler(this.myNotify_DoubleClick);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.modeWin);
			this.groupBox1.Controls.Add(this.modeSql);
			this.groupBox1.Location = new System.Drawing.Point(30, 21);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(200, 64);
			this.groupBox1.TabIndex = 45;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "数据库连接验证方式";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(28, 240);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(53, 12);
			this.label1.TabIndex = 46;
			this.label1.Text = "日志信息";
			// 
			// Server
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(563, 395);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.groupBox1);
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
			this.MaximizeBox = false;
			this.Name = "Server";
			this.Text = "DBSyncServer";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Server_FormClosing);
			this.Load += new System.EventHandler(this.Server_Load);
			this.Resize += new System.EventHandler(this.Server_Resize);
			((System.ComponentModel.ISupportInitialize)(this.syncCycle)).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.tcpServerPort)).EndInit();
			this.dbGroupBox.ResumeLayout(false);
			this.dbGroupBox.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dbPort)).EndInit();
			this.contextMenuStrip1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnSaveConfig;
		private System.Windows.Forms.NumericUpDown syncCycle;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.NumericUpDown tcpServerPort;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox tcpServerIP;
		private System.Windows.Forms.GroupBox dbGroupBox;
		private System.Windows.Forms.TextBox dbIP;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.NumericUpDown dbPort;
		private System.Windows.Forms.TextBox password;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox userName;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.RadioButton modeSql;
		private System.Windows.Forms.RadioButton modeWin;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox dbServerName;
		private System.Windows.Forms.TextBox dbName;
		private System.Windows.Forms.Button btnExit;
		private System.Windows.Forms.Button btnLink;
		private System.Windows.Forms.ToolTip tips;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.NotifyIcon myNotify;
		private System.Windows.Forms.ToolStripMenuItem showWinToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox logInfoBox;
	}
}

