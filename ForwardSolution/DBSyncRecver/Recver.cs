using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using FileParser;
using DBOps;
using Newtonsoft.Json;

namespace DBSyncRecver
{
	public partial class Recver : Form
	{
		private TcpClient client;
		private Thread tcpThread;

		private MsSqlOps dbConn;

		private IniFile ini;

		private Dictionary<string, int> lastIDs;

		private bool dbConnected = false;
		private bool tcpConnected = false;

		public Recver()
		{
			InitializeComponent();
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

		// clientCallback作为后台线程，防止UI线程阻塞
		private void clientCallback()
		{
			NetworkStream stream2Client = this.client.GetStream();
			StreamReader reader = new StreamReader(stream2Client);
			StreamWriter writer = new StreamWriter(stream2Client);
			writer.AutoFlush = true;

			writer.WriteLine("recver");
			this.log("Waiting for sender to transport data...");
			string recvStr = string.Empty;
			try
			{
				recvStr = reader.ReadLine();
				if (string.IsNullOrEmpty(recvStr) || recvStr != "OK")
				{
					this.log("Something seems wrong! Please retry.");
					this.stopLink();
					return;
				}
				stream2Client.ReadTimeout = 30000;	// 30s超时时间
				while (true)
				{
					recvStr = reader.ReadLine();
					if (!string.IsNullOrEmpty(recvStr))
					{
						if (recvStr == "88")
						{
							this.log("Client closed the connection!");
							break;
						}
						try
						{
							this.log(string.Format("Received {0} byte(s) data.", recvStr.Length));
							DataSet dataSet = JsonConvert.DeserializeObject<DataSet>(recvStr);
							DataTable table = dataSet.Tables[0];

							var rowNum = table.Rows.Count;
							this.log(string.Format("Received {0} row(s) in table {1}.",
								rowNum, table.TableName));
							var maxID = int.Parse(dataSet.Tables[1].TableName);
							this.log("Last max ID is " + maxID);

							// 防止因为网络原因sender未收到回复而重发数据
							if (!this.lastIDs.ContainsKey(table.TableName) ||
								maxID > this.lastIDs[table.TableName])
							{
								this.dbConn.updateDataTable(table);
								this.lastIDs[table.TableName] = maxID;

							}
							else
							{
								maxID = this.lastIDs[table.TableName];
							}

							this.log("Update to database done. Now sending ACK to client...");
							writer.WriteLine(dataSet.Tables[0].TableName + ":" + maxID);
							// 释放资源
							dataSet.Dispose();
						}
						catch (Exception ex)
						{
							this.log("[ERROR] " + ex.Message);
							writer.WriteLine("ERROR:0");
						}
					}
					else
					{
						break;
					}
				}
				this.stopLink();
			}
			catch (ThreadAbortException)
			{
				this.log("Thread abort!");
				writer.WriteLine("88");
				this.log("Now dispose all resource in this tcp connection.");
				reader.Close();
				writer.Close();
				stream2Client.Close();
				this.client.Close();
			}
			catch (Exception ex)
			{
				this.log("[ERROR] " + ex.Message);
				this.client.Close();
				this.stopLink();
			}
		}

		// 给clientCallback线程执行exit函数的委托
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
			this.btnStart_Click(this, EventArgs.Empty);
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

		private void Server_Resize(object sender, EventArgs e)
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

		private void showWinToolStripMenuItem_Click(object sender, EventArgs e)
		{
			myNotify_DoubleClick(sender, e);
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnSaveConfig_Click(object sender, EventArgs e)
		{
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

			this.log("Configure write done!");
		}

		private void btnStart_Click(object sender, EventArgs e)
		{
			try
			{
				if (this.dbConnected == false)
				{
					// init mssql connection
					this.dbConn = new MsSqlOps(getConnStr());
					this.dbConnected = true;
					this.log("Connect to database succeed!");
				}

				// init tcp link
				var lIP = this.tcpServerIP.Text;
				var lPort = (int)this.tcpServerPort.Value;
				this.client = new TcpClient(lIP, lPort);
				this.tcpConnected = true;

				this.btnStart.Enabled = false;
				this.btnExit.Enabled = true;
				this.log("Connect to tcp server succeed!");

				// 新线程开启
				this.tcpThread = new Thread(this.clientCallback);
				this.tcpThread.IsBackground = true;
				this.tcpThread.Start();
			}
			catch (SqlException ex)
			{
				this.log("Link to database failed!");
				this.log(ex.Message);
			}
			catch (SocketException ex)
			{
				this.log("Open tcp listener failed!");
				this.log(ex.Message);
			}
			catch (Exception ex)
			{
				this.log(ex.Message);
			}
		}

		// 停止tcp线程，关闭数据库和tcp listener，
		private void btnExit_Click(object sender, EventArgs e)
		{
			if (this.tcpConnected)
			{
				if (this.dbConnected)
				{
					this.dbConn.close();
					this.dbConnected = false;
				}

				if (this.tcpThread.ThreadState != ThreadState.Unstarted)
				{
					this.tcpThread.Abort();
					this.log("TCP server thread closed!");
				}
				this.tcpConnected = false;

				this.log("Link closed!");
				this.log("Now you can link to database and tcp server again.");
			}

			this.btnStart.Enabled = true;
			this.btnExit.Enabled = false;

			// write last id back
			foreach (var item in this.lastIDs)
			{
				this.ini.WriteInteger("LastID", item.Key, item.Value);
			}
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

		private void Server_Load(object sender, EventArgs e)
		{
			this.ini = new IniFile("Config.ini");

			this.dbServerName.Text = ini.ReadString("DBConnection", "Server", ".");
			this.dbName.Text = this.ini.ReadString("DBConnection", "DB", "");
			this.dbIP.Text = this.ini.ReadString("DBConnection", "IP", "127.0.0.1");
			this.dbPort.Value = this.ini.ReadInteger("DBConnection", "Port", 1433);
			this.userName.Text = this.ini.ReadString("DBConnection", "UID", "Administrator");
			this.password.Text = this.ini.ReadString("DBConnection", "PW", "");
			this.tcpServerIP.Text = this.ini.ReadString("TCPServer", "IP", "127.0.0.1");
			this.tcpServerPort.Value = this.ini.ReadInteger("TCPServer", "Port", 54321);

			var mode = this.ini.ReadInteger("DBConnection", "Mode", 1);
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

			this.lastIDs = new Dictionary<string, int>();
			StringCollection names = new StringCollection();
			this.ini.ReadSection("LastID", names);
			foreach (var name in names)
			{
				lastIDs[name] = this.ini.ReadInteger("LastID", name, 0);
			}
			this.log("Load Last id done!");
		}

		private void Server_FormClosing(object sender, FormClosingEventArgs e)
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
				StreamWriter log = new StreamWriter("Recver.log", true);
				log.Write(this.logInfoBox.Text);
				log.Close();
			}
		}

		// 每10分钟检测日志长度是否超过5000行，超过则备份日志
		private void timerForLog_Tick(object sender, EventArgs e)
		{
			if (this.logInfoBox.Lines.Length > 5000)
			{
				StreamWriter log = new StreamWriter("Recver.log", true);
				log.Write(this.logInfoBox.Text);
				log.WriteLine("\n\n");
				log.Close();
				this.logInfoBox.Text = "";
			}
			FileInfo fInfo = new FileInfo("Recver.log");
			if (fInfo.Length > 10 * 1024 * 1024)
			{
				// 大于10MB进行归档
				fInfo.MoveTo(string.Format("Recver-{0}.log",
					DateTime.Now.ToString("yyMMdd-HHmmss")));
			}
		}
	}
}
