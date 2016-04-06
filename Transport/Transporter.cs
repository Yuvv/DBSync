using System;
using System.IO;
using System.Timers;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using DBOps;
using FileParser;

namespace Transport
{
	class Transporter
	{
		private MsSqlOps localConn;
		private MsSqlOps remoteConn;
		private DataSet tables;

		private Timer timer;

		private IniFile ini;
		private StreamWriter wLog;

		private Dictionary<string, int> lastIDs;

		public Transporter()
		{
			// init files
			this.ini = new IniFile("Config.ini");
			this.wLog = new StreamWriter("Transporter.log", true);

			// init timer
			this.timer = new Timer();
			this.timer.Interval = this.ini.ReadInteger("SyncConfig", "Cycle", 5) * 1000;
			this.timer.Elapsed += new ElapsedEventHandler(this.timerCallback);

			// init last syncID
			this.lastIDs = new Dictionary<string, int>();
			foreach (string tableName in Tables.TableNames)
			{
				this.lastIDs[tableName] = this.ini.ReadInteger("LastID", tableName, 0);
			}

			// init tables;
			this.tables = Tables.GetTables();

			// init database connection
			this.localConn = new MsSqlOps(getConnStr("LocalDBConnection"));
			this.remoteConn = new MsSqlOps(getConnStr("RemoteDBConnection"));
		}

		public void close()
		{
			this.wLog.Close();
			this.timer.Dispose();
			this.localConn.close();
			this.remoteConn.close();
		}

		public string getConnStr(string section)
		{
			// 参数详见 https://msdn.microsoft.com/en-us/library/system.data.sqlclient.sqlconnection.connectionstring%28v=vs.110%29.aspx

			SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

			var mode = this.ini.ReadInteger(section, "Mode", 1);
			if (0 == mode)
			{
				var server = this.ini.ReadString(section, "Server", ".");
				builder.Add("Data Source", server);
				builder.Add("Integrated Security", "SSPI");
			}
			else if (1 == mode)
			{
				var ip = this.ini.ReadString(section, "IP", "127.0.0.1");
				var port = this.ini.ReadString(section, "Port", "1043");
				var uid = this.ini.ReadString(section, "UID", "Administrator");
				var pw = this.ini.ReadString(section, "PW", "");
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

			var dbname = this.ini.ReadString(section, "DB", "");
			builder.Add("Initial Catalog", dbname);

			return builder.ConnectionString;
		}

		public void log(string logStr)
		{
			this.wLog.WriteLine(string.Format("[{0}] {1}", DateTime.Now.ToString(), logStr));
		}

		private void timerCallback(object source, ElapsedEventArgs e)
		{
			//
		}

		public void run()
		{
			this.timer.Start();
		}
	}
}
