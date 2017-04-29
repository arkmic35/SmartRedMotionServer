using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SmartRedMotion_Serwer
{
	static class Program
	{
		public static bool CichyRozruch = false;
		public static OknoGlowne OknoPierwsze;

		[STAThread]
		static void Main(string[] args)
		{
			AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(Debug.PrzechwycBlad);

			foreach (string arg in args)
			{
				if (arg == "-cicho")
				{
					CichyRozruch = true;
				}
			}

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			OknoPierwsze = new OknoGlowne();
			Application.Run(OknoPierwsze);
		}
	}
}
