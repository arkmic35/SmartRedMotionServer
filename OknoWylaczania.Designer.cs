namespace SmartRedMotion_Serwer
{
	partial class OknoWylaczania
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.Panel = new MetroFramework.Controls.MetroPanel();
			this.Porada = new MetroFramework.Components.MetroToolTip();
			this.SuspendLayout();
			// 
			// Panel
			// 
			this.Panel.AutoScroll = true;
			this.Panel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Panel.HorizontalScrollbar = true;
			this.Panel.HorizontalScrollbarBarColor = true;
			this.Panel.HorizontalScrollbarHighlightOnWheel = true;
			this.Panel.HorizontalScrollbarSize = 10;
			this.Panel.Location = new System.Drawing.Point(20, 60);
			this.Panel.Name = "Panel";
			this.Panel.Size = new System.Drawing.Size(600, 87);
			this.Panel.TabIndex = 1;
			this.Panel.VerticalScrollbar = true;
			this.Panel.VerticalScrollbarBarColor = false;
			this.Panel.VerticalScrollbarHighlightOnWheel = false;
			this.Panel.VerticalScrollbarSize = 5;
			// 
			// Porada
			// 
			this.Porada.Style = MetroFramework.MetroColorStyle.White;
			this.Porada.StyleManager = null;
			this.Porada.Theme = MetroFramework.MetroThemeStyle.Default;
			// 
			// OknoWylaczania
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(640, 167);
			this.Controls.Add(this.Panel);
			this.MaximizeBox = false;
			this.Name = "OknoWylaczania";
			this.Resizable = false;
			this.Style = MetroFramework.MetroColorStyle.Black;
			this.Text = "Testowanie";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OknoWylaczania_FormClosing);
			this.Load += new System.EventHandler(this.OknoWylaczania_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private MetroFramework.Controls.MetroPanel Panel;
		private MetroFramework.Components.MetroToolTip Porada;
	}
}