using System;
using System.IO;

namespace Transport
{
	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				Transporter trans = new Transporter();
				trans.run();
			}
			catch (Exception ex)
			{
				StreamWriter sw = new StreamWriter("Error.log");
				sw.WriteLine(DateTime.Now.ToString());
				sw.WriteLine(ex.ToString());
				sw.Close();
			}
			Console.Read();
		}
	}
}
