using System;
using System.IO;

namespace Transport
{
	class Program
	{
		// CTRL-C 回调
		internal static void onConsoleClose(object sender, ConsoleCancelEventArgs e)
		{
			if (trans != null)
			{
				trans.log("User closed the window.");
				trans.close();
			}
		}

		static Transporter trans = null;

		static void Main(string[] args)
		{
			try
			{
				trans = new Transporter();
				trans.run();
				Console.CancelKeyPress += onConsoleClose;

				// 单线程方式只能主动退出
				Console.Title = "Press ESC to exit!";
				while (true)
				{
					if (!trans.timer.Enabled)
					{
						Console.WriteLine("Something seems wrong!");
						break;
					}
					if (Console.KeyAvailable)
					{
						var key = Console.ReadKey();
						if (key.Key == ConsoleKey.Escape)
						{
							trans.timer.Stop();
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
				if (trans != null)
				{
					trans.close();
				}
			}
		}
	}
}
