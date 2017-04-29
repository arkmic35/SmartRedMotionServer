using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SmartRedMotion_Serwer
{
	class Debug
	{
		static string AdresDocelowy = Environment.ExpandEnvironmentVariables("%programdata%/srmserver.txt");

		public static void PrzechwycBlad(object wysylacz, UnhandledExceptionEventArgs arg)
		{
			Debug.Blad((Exception)arg.ExceptionObject);
		}

		public static void Blad(Exception blad)
		{
			StreamWriter zapis = new StreamWriter(AdresDocelowy, true);
			zapis.WriteLine(blad.ToString());
			zapis.WriteLine("");
			zapis.Close();

			MessageBox.Show("Wystąpił błąd programu. Program zostanie zamknięty.\nProszę o poinformowanie opiekuna pracowni.", "SmartRedMotion Serwer");
			Application.Exit();
			Environment.Exit(0);
		}
	}
}
