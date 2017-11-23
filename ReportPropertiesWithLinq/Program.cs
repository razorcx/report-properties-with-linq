using System;
using System.Diagnostics;

namespace ReportPropertiesWithLinq
{
	public class Program
	{
		public static void Main(string[] args)
		{
			try
			{
				new ReportPropertiesWithLinqExample().Run();
			}
			catch (Exception ex)
			{
				Trace.WriteLine(ex.InnerException + ex.Message + ex.StackTrace);
			}
		}
	}
}
