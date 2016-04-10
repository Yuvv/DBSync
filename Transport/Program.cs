using System;
using System.IO;

namespace Transport
{
	class Program
	{
		static void Main(string[] args)
		{
			Transporter trans = null;
			try
			{
				trans = new Transporter();
				trans.run();

				// 单线程方式只能主动退出
				Console.WriteLine("Press ESC twice to exit!");
				while (true)
				{
					var key1 = Console.ReadKey();
					var key2 = Console.ReadKey();
					if (key1.Key == ConsoleKey.Escape && key2.Key == ConsoleKey.Escape)
					{
						Console.WriteLine("Now exit...");
						break;
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
				if (trans != null)
				{
					trans.close();
				}
			}
		}
	}
}
