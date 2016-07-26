using System;
using System.Threading;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using FileParser;
using DBOps;
using Newtonsoft.Json;
using System.IO;
using System.Net.Sockets;

namespace DBSyncSender
{
	public partial class Sender : Form
	{
		private TcpClient client;
		private NetworkStream stream2Server;
		private StreamReader reader;
		private StreamWriter writer;

		private MsSqlOps dbConn;
		private DataTable localTable;

		private List<TableItem> tableItems;
		private bool dbConnected = false;
		private bool tcpConnected = false;

		private Thread waitThread;

		public Sender()
		{
			InitializeComponent();
		}

		private string getConnStr()
		{
			// 参数详见 https://msdn.microsoft.com/en-us/library/system.data.sqlclient.sqlconnection.connectionstring%28v=vs.110%29.aspx

			SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

			if (this.modeWin.Checked)
			{
				builder.Add("Data Source", this.dbServerName.Text);
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

		// 给其它线程操作日志的委托
		private delegate void logDelegate(string logStr);
		private void log(string logStr)
		{
			if (this.logInfoBox.InvokeRequired)
			{
				logDelegate logD = new logDelegate(log);
				this.BeginInvoke(logD, new object[] { logStr });
				return;
			}
			this.logInfoBox.AppendText(string.Format(
				"[{0}] {1}", DateTime.Now.ToLongTimeString(), logStr));
			this.logInfoBox.AppendText(Environment.NewLine);
			this.logInfoBox.ScrollToCaret();
		}

		private int getLastID(TableItem item)
		{
			var currentID = item.lastID;
			var realTableName = item.plusItem ? ("trigger4" + item.tableName) : item.tableName;

			object obj = this.dbConn.scalar(
				string.Format("select ident_current('{0}')", realTableName));
			if (obj != null)
			{
				currentID = int.Parse(obj.ToString());
			}

			return currentID;
		}

		private bool getRecords(TableItem item, int maxSize = 50)
		{
			var currentID = getLastID(item);
			var realTableName = item.plusItem ? ("trigger4" + item.tableName) : item.tableName;
			if (item.lastID < currentID)
			{
				this.log("Detect changes in table " + item.tableName);
				this.localTable = this.dbConn.getTable(realTableName);

				string sql = string.Format("select top {0} * from [{1}] where {2}>{3}",
					maxSize, realTableName, item.identColumn, item.lastID);
				SqlDataAdapter adapter = this.dbConn.select(sql);
				adapter.Fill(this.localTable);
				adapter.Dispose();

				var rows = this.localTable.Rows.Count;
				this.log("Get " + rows + " records.");

				// 更新lastID
				if (rows == 0)
				{
					item.lastID = currentID;
					return false;
				}

				return true;
			}
			else
			{
				if (item.backoffCycle > 16)
				{
					item.backoffTime = 0;
					item.backoffCycle = 2;
				}
				else
				{
					item.backoffTime = item.backoffCycle;
					item.backoffCycle *= 2;
				}
				return false;
			}
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
				this.btnExit.Enabled = true;

				// 新开wait线程防止UI线程阻塞
				this.waitThread = new Thread(this.startLink);
				this.waitThread.IsBackground = true;
				this.waitThread.Start();
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
			catch (Exception ex)
			{
				this.log(ex.Message);
			}
		}

		// 关闭连接
		private void btnExit_Click(object sender, EventArgs e)
		{
			this.log("Now stop synchrony...");
			if (this.dbConnected)
			{
				this.dbConn.close();
				this.dbConnected = false;
			}
			if (this.tcpConnected)
			{
				if (this.waitThread.ThreadState != ThreadState.Unstarted)
				{
					this.waitThread.Abort();
				}
				try
				{
					this.writer.WriteLine("88");		// 主动say 88
				}
				catch (Exception ex)
				{
					this.log("[ERROR] " + ex.Message);
				}
				this.timer.Stop();
				if (this.client.Client.Connected)
				{
					this.client.Close();
				}
				this.tcpConnected = false;
			}
			this.btnLink.Enabled = true;
			this.btnExit.Enabled = false;

			// write lastIDs back
			IniFile ini = new IniFile("Config.ini");
			foreach (var item in this.tableItems)
			{
				string sectionName = item.plusItem ? "LastIDPlus" : "LastID";
				ini.WriteString(sectionName, item.tableName,
					item.identColumn + "," + item.lastID.ToString());
			}
		}

		// 给其它线程执行exit函数的委托
		private delegate void clientDelegate();
		private void stopLink()
		{
			if (this.logInfoBox.InvokeRequired)
			{
				clientDelegate timerD = new clientDelegate(stopLink);
				this.BeginInvoke(timerD);
				return;
			}
			this.btnExit_Click(this, EventArgs.Empty);
			this.log("Now auto restart...");
			this.btnLink_Click(this, EventArgs.Empty);
		}

		// 等待recver临时线程
		private void startLink()
		{
			try
			{
				this.log("Waiting for start signal...");
				this.writer.WriteLine("sender");
				string signal = this.reader.ReadLine();
				if (string.IsNullOrEmpty(signal) || signal != "OK")
				{
					this.log("Link failed! Please restart.");
					this.stopLink();
				}
				else
				{
					// 启动计时器
					this.log("Now starting...");
					this.startTimer();
					this.client.ReceiveTimeout = 30000;		// 超时时间30s
				}
			}
			catch (ThreadAbortException)
			{
				this.log("Stop Waiting.");
			}
			catch (Exception ex)
			{
				this.log("[ERROR] " + ex.Message);
				this.stopLink();
			}
		}

		// 给startLink线程启动计时器的委托
		private delegate void timerDelegate();
		private void startTimer()
		{
			if (this.logInfoBox.InvokeRequired)
			{
				timerDelegate timerD = new timerDelegate(startTimer);
				this.BeginInvoke(timerD);
				return;
			}
			this.timer.Interval = (int)this.syncCycle.Value * 1000;
			this.timer.Start();
		}

		// timer回调
		private void timer_Tick(object sender, EventArgs e)
		{
			DataSet ds = new DataSet();
			string respStr = string.Empty;
			try
			{
				foreach (var item in this.tableItems)
				{
					if (item.backoffTime > 0)
					{
						this.log(item.tableName + " doesn't change. backoff time changed!");
						item.backoffTime -= 1;
						continue;
					}
					if (getRecords(item))
					{
						var maxid = this.localTable.Rows[this.localTable.Rows.Count - 1][item.identColumn].ToString();
						this.log(string.Format("Local max ID in table {0} is {1}.", item.tableName, maxid));
						if (item.plusItem)
						{
							this.localTable.Columns.Remove(item.identColumn);
							this.localTable.TableName = item.tableName;
						}
						ds.Tables.Add(this.localTable);
						ds.Tables.Add(new DataTable(maxid));
						var json = JsonConvert.SerializeObject(ds, Formatting.None);

						this.log("Now sending data to recver...");
						this.writer.WriteLine(json);
						this.localTable.Dispose();

						respStr = this.reader.ReadLine();
						if (!string.IsNullOrEmpty(respStr))
						{
							// recver关闭连接
							if (respStr == "88")
							{
								ds.Dispose();
								this.log("Recver closed!");
								this.stopLink();	// auto restart
								break;
							}
							this.log("response string is " + respStr);

							string[] resp = respStr.Split(':');
							if (resp.Length > 1 && resp[0] == item.tableName)
							{
								if (item.lastID < int.Parse(resp[1]))
								{
									item.lastID = int.Parse(resp[1]);
								}
							}
						}
					}
					ds.Tables.Clear();
					ds.Dispose();
				}
			}
			catch (Exception ex)
			{
				this.log("[ERROR] " + ex.Message);
				this.stopLink();
			}
		}

		// 启动时加载配置
		private void Client_Load(object sender, EventArgs e)
		{
			IniFile ini = new IniFile("Config.ini");
			this.dbServerName.Text = ini.ReadString("DBConnection", "Server", ".");
			this.dbName.Text = ini.ReadString("DBConnection", "DB", "");
			this.dbIP.Text = ini.ReadString("DBConnection", "IP", "127.0.0.1");
			this.dbPort.Value = ini.ReadInteger("DBConnection", "Port", 1433);
			this.userName.Text = ini.ReadString("DBConnection", "UID", "sa");
			this.password.Text = ini.ReadString("DBConnection", "PW", "sa");
			this.tcpServerIP.Text = ini.ReadString("TCPServer", "IP", "0.0.0.0");
			this.tcpServerPort.Value = ini.ReadInteger("TCPServer", "Port", 54321);
			this.syncCycle.Value = ini.ReadInteger("SyncConfig", "Cycle", 5);
			var mode = ini.ReadInteger("DBConnection", "Mode", 1);
			if (0 == mode)
			{
				this.modeSql.Checked = false;
				this.modeWin.Checked = true;
				this.dbGroupBox.Enabled = false;
			}
			else
			{
				this.modeSql.Checked = true;
				this.modeWin.Checked = false;
				this.dbServerName.Enabled = false;
			}
			this.log("Load configuration done!");

			// init last syncID and back-off time
			this.tableItems = new List<TableItem>();
			NameValueCollection values = new NameValueCollection();
			ini.ReadSectionValues("LastID", values);
			foreach (string key in values.Keys)
			{
				string col = values.Get(key).Split(',')[0];
				int id = int.Parse(values.Get(key).Split(',')[1]);
				this.tableItems.Add(new TableItem(key, col, id));
			}
			this.log("Load table items done!");

			// init last syncID plus and back-off time
			values.Clear();
			ini.ReadSectionValues("LastIDPlus", values);
			foreach (string key in values.Keys)
			{
				string col = values.Get(key).Split(',')[0];
				int id = int.Parse(values.Get(key).Split(',')[1]);
				this.tableItems.Add(new TableItem(key, col, id, true));
			}
			this.log("Load table items plus done!");

			// init mssql connection
			this.dbConn = new MsSqlOps();
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

		private void btnSaveConfig_Click(object sender, EventArgs e)
		{
			IniFile ini = new IniFile("Config.ini");
			var mode = (this.modeWin.Checked) ? 0 : 1;
			ini.WriteInteger("DBConnection", "Mode", mode);

			ini.WriteString("DBConnection", "Server", this.dbServerName.Text);
			ini.WriteString("DBConnection", "IP", this.dbIP.Text);
			ini.WriteInteger("DBConnection", "Port", (int)this.dbPort.Value);
			ini.WriteString("DBConnection", "UID", this.userName.Text);
			ini.WriteString("DBConnection", "PW", this.password.Text);

			ini.WriteString("DBConnection", "DB", this.dbName.Text);

			ini.WriteString("TCPServer", "IP", this.tcpServerIP.Text);
			ini.WriteInteger("TCPServer", "Port", (int)this.tcpServerPort.Value);
			ini.WriteInteger("SyncConfig", "Cycle", (int)this.syncCycle.Value);

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
			this.Close();
		}

		// 关闭连接并退出
		private void Client_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (this.tcpConnected)
			{
				MessageBox.Show(
					"与服务器的连接尚未关闭，请先关闭再退出！",
					"别乱关", MessageBoxButtons.OK);

				e.Cancel = true;
				return;
			}

			// 备份日志
			if (this.logInfoBox.Lines.Length > 0)
			{
				StreamWriter log = new StreamWriter("Sender.log", true);
				log.Write(this.logInfoBox.Text);
				log.Close();
			}
		}

		// 每10分钟检测日志长度是否超过5000行，超过则备份日志
		private void timerForLog_Tick(object sender, EventArgs e)
		{
			if (this.logInfoBox.Lines.Length > 5000)
			{
				StreamWriter log = new StreamWriter("Sender.log", true);
				log.Write(this.logInfoBox.Text);
				log.WriteLine("\n\n");
				log.Close();
				this.logInfoBox.Text = "";
			}
			FileInfo fInfo = new FileInfo("Sender.log");
			if (fInfo.Length > 10 * 1024 * 1024)
			{
				// 大于10MB进行归档
				fInfo.MoveTo(string.Format("Sender-{0}.log",
					DateTime.Now.ToString("yyMMdd-HHmmss")));
			}
		}
	}
}
