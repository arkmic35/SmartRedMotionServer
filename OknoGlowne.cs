using MetroFramework;
using MetroFramework.Forms;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Management;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace SmartRedMotion_Serwer
{
	public partial class OknoGlowne : MetroForm
	{
		string PlikKonfiguracji = "SmartRedMotion Serwer.cfg";
		bool BlokadaKonfiguracji;

		Icon IkonaBrakPolaczenia;
		Icon IkonaRuch;
		Icon IkonaBezruch;

		public OknoGlowne()
		{
			InitializeComponent();

			if (Program.CichyRozruch)
			{
				Zasobnik_UkryjOkno();
			}
		}

		//-=-=-=-=-=-=-=-=-=-=-=
		// Wydarzenia

		private void Form1_Load(object sender, EventArgs e)
		{
			//Wczytanie ikon
			Konfiguracja_WczytajIkony();

			//Przygotowanie zasobnika
			Zasobnik_UstawIkone(0);

			//Konfiguracja
			Konfiguracja_Wczytaj();

			Autostart_BlokadaWydarzenia = true;
			Pole_Autostart.Checked = Autostart_Sprawdz();
			Etykieta_Autostart.Text = Pole_Autostart.Checked ? "Włączony" : "Wyłączony";
			Autostart_BlokadaWydarzenia = false;

			//Próba połączenia
			Port_Polacz(true);
		}

		//-=-=-=-=-=-=-=-=-=-=-= KONFIGURACJA
		// Zmienne

		public static int[,] IP = new int[4, 2];

		// Wydarzenia

		private void Pole_CzasWylaczenia_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!(Char.IsDigit(e.KeyChar) || e.KeyChar == '\b'))
			{
				e.Handled = true;
				return;
			}
		}

		private void Pole_WylaczaneKomputery_TextChanged(object sender, EventArgs e)
		{
			Konfiguracja_ParsujIP();
			Konfiguracja_Zapisz();
		}

		private void Pole_WylaczTenKomputer_CheckedChanged(object sender, EventArgs e)
		{
			Konfiguracja_Zapisz();
		}

		private void Pole_CzasWylaczenia_TextChanged(object sender, EventArgs e)
		{
			if (String.IsNullOrEmpty(Pole_CzasWylaczenia.Text))
			{
				return;
			}

			Konfiguracja_Zapisz();

			int wartosc;
			int jednosci;
			int dziesiatki;

			wartosc = Convert.ToInt32(Pole_CzasWylaczenia.Text);
			jednosci = wartosc % 10;
			dziesiatki = ((wartosc % 100) - jednosci) / 10;

			if (wartosc == 1)
			{
				Etykieta_CzasWylaczeniaNapis.Text = "minuta bezruchu";
			}
			else if (dziesiatki != 1 && jednosci >= 2 && jednosci <= 4)
			{
				Etykieta_CzasWylaczeniaNapis.Text = "minuty bezruchu";
			}
			else
			{
				Etykieta_CzasWylaczeniaNapis.Text = "minut bezruchu";
			}

			if (Odliczanie_ZegarTrwa == true)
			{
				Odliczanie_ZatrzymajZegar();
				Odliczanie_RozpocznijZegar();
			}
		}

		// Procedury

		private void Konfiguracja_WczytajIkony()
		{
			Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
			IkonaBrakPolaczenia = new System.Drawing.Icon(assembly.GetManifestResourceStream("SmartRedMotion_Serwer.Resources.ikona_brakpolaczenia.ico"));
			IkonaRuch = new System.Drawing.Icon(assembly.GetManifestResourceStream("SmartRedMotion_Serwer.Resources.ikona_ruch.ico"));
			IkonaBezruch = new System.Drawing.Icon(assembly.GetManifestResourceStream("SmartRedMotion_Serwer.Resources.ikona_bezruch.ico"));
		}

		private void Konfiguracja_ParsujIP()
		{
			string txt = Pole_WylaczaneKomputery.Text;
			string[] czlony = txt.Split('.');
			int[,] ip = new int[4, 2];

			Array.Clear(IP, 0, 8);

			if (czlony.Length != 4)
			{
				Pole_WylaczaneKomputery.BackColor = Color.LightCoral;
				return;
			}

			int a, b;

			for (int i = 0; i < 4; i++)
			{
				if (czlony[i].Contains('-'))
				{
					string[] zakres = czlony[i].Split('-');

					if (zakres.Length == 2 && int.TryParse(zakres[0], out a) && int.TryParse(zakres[1], out b) && a >= 0 && a <= 255 && b >= 0 && b <= 255)
					{
						ip[i, 0] = a;
						ip[i, 1] = b;
					}
					else
					{
						Pole_WylaczaneKomputery.BackColor = Color.LightCoral;
						return;
					}
				}
				else
				{
					if (int.TryParse(czlony[i], out a) && a >= 0 && a <= 255)
					{
						ip[i, 0] = a;
						ip[i, 1] = a;
					}
					else
					{
						Pole_WylaczaneKomputery.BackColor = Color.LightCoral;
						return;
					}
				}
			}

			Pole_WylaczaneKomputery.BackColor = SystemColors.Control;
			IP = ip;
		}

		private void Konfiguracja_Wczytaj(bool WymusZapis = false)
		{
			BlokadaKonfiguracji = true;

			IsolatedStorageFile Magazyn;
			IsolatedStorageFileStream Strumien;
			StreamWriter Zapis;
			StreamReader Odczyt;

			Magazyn = IsolatedStorageFile.GetMachineStoreForAssembly();

			string[] pliki = Magazyn.GetFileNames(PlikKonfiguracji);

			if (pliki.Length == 0 || WymusZapis == true)
			{
				Strumien = new IsolatedStorageFileStream(PlikKonfiguracji, FileMode.Create, Magazyn);
				Zapis = new StreamWriter(Strumien);
				Zapis.WriteLine("10.1.56.1-15");
				Zapis.WriteLine("true");
				Zapis.WriteLine("20");
				Zapis.Close();
				Strumien.Close();
			}

			try
			{
				Strumien = new IsolatedStorageFileStream(PlikKonfiguracji, FileMode.Open, Magazyn);
				Odczyt = new StreamReader(Strumien);

				Pole_WylaczaneKomputery.Text = Odczyt.ReadLine();
				Pole_WylaczTenKomputer.Checked = Convert.ToBoolean(Odczyt.ReadLine());
				Pole_CzasWylaczenia.Text = Odczyt.ReadLine();

				Odczyt.Close();
				Strumien.Close();

				Magazyn.Close();

				Konfiguracja_ParsujIP();
			}
			catch (Exception)
			{
				Konfiguracja_Wczytaj(true);
			}

			BlokadaKonfiguracji = false;
		}

		private void Konfiguracja_Zapisz()
		{
			if (BlokadaKonfiguracji == true)
				return;

			IsolatedStorageFile Magazyn = IsolatedStorageFile.GetMachineStoreForAssembly();

			IsolatedStorageFileStream Strumien = new IsolatedStorageFileStream(PlikKonfiguracji, FileMode.Create, Magazyn);
			StreamWriter Zapis = new StreamWriter(Strumien);

			Zapis.WriteLine(Pole_WylaczaneKomputery.Text);
			Zapis.WriteLine(Pole_WylaczTenKomputer.Checked);
			Zapis.WriteLine(Pole_CzasWylaczenia.Text);

			Zapis.Close();
			Strumien.Close();

			Magazyn.Close();
		}

		private void Konfiguracja_Usun()
		{
			if (BlokadaKonfiguracji == true)
				return;

			IsolatedStorageFile Magazyn = IsolatedStorageFile.GetMachineStoreForAssembly();
			Magazyn.Remove();
			Magazyn.Close();
		}

		//-=-=-=-=-=-=-=-=-=-=-= ZASOBNIK
		// Zmienne

		bool Zasobnik_OknoWidoczne = true;

		// Wydarzenia

		private void OknoGlowne_Resize(object sender, EventArgs e)
		{
			if (WindowState == FormWindowState.Minimized)
			{
				Zasobnik_UkryjOkno();
			}
		}

		private void Zasobnik_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				Zasobnik_PrzelaczOkno();
			}
		}

		private void Wybor_OpcjaPokazOkno_Click(object sender, EventArgs e)
		{
			Zasobnik_PrzelaczOkno();
		}

		private void Wybor_OpcjaOdinstaluj_Click(object sender, EventArgs e)
		{
			Autostart_Ustaw(false);
			Konfiguracja_Usun();
			Close();
		}

		private void Wybor_OpcjaZamknij_Click(object sender, EventArgs e)
		{
			Close();
		}

		// Procedury

		private void Zasobnik_UkryjOkno()
		{
			Visible = false;
			ShowInTaskbar = false;
			WindowState = FormWindowState.Minimized;

			Zasobnik_OknoWidoczne = false;
			Wybor_OpcjaPokazOkno.Text = "Pokaż okno";
		}

		private void Zasobnik_PokazOkno()
		{
			Visible = true;
			ShowInTaskbar = true;
			WindowState = FormWindowState.Normal;

			BringToFront();
			Activate();

			Zasobnik_OknoWidoczne = true;
			Wybor_OpcjaPokazOkno.Text = "Ukryj okno";
		}

		private void Zasobnik_PrzelaczOkno()
		{
			if (Zasobnik_OknoWidoczne == true)
				Zasobnik_UkryjOkno();
			else
				Zasobnik_PokazOkno();
		}

		private void Zasobnik_UstawIkone(int ikona) //0 - brak połączenia; 1 - bezruch; 2 - ruch
		{
			switch (ikona)
			{
				case 0:
					{
						Zasobnik.Icon = IkonaBrakPolaczenia;
						Zasobnik.Text = "SmartRedMotion - brak połączenia";
						Etykieta_StanCzujnika.Text = "brak połączenia";
						break;
					}

				case 1:
					{
						Zasobnik.Icon = IkonaBezruch;
						Zasobnik.Text = "SmartRedMotion - brak ruchu";
						Etykieta_StanCzujnika.Text = "połączono, brak ruchu";
						break;
					}

				case 2:
					{
						Zasobnik.Icon = IkonaRuch;
						Zasobnik.Text = "SmartRedMotion - ruch";
						Etykieta_StanCzujnika.Text = "połączono, ruch";
						break;
					}
			}

			if (ikona == 1 && Odliczanie_ZegarTrwa == false)
			{
				Odliczanie_RozpocznijZegar();
			}

			if ((ikona == 2 || ikona == 0) && Odliczanie_ZegarTrwa == true)
			{
				Odliczanie_ZatrzymajZegar();
			}
		}

		//-=-=-=-=-=-=-=-=-=-=-= PORT
		// Zmienne

		private bool Port_Cicho = false;

		// Wydarzenia

		private void Przycisk_Polacz_Click(object sender, EventArgs e)
		{
			if (Serial_Uchwyt.IsOpen == false)
			{
				Port_Polacz();
			}
			else
			{
				Port_Rozlacz();
			}
		}

		private void Zegar_Laczenie_Tick(object sender, EventArgs e)
		{
			Port_BrakOdpowiedzi();
		}

		private void Serial_Uchwyt_ErrorReceived(object sender, System.IO.Ports.SerialErrorReceivedEventArgs e)
		{
			Port_Rozlacz();
			MetroMessageBox.Show(this, "Wystąpił błąd połączenia szeregowego.", "Problem", MessageBoxButtons.OK, MessageBoxIcon.Warning); //do sprawdzenia, czy działa podczas odpięcia portu USB
		}

		private void Serial_Uchwyt_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
		{
			string txt = "";

			try
			{
				txt = Serial_Uchwyt.ReadExisting();
			}
			catch (Exception)
			{
				Port_Rozlacz();
				MetroMessageBox.Show(this, "Wystąpił błąd połączenia szeregowego.", "Problem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}

			if (InvokeRequired)
			{
				Invoke((MethodInvoker)delegate
				{
					Port_OdebranaWiadomosc(txt);
				});
			}
			else
			{
				Port_OdebranaWiadomosc(txt);
			}
		}

		// Procedury

		private void Port_Polacz(bool cicho = false)
		{
			Port_Cicho = cicho;

			ManagementObjectCollection Urzadzenia = new ManagementObjectSearcher("Select * from Win32_SerialPort").Get();
			ManagementObject SRM_Board = null;

			foreach (ManagementObject Urzadzenie in Urzadzenia)
			{
				if ((Urzadzenie["Description"].ToString().Contains("SmartRedMotion") || Urzadzenie["Description"].ToString().Contains("Silicon"))) //TODO
				{
					SRM_Board = Urzadzenie;
					break;
				}
			}

			if (SRM_Board == null)
			{
				if (!Port_Cicho)
				{
					MetroMessageBox.Show(this, "Nie znaleziono urządzenia SmartRedMotion.\r\n\r\nMożliwości:\r\n- urządzenie jest niepodłączone\r\n- sterowniki są niezainstalowane", "Problem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
				return;
			}

			Przycisk_Polacz.Enabled = false;
			Przycisk_Polacz.Text = "Połącz";
			Etykieta_StanCzujnika.Text = "Łączenie...";
			Zasobnik_UstawIkone(0);

			try
			{
				Serial_Uchwyt.PortName = SRM_Board["DeviceID"].ToString();
				Serial_Uchwyt.Open();
				Zegar_Laczenie.Start();
			}
			catch (Exception)
			{
				Port_Rozlacz();

				if (!Port_Cicho)
				{
					MetroMessageBox.Show(this, "Wystąpił błąd połączenia z urządzeniem.", "Problem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
			}
		}

		private void Port_Rozlacz()
		{
			Przycisk_Polacz.Enabled = true;
			Przycisk_Polacz.Text = "Połącz";
			Etykieta_StanCzujnika.Text = "Brak połączenia";
			Zasobnik_UstawIkone(0);
			Zegar_Laczenie.Stop();
			Serial_Uchwyt.Close();
		}

		private void Port_BrakOdpowiedzi()
		{
			Port_Rozlacz();

			if (!Port_Cicho)
			{
				MetroMessageBox.Show(this, "Nie rozpoznano urządzenia.", "Problem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		private void Port_OdpowiedzOK()
		{
			Przycisk_Polacz.Enabled = true;
			Przycisk_Polacz.Text = "Rozłącz";
			Etykieta_StanCzujnika.Text = "połączono";

			Zegar_Laczenie.Stop();
		}

		private void Port_OdebranaWiadomosc(string wiadomosc)
		{
			if (wiadomosc.Contains("B"))
			{
				if (Zegar_Laczenie.Enabled == true)
				{
					Port_OdpowiedzOK();
				}

				Zasobnik_UstawIkone(1);
			}
			else if (wiadomosc.Contains("R"))
			{
				if (Zegar_Laczenie.Enabled == true)
				{
					Port_OdpowiedzOK();
				}

				Zasobnik_UstawIkone(2);
			}
		}

		//-=-=-=-=-=-=-=-=-=-=-= ODLICZANIE
		// Zmienne

		private int Odliczanie_Czas;

		// Wydarzenia

		private void Zegar_Odliczanie_Tick(object sender, EventArgs e)
		{
			Odliczanie_Czas--;

			if (Odliczanie_Czas >= 0)
			{
				Odliczanie_OdswiezZegar();
			}
			else
			{
				Odliczanie_ZatrzymajZegar();
				WylaczAdresy();
			}
		}

		//Procedury

		private bool Odliczanie_ZegarTrwa
		{
			get
			{
				return Zegar_Odliczanie.Enabled;
			}
		}

		private void Odliczanie_RozpocznijZegar()
		{
			Odliczanie_Czas = Convert.ToInt32(Pole_CzasWylaczenia.Text) * 60;
			Odliczanie_OdswiezZegar();
			Etykieta_CzasWylaczenia.Visible = true;
			Pasek_CzasPolaczenia.Visible = true;
			Zegar_Odliczanie.Start();
		}

		private void Odliczanie_OdswiezZegar()
		{
			TimeSpan czas = TimeSpan.FromSeconds(Odliczanie_Czas);
			int
				godz = czas.Hours,
				min = czas.Minutes,
				sek = czas.Seconds,

				czas_caly = Convert.ToInt32(Pole_CzasWylaczenia.Text) * 60,
				czas_pozostaly = czas_caly - Odliczanie_Czas,
				procent = (int)((double)czas_pozostaly / czas_caly * 100);

			if (godz >= 1)
			{
				Etykieta_CzasWylaczenia.Text = String.Format("Wyłączenie za {0} godz {1} min {2} s", godz, min, sek);
			}
			else if (min >= 1)
			{
				Etykieta_CzasWylaczenia.Text = String.Format("Wyłączenie za {0} min {1} s", min, sek);
			}
			else
			{
				Etykieta_CzasWylaczenia.Text = String.Format("Wyłączenie za {0} s", sek);
			}

			Pasek_CzasPolaczenia.Value = procent;

			if (godz == 0 && min == 0 && sek == 30)
			{
				Zasobnik.ShowBalloonTip(3000);
			}
		}

		private void Odliczanie_ZatrzymajZegar()
		{
			Etykieta_CzasWylaczenia.Visible = false;
			Pasek_CzasPolaczenia.Visible = false;
			Zegar_Odliczanie.Stop();
		}

		//-=-=-=-=-=-=-=-=-=-=-= TESTOWANIE i WYŁĄCZANIE
		// Zmienne

		OknoWylaczania OknoDrugie;

		// Wydarzenia

		private void Przycisk_Testuj_Click(object sender, EventArgs e)
		{
			TestujAdresy();
		}

		private void Przycisk_Wylacz_Click(object sender, EventArgs e)
		{
			WylaczAdresy();
		}

		// Procedury

		private void TestujAdresy()
		{
			if (OknoDrugie != null)
			{
				OknoDrugie.Close();
			}

			OknoDrugie = new OknoWylaczania(0);
			OknoDrugie.Show();
		}

		private void WylaczAdresy()
		{
			if (OknoDrugie != null)
			{
				OknoDrugie.Close();
			}

			OknoDrugie = new OknoWylaczania(Pole_WylaczTenKomputer.Checked == true ? (byte)2 : (byte)1);
			OknoDrugie.Show();
		}

		//-=-=-=-=-=-=-=-=-=-=-= AUTOSTART
		// Zmienne
		bool Autostart_BlokadaWydarzenia = false;

		// Wydarzenia

		private void Pole_Autostart_CheckedChanged(object sender, EventArgs e)
		{
			if (Autostart_BlokadaWydarzenia)
			{
				return;
			}

			bool Wybor = Pole_Autostart.Checked;

			Etykieta_Autostart.Text = Wybor ? "Włączony" : "Wyłączony";

			Autostart_Ustaw(Wybor);
		}

		// Procedury

		private bool Autostart_Sprawdz()
		{
			bool istnieje = false;

			RegistryKey klucz = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", false);

			istnieje = klucz.GetValue(Application.ProductName) != null;

			klucz.Close();

			return istnieje;
		}

		private void Autostart_Ustaw(bool autostart)
		{
			RegistryKey klucz = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
			klucz.DeleteValue(Application.ProductName, false);

			if (autostart == true)
			{
				klucz.SetValue(Application.ProductName, Application.ExecutablePath + " -cicho", RegistryValueKind.String);
			}

			klucz.Close();
		}

		///////////////////////////////////////////////////////////

		private void OknoGlowne_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.F3)
			{
				Port_OdpowiedzOK();
			}
			if (e.KeyCode == Keys.F4)
			{
				Zasobnik_UstawIkone(1);
			}
			if (e.KeyCode == Keys.F5)
			{
				Zasobnik_UstawIkone(2);
			}
		}







		////////////////////////////////////////////////////////
	}
}
