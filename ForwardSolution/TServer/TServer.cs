using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;

namespace TServer
{
	class TServer
	{
		private TcpListener listener;
		private TcpClient sender;
		private TcpClient recver;

		private StreamWriter senderWriter, recverWriter;
		private StreamReader senderReader, recverReader;

		private StreamWriter wLog;
		private FileInfo fInfo;
		private System.Timers.Timer timer;

		public TServer(IPAddress ip, int port)
		{
			try
			{
				this.wLog = new StreamWriter("TServer.log", true);
				this.wLog.AutoFlush = true;
				this.fInfo = new FileInfo("TServer.log");
				this.listener = new TcpListener(ip, port);
				this.timer = new System.Timers.Timer();
				this.timer.Elapsed += new System.Timers.ElapsedEventHandler(this.timerTick);
				this.timer.Interval = 3600000;	// 1 hour.
				this.timer.Start();
			}
			catch (SocketException ex)
			{
				this.log("[ERROR] " + ex.Message);
				this.log("Please shutdown and restart!");
			}
		}

		private void Swap<T>(ref T a, ref T b)
		{
			T t = a;
			a = b;
			b = t;
		}

		public void log(string logStr)
		{
			Console.WriteLine(logStr);
			this.wLog.WriteLine(string.Format("[{0}] {1}", DateTime.Now.ToString(), logStr));
		}

		public void close()
		{
			if (this.listener != null)
			{
				this.listener.Stop();
			}
			this.wLog.Close();
			this.timer.Stop();
		}

		private void timerTick(object sender, EventArgs e)
		{
			if (this.fInfo.Length > 10 * 1024 * 1024)
			{
				this.wLog.Close();
				this.fInfo.MoveTo(string.Format("TServer-{0}.log", DateTime.Now.ToString("yyMMdd-HHmmss")));
				this.wLog = new StreamWriter("TServer.log", true);
				this.fInfo = new FileInfo("TServer.log");
				this.wLog.AutoFlush = true;
			}
		}

		private void transCallback()
		{
			try
			{
				this.senderReader = new StreamReader(this.sender.GetStream());
				this.senderWriter = new StreamWriter(this.sender.GetStream());
				this.recverReader = new StreamReader(this.recver.GetStream());
				this.recverWriter = new StreamWriter(this.recver.GetStream());
				string sstr = this.senderReader.ReadLine();
				string rstr = this.recverReader.ReadLine();
				if (rstr == "sender" && sstr == "recver")
				{
					this.Swap(ref this.recver, ref this.sender);
					this.Swap(ref this.recverReader, ref this.senderReader);
					this.Swap(ref this.recverWriter, ref this.senderWriter);
				}
				else if (rstr != "recver" || sstr != "sender")
				{
					// 非法类型连接
					this.recverWriter.WriteLine("88");
					this.senderWriter.WriteLine("88");
					this.log("Unknow link type.");
					this.recver.Close();
					this.sender.Close();
					return;
				}

				this.recverWriter.AutoFlush = true;
				this.senderWriter.AutoFlush = true;

				string transStr = string.Empty;
				this.senderWriter.WriteLine("OK");
				this.recverWriter.WriteLine("OK");
				while (true)
				{
					transStr = this.senderReader.ReadLine();
					if (!string.IsNullOrEmpty(transStr))
					{
						if (transStr == "88")
						{
							this.recverWriter.WriteLine("88");
							this.log("Client closed the connection!");
							break;
						}

						this.log(string.Format("Received {0} byte(s) data from sender.",
							transStr.Length));
						this.log("[data] [sender] " + transStr.Substring(0,
							(transStr.Length > 100) ? 100 : transStr.Length));
						this.log("Now sending data to recever...");
						this.recverWriter.WriteLine(transStr);
					}

					transStr = this.recverReader.ReadLine();
					if (!string.IsNullOrEmpty(transStr))
					{
						if (transStr == "88")
						{
							this.senderWriter.WriteLine("88");
							this.log("Client closed the connection!");
							break;
						}

						this.log(string.Format("Received {0} byte(s) data from recver.",
							transStr.Length));
						this.log("[data] [recver] " + transStr);
						this.log("Now sending data to sender...");
						this.senderWriter.WriteLine(transStr);
					}
				}
			}
			catch (Exception ex)
			{
				this.log("[ERROR] " + ex.Message);
			}
			finally
			{
				this.recver.Close();
				this.sender.Close();
			}
		}

		public void run()
		{
			this.listener.Start(2);
			this.log("TServer started!");

			List<TcpClient> clients = new List<TcpClient>(2);
			try
			{
				this.log("Waiting for sender & recver...");
				while (true)
				{
					clients.Add(this.listener.AcceptTcpClient());
					this.log("Accept a client from " + clients[clients.Count - 1].Client.LocalEndPoint);
					if (clients.Count == 2)
					{
						if (clients[0].Connected && clients[1].Connected)
						{
							this.sender = clients[0];
							this.sender.ReceiveTimeout = 10000;	// 10s超时时间
							this.recver = clients[1];
							this.recver.ReceiveTimeout = 10000;
							this.transCallback();
							clients.Clear();
							this.log("Now reListening...");
						}
					}
				}
			}
			catch (Exception ex)
			{
				this.log("[ERROR] " + ex.Message);
			}
		}
	}
}
