using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Timers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data;
using DBOps;
using FileParser;
using System.Data.SqlClient;

namespace SyncClient
{
	class Client
	{
		private TcpClient client;
		private NetworkStream stream2Server;
		private StreamReader reader;
		private StreamWriter writer;

		private MsSqlOps dbConn;
		private DataTable localTable;
		private IniFile ini;
		private StreamWriter wLog;

		private Dictionary<string, int> lastIDs;
		private StringCollection tableNames;
		private Dictionary<string, int[]> backoffTime;
		private bool dbConnected = false;
		private bool tcpConnected = false;

		private Timer timer;

		public Client()
		{
			// init config file
			this.ini = new IniFile("Config.ini");

			// init mssql connection
			this.dbConn = new MsSqlOps(getConnStr());
			this.dbConnected = true;

			// init tcp connection
			var addr = this.ini.ReadString("TCPServer", "IP", "localhost");
			var port = this.ini.ReadInteger("TCPServer", "Port", 1433);
			this.client = new TcpClient(addr, port);
			this.stream2Server = this.client.GetStream();
			this.reader = new StreamReader(this.stream2Server);
			this.writer = new StreamWriter(this.stream2Server);
			this.writer.AutoFlush = true;
			this.tcpConnected = true;

			// init last syncID and tables
			this.tableNames = new StringCollection();
			this.ini.ReadSection("LastID", this.tableNames);
			this.lastIDs = new Dictionary<string, int>();
			this.backoffTime = new Dictionary<string, int[]>();
			foreach (string tableName in this.tableNames)
			{
				this.lastIDs[tableName] = this.ini.ReadInteger("LastID", tableName, 0);
				this.backoffTime[tableName] = new int[2] { 0, 2 };
			}

			// init log file
			this.wLog = new StreamWriter("ClientSync.log", true);
			this.wLog.AutoFlush = true;

			// init timer
			this.timer = new Timer();
			this.timer.Interval = this.ini.ReadInteger("SyncConfig", "Cycle", 5) * 1000;
			this.timer.Elapsed += new ElapsedEventHandler(this.timerCallback);
		}

		public void close()
		{
			this.log("Now closing...");
			if (this.dbConnected)
			{
				this.dbConn.close();
			}
			if (this.tcpConnected)
			{
				this.writer.WriteLine("88");		// 主动say 88
				if (this.client.Client.Connected)
				{
					this.client.Close();
				}
				this.timer.Stop();
				this.wLog.Close();
			}
			// write last ids back
			foreach (string tableName in this.tableNames)
			{
				this.ini.WriteInteger("LastID", tableName, this.lastIDs[tableName]);
			}
		}

		public string getConnStr()
		{
			// 参数详见 https://msdn.microsoft.com/en-us/library/system.data.sqlclient.sqlconnection.connectionstring%28v=vs.110%29.aspx

			SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

			var mode = this.ini.ReadInteger("DBConnection", "Mode", 1);
			if (0 == mode)
			{
				var server = this.ini.ReadString("DBConnection", "Server", ".");
				builder.Add("Data Source", server);
				builder.Add("Integrated Security", "SSPI");
			}
			else if (1 == mode)
			{
				var ip = this.ini.ReadString("DBConnection", "IP", "127.0.0.1");
				var port = this.ini.ReadString("DBConnection", "Port", "1433");
				var uid = this.ini.ReadString("DBConnection", "UID", "sa");
				var pw = this.ini.ReadString("DBConnection", "PW", "sa");
				builder.Add("Data Source", ip + "," + port);
				builder.Add("User ID", uid);
				builder.Add("Password", pw);
				builder.Add("Network Library", "DBMSSOCN");
			}
			else
			{
				this.log("Your setting mode=" + mode.ToString() + "is illegal!");
				return string.Empty;
			}

			var dbname = this.ini.ReadString("DBConnection", "DB", "");
			builder.Add("Initial Catalog", dbname);

			return builder.ConnectionString;
		}

		public void log(string logStr)
		{
			Console.WriteLine(logStr);
			this.wLog.WriteLine(string.Format("[{0}] {1}", DateTime.Now.ToString(), logStr));
		}

		public int getLastID(string tableName)
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

		private bool getRecords(string tableName, int lastID, int maxSize = 50)
		{
			var currentID = getLastID(tableName);
			if (lastID < currentID)
			{
				this.log("Detect changes in table " + tableName);
				this.localTable = this.dbConn.getTable(tableName);

				string sql = string.Format("select top {0} * from {1} where sysid>{2}",
					maxSize, tableName, lastID);
				SqlDataAdapter adapter = this.dbConn.select(sql);
				adapter.Fill(this.localTable);
				adapter.Dispose();

				var rows = this.localTable.Rows.Count;
				this.log("Get " + rows + " records.");

				// 更新lastID
				if (rows == 0)
				{
					this.lastIDs[tableName] = currentID;
				}
				//if (rows < maxSize)
				//{
				//	this.lastIDs[tableName] = currentID;
				//}
				//else
				//{
				//	this.lastIDs[tableName] = (int)this.localTable.Rows[rows - 1]["SysId"];
				//}

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
				return false;
			}
		}

		private void timerCallback(object source, ElapsedEventArgs e)
		{
			DataSet ds = new DataSet();
			string respStr = string.Empty;
			foreach (string tableName in this.tableNames)
			{
				// TODO: 关于退避时间的设计
				if (this.backoffTime[tableName][0] > 0)
				{
					this.backoffTime[tableName][0] -= 1;
					continue;
				}
				if (getRecords(tableName, this.lastIDs[tableName]))
				{
					ds.Tables.Add(this.localTable);
					var json = JsonConvert.SerializeObject(ds, Formatting.None);
					this.log("Now sending data to remote host...");
					this.writer.WriteLine(json);
					this.localTable.Dispose();

					respStr = this.reader.ReadLine();
					if (!string.IsNullOrEmpty(respStr))
					{
						string[] resp = respStr.Split(',');
						this.lastIDs[resp[0]] = int.Parse(resp[1]);
						// 写回lastID
						this.ini.WriteInteger("LastID", tableName, this.lastIDs[tableName]);
					}
				}
				ds.Clear();
			}
		}

		public void start()
		{
			this.log("Now starting...");
			this.timer.Start();
		}
	}
}
