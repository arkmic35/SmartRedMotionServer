namespace SmartRedMotion_Serwer
{
	partial class OknoGlowne
	{
		/// <summary>
		/// Wymagana zmienna projektanta.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Wyczyść wszystkie używane zasoby.
		/// </summary>
		/// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Kod generowany przez Projektanta formularzy systemu Windows

		/// <summary>
		/// Wymagana metoda wsparcia projektanta - nie należy modyfikować
		/// zawartość tej metody z edytorem kodu.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.Zasobnik = new System.Windows.Forms.NotifyIcon(this.components);
			this.Zasobnik_Menu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.Wybor_OpcjaPokazOkno = new System.Windows.Forms.ToolStripMenuItem();
			this.Wybor_OpcjaOdinstaluj = new System.Windows.Forms.ToolStripMenuItem();
			this.Wybor_OpcjaZamknij = new System.Windows.Forms.ToolStripMenuItem();
			this.Serial_Uchwyt = new System.IO.Ports.SerialPort(this.components);
			this.Zegar_Laczenie = new System.Windows.Forms.Timer(this.components);
			this.Zegar_Odliczanie = new System.Windows.Forms.Timer(this.components);
			this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
			this.tabPage1 = new MetroFramework.Controls.MetroTabPage();
			this.Etykieta_CzasWylaczenia = new MetroFramework.Controls.MetroLabel();
			this.Pasek_CzasPolaczenia = new MetroFramework.Controls.MetroProgressBar();
			this.Przycisk_Polacz = new MetroFramework.Controls.MetroButton();
			this.Etykieta_StanCzujnika = new MetroFramework.Controls.MetroLabel();
			this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
			this.tabPage2 = new MetroFramework.Controls.MetroTabPage();
			this.Etykieta_Autostart = new MetroFramework.Controls.MetroLabel();
			this.Przycisk_Wylacz = new MetroFramework.Controls.MetroButton();
			this.Przycisk_Testuj = new MetroFramework.Controls.MetroButton();
			this.Pole_Autostart = new MetroFramework.Controls.MetroToggle();
			this.Etykieta_CzasWylaczeniaNapis = new MetroFramework.Controls.MetroLabel();
			this.Pole_CzasWylaczenia = new MetroFramework.Controls.MetroTextBox();
			this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
			this.Pole_WylaczTenKomputer = new MetroFramework.Controls.MetroCheckBox();
			this.Pole_WylaczaneKomputery = new MetroFramework.Controls.MetroTextBox();
			this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
			this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
			this.Zasobnik_Menu.SuspendLayout();
			this.metroTabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.SuspendLayout();
			// 
			// Zasobnik
			// 
			this.Zasobnik.BalloonTipText = "Za 30 sekund nastąpi wyłączenie.";
			this.Zasobnik.BalloonTipTitle = "SmartRedMotion - bezruch";
			this.Zasobnik.ContextMenuStrip = this.Zasobnik_Menu;
			this.Zasobnik.Text = "SmartRedMotion";
			this.Zasobnik.Visible = true;
			this.Zasobnik.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Zasobnik_MouseClick);
			// 
			// Zasobnik_Menu
			// 
			this.Zasobnik_Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Wybor_OpcjaPokazOkno,
            this.Wybor_OpcjaOdinstaluj,
            this.Wybor_OpcjaZamknij});
			this.Zasobnik_Menu.Name = "Zasobnik_Menu";
			this.Zasobnik_Menu.Size = new System.Drawing.Size(153, 92);
			// 
			// Wybor_OpcjaPokazOkno
			// 
			this.Wybor_OpcjaPokazOkno.Name = "Wybor_OpcjaPokazOkno";
			this.Wybor_OpcjaPokazOkno.Size = new System.Drawing.Size(152, 22);
			this.Wybor_OpcjaPokazOkno.Text = "Ukryj okno";
			this.Wybor_OpcjaPokazOkno.Click += new System.EventHandler(this.Wybor_OpcjaPokazOkno_Click);
			// 
			// Wybor_OpcjaOdinstaluj
			// 
			this.Wybor_OpcjaOdinstaluj.Name = "Wybor_OpcjaOdinstaluj";
			this.Wybor_OpcjaOdinstaluj.Size = new System.Drawing.Size(152, 22);
			this.Wybor_OpcjaOdinstaluj.Text = "Odinstaluj";
			this.Wybor_OpcjaOdinstaluj.Click += new System.EventHandler(this.Wybor_OpcjaOdinstaluj_Click);
			// 
			// Wybor_OpcjaZamknij
			// 
			this.Wybor_OpcjaZamknij.Name = "Wybor_OpcjaZamknij";
			this.Wybor_OpcjaZamknij.Size = new System.Drawing.Size(152, 22);
			this.Wybor_OpcjaZamknij.Text = "Zamknij";
			this.Wybor_OpcjaZamknij.Click += new System.EventHandler(this.Wybor_OpcjaZamknij_Click);
			// 
			// Serial_Uchwyt
			// 
			this.Serial_Uchwyt.ErrorReceived += new System.IO.Ports.SerialErrorReceivedEventHandler(this.Serial_Uchwyt_ErrorReceived);
			this.Serial_Uchwyt.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.Serial_Uchwyt_DataReceived);
			// 
			// Zegar_Laczenie
			// 
			this.Zegar_Laczenie.Interval = 10000;
			this.Zegar_Laczenie.Tick += new System.EventHandler(this.Zegar_Laczenie_Tick);
			// 
			// Zegar_Odliczanie
			// 
			this.Zegar_Odliczanie.Interval = 1000;
			this.Zegar_Odliczanie.Tick += new System.EventHandler(this.Zegar_Odliczanie_Tick);
			// 
			// metroTabControl1
			// 
			this.metroTabControl1.Controls.Add(this.tabPage1);
			this.metroTabControl1.Controls.Add(this.tabPage2);
			this.metroTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.metroTabControl1.Location = new System.Drawing.Point(20, 60);
			this.metroTabControl1.Name = "metroTabControl1";
			this.metroTabControl1.SelectedIndex = 0;
			this.metroTabControl1.Size = new System.Drawing.Size(476, 174);
			this.metroTabControl1.Style = MetroFramework.MetroColorStyle.Red;
			this.metroTabControl1.TabIndex = 4;
			this.metroTabControl1.UseSelectable = true;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.Etykieta_CzasWylaczenia);
			this.tabPage1.Controls.Add(this.Pasek_CzasPolaczenia);
			this.tabPage1.Controls.Add(this.Przycisk_Polacz);
			this.tabPage1.Controls.Add(this.Etykieta_StanCzujnika);
			this.tabPage1.Controls.Add(this.metroLabel1);
			this.tabPage1.HorizontalScrollbarBarColor = true;
			this.tabPage1.HorizontalScrollbarHighlightOnWheel = false;
			this.tabPage1.HorizontalScrollbarSize = 10;
			this.tabPage1.Location = new System.Drawing.Point(4, 38);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(468, 132);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Stan";
			this.tabPage1.VerticalScrollbarBarColor = true;
			this.tabPage1.VerticalScrollbarHighlightOnWheel = false;
			this.tabPage1.VerticalScrollbarSize = 10;
			// 
			// Etykieta_CzasWylaczenia
			// 
			this.Etykieta_CzasWylaczenia.FontWeight = MetroFramework.MetroLabelWeight.Regular;
			this.Etykieta_CzasWylaczenia.Location = new System.Drawing.Point(0, 85);
			this.Etykieta_CzasWylaczenia.Name = "Etykieta_CzasWylaczenia";
			this.Etykieta_CzasWylaczenia.Size = new System.Drawing.Size(465, 23);
			this.Etykieta_CzasWylaczenia.TabIndex = 6;
			this.Etykieta_CzasWylaczenia.Text = "Wyłączenie za 20 sekund";
			this.Etykieta_CzasWylaczenia.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.Etykieta_CzasWylaczenia.Visible = false;
			// 
			// Pasek_CzasPolaczenia
			// 
			this.Pasek_CzasPolaczenia.Location = new System.Drawing.Point(0, 109);
			this.Pasek_CzasPolaczenia.Name = "Pasek_CzasPolaczenia";
			this.Pasek_CzasPolaczenia.ProgressBarStyle = System.Windows.Forms.ProgressBarStyle.Blocks;
			this.Pasek_CzasPolaczenia.Size = new System.Drawing.Size(465, 23);
			this.Pasek_CzasPolaczenia.Style = MetroFramework.MetroColorStyle.Red;
			this.Pasek_CzasPolaczenia.TabIndex = 5;
			this.Pasek_CzasPolaczenia.Value = 77;
			this.Pasek_CzasPolaczenia.Visible = false;
			// 
			// Przycisk_Polacz
			// 
			this.Przycisk_Polacz.Location = new System.Drawing.Point(378, 10);
			this.Przycisk_Polacz.Name = "Przycisk_Polacz";
			this.Przycisk_Polacz.Size = new System.Drawing.Size(87, 23);
			this.Przycisk_Polacz.TabIndex = 4;
			this.Przycisk_Polacz.Text = "Połącz";
			this.Przycisk_Polacz.UseSelectable = true;
			this.Przycisk_Polacz.Click += new System.EventHandler(this.Przycisk_Polacz_Click);
			// 
			// Etykieta_StanCzujnika
			// 
			this.Etykieta_StanCzujnika.AutoSize = true;
			this.Etykieta_StanCzujnika.FontWeight = MetroFramework.MetroLabelWeight.Regular;
			this.Etykieta_StanCzujnika.Location = new System.Drawing.Point(113, 10);
			this.Etykieta_StanCzujnika.Name = "Etykieta_StanCzujnika";
			this.Etykieta_StanCzujnika.Size = new System.Drawing.Size(104, 19);
			this.Etykieta_StanCzujnika.TabIndex = 3;
			this.Etykieta_StanCzujnika.Text = "brak połączenia";
			// 
			// metroLabel1
			// 
			this.metroLabel1.AutoSize = true;
			this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Regular;
			this.metroLabel1.Location = new System.Drawing.Point(4, 10);
			this.metroLabel1.Name = "metroLabel1";
			this.metroLabel1.Size = new System.Drawing.Size(53, 19);
			this.metroLabel1.TabIndex = 2;
			this.metroLabel1.Text = "Czujnik";
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.Etykieta_Autostart);
			this.tabPage2.Controls.Add(this.Przycisk_Wylacz);
			this.tabPage2.Controls.Add(this.Przycisk_Testuj);
			this.tabPage2.Controls.Add(this.Pole_Autostart);
			this.tabPage2.Controls.Add(this.Etykieta_CzasWylaczeniaNapis);
			this.tabPage2.Controls.Add(this.Pole_CzasWylaczenia);
			this.tabPage2.Controls.Add(this.metroLabel6);
			this.tabPage2.Controls.Add(this.Pole_WylaczTenKomputer);
			this.tabPage2.Controls.Add(this.Pole_WylaczaneKomputery);
			this.tabPage2.Controls.Add(this.metroLabel5);
			this.tabPage2.Controls.Add(this.metroLabel3);
			this.tabPage2.HorizontalScrollbarBarColor = true;
			this.tabPage2.HorizontalScrollbarHighlightOnWheel = false;
			this.tabPage2.HorizontalScrollbarSize = 10;
			this.tabPage2.Location = new System.Drawing.Point(4, 38);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Size = new System.Drawing.Size(468, 132);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Ustawienia";
			this.tabPage2.VerticalScrollbarBarColor = true;
			this.tabPage2.VerticalScrollbarHighlightOnWheel = false;
			this.tabPage2.VerticalScrollbarSize = 10;
			// 
			// Etykieta_Autostart
			// 
			this.Etykieta_Autostart.AutoSize = true;
			this.Etykieta_Autostart.FontWeight = MetroFramework.MetroLabelWeight.Bold;
			this.Etykieta_Autostart.Location = new System.Drawing.Point(160, 10);
			this.Etykieta_Autostart.Name = "Etykieta_Autostart";
			this.Etykieta_Autostart.Size = new System.Drawing.Size(82, 19);
			this.Etykieta_Autostart.TabIndex = 15;
			this.Etykieta_Autostart.Text = "Wyłączony";
			// 
			// Przycisk_Wylacz
			// 
			this.Przycisk_Wylacz.Location = new System.Drawing.Point(390, 100);
			this.Przycisk_Wylacz.Name = "Przycisk_Wylacz";
			this.Przycisk_Wylacz.Size = new System.Drawing.Size(75, 23);
			this.Przycisk_Wylacz.TabIndex = 14;
			this.Przycisk_Wylacz.Text = "Wyłącz";
			this.Przycisk_Wylacz.UseSelectable = true;
			this.Przycisk_Wylacz.Click += new System.EventHandler(this.Przycisk_Wylacz_Click);
			// 
			// Przycisk_Testuj
			// 
			this.Przycisk_Testuj.Location = new System.Drawing.Point(390, 70);
			this.Przycisk_Testuj.Name = "Przycisk_Testuj";
			this.Przycisk_Testuj.Size = new System.Drawing.Size(75, 23);
			this.Przycisk_Testuj.TabIndex = 13;
			this.Przycisk_Testuj.Text = "Testuj";
			this.Przycisk_Testuj.UseSelectable = true;
			this.Przycisk_Testuj.Click += new System.EventHandler(this.Przycisk_Testuj_Click);
			// 
			// Pole_Autostart
			// 
			this.Pole_Autostart.AutoSize = true;
			this.Pole_Autostart.DisplayStatus = false;
			this.Pole_Autostart.Location = new System.Drawing.Point(248, 11);
			this.Pole_Autostart.Name = "Pole_Autostart";
			this.Pole_Autostart.Size = new System.Drawing.Size(50, 17);
			this.Pole_Autostart.Style = MetroFramework.MetroColorStyle.Red;
			this.Pole_Autostart.TabIndex = 12;
			this.Pole_Autostart.Text = "Off";
			this.Pole_Autostart.UseSelectable = true;
			this.Pole_Autostart.CheckedChanged += new System.EventHandler(this.Pole_Autostart_CheckedChanged);
			// 
			// Etykieta_CzasWylaczeniaNapis
			// 
			this.Etykieta_CzasWylaczeniaNapis.AutoSize = true;
			this.Etykieta_CzasWylaczeniaNapis.FontWeight = MetroFramework.MetroLabelWeight.Regular;
			this.Etykieta_CzasWylaczeniaNapis.Location = new System.Drawing.Point(212, 40);
			this.Etykieta_CzasWylaczeniaNapis.Name = "Etykieta_CzasWylaczeniaNapis";
			this.Etykieta_CzasWylaczeniaNapis.Size = new System.Drawing.Size(105, 19);
			this.Etykieta_CzasWylaczeniaNapis.TabIndex = 11;
			this.Etykieta_CzasWylaczeniaNapis.Text = "minut bezruchu";
			// 
			// Pole_CzasWylaczenia
			// 
			this.Pole_CzasWylaczenia.Lines = new string[] {
        "5"};
			this.Pole_CzasWylaczenia.Location = new System.Drawing.Point(160, 38);
			this.Pole_CzasWylaczenia.MaxLength = 6;
			this.Pole_CzasWylaczenia.Name = "Pole_CzasWylaczenia";
			this.Pole_CzasWylaczenia.PasswordChar = '\0';
			this.Pole_CzasWylaczenia.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.Pole_CzasWylaczenia.SelectedText = "";
			this.Pole_CzasWylaczenia.Size = new System.Drawing.Size(46, 23);
			this.Pole_CzasWylaczenia.TabIndex = 10;
			this.Pole_CzasWylaczenia.Text = "5";
			this.Pole_CzasWylaczenia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.Pole_CzasWylaczenia.UseSelectable = true;
			this.Pole_CzasWylaczenia.TextChanged += new System.EventHandler(this.Pole_CzasWylaczenia_TextChanged);
			this.Pole_CzasWylaczenia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Pole_CzasWylaczenia_KeyPress);
			// 
			// metroLabel6
			// 
			this.metroLabel6.AutoSize = true;
			this.metroLabel6.FontWeight = MetroFramework.MetroLabelWeight.Regular;
			this.metroLabel6.Location = new System.Drawing.Point(4, 40);
			this.metroLabel6.Name = "metroLabel6";
			this.metroLabel6.Size = new System.Drawing.Size(106, 19);
			this.metroLabel6.TabIndex = 9;
			this.metroLabel6.Text = "Czas wyłączenia";
			// 
			// Pole_WylaczTenKomputer
			// 
			this.Pole_WylaczTenKomputer.AutoSize = true;
			this.Pole_WylaczTenKomputer.Location = new System.Drawing.Point(160, 100);
			this.Pole_WylaczTenKomputer.Name = "Pole_WylaczTenKomputer";
			this.Pole_WylaczTenKomputer.Size = new System.Drawing.Size(116, 15);
			this.Pole_WylaczTenKomputer.TabIndex = 8;
			this.Pole_WylaczTenKomputer.Text = "Ten komputer też";
			this.Pole_WylaczTenKomputer.UseSelectable = true;
			this.Pole_WylaczTenKomputer.CheckedChanged += new System.EventHandler(this.Pole_WylaczTenKomputer_CheckedChanged);
			// 
			// Pole_WylaczaneKomputery
			// 
			this.Pole_WylaczaneKomputery.ForeColor = System.Drawing.SystemColors.ButtonFace;
			this.Pole_WylaczaneKomputery.Lines = new string[] {
        "10.1.56.1-15"};
			this.Pole_WylaczaneKomputery.Location = new System.Drawing.Point(160, 70);
			this.Pole_WylaczaneKomputery.MaxLength = 32767;
			this.Pole_WylaczaneKomputery.Name = "Pole_WylaczaneKomputery";
			this.Pole_WylaczaneKomputery.PasswordChar = '\0';
			this.Pole_WylaczaneKomputery.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.Pole_WylaczaneKomputery.SelectedText = "";
			this.Pole_WylaczaneKomputery.Size = new System.Drawing.Size(138, 23);
			this.Pole_WylaczaneKomputery.TabIndex = 7;
			this.Pole_WylaczaneKomputery.Text = "10.1.56.1-15";
			this.Pole_WylaczaneKomputery.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.Pole_WylaczaneKomputery.UseCustomBackColor = true;
			this.Pole_WylaczaneKomputery.UseSelectable = true;
			this.Pole_WylaczaneKomputery.TextChanged += new System.EventHandler(this.Pole_WylaczaneKomputery_TextChanged);
			// 
			// metroLabel5
			// 
			this.metroLabel5.AutoSize = true;
			this.metroLabel5.FontWeight = MetroFramework.MetroLabelWeight.Regular;
			this.metroLabel5.Location = new System.Drawing.Point(4, 70);
			this.metroLabel5.Name = "metroLabel5";
			this.metroLabel5.Size = new System.Drawing.Size(145, 19);
			this.metroLabel5.TabIndex = 6;
			this.metroLabel5.Text = "Wyłączane komputery";
			// 
			// metroLabel3
			// 
			this.metroLabel3.AutoSize = true;
			this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Regular;
			this.metroLabel3.Location = new System.Drawing.Point(4, 10);
			this.metroLabel3.Name = "metroLabel3";
			this.metroLabel3.Size = new System.Drawing.Size(67, 19);
			this.metroLabel3.TabIndex = 2;
			this.metroLabel3.Text = "Autostart";
			// 
			// OknoGlowne
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(516, 254);
			this.Controls.Add(this.metroTabControl1);
			this.ForeColor = System.Drawing.SystemColors.ButtonFace;
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.Name = "OknoGlowne";
			this.Resizable = false;
			this.Style = MetroFramework.MetroColorStyle.Red;
			this.Text = "SmartRedMotion Serwer";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OknoGlowne_KeyDown);
			this.Resize += new System.EventHandler(this.OknoGlowne_Resize);
			this.Zasobnik_Menu.ResumeLayout(false);
			this.metroTabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.NotifyIcon Zasobnik;
		private System.IO.Ports.SerialPort Serial_Uchwyt;
		private System.Windows.Forms.Timer Zegar_Laczenie;
		private System.Windows.Forms.Timer Zegar_Odliczanie;
		private MetroFramework.Controls.MetroTabControl metroTabControl1;
		private MetroFramework.Controls.MetroTabPage tabPage1;
		private MetroFramework.Controls.MetroTabPage tabPage2;
		private MetroFramework.Controls.MetroButton Przycisk_Polacz;
		private MetroFramework.Controls.MetroLabel Etykieta_StanCzujnika;
		private MetroFramework.Controls.MetroLabel metroLabel1;
		private MetroFramework.Controls.MetroLabel metroLabel3;
		private MetroFramework.Controls.MetroProgressBar Pasek_CzasPolaczenia;
		private MetroFramework.Controls.MetroTextBox Pole_WylaczaneKomputery;
		private MetroFramework.Controls.MetroLabel metroLabel5;
		private MetroFramework.Controls.MetroLabel metroLabel6;
		private MetroFramework.Controls.MetroTextBox Pole_CzasWylaczenia;
		private MetroFramework.Controls.MetroLabel Etykieta_CzasWylaczeniaNapis;
		private MetroFramework.Controls.MetroToggle Pole_Autostart;
		private MetroFramework.Controls.MetroLabel Etykieta_CzasWylaczenia;
		private MetroFramework.Controls.MetroButton Przycisk_Wylacz;
		private MetroFramework.Controls.MetroButton Przycisk_Testuj;
		private MetroFramework.Controls.MetroLabel Etykieta_Autostart;
		private MetroFramework.Controls.MetroCheckBox Pole_WylaczTenKomputer;
		private System.Windows.Forms.ContextMenuStrip Zasobnik_Menu;
		private System.Windows.Forms.ToolStripMenuItem Wybor_OpcjaPokazOkno;
		private System.Windows.Forms.ToolStripMenuItem Wybor_OpcjaOdinstaluj;
		private System.Windows.Forms.ToolStripMenuItem Wybor_OpcjaZamknij;
	}
}

