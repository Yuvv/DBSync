using System;
using System.IO;

namespace SyncClient
{
	class Program
	{
		static void Main(string[] args)
		{
			Client client = null;
			try
			{
				client = new Client();
				client.start();

				// 单线程方式只能主动退出
				Console.WriteLine("Press ESC to exit!");
				while (true)
				{
					if (Console.KeyAvailable)
					{
						var key = Console.ReadKey();
						if (key.Key == ConsoleKey.Escape)
						{
							Console.WriteLine("Now exit...");
							break;
						}
					}
				}
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
				if(client!=null)
				{
				client.close();
				}
			}
		}
	}
}
