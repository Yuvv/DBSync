using System;
using System.IO;
using System.Net;

namespace TServer
{
	class Program
	{
		static void Main(string[] args)
		{
			TServer ts = null;
			try
			{
				IPAddress ip = IPAddress.Parse("0.0.0.0");
				int port = 54321;
				if (args.Length > 0)
				{
					if (args[0].Contains(":"))
					{
						ip = IPAddress.Parse(args[0].Split(':')[0]);
						port = int.Parse(args[0].Split(':')[1]);
					}
					else if (args[0].Contains("."))
					{
						ip = IPAddress.Parse(args[0]);
					}
					else
					{
						port = int.Parse(args[0]);
					}
				}
				ts = new TServer(ip, port);
				ts.run();
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
				if (ts != null)
				{
					ts.close();
				}
			}
		}
	}
}
