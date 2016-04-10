using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using FileParser;
using DBOps;
using Newtonsoft.Json;
using System.IO;
using System.Net.Sockets;

namespace DBSyncClient
{
	public partial class Client : Form
	{
		private TcpClient client;
		private NetworkStream stream2Server;
		private StreamReader reader;
		private StreamWriter writer;

		private MsSqlOps dbConn;
		private DataSet tables;
		//private StreamWriter wLog;

		private Dictionary<string, int> lastIDs;
		private bool dbConnected = false;
		private bool tcpConnected = false;

		public Client()
		{
			InitializeComponent();
		}

		// 启动连接
		private void btnLink_Click(object sender, EventArgs e)
		{
			try
			{
				if (!this.dbConnected)
				{
					this.dbConn.connect(getConnStr());
					this.dbConnected = true;
					this.log("Connect to database succeed!");
				}
				// init tcp connection
				string addr = this.tcpServerIP.Text;
				int port = (int)this.tcpServerPort.Value;
				this.client = new TcpClient(addr, port);
				this.stream2Server = this.client.GetStream();
				this.reader = new StreamReader(this.stream2Server);
				this.writer = new StreamWriter(this.stream2Server);
				this.writer.AutoFlush = true;
				this.tcpConnected = true;
				this.log("Connect to tcp server succeed!");

				this.btnLink.Enabled = false;

				// 启动计时器
				this.log("Now starting...");
				this.timer.Start();
			}
			catch (SocketException ex)
			{
				MessageBox.Show("连接到tcp server失败！\n" + ex.Message);
				this.log(ex.Message);
			}
			catch (SqlException ex)
			{
				MessageBox.Show("连接到数据库失败！\n" + ex.Message);
				this.log(ex.Message);
			}
		}

		private string getConnStr()
		{
			// 参数详见 https://msdn.microsoft.com/en-us/library/system.data.sqlclient.sqlconnection.connectionstring%28v=vs.110%29.aspx

			SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

			if (this.modeWin.Checked)
			{
				var server = this.dbServerName.Text;
				builder.Add("Data Source", server);
				builder.Add("Integrated Security", "SSPI");
			}
			else
			{
				builder.Add("Data Source", this.dbIP.Text + "," + this.dbPort.Value.ToString());
				builder.Add("User ID", this.userName.Text);
				builder.Add("Password", this.password.Text);
				builder.Add("Network Library", "DBMSSOCN");
			}

			builder.Add("Initial Catalog", this.dbName.Text);

			return builder.ConnectionString;
		}

		private void log(string logStr)
		{
			//this.wLog.WriteLine(string.Format("[{0}] {1}", DateTime.Now.ToString(), logStr));
			this.logInfoBox.AppendText(logStr);
			this.logInfoBox.AppendText(Environment.NewLine);
			this.logInfoBox.ScrollToCaret();
		}

		private int getLastID(string tableName)
		{
			var currentID = this.lastIDs[tableName];
			object obj = this.dbConn.scalar(
				string.Format("select ident_current('{0}')", tableName));
			if (obj != null)
			{
				currentID = int.Parse(obj.ToString());
			}
			return currentID;
		}

		private void getRecords(string tableName, int lastID, int maxSize = 10)
		{
			var currentID = getLastID(tableName);
			if (lastID < currentID)
			{
				this.log("Detect changes in table " + tableName);

				string sql = string.Format("select top {0} * from {1} where id>{2}",
					maxSize, tableName, lastID);
				SqlDataAdapter adapter = this.dbConn.select(sql);
				adapter.Fill(this.tables, tableName);
				this.log("Get " + this.tables.Tables[tableName].Rows.Count + " records.");
			}
		}

		// 关闭连接
		private void btnExit_Click(object sender, EventArgs e)
		{
			IniFile ini = new IniFile("Config.ini");
			this.log("Now closing...");
			foreach (string tableName in Tables.TableNames)
			{
				ini.WriteInteger("LastID", tableName, this.lastIDs[tableName]);
			}
			if (this.dbConnected)
			{
				this.dbConn.close();
				this.dbConnected = false;
			}
			if (this.tcpConnected)
			{
				this.writer.WriteLine("88");		// 主动say 88
				this.timer.Stop();
				if (this.client.Client.Connected)
				{
					this.client.Close();
				}
				this.tcpConnected = false;
			}
			this.btnLink.Enabled = true;
		}

		// timer回调
		private void timer_Tick(object sender, EventArgs e)
		{
			foreach (string tableName in Tables.TableNames)
			{
				getRecords(tableName, this.lastIDs[tableName]);
			}

			var json = JsonConvert.SerializeObject(this.tables, Formatting.None);

			this.log("Now sending data to remote host...");
			this.writer.WriteLine(json);

			// 清空已经送数据
			this.tables.Clear();

			var resp = this.reader.ReadLine();
			if (!string.IsNullOrEmpty(resp))
			{
				this.log("Get response " + resp);
				this.lastIDs = JsonConvert.DeserializeObject<Dictionary<string, int>>(resp);
				// TODO: 哪种处理方式还有待考究
				//Dictionary<string, int>  remoteIDs = JsonConvert.DeserializeObject<Dictionary<string, int>>(resp);
				//foreach(string tableName in remoteIDs.Keys)
				//{
				//	if(remoteIDs[])
				//}
			}
		}

		// 启动时加载配置
		private void Client_Load(object sender, EventArgs e)
		{
			FileInfo fInfo = new FileInfo("Config.ini");
			if (!fInfo.Exists)
			{
				this.log("Missing configure file!");
				this.log("Now load default configures.");
			}
			IniFile ini = new IniFile("Config.ini");
			var mode = ini.ReadInteger("DBConnection", "Mode", 1);
			if (0 == mode)
			{
				this.dbServerName.Text = ini.ReadString("DBConnection", "Server", ".");
				this.dbGroupBox.Enabled = false;
				this.modeSql.Checked = false;
			}
			else
			{
				this.modeWin.Checked = false;
				this.dbServerName.Enabled = false;
				this.dbIP.Text = ini.ReadString("DBConnection", "IP", "127.0.0.1");
				this.dbPort.Value = ini.ReadInteger("DBConnection", "Port", 1043);
				this.userName.Text = ini.ReadString("DBConnection", "UID", "Administrator");
				this.password.Text = ini.ReadString("DBConnection", "PW", "");
			}

			this.dbName.Text = ini.ReadString("DBConnection", "DB", "");

			this.tcpServerIP.Text = ini.ReadString("TCPServer", "IP", "0.0.0.0");
			this.tcpServerPort.Value = ini.ReadInteger("TCPServer", "Port", 54321);
			this.syncCycle.Value = ini.ReadInteger("SyncConfig", "Cycle", 5);

			this.log("Load configure done!");

			// init last syncID
			this.lastIDs = new Dictionary<string, int>();
			foreach (string tableName in Tables.TableNames)
			{
				this.lastIDs[tableName] = ini.ReadInteger("LastID", tableName, 0);
			}
			this.log("Load last syncIDs done!");

			// init timer
			this.timer = new Timer();
			this.timer.Interval = (int)this.syncCycle.Value * 1000;

			// init mssql connection
			this.dbConn = new MsSqlOps();

			// init tables;
			this.tables = Tables.GetTables();
		}

		private void modeSql_CheckedChanged(object sender, EventArgs e)
		{
			if (this.modeSql.Checked)
			{
				this.dbGroupBox.Enabled = true;
				this.dbServerName.Enabled = false;
			}
			else
			{
				this.dbGroupBox.Enabled = false;
				this.dbServerName.Enabled = true;
			}
		}

		private void modeWin_CheckedChanged(object sender, EventArgs e)
		{
			this.modeSql_CheckedChanged(sender, e);
		}

		private void btnSaveConfig_Click(object sender, EventArgs e)
		{
			IniFile ini = new IniFile("Config.ini");
			if (this.modeWin.Checked)
			{
				ini.WriteInteger("DBConnection", "Mode", 0);
				ini.WriteString("DBConnection", "Server", this.dbServerName.Text);
			}
			else
			{
				ini.WriteInteger("DBConnection", "Mode", 1);
				ini.WriteString("DBConnection", "IP", this.dbIP.Text);
				ini.WriteInteger("DBConnection", "Port", (int)this.dbPort.Value);
				ini.WriteString("DBConnection", "UID", this.userName.Text);
				ini.WriteString("DBConnection", "PW", this.password.Text);
			}

			ini.WriteString("DBConnection", "DB", this.dbName.Text);

			ini.WriteString("TCPServer", "IP", this.tcpServerIP.Text);
			ini.WriteInteger("TCPServer", "Port", (int)this.tcpServerPort.Value);
			ini.WriteInteger("SyncConfig", "Cycle", (int)this.syncCycle.Value);

			// init last syncID
			foreach (string tableName in Tables.TableNames)
			{
				ini.WriteInteger("LastID", tableName, this.lastIDs[tableName]);
			}

			this.log("Configure write done!");
		}

		private void Client_Resize(object sender, EventArgs e)
		{
			if (this.WindowState == FormWindowState.Minimized)
			{
				this.WindowState = FormWindowState.Minimized;
				this.ShowInTaskbar = false;
				this.Hide();
				this.myNotify.Visible = true;
				this.myNotify.ShowBalloonTip(1000);
			}
		}

		private void myNotify_DoubleClick(object sender, EventArgs e)
		{
			if (this.ShowInTaskbar == false)
			{
				this.ShowInTaskbar = true;
				this.myNotify.Visible = false;
				this.Show();
				this.Activate();
				this.WindowState = FormWindowState.Normal;
			}
		}

		private void showWinToolStripMenuItem_Click(object sender, EventArgs e)
		{
			myNotify_DoubleClick(sender, e);
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			btnExit_Click(sender, e);
		}

		// 关闭连接并退出
		private void Client_FormClosing(object sender, FormClosingEventArgs e)
		{
			btnExit_Click(sender, e);
		}
	}
}
