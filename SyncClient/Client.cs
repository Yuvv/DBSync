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
		private DataSet tables;
		private IniFile ini;
		private StreamWriter wLog;

		private Dictionary<string, int> lastIDs;
		private bool dbConnected = false;
		private bool tcpConnected = false;

		private Timer timer;

		public Client()
		{
			// init files
			this.ini = new IniFile("Config.ini");
			this.wLog = new StreamWriter("ClientSync.log", true);
			this.wLog.AutoFlush = true;

			// init timer
			this.timer = new Timer();
			this.timer.Interval = this.ini.ReadInteger("SyncConfig", "Cycle", 5) * 1000;
			this.timer.Elapsed += new ElapsedEventHandler(this.timerCallback);

			// init mssql connection
			this.dbConn = new MsSqlOps(getConnStr());
			this.dbConnected = true;

			// init last syncID and tables
			this.lastIDs = new Dictionary<string, int>();
			this.tables = new DataSet();
			StringCollection tableNameKeys = new StringCollection();
			this.ini.ReadSection("LastID", tableNameKeys);
			foreach (string tableName in tableNameKeys)
			{
				this.lastIDs[tableName] = this.ini.ReadInteger("LastID", tableName, 0);
				DataTable table = this.dbConn.getTable(tableName);
				table.Clear();
				this.tables.Tables.Add(table);
			}

			#region 更改shecma获取方式为自动，此处暂废弃
			//foreach (string tableName in Tables.TableNames)
			//{
			//	this.lastIDs[tableName] = this.ini.ReadInteger("LastID", tableName, 0);
			//}

			// init tables;
			// this.tables = Tables.GetTables();
			#endregion

			// init tcp connection
			var addr = this.ini.ReadString("TCPServer", "IP", "localhost");
			var port = this.ini.ReadInteger("TCPServer", "Port", 1043);
			this.client = new TcpClient(addr, port);
			this.stream2Server = this.client.GetStream();
			this.reader = new StreamReader(this.stream2Server);
			this.writer = new StreamWriter(this.stream2Server);
			this.writer.AutoFlush = true;
			this.tcpConnected = true;
		}

		public void close()
		{
			this.log("Now closing...");
			if (this.dbConnected)
			{
				this.dbConn.close();
			}
			this.wLog.Close();
			if (this.tcpConnected)
			{
				this.writer.WriteLine("88");		// 主动say 88
				if (this.client.Client.Connected)
				{
					this.client.Close();
				}
				this.timer.Stop();
			}
			foreach (string tableName in Tables.TableNames)
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
				var port = this.ini.ReadString("DBConnection", "Port", "1043");
				var uid = this.ini.ReadString("DBConnection", "UID", "Administrator");
				var pw = this.ini.ReadString("DBConnection", "PW", "");
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

		private void timerCallback(object source, ElapsedEventArgs e)
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

		public void start()
		{
			this.log("Now starting...");
			this.timer.Start();
		}
	}
}
