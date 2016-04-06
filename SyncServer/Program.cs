using System;
using System.IO;

namespace SyncServer
{
	class Program
	{
		static void Main(string[] args)
		{
			Server server = new Server();
			try
			{
				server.startListen();
				//server.test();
			}
			catch (Exception ex)
			{
				StreamWriter sw = new StreamWriter("Error.log");
				sw.WriteLine(DateTime.Now.ToString());
				sw.WriteLine(ex.ToString());
				sw.Close();
			}
			finally
			{
				server.close();
			}
		}
	}
}
