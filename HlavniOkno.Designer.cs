namespace EvidencePrijimacihoRizeni_Vilimek
{
	partial class HlavniOkno
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HlavniOkno));
			listBoxStredniSkola = new ListBox();
			buttonUpravitPrihlasku = new Button();
			buttonPridatPrihlasku = new Button();
			listBoxVyssiOdbornaSkola = new ListBox();
			groupBox_prihlaskyStredni = new GroupBox();
			groupBox_prihlaskyVyssi = new GroupBox();
			groupBox3 = new GroupBox();
			groupBox4 = new GroupBox();
			groupBox8 = new GroupBox();
			buttonZvolitSouborVyssi = new Button();
			textBoxCestaVyssiSkoly = new TextBox();
			groupBox5 = new GroupBox();
			buttonZvolitSouborStredni = new Button();
			textBoxCestaSouboruStredni = new TextBox();
			groupBox_prihlaskyTlacitka = new GroupBox();
			buttonVyhledatPrihlasku = new Button();
			buttonVypsatPrihlasku = new Button();
			buttonZobrazitPrihlasky = new Button();
			buttonSmazatPrihlasku = new Button();
			groupBox7 = new GroupBox();
			buttonSynchronizovat = new Button();
			toolStrip = new ToolStrip();
			toolStripDropDownButtonSoubor = new ToolStripDropDownButton();
			toolStripMenuItem1 = new ToolStripMenuItem();
			toolStripMenuItemNacistStredni = new ToolStripMenuItem();
			toolStripMenuItemNacistVyssi = new ToolStripMenuItem();
			toolStripSeparator1 = new ToolStripSeparator();
			toolStripMenuItemZavrit = new ToolStripMenuItem();
			toolStripDropDownButtonPrihlasky = new ToolStripDropDownButton();
			toolStripMenuItemNovaPrihlaska = new ToolStripMenuItem();
			toolStripMenuItemEditovatPrihlasku = new ToolStripMenuItem();
			toolStripMenuItemSmazatPrihlasku = new ToolStripMenuItem();
			toolStripMenuItemVypsatPrihlasku = new ToolStripMenuItem();
			toolStripMenuItemZobrazitPrihlaskoveSoubory = new ToolStripMenuItem();
			toolStripMenuItemVyhledatPodleId = new ToolStripMenuItem();
			toolStripMenuItemZobrazitPrijate = new ToolStripMenuItem();
			toolStripDropDownButtonSynchronizace = new ToolStripDropDownButton();
			toolStripMenuItemSynchronizovat = new ToolStripMenuItem();
			groupBox_prihlaskyStredni.SuspendLayout();
			groupBox_prihlaskyVyssi.SuspendLayout();
			groupBox3.SuspendLayout();
			groupBox4.SuspendLayout();
			groupBox8.SuspendLayout();
			groupBox5.SuspendLayout();
			groupBox_prihlaskyTlacitka.SuspendLayout();
			groupBox7.SuspendLayout();
			toolStrip.SuspendLayout();
			SuspendLayout();
			// 
			// listBoxStredniSkola
			// 
			listBoxStredniSkola.FormattingEnabled = true;
			listBoxStredniSkola.ItemHeight = 15;
			listBoxStredniSkola.Location = new Point(6, 22);
			listBoxStredniSkola.Name = "listBoxStredniSkola";
			listBoxStredniSkola.Size = new Size(190, 514);
			listBoxStredniSkola.TabIndex = 0;
			// 
			// buttonUpravitPrihlasku
			// 
			buttonUpravitPrihlasku.Location = new Point(117, 20);
			buttonUpravitPrihlasku.Margin = new Padding(2, 1, 2, 1);
			buttonUpravitPrihlasku.Name = "buttonUpravitPrihlasku";
			buttonUpravitPrihlasku.Size = new Size(107, 61);
			buttonUpravitPrihlasku.TabIndex = 1;
			buttonUpravitPrihlasku.Text = "Editovat přihlášku";
			buttonUpravitPrihlasku.UseVisualStyleBackColor = true;
			// 
			// buttonPridatPrihlasku
			// 
			buttonPridatPrihlasku.Location = new Point(6, 20);
			buttonPridatPrihlasku.Margin = new Padding(2, 1, 2, 1);
			buttonPridatPrihlasku.Name = "buttonPridatPrihlasku";
			buttonPridatPrihlasku.Size = new Size(107, 61);
			buttonPridatPrihlasku.TabIndex = 2;
			buttonPridatPrihlasku.Text = "Nová přihláška";
			buttonPridatPrihlasku.UseVisualStyleBackColor = true;
			// 
			// listBoxVyssiOdbornaSkola
			// 
			listBoxVyssiOdbornaSkola.FormattingEnabled = true;
			listBoxVyssiOdbornaSkola.ItemHeight = 15;
			listBoxVyssiOdbornaSkola.Location = new Point(6, 22);
			listBoxVyssiOdbornaSkola.Name = "listBoxVyssiOdbornaSkola";
			listBoxVyssiOdbornaSkola.Size = new Size(190, 514);
			listBoxVyssiOdbornaSkola.TabIndex = 3;
			// 
			// groupBox_prihlaskyStredni
			// 
			groupBox_prihlaskyStredni.Controls.Add(listBoxStredniSkola);
			groupBox_prihlaskyStredni.Location = new Point(6, 25);
			groupBox_prihlaskyStredni.Name = "groupBox_prihlaskyStredni";
			groupBox_prihlaskyStredni.Size = new Size(202, 539);
			groupBox_prihlaskyStredni.TabIndex = 4;
			groupBox_prihlaskyStredni.TabStop = false;
			groupBox_prihlaskyStredni.Text = "Přihlášky na střední školu";
			// 
			// groupBox_prihlaskyVyssi
			// 
			groupBox_prihlaskyVyssi.Controls.Add(listBoxVyssiOdbornaSkola);
			groupBox_prihlaskyVyssi.Location = new Point(214, 25);
			groupBox_prihlaskyVyssi.Name = "groupBox_prihlaskyVyssi";
			groupBox_prihlaskyVyssi.Size = new Size(202, 539);
			groupBox_prihlaskyVyssi.TabIndex = 5;
			groupBox_prihlaskyVyssi.TabStop = false;
			groupBox_prihlaskyVyssi.Text = "Přihlášky na vyšší odb. školu";
			// 
			// groupBox3
			// 
			groupBox3.Controls.Add(groupBox_prihlaskyStredni);
			groupBox3.Controls.Add(groupBox_prihlaskyVyssi);
			groupBox3.Location = new Point(12, 30);
			groupBox3.Name = "groupBox3";
			groupBox3.Size = new Size(429, 570);
			groupBox3.TabIndex = 6;
			groupBox3.TabStop = false;
			groupBox3.Text = "Přihlášky";
			// 
			// groupBox4
			// 
			groupBox4.Controls.Add(groupBox8);
			groupBox4.Controls.Add(groupBox5);
			groupBox4.Location = new Point(447, 30);
			groupBox4.Name = "groupBox4";
			groupBox4.Size = new Size(341, 139);
			groupBox4.TabIndex = 7;
			groupBox4.TabStop = false;
			groupBox4.Text = "Soubor";
			// 
			// groupBox8
			// 
			groupBox8.Controls.Add(buttonZvolitSouborVyssi);
			groupBox8.Controls.Add(textBoxCestaVyssiSkoly);
			groupBox8.Location = new Point(6, 80);
			groupBox8.Name = "groupBox8";
			groupBox8.Size = new Size(329, 53);
			groupBox8.TabIndex = 2;
			groupBox8.TabStop = false;
			groupBox8.Text = "Cesta k souboru pro přihl. pro vyšší odb. školy";
			// 
			// buttonZvolitSouborVyssi
			// 
			buttonZvolitSouborVyssi.Location = new Point(239, 22);
			buttonZvolitSouborVyssi.Name = "buttonZvolitSouborVyssi";
			buttonZvolitSouborVyssi.Size = new Size(84, 23);
			buttonZvolitSouborVyssi.TabIndex = 1;
			buttonZvolitSouborVyssi.Text = "Zvolit";
			buttonZvolitSouborVyssi.UseVisualStyleBackColor = true;
			// 
			// textBoxCestaVyssiSkoly
			// 
			textBoxCestaVyssiSkoly.Location = new Point(6, 22);
			textBoxCestaVyssiSkoly.Name = "textBoxCestaVyssiSkoly";
			textBoxCestaVyssiSkoly.Size = new Size(227, 23);
			textBoxCestaVyssiSkoly.TabIndex = 0;
			// 
			// groupBox5
			// 
			groupBox5.Controls.Add(buttonZvolitSouborStredni);
			groupBox5.Controls.Add(textBoxCestaSouboruStredni);
			groupBox5.Location = new Point(6, 22);
			groupBox5.Name = "groupBox5";
			groupBox5.Size = new Size(329, 53);
			groupBox5.TabIndex = 0;
			groupBox5.TabStop = false;
			groupBox5.Text = "Cesta k souboru pro přihl. pro střední školy";
			// 
			// buttonZvolitSouborStredni
			// 
			buttonZvolitSouborStredni.Location = new Point(239, 22);
			buttonZvolitSouborStredni.Name = "buttonZvolitSouborStredni";
			buttonZvolitSouborStredni.Size = new Size(84, 23);
			buttonZvolitSouborStredni.TabIndex = 1;
			buttonZvolitSouborStredni.Text = "Zvolit";
			buttonZvolitSouborStredni.UseVisualStyleBackColor = true;
			// 
			// textBoxCestaSouboruStredni
			// 
			textBoxCestaSouboruStredni.Location = new Point(6, 22);
			textBoxCestaSouboruStredni.Name = "textBoxCestaSouboruStredni";
			textBoxCestaSouboruStredni.Size = new Size(227, 23);
			textBoxCestaSouboruStredni.TabIndex = 0;
			// 
			// groupBox_prihlaskyTlacitka
			// 
			groupBox_prihlaskyTlacitka.Controls.Add(buttonVyhledatPrihlasku);
			groupBox_prihlaskyTlacitka.Controls.Add(buttonVypsatPrihlasku);
			groupBox_prihlaskyTlacitka.Controls.Add(buttonZobrazitPrihlasky);
			groupBox_prihlaskyTlacitka.Controls.Add(buttonSmazatPrihlasku);
			groupBox_prihlaskyTlacitka.Controls.Add(buttonPridatPrihlasku);
			groupBox_prihlaskyTlacitka.Controls.Add(buttonUpravitPrihlasku);
			groupBox_prihlaskyTlacitka.Location = new Point(447, 262);
			groupBox_prihlaskyTlacitka.Name = "groupBox_prihlaskyTlacitka";
			groupBox_prihlaskyTlacitka.Size = new Size(341, 171);
			groupBox_prihlaskyTlacitka.TabIndex = 8;
			groupBox_prihlaskyTlacitka.TabStop = false;
			groupBox_prihlaskyTlacitka.Text = "Přihlášky";
			// 
			// buttonVyhledatPrihlasku
			// 
			buttonVyhledatPrihlasku.Location = new Point(228, 93);
			buttonVyhledatPrihlasku.Margin = new Padding(2, 1, 2, 1);
			buttonVyhledatPrihlasku.Name = "buttonVyhledatPrihlasku";
			buttonVyhledatPrihlasku.Size = new Size(105, 61);
			buttonVyhledatPrihlasku.TabIndex = 6;
			buttonVyhledatPrihlasku.Text = "Vyhledat přihlášku";
			buttonVyhledatPrihlasku.UseVisualStyleBackColor = true;
			// 
			// buttonVypsatPrihlasku
			// 
			buttonVypsatPrihlasku.Location = new Point(6, 93);
			buttonVypsatPrihlasku.Margin = new Padding(2, 1, 2, 1);
			buttonVypsatPrihlasku.Name = "buttonVypsatPrihlasku";
			buttonVypsatPrihlasku.Size = new Size(107, 61);
			buttonVypsatPrihlasku.TabIndex = 5;
			buttonVypsatPrihlasku.Text = "Vypsat přihlášku";
			buttonVypsatPrihlasku.UseVisualStyleBackColor = true;
			// 
			// buttonZobrazitPrihlasky
			// 
			buttonZobrazitPrihlasky.Location = new Point(117, 93);
			buttonZobrazitPrihlasky.Margin = new Padding(2, 1, 2, 1);
			buttonZobrazitPrihlasky.Name = "buttonZobrazitPrihlasky";
			buttonZobrazitPrihlasky.Size = new Size(107, 61);
			buttonZobrazitPrihlasky.TabIndex = 4;
			buttonZobrazitPrihlasky.Text = "Zobrazit přijaté";
			buttonZobrazitPrihlasky.UseVisualStyleBackColor = true;
			// 
			// buttonSmazatPrihlasku
			// 
			buttonSmazatPrihlasku.Location = new Point(228, 20);
			buttonSmazatPrihlasku.Margin = new Padding(2, 1, 2, 1);
			buttonSmazatPrihlasku.Name = "buttonSmazatPrihlasku";
			buttonSmazatPrihlasku.Size = new Size(105, 61);
			buttonSmazatPrihlasku.TabIndex = 3;
			buttonSmazatPrihlasku.Text = "Smazat přihlášku";
			buttonSmazatPrihlasku.UseVisualStyleBackColor = true;
			// 
			// groupBox7
			// 
			groupBox7.Controls.Add(buttonSynchronizovat);
			groupBox7.Location = new Point(447, 175);
			groupBox7.Name = "groupBox7";
			groupBox7.Size = new Size(341, 81);
			groupBox7.TabIndex = 10;
			groupBox7.TabStop = false;
			groupBox7.Text = "Synchronizace";
			// 
			// buttonSynchronizovat
			// 
			buttonSynchronizovat.Location = new Point(12, 22);
			buttonSynchronizovat.Name = "buttonSynchronizovat";
			buttonSynchronizovat.Size = new Size(317, 39);
			buttonSynchronizovat.TabIndex = 0;
			buttonSynchronizovat.Text = "Synchronizovat s databází";
			buttonSynchronizovat.UseVisualStyleBackColor = true;
			// 
			// toolStrip
			// 
			toolStrip.Items.AddRange(new ToolStripItem[] { toolStripDropDownButtonSoubor, toolStripDropDownButtonPrihlasky, toolStripDropDownButtonSynchronizace });
			toolStrip.Location = new Point(0, 0);
			toolStrip.Name = "toolStrip";
			toolStrip.Size = new Size(800, 25);
			toolStrip.TabIndex = 12;
			toolStrip.Text = "toolStrip1";
			// 
			// toolStripDropDownButtonSoubor
			// 
			toolStripDropDownButtonSoubor.DisplayStyle = ToolStripItemDisplayStyle.Text;
			toolStripDropDownButtonSoubor.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem1, toolStripSeparator1, toolStripMenuItemZavrit });
			toolStripDropDownButtonSoubor.Image = (Image)resources.GetObject("toolStripDropDownButtonSoubor.Image");
			toolStripDropDownButtonSoubor.ImageTransparentColor = Color.Magenta;
			toolStripDropDownButtonSoubor.Name = "toolStripDropDownButtonSoubor";
			toolStripDropDownButtonSoubor.Size = new Size(58, 22);
			toolStripDropDownButtonSoubor.Text = "Soubor";
			// 
			// toolStripMenuItem1
			// 
			toolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItemNacistStredni, toolStripMenuItemNacistVyssi });
			toolStripMenuItem1.Name = "toolStripMenuItem1";
			toolStripMenuItem1.Size = new Size(147, 22);
			toolStripMenuItem1.Text = "Načíst soubor";
			// 
			// toolStripMenuItemNacistStredni
			// 
			toolStripMenuItemNacistStredni.Name = "toolStripMenuItemNacistStredni";
			toolStripMenuItemNacistStredni.Size = new Size(96, 22);
			toolStripMenuItemNacistStredni.Text = "SŠ";
			// 
			// toolStripMenuItemNacistVyssi
			// 
			toolStripMenuItemNacistVyssi.Name = "toolStripMenuItemNacistVyssi";
			toolStripMenuItemNacistVyssi.Size = new Size(96, 22);
			toolStripMenuItemNacistVyssi.Text = "VOŠ";
			// 
			// toolStripSeparator1
			// 
			toolStripSeparator1.Name = "toolStripSeparator1";
			toolStripSeparator1.Size = new Size(144, 6);
			// 
			// toolStripMenuItemZavrit
			// 
			toolStripMenuItemZavrit.Name = "toolStripMenuItemZavrit";
			toolStripMenuItemZavrit.Size = new Size(147, 22);
			toolStripMenuItemZavrit.Text = "Zavřít";
			// 
			// toolStripDropDownButtonPrihlasky
			// 
			toolStripDropDownButtonPrihlasky.DisplayStyle = ToolStripItemDisplayStyle.Text;
			toolStripDropDownButtonPrihlasky.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItemNovaPrihlaska, toolStripMenuItemEditovatPrihlasku, toolStripMenuItemSmazatPrihlasku, toolStripMenuItemVypsatPrihlasku, toolStripMenuItemZobrazitPrihlaskoveSoubory, toolStripMenuItemVyhledatPodleId, toolStripMenuItemZobrazitPrijate });
			toolStripDropDownButtonPrihlasky.Image = (Image)resources.GetObject("toolStripDropDownButtonPrihlasky.Image");
			toolStripDropDownButtonPrihlasky.ImageTransparentColor = Color.Magenta;
			toolStripDropDownButtonPrihlasky.Name = "toolStripDropDownButtonPrihlasky";
			toolStripDropDownButtonPrihlasky.Size = new Size(67, 22);
			toolStripDropDownButtonPrihlasky.Text = "Přihlášky";
			// 
			// toolStripMenuItemNovaPrihlaska
			// 
			toolStripMenuItemNovaPrihlaska.Name = "toolStripMenuItemNovaPrihlaska";
			toolStripMenuItemNovaPrihlaska.Size = new Size(226, 22);
			toolStripMenuItemNovaPrihlaska.Text = "Nová přihláška";
			// 
			// toolStripMenuItemEditovatPrihlasku
			// 
			toolStripMenuItemEditovatPrihlasku.Name = "toolStripMenuItemEditovatPrihlasku";
			toolStripMenuItemEditovatPrihlasku.Size = new Size(226, 22);
			toolStripMenuItemEditovatPrihlasku.Text = "Editovat přihlášku";
			// 
			// toolStripMenuItemSmazatPrihlasku
			// 
			toolStripMenuItemSmazatPrihlasku.Name = "toolStripMenuItemSmazatPrihlasku";
			toolStripMenuItemSmazatPrihlasku.Size = new Size(226, 22);
			toolStripMenuItemSmazatPrihlasku.Text = "Smazat přihlášku";
			// 
			// toolStripMenuItemVypsatPrihlasku
			// 
			toolStripMenuItemVypsatPrihlasku.Name = "toolStripMenuItemVypsatPrihlasku";
			toolStripMenuItemVypsatPrihlasku.Size = new Size(226, 22);
			toolStripMenuItemVypsatPrihlasku.Text = "Vypsat přihlášku";
			// 
			// toolStripMenuItemZobrazitPrihlaskoveSoubory
			// 
			toolStripMenuItemZobrazitPrihlaskoveSoubory.Name = "toolStripMenuItemZobrazitPrihlaskoveSoubory";
			toolStripMenuItemZobrazitPrihlaskoveSoubory.Size = new Size(226, 22);
			toolStripMenuItemZobrazitPrihlaskoveSoubory.Text = "Zobrazit přihláškové soubory";
			// 
			// toolStripMenuItemVyhledatPodleId
			// 
			toolStripMenuItemVyhledatPodleId.Name = "toolStripMenuItemVyhledatPodleId";
			toolStripMenuItemVyhledatPodleId.Size = new Size(226, 22);
			toolStripMenuItemVyhledatPodleId.Text = "Vyhledat přihlášku podle ID";
			// 
			// toolStripMenuItemZobrazitPrijate
			// 
			toolStripMenuItemZobrazitPrijate.Name = "toolStripMenuItemZobrazitPrijate";
			toolStripMenuItemZobrazitPrijate.Size = new Size(226, 22);
			toolStripMenuItemZobrazitPrijate.Text = "Zobrazit přijaté přihlášky";
			// 
			// toolStripDropDownButtonSynchronizace
			// 
			toolStripDropDownButtonSynchronizace.DisplayStyle = ToolStripItemDisplayStyle.Text;
			toolStripDropDownButtonSynchronizace.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItemSynchronizovat });
			toolStripDropDownButtonSynchronizace.Image = (Image)resources.GetObject("toolStripDropDownButtonSynchronizace.Image");
			toolStripDropDownButtonSynchronizace.ImageTransparentColor = Color.Magenta;
			toolStripDropDownButtonSynchronizace.Name = "toolStripDropDownButtonSynchronizace";
			toolStripDropDownButtonSynchronizace.Size = new Size(96, 22);
			toolStripDropDownButtonSynchronizace.Text = "Synchronizace";
			// 
			// toolStripMenuItemSynchronizovat
			// 
			toolStripMenuItemSynchronizovat.Name = "toolStripMenuItemSynchronizovat";
			toolStripMenuItemSynchronizovat.Size = new Size(181, 22);
			toolStripMenuItemSynchronizovat.Text = "Synchronizovat s DB";
			// 
			// HlavniOkno
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 594);
			Controls.Add(toolStrip);
			Controls.Add(groupBox7);
			Controls.Add(groupBox_prihlaskyTlacitka);
			Controls.Add(groupBox4);
			Controls.Add(groupBox3);
			Name = "HlavniOkno";
			Text = "Form1";
			groupBox_prihlaskyStredni.ResumeLayout(false);
			groupBox_prihlaskyVyssi.ResumeLayout(false);
			groupBox3.ResumeLayout(false);
			groupBox4.ResumeLayout(false);
			groupBox8.ResumeLayout(false);
			groupBox8.PerformLayout();
			groupBox5.ResumeLayout(false);
			groupBox5.PerformLayout();
			groupBox_prihlaskyTlacitka.ResumeLayout(false);
			groupBox7.ResumeLayout(false);
			toolStrip.ResumeLayout(false);
			toolStrip.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private ListBox listBoxStredniSkola;
		private Button buttonUpravitPrihlasku;
		private Button buttonPridatPrihlasku;
		private ListBox listBoxVyssiOdbornaSkola;
		private GroupBox groupBox_prihlaskyStredni;
		private GroupBox groupBox_prihlaskyVyssi;
		private GroupBox groupBox3;
		private GroupBox groupBox4;
		private GroupBox groupBox8;
		private Button buttonZvolitSouborVyssi;
		private TextBox textBoxCestaVyssiSkoly;
		private GroupBox groupBox5;
		private Button buttonZvolitSouborStredni;
		private TextBox textBoxCestaSouboruStredni;
		private GroupBox groupBox_prihlaskyTlacitka;
		private Button buttonVyhledatPrihlasku;
		private Button buttonVypsatPrihlasku;
		private Button buttonZobrazitPrihlasky;
		private Button buttonSmazatPrihlasku;
		private GroupBox groupBox7;
		private ToolStrip toolStrip;
		private ToolStripDropDownButton toolStripDropDownButtonSoubor;
		private ToolStripMenuItem toolStripMenuItem1;
		private ToolStripMenuItem toolStripMenuItemZavrit;
		private ToolStripDropDownButton toolStripDropDownButtonPrihlasky;
		private ToolStripDropDownButton toolStripDropDownButtonSynchronizace;
		private ToolStripMenuItem toolStripMenuItemNacistStredni;
		private ToolStripMenuItem toolStripMenuItemNacistVyssi;
		private ToolStripSeparator toolStripSeparator1;
		private ToolStripMenuItem toolStripMenuItemNovaPrihlaska;
		private ToolStripMenuItem toolStripMenuItemEditovatPrihlasku;
		private ToolStripMenuItem toolStripMenuItemSmazatPrihlasku;
		private ToolStripMenuItem toolStripMenuItemVypsatPrihlasku;
		private ToolStripMenuItem toolStripMenuItemZobrazitPrihlaskoveSoubory;
		private ToolStripMenuItem toolStripMenuItemVyhledatPodleId;
		private ToolStripMenuItem toolStripMenuItemSynchronizovat;
		private ToolStripMenuItem toolStripMenuItemZobrazitPrijate;
		private Button buttonSynchronizovat;
	}
}
