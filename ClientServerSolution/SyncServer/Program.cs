using System;
using System.IO;

namespace SyncServer
{
	class Program
	{
		static void Main(string[] args)
		{
			Server server = null;
			try
			{
				server = new Server();
				server.startListen();
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
				if (server != null)
				{
					server.close();
				}
			}
		}
	}
}
