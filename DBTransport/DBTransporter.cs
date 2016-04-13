using DBOps;
using FileParser;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DBTransport
{
	public partial class DBTransporter : Form
	{
		private MsSqlOps localConn;
		private MsSqlOps remoteConn;
		private DataTable localTable;

		private IniFile ini;
		private Dictionary<string, int> lastIDs;
		private StringCollection tableNames;
		private Dictionary<string, int[]> backoffTime;

		private bool ldbConnected = false;
		private bool rdbConnected = false;

		public DBTransporter()
		{
			InitializeComponent();
		}

		public string getConnStr(bool islocal)
		{
			// 参数详见 https://msdn.microsoft.com/en-us/library/system.data.sqlclient.sqlconnection.connectionstring%28v=vs.110%29.aspx

			SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
			if (islocal)
			{
				if (this.lModeWin.Checked)
				{
					builder.Add("Data Source", this.ldbServerName.Text);
					builder.Add("Integrated Security", "SSPI");
				}
				else
				{
					builder.Add("Data Source", this.ldbIP.Text + "," + this.ldbPort.Value.ToString());
					builder.Add("User ID", this.lUserName.Text);
					builder.Add("Password", this.lPassword.Text);
					builder.Add("Network Library", "DBMSSOCN");
				}
				builder.Add("Initial Catalog", this.ldbName.Text);
			}
			else
			{
				if (this.rModeWin.Checked)
				{
					builder.Add("Data Source", this.rdbServerName.Text);
					builder.Add("Integrated Security", "SSPI");
				}
				else
				{
					builder.Add("Data Source", this.rdbIP.Text + "," + this.rdbPort.Value.ToString());
					builder.Add("User ID", this.rUserName.Text);
					builder.Add("Password", this.rPassword.Text);
					builder.Add("Network Library", "DBMSSOCN");
				}
				builder.Add("Initial Catalog", this.rdbName.Text);
			}

			return builder.ConnectionString;
		}

		public int getLastID(string tableName)
		{
			var currentID = this.lastIDs[tableName];
			object obj = this.localConn.scalar(
				string.Format("select ident_current('{0}')", tableName));
			if (obj != null)
			{
				currentID = int.Parse(obj.ToString());
			}
			return currentID;
		}

		private bool getLocalRecords(string tableName, int lastID, int maxSize = 50)
		{
			var currentID = getLastID(tableName);
			if (lastID < currentID)
			{
				this.log("Detect changes in table " + tableName);
				this.localTable = this.localConn.getTable(tableName);

				string sql = string.Format("select top {0} * from {1} where sysid>{2}",
					maxSize, tableName, lastID);
				SqlDataAdapter adapter = this.localConn.select(sql);
				adapter.Fill(this.localTable);
				adapter.Dispose();

				var rows = this.localTable.Rows.Count;
				this.log("Get " + rows + " records.");

				// 更新lastID
				if (rows < maxSize)
				{
					this.lastIDs[tableName] = currentID;
				}
				else
				{
					this.lastIDs[tableName] = (int)this.localTable.Rows[rows - 1]["SysId"];
				}

				return true;
			}
			else
			{
				// TODO: 关于退避时间的设计
				if (this.backoffTime[tableName][1] > 16)
				{
					this.backoffTime[tableName][0] = 0;
					this.backoffTime[tableName][1] = 2;
				}
				else
				{
					this.backoffTime[tableName][0] = this.backoffTime[tableName][1];
					this.backoffTime[tableName][1] *= 2;
				}
			}
			return false;
		}

		//// 复制原data set
		//private DataSet getNewDateSet()
		//{
		//	DataSet dataSet = Tables.GetTables();
		//	foreach (DataTable table in this.tables.Tables)
		//	{
		//		foreach (DataRow row in table.Rows)
		//		{
		//			dataSet.Tables[table.TableName].LoadDataRow(row.ItemArray, false);
		//		}
		//	}

		//	return dataSet;
		//}

		/// <summary>
		/// 复制原table
		/// </summary>
		/// <param name="tableName">需要获取的表名</param>
		/// <returns>返回新的复制的表</returns>
		private DataTable getNewDataTable(string tableName)
		{
			DataTable newTable = this.remoteConn.getTable(tableName);
			foreach (DataRow row in this.localTable.Rows)
			{
				newTable.LoadDataRow(row.ItemArray, false);
			}

			return newTable;
		}

		private void btnStart_Click(object sender, EventArgs e)
		{
			try
			{
				if (!this.rdbConnected)
				{
					if (!this.ldbConnected)
					{
						this.localConn = new MsSqlOps(getConnStr(true));
						this.ldbConnected = true;
						this.log("Local database connected!");
					}
					this.remoteConn = new MsSqlOps(getConnStr(false));
					this.rdbConnected = true;
					this.log("Remote database connected!");
					this.timer.Start();

					// 成功启动则使启动无效
					this.btnStart.Enabled = false;
					this.btnClose.Enabled = true;
				}
			}
			catch (SqlException ex)
			{
				this.log("Start link failed!");
				this.log(ex.Message);
			}
		}

		private void btnSaveConfig_Click(object sender, EventArgs e)
		{
			// save local configuration
			int lmode = this.lModeWin.Checked ? 0 : 1;
			this.ini.WriteInteger("LocalDBConnection", "Mode", lmode);
			this.ini.WriteString("LocalDBConnection", "Server", this.ldbServerName.Text);
			this.ini.WriteString("LocalDBConnection", "IP", this.ldbIP.Text);
			this.ini.WriteInteger("LocalDBConnection", "Port", (int)this.ldbPort.Value);
			this.ini.WriteString("LocalDBConnection", "UID", this.lUserName.Text);
			this.ini.WriteString("LocalDBConnection", "PW", this.lPassword.Text);
			this.ini.WriteString("LocalDBConnection", "DB", this.ldbName.Text);
			this.ini.WriteInteger("SyncConfig", "Cycle", (int)this.syncCycle.Value);

			// save remote configuration
			int rmode = this.rModeWin.Checked ? 0 : 1;
			this.ini.WriteInteger("RemoteDBConnection", "Mode", rmode);
			this.ini.WriteString("RemoteDBConnection", "Server", this.rdbServerName.Text);
			this.ini.WriteString("RemoteDBConnection", "IP", this.rdbIP.Text);
			this.ini.WriteInteger("RemoteDBConnection", "Port", (int)this.rdbPort.Value);
			this.ini.WriteString("RemoteDBConnection", "UID", this.rUserName.Text);
			this.ini.WriteString("RemoteDBConnection", "PW", this.rPassword.Text);
			this.ini.WriteString("RemoteDBConnection", "DB", this.rdbName.Text);

			// save sysnc cycle
			this.ini.WriteInteger("SyncConfig", "Cycle", (int)this.syncCycle.Value);
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			if (this.ldbConnected)
			{
				this.localConn.close();
				if (this.rdbConnected)
				{
					this.remoteConn.close();
					this.timer.Stop();
					this.timer.Dispose();
					this.rdbConnected = false;
					this.log("Remote database connection closed!");
					// 全部关闭成功则使启动有效
					this.btnStart.Enabled = true;
					this.btnClose.Enabled = false;
					this.log("Now you can start a new transportion.");
				}
				this.ldbConnected = false;
				this.log("Local database connection closed!");
			}
		}

		private void timer_Tick(object sender, EventArgs e)
		{
			foreach (string tableName in this.tableNames)
			{
				// TODO: 关于退避时间的设计
				if (this.backoffTime[tableName][0] > 0)
				{
					this.backoffTime[tableName][0] -= 1;
					continue;
				}
				if (getLocalRecords(tableName, this.lastIDs[tableName]))
				{
					// 按table进行更新，防止无数据更改仍旧进行更新
					this.log("Now sending data to remote host...");
					this.remoteConn.updateDateTable(getNewDataTable(tableName));
					this.log("Update to remote succeed!");
					// 写回lastID
					this.ini.WriteInteger("LastID", tableName, this.lastIDs[tableName]);
				}
			}

			//this.log("Now sending data to remote host...");
			//this.remoteConn.updateDataSet(getNewDateSet());
			//this.log("Update to remote succeed!");

			// 清空已经发送数据
			this.localTable.Clear();
		}

		private void log(string logStr)
		{
			this.infoLog.AppendText(logStr);
			this.infoLog.AppendText(Environment.NewLine);
			this.infoLog.ScrollToCaret();
		}

		// 载入窗口过程中加载配置初始化基本值
		private void DBTransport_Load(object sender, EventArgs e)
		{
			// load configuration
			this.ini = new IniFile("Config.ini");

			int lmode = this.ini.ReadInteger("LocalDBConnection", "Mode", 1);
			if (0 == lmode)
			{
				this.lModeWin.Checked = true;
				this.ldbGroupBox.Enabled = false;
				this.ldbServerName.Text = this.ini.ReadString("LocalDBConnection", "Server", ".");
			}
			else
			{
				this.lModeSql.Checked = true;
				this.ldbServerName.Enabled = false;
				this.ldbIP.Text = this.ini.ReadString("LocalDBConnection", "IP", "127.0.0.1");
				this.ldbPort.Value = this.ini.ReadInteger("LocalDBConnection", "Port", 1433);
				this.lUserName.Text = this.ini.ReadString("LocalDBConnection", "UID", "sa");
				this.lPassword.Text = this.ini.ReadString("LocalDBConnection", "PW", "sa");
			}
			this.ldbName.Text = this.ini.ReadString("LocalDBConnection", "DB", "mydb");
			this.syncCycle.Value = this.ini.ReadInteger("SyncConfig", "Cycle", 5);

			int rmode = this.ini.ReadInteger("RemoteDBConnection", "Mode", 1);
			if (0 == rmode)
			{
				this.rModeWin.Checked = true;
				this.rdbGroupBox.Enabled = false;
				this.rdbServerName.Text = this.ini.ReadString("RemoteDBConnection", "Server", ".");
			}
			else
			{
				this.rModeSql.Checked = true;
				this.rdbServerName.Enabled = false;
				this.rdbIP.Text = this.ini.ReadString("RemoteDBConnection", "IP", "127.0.0.1");
				this.rdbPort.Value = this.ini.ReadInteger("RemoteDBConnection", "Port", 1433);
				this.rUserName.Text = this.ini.ReadString("RemoteDBConnection", "UID", "sa");
				this.rPassword.Text = this.ini.ReadString("RemoteDBConnection", "PW", "sa");
			}
			this.rdbName.Text = this.ini.ReadString("RemoteDBConnection", "DB", "tempdb");

			this.log("Load config succeed!");

			// init last syncID and back-off time
			this.tableNames = new StringCollection();
			this.ini.ReadSection("LastID", this.tableNames);
			this.lastIDs = new Dictionary<string, int>();
			this.backoffTime = new Dictionary<string, int[]>();
			foreach (string tableName in this.tableNames)
			{
				this.lastIDs[tableName] = this.ini.ReadInteger("LastID", tableName, 0);
				this.backoffTime[tableName] = new int[2] { 0, 2 };
			}
			this.log("Last sync ID loaded!");

			// init timer
			this.timer.Interval = this.ini.ReadInteger("SyncConfig", "Cycle", 5) * 1000;
		}

		private void DBTransport_Resize(object sender, EventArgs e)
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

		private void DBTransport_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (this.rdbConnected)
			{
				if (MessageBox.Show(
				"是否确认退出程序？", "退出",
				MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
				{
					e.Cancel = true;
					return;
				}
			}
			btnClose_Click(sender, e);
		}

		private void lModeWin_CheckedChanged(object sender, EventArgs e)
		{
			if (this.lModeWin.Checked)
			{
				this.ldbGroupBox.Enabled = false;
				this.ldbServerName.Enabled = true;
			}
			else
			{
				this.ldbGroupBox.Enabled = true;
				this.ldbServerName.Enabled = false;
			}
		}

		private void rModeWin_CheckedChanged(object sender, EventArgs e)
		{
			if (this.rModeWin.Checked)
			{
				this.rdbGroupBox.Enabled = false;
				this.rdbServerName.Enabled = true;
			}
			else
			{
				this.rdbGroupBox.Enabled = true;
				this.rdbServerName.Enabled = false;
			}
		}

		private void showWinToolStripMenuItem_Click(object sender, EventArgs e)
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

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void myNotify_DoubleClick(object sender, EventArgs e)
		{
			showWinToolStripMenuItem_Click(sender, e);
		}
	}
}