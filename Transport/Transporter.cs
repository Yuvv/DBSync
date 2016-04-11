using DBOps;
using FileParser;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Timers;

namespace Transport
{
	class Transporter
	{
		private MsSqlOps localConn;
		private MsSqlOps remoteConn;
		private DataSet tables;

		public Timer timer;

		private IniFile ini;
		private StreamWriter wLog;

		private Dictionary<string, int> lastIDs;
		private bool ldbConnected = false;
		private bool rdbConnected = false;

		public Transporter()
		{
			// init files
			this.ini = new IniFile("Config.ini");
			//FileInfo fi = new FileInfo("Transporter.log");
			//if (fi.Length > 20 * 1024 * 1024)
			//{
			//	fi.MoveTo(string.Format("Transporter-{0}.log", DateTime.Now.ToString()));
			//}
			this.wLog = new StreamWriter("Transporter.log", true);
			this.wLog.AutoFlush = true;

			// init database connection
			this.localConn = new MsSqlOps(getConnStr("LocalDBConnection"));
			this.ldbConnected = true;
			this.log("Local database connected!");
			this.remoteConn = new MsSqlOps(getConnStr("RemoteDBConnection"));
			this.rdbConnected = true;
			this.log("Remote database connected!");

			// init tables;
			this.tables = Tables.GetTables();

			// init last syncID
			this.lastIDs = new Dictionary<string, int>();
			foreach (string tableName in Tables.TableNames)
			{
				this.lastIDs[tableName] = this.ini.ReadInteger("LastID", tableName, 0);
			}

			// init timer
			this.timer = new Timer();
			this.timer.Interval = this.ini.ReadInteger("SyncConfig", "Cycle", 5) * 1000;
			this.timer.Elapsed += new ElapsedEventHandler(this.timerCallback);
		}

		public void close()
		{
			this.wLog.WriteLine("Now closing...");
			this.wLog.Close();
			if (this.ldbConnected)
			{
				this.localConn.close();
			}
			if (this.rdbConnected)
			{
				this.remoteConn.close();
				this.timer.Stop();
				this.timer.Dispose();
			}
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
				var port = this.ini.ReadString(section, "Port", "1433");
				var uid = this.ini.ReadString(section, "UID", "sa");
				var pw = this.ini.ReadString(section, "PW", "sa");
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
			Console.WriteLine(logStr);
			this.wLog.WriteLine(string.Format("[{0}] {1}", DateTime.Now.ToString(), logStr));
		}

		public int getLastID(string tableName)
		{
			var currentID = this.lastIDs[tableName];
			//object obj = this.localConn.scalar(
			//	string.Format("select ident_current('{0}')", tableName));

			// HACK: 使用trigger实现
			object obj = this.localConn.scalar(
				string.Format("select ident_current('trigger4{0}')", tableName));
			// HACKEND

			if (obj != null)
			{
				currentID = int.Parse(obj.ToString());
			}
			return currentID;
		}

		private bool getLocalRecords(string tableName, int lastID, int maxSize = 10)
		{
			var currentID = getLastID(tableName);
			if (lastID < currentID)
			{
				this.log("Detect changes in table " + tableName);

				//string sql = string.Format("select top {0} * from {1} where id>{2}",
				//	maxSize, tableName, lastID);
				//SqlDataAdapter adapter = this.localConn.select(sql);
				//adapter.Fill(this.tables, tableName);

				// HACK: 使用trigger实现
				string sql = string.Format("select top {0} pk from trigger4{1} where id>{2}",
					maxSize, tableName, lastID);
				SqlDataReader reader = this.localConn.query(sql);
				SqlDataAdapter adapter;
				//string pkname = reader.GetName(0);
				//Console.WriteLine("pkname: " + pkname);
				StringCollection pks = new StringCollection();
				while (reader.Read())
				{
					pks.Add(reader[0].ToString());
				}
				reader.Close();
				foreach (string pk in pks)
				{
					string sqll = string.Format("select * from {0} where id={1}", tableName, pk);
					adapter = this.localConn.select(sqll);
					adapter.Fill(this.tables, tableName);
				}
				// HACKEND

				this.log("Get " + this.tables.Tables[tableName].Rows.Count + " records.");

				// 更新lastID
				this.lastIDs[tableName] = (currentID - lastID > maxSize) ? (lastID + maxSize) : currentID;
				// 写回lastID
				this.ini.WriteInteger("LastID", tableName, this.lastIDs[tableName]);

				return true;
			}
			return false;
		}

		// 复制原数据集
		private DataSet getNewDateSet()
		{
			DataSet dataSet = Tables.GetTables();
			foreach (DataTable table in this.tables.Tables)
			{
				foreach (DataRow row in table.Rows)
				{
					dataSet.Tables[table.TableName].LoadDataRow(row.ItemArray, false);
				}
			}

			return dataSet;
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
			DataTable newTable = Tables.GetTableByName(this.tables.Tables[tableName].TableName);
			foreach (DataRow row in this.tables.Tables[tableName].Rows)
			{
				newTable.LoadDataRow(row.ItemArray, false);
			}

			return newTable;
		}

		// 计时器回调
		private void timerCallback(object source, ElapsedEventArgs e)
		{
			try
			{
				foreach (string tableName in Tables.TableNames)
				{
					// 按table进行更新，防止无数据更改仍旧进行更新
					if (getLocalRecords(tableName, this.lastIDs[tableName]))
					{
						this.log("Now sending data to remote host...");
						this.remoteConn.updateDateTable(getNewDataTable(tableName));
						this.log("Update to remote succeed!");
					}
				}
			}
			catch (Exception ex)
			{
				this.log(ex.ToString());
				this.timer.Close();
				StreamWriter sw = new StreamWriter("Error.log");
				sw.WriteLine(DateTime.Now.ToString());
				sw.WriteLine(ex.ToString());
				sw.Close();
			}

			//this.log("Now sending data to remote host...");
			//this.remoteConn.updateDataSet(getNewDateSet());
			//this.log("Update to remote succeed!");

			// 清空已经发送数据
			this.tables.Clear();
		}

		public void run()
		{
			this.log("Now start...");
			this.timer.Start();
		}
	}
}