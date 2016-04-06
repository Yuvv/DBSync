using System;
using System.Collections.Generic;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Sockets;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using DBOps;
using FileParser;

namespace SyncServer
{
	class Server
	{
		private TcpListener listener;

		private MsSqlOps dbConn;

		private IniFile ini;
		private StreamWriter wLog;
		private Dictionary<string, int> lastIDs;

		public Server()
		{
			// init files
			this.ini = new IniFile("Config.ini");
			this.wLog = new StreamWriter("ServerSync.log", true);
			this.wLog.AutoFlush = true;

			// init last syncID
			this.lastIDs = new Dictionary<string, int>();
			foreach (string tableName in Tables.TableNames)
			{
				this.lastIDs[tableName] = this.ini.ReadInteger("LastID", tableName, 0);
			}

			// init local database connection
			this.dbConn = new MsSqlOps(getConnStr());

			// init tcp listener
			var lIP = this.ini.ReadString("TCPServer", "IP", "0.0.0.0");
			var lPort = this.ini.ReadInteger("TCPServer", "Port", 54321);
			this.listener = new TcpListener(IPAddress.Parse(lIP), lPort);
		}

		public void close()
		{
			// TODO: 对是否初始化进行检测，防出错
			this.log("Now closing...");
			this.writeIDsBack();
			this.wLog.Close();
			this.dbConn.close();
			this.listener.Stop();
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

		public void writeIDsBack()
		{
			foreach (string tableName in Tables.TableNames)
			{
				this.ini.WriteInteger("LastID", tableName, this.lastIDs[tableName]);
			}
		}

		private void clientCallback(TcpClient newClient)
		{
			TcpClient client = (TcpClient)newClient;
			NetworkStream stream2Client = client.GetStream();
			StreamReader reader = new StreamReader(stream2Client);
			StreamWriter writer = new StreamWriter(stream2Client);
			writer.AutoFlush = true;

			while (true)
			{
				string recvStr = reader.ReadLine();
				if (recvStr == "88")
				{
					this.log("Client closed the connection!");
					this.writeIDsBack();
					break;
				}
				if (!string.IsNullOrEmpty(recvStr))
				{
					this.log(string.Format("Received {0} byte(s) data.", recvStr.Length));
					DataSet dataSet = JsonConvert.DeserializeObject<DataSet>(recvStr);
					this.dbConn.update(dataSet);

					foreach (string tableName in Tables.TableNames)
					{
						//this.lastIDs[tableName] = getLastID(tableName);
						var rowNum = dataSet.Tables[tableName].Rows.Count;
						this.lastIDs[tableName] += rowNum;
						if (rowNum > 0)
						{
							this.log(string.Format(
								"Insert {0} record(s) into table {1}",
								rowNum, tableName));
						}
					}

					string myLastIDs = JsonConvert.SerializeObject(this.lastIDs);
					this.log("Now sending ACK to client...");
					writer.WriteLine(myLastIDs);
					// 释放资源
					dataSet.Dispose();
				}
			}
			client.Close();
		}

		public void startListen()
		{
			this.listener.Start();
			this.log("Server started!");

			while (true)
			{
				this.log("Waiting for a connection...");
				TcpClient newClient = this.listener.AcceptTcpClient();
				this.log("Accept a new client");

				// 一对一，不需要多线程方式
				this.clientCallback(newClient);

				// 多线程方式
				//Thread clientThread = new Thread(this.clientCallback);
				//clientThread.Start(newClient);
			}
		}
	}
}
