using MetroFramework;
using MetroFramework.Controls;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SmartRedMotion_Serwer
{
	public partial class OknoWylaczania : MetroForm
	{
		// Zmienne

		Thread Watek;
		bool PrzerwijWatek;

		byte Tryb; //0 - testowanie; 1 - wyłączenie klientów; 2 - wyłączenie klientów i serwera

		// Wydarzenia

		public OknoWylaczania(byte tryb)
		{
			InitializeComponent();

			Tryb = tryb;

			//Ustawienie wyglądu okna zależne od wykonanej czynności
			{
				if (Tryb == 0)
				{
					Style = MetroFramework.MetroColorStyle.Green;
					Text = "Testowanie połączenia";
				}
				else
				{
					Style = MetroFramework.MetroColorStyle.Black;
					Text = "Wyłączanie komputerów";
				}
			}

			//Utworzenie wątku
			{
				PrzerwijWatek = false;
				Watek = new Thread(new ThreadStart(this.Watek_Petla));
				Watek.Start();
			}
		}

		private void OknoWylaczania_Load(object sender, EventArgs e)
		{
			//Ustawienie pozycji okna
			{
				StartPosition = FormStartPosition.Manual;
				Location = new Point(Left, Program.OknoPierwsze.Location.Y + 290);
			}

			//Ustawienie wysokości okna
			{
				int komputery = 0;
				int y = 0;

				for (int a = OknoGlowne.IP[0, 0]; a <= OknoGlowne.IP[0, 1]; a++)
				{
					for (int b = OknoGlowne.IP[1, 0]; b <= OknoGlowne.IP[1, 1]; b++)
					{
						for (int c = OknoGlowne.IP[2, 0]; c <= OknoGlowne.IP[2, 1]; c++)
						{
							for (int d = OknoGlowne.IP[3, 0]; d <= OknoGlowne.IP[3, 1]; d++)
							{
								komputery++;
							}
						}
					}
				}

				y = 100 + (int)(Math.Ceiling((double)komputery / 5.0) * 46);

				if (y > 500)
				{
					y = 500;
				}

				Size rozmiar = Size;
				rozmiar.Height = y;
				Size = rozmiar;
			}
		}

		private void OknoWylaczania_FormClosing(object sender, FormClosingEventArgs e)
		{
			//Zlecenie przerwania wątku, jeśli pracuje
			{
				if (PrzerwijWatek == false && Watek != null && Watek.IsAlive)
				{
					e.Cancel = true;
					PrzerwijWatek = true;
				}
			}
		}

		// Wątek

		private void Watek_Petla()
		{
			for (int a = OknoGlowne.IP[0, 0]; a <= OknoGlowne.IP[0, 1]; a++)
			{
				for (int b = OknoGlowne.IP[1, 0]; b <= OknoGlowne.IP[1, 1]; b++)
				{
					for (int c = OknoGlowne.IP[2, 0]; c <= OknoGlowne.IP[2, 1]; c++)
					{
						for (int d = OknoGlowne.IP[3, 0]; d <= OknoGlowne.IP[3, 1]; d++)
						{
							Watek_WyslijPakiet(a.ToString() + '.' + b.ToString() + '.' + c.ToString() + '.' + d.ToString());

							//Przerwanie pracy jeśli trzeba zamknąć okno
							{
								if (PrzerwijWatek == true)
								{
									if (InvokeRequired)
									{
										Invoke((MethodInvoker)delegate
										{
											Close();
										});
									}
									else
									{
										Close();
									}
									return;
								}
							}
						}
					}
				}
			}

			//Wyłączenie serwera, jeśli aktywowane
			{
				if (Tryb == 2)
				{
					WylaczSerwer();
				}
			}
		}

		private void Watek_WyslijPakiet(string adres)
		{
			TcpClient Klient;
			NetworkStream Strumien;
			StreamWriter Zapis;
			StreamReader Odczyt;
			string Txt;

			//Pingowanie
			{
				if (new Ping().Send(adres, 1000, Encoding.ASCII.GetBytes("AAAA")).Status != IPStatus.Success)
				{
					Watek_DodajKafelek(adres, MetroColorStyle.Black);
					return;
				}
			}

			//Połączenie TCP
			{
				try
				{
					Klient = new TcpClient();
					Klient.NoDelay = true;
					Klient.Connect(adres, 2736);
				}
				catch (SocketException)
				{
					Watek_DodajKafelek(adres, MetroColorStyle.Red);
					return;
				}

				Strumien = Klient.GetStream();
				Strumien.ReadTimeout = 1000;
				Strumien.WriteTimeout = 1000;
				Zapis = new StreamWriter(Strumien);
				Odczyt = new StreamReader(Strumien);
			}

			//Wysłanie wiadomości
			{
				Zapis.WriteLine(Tryb >= 1 ? "W" : "T");
				Zapis.Flush();
			}

			//Odebranie wiadomości zwrotnej
			{
				try
				{
					Txt = Odczyt.ReadLine();

					if (!Txt.Contains(Tryb == 0 ? "T_OK" : "W_OK"))
					{
						throw new IOException();
					}

					Odczyt.Close();
				}
				catch (IOException)
				{
					Watek_DodajKafelek(adres, MetroColorStyle.Yellow);
					Strumien.Close();
					Klient.Close();
					return;
				}
			}

			//Zakończenie
			{
				Strumien.Close();
				Klient.Close();
			}

			//Dodanie kafelka
			{
				Watek_DodajKafelek(adres, MetroColorStyle.Green);
			}
		}

		int NowyKafelek_X = 3,
			NowyKafelek_Y = 3;

		private void Watek_DodajKafelek(string ip, MetroColorStyle styl)
		{
			if (InvokeRequired)
			{
				Invoke((MethodInvoker)delegate
				{
					Watek_DodajKafelek2(ip, styl);
				});
			}
			else
			{
				Watek_DodajKafelek2(ip, styl);
			}
		}

		private void Watek_DodajKafelek2(string ip, MetroColorStyle styl)
		{
			MetroTile Kafelek = new MetroTile()
			{
				Location = new System.Drawing.Point(NowyKafelek_X, NowyKafelek_Y),
				Size = new System.Drawing.Size(110, 40),
				Style = styl,
				Text = ip,
				Visible = true
			};

			switch (styl)
			{
				case MetroColorStyle.Black:
					{
						Porada.SetToolTip(Kafelek, "Brak połączenia");
						break;
					}

				case MetroColorStyle.Red:
					{
						Porada.SetToolTip(Kafelek, "Brak zainstalowanego klienta");
						break;
					}

				case MetroColorStyle.Yellow:
					{
						Porada.SetToolTip(Kafelek, "Brak potwierdzenia (nieaktualna wersja klienta?)");
						break;
					}

				case MetroColorStyle.Green:
					{
						Porada.SetToolTip(Kafelek, "OK");
						break;
					}
			}

			Panel.Controls.Add(Kafelek);

			NowyKafelek_X += 116;

			if (NowyKafelek_X > 470)
			{
				NowyKafelek_X = 3;
				NowyKafelek_Y += 46;
			}
		}

		private void WylaczSerwer()
		{
			if (InvokeRequired)
			{
				Invoke((MethodInvoker)delegate
				{
					WylaczSerwer2();
				});
			}
			else
			{
				WylaczSerwer2();
			}
		}

		private void WylaczSerwer2()
		{
#if DEBUG
			System.Diagnostics.Process.Start("cmd.exe");
#else
			System.Diagnostics.Process.Start("shutdown.exe", "-s -t 0");
#endif
		}
	}
}

