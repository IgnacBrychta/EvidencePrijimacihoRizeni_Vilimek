using System.Data;
using System.Diagnostics;
using System.Globalization;

namespace EvidencePrijimacihoRizeni_Vilimek;

public partial class HlavniOkno : Form
{
	List<PrihlaskaVyssiOdbornaSkola> prihlaskyVyssi = new();
	List<PrihlaskaStredniOdbornaSkola> prihlaskyStredni = new();
	DbValuesLimits limits = new DbValuesLimits
	{
		MaxCharacters = 255,
		MinAge = 15,
		Delimiter = ';',
		DateFormat = "dd.mm.yyyy",
		NejlepsiZnamka = 1.0m,
		NejhorsiZnamka = 5.0m,
		MaturitniPrumerProPrijeti = 1.5m
	};
	ListBox? zvolenySeznam = null;
	bool zmenaUzamcena = false;
	string? cestaSouborStredni = null;
	string? cestaSouborVyssi = null;
	public HlavniOkno()
	{
		InitializeComponent();
		Text = "Ignácova evidence uchazeèù";
		ZakazatPrihlaskovaTlacitka();
		buttonUpravitPrihlasku.Click += ButtonUpravitPrihlasku_Click;
		buttonPridatPrihlasku.Click += ButtonPridatPrihlasku_Click;
		buttonSmazatPrihlasku.Click += ButtonSmazatPrihlasku_Click;
		buttonZvolitSouborStredni.Click += ButtonZvolitSouborStredni_Click;
		buttonZvolitSouborVyssi.Click += ButtonZvolitSouborVyssi_Click;
		buttonVypsatPrihlasku.Click += ButtonVypsatPrihlasku_Click;
		buttonZobrazitPrihlasky.Click += ButtonZobrazitPrihlasky_Click;
		buttonVyhledatPrihlasku.Click += ButtonVyhledatPrihlasku_Click;
		
		listBoxStredniSkola.Click += ListBoxStredniSkola_Click;
		listBoxVyssiOdbornaSkola.Click += ListBoxVyssiOdbornaSkola_Click;
		Load += HlavniOkno_Load;

		/*===========*/
		cestaSouborStredni = @"C:\Users\Ignác\source\repos\IgnacBrychta\EvidencePrijimacihoRizeni_Vilimek\data mock\prihlaska stredni mock 3.txt";
		NacistPrihlasky(cestaSouborStredni, typeof(PrihlaskaStredniOdbornaSkola));
		ObnovitSeznamPrihlasek();
		PovolitPrihlaskovaTlacitka();
		textBoxCestaSouboruStredni.Text = cestaSouborStredni;
	}

	private void ButtonVyhledatPrihlasku_Click(object? sender, EventArgs e)
	{
		new OknoVyhledatPrihlasku(prihlaskyStredni, prihlaskyVyssi).Show();
	}

	private void ButtonZobrazitPrihlasky_Click(object? sender, EventArgs e)
	{
		if (cestaSouborStredni is not null) Process.Start(new ProcessStartInfo(cestaSouborStredni) { UseShellExecute = true });
		if(cestaSouborVyssi is not null) Process.Start(new ProcessStartInfo(cestaSouborVyssi) { UseShellExecute = true });
	}

	private void PovolitPrihlaskovaTlacitka()
	{
		buttonUpravitPrihlasku.Enabled = true;
		buttonPridatPrihlasku.Enabled =   true;
		buttonSmazatPrihlasku.Enabled =   true;
		buttonVypsatPrihlasku.Enabled =   true;
		buttonZobrazitPrihlasky.Enabled = true;
		buttonVyhledatPrihlasku.Enabled = true;
	}

	private void ZakazatPrihlaskovaTlacitka()
	{
		buttonUpravitPrihlasku.Enabled = false;
		buttonPridatPrihlasku.Enabled =   false;
		buttonSmazatPrihlasku.Enabled =   false;
		buttonVypsatPrihlasku.Enabled =   false;
		buttonZobrazitPrihlasky.Enabled = false;
		buttonVyhledatPrihlasku.Enabled = false;
	}

	private void ButtonVypsatPrihlasku_Click(object? sender, EventArgs e)
	{
		Prihlaska? p = ZiskatZvolenouPrihlasku();
		if (p is null) return;
		new OknoZobrazitPrihlasku(p).Show();
	}

	private void ButtonSmazatPrihlasku_Click(object? sender, EventArgs e)
	{
		Prihlaska? p = ZiskatZvolenouPrihlasku();
		if (p is null) return;
		if (p is PrihlaskaStredniOdbornaSkola pStredni) prihlaskyStredni.Remove(pStredni);
		else if (p is PrihlaskaVyssiOdbornaSkola pVyssi) prihlaskyVyssi.Remove(pVyssi);
		ObnovitSeznamPrihlasek();
	}

	private void ButtonZvolitSouborVyssi_Click(object? sender, EventArgs e)
	{
		OpenFileDialog pfd = new OpenFileDialog()
		{
			FileName = "prihlasky_vyssi.txt",
			DefaultExt = "*.txt",
			InitialDirectory = Directory.GetCurrentDirectory(),
			Filter = "prihlasky_vyssi.txt|*.txt",
			Title = "Zvolte soubor s pøihláškami pro vyšší odborné školy pro naètení.",
			Multiselect = false
		};
		DialogResult result = pfd.ShowDialog();
		if (result == DialogResult.OK)
		{
			NacistPrihlasky(pfd.FileName, typeof(PrihlaskaVyssiOdbornaSkola));
			cestaSouborVyssi = pfd.FileName;
			ObnovitSeznamPrihlasek();
			PovolitPrihlaskovaTlacitka();
			textBoxCestaVyssiSkoly.Text = pfd.FileName;
		}
		else
		{
			ZobrazitSouborNezvolen();
		}
	}

	private void ButtonZvolitSouborStredni_Click(object? sender, EventArgs e)
	{
		OpenFileDialog pfd = new OpenFileDialog()
		{
			FileName = "prihlasky_stredni.txt",
			DefaultExt = "*.txt",
			InitialDirectory = Directory.GetCurrentDirectory(),
			Filter = "prihlasky_stredni.txt|*.txt",
			Title = "Zvolte soubor s pøihláškami pro støední školy pro naètení.",
			Multiselect = false
		};
		DialogResult result = pfd.ShowDialog();
		if(result == DialogResult.OK)
		{
			NacistPrihlasky(pfd.FileName, typeof(PrihlaskaStredniOdbornaSkola));
			cestaSouborStredni = pfd.FileName;
			ObnovitSeznamPrihlasek();
			PovolitPrihlaskovaTlacitka();
			textBoxCestaSouboruStredni.Text = pfd.FileName;
		}
		else
		{
			ZobrazitSouborNezvolen();
		}
	}

	private static void ZobrazitSouborNezvolen()
	{
		MessageBox.Show(
			"Nebyl zvolen žádný soubor",
			"Soubor nezvolen",
			MessageBoxButtons.OK,
			MessageBoxIcon.Warning
			);
	}

	private void NacistPrihlasky(string cestaSouboru, Type typ)
	{
		bool stredni = typ == typeof(PrihlaskaStredniOdbornaSkola);
		if (stredni) prihlaskyStredni.Clear();
		else prihlaskyVyssi.Clear();

		using FileStream fs = new FileStream(cestaSouboru, FileMode.Open, FileAccess.Read);
		using StreamReader sr = new StreamReader(fs);
		string? line;
		_ = sr.ReadLine(); // pøeèíst header
		while((line = sr.ReadLine()) != null)
		{
			string[] data = line.Split(limits.Delimiter);
			if (stredni) PokusitPridatPrihlaskuStredni(data, line);
			else PokusitPridatPrihlaskuVyssi(data, line);
		}
	}

	private void PokusitPridatPrihlaskuStredni(string[] data, string? line)
	{
		PrihlaskaStredniOdbornaSkola p;
		try
		{
			p = new(
				int.Parse(data[0]),
				data[1],
				data[2],
				DateTime.ParseExact(data[3], limits.DateFormat, CultureInfo.InvariantCulture),
				(OborStredni)int.Parse(data[4]),
				int.Parse(data[5]),
				bool.Parse(data[6])
				);
			if (!Prihlaska.JsouUdajeSpravne(limits, p.jmeno, p.prijmeni, p.datumNarozeni)) throw new Exception();
		}
		catch (Exception)
		{
			ZobrazitChybuNacitani(line);
			return;
		}
		prihlaskyStredni.Add(p);
	}

	private void PokusitPridatPrihlaskuVyssi(string[] data, string? line)
	{
		PrihlaskaVyssiOdbornaSkola p;
		try
		{
			p = new(
				int.Parse(data[0]),
				data[1],
				data[2],
				DateTime.ParseExact(data[3], limits.DateFormat, CultureInfo.InvariantCulture),
				(OborVyssiOdborna)int.Parse(data[4]),
				int.Parse(data[5]),
				bool.Parse(data[6]),
				decimal.Parse(data[7])
				);
			if (!PrihlaskaVyssiOdbornaSkola.JsouUdajeSpravne(limits, p.jmeno, p.prijmeni, p.datumNarozeni, p.prumerZnamekMaturitniZkousky)) throw new Exception();
		}
		catch (Exception)
		{
			ZobrazitChybuNacitani(line);
			return;
		}
		prihlaskyVyssi.Add(p);
	}

	private static void ZobrazitChybuNacitani(string? line)
	{
		MessageBox.Show(
				$"Nebylo možné naèíst pøihlášku s tìmito údaji: {line}",
				"Chyba naètení pøihlášky",
				MessageBoxButtons.OK,
				MessageBoxIcon.Error
				);
	}

	private void ListBoxVyssiOdbornaSkola_Click(object? sender, EventArgs e)
	{
		listBoxStredniSkola.SelectedIndex = -1;
		zvolenySeznam = (ListBox?)sender;
	}

	private void ListBoxStredniSkola_Click(object? sender, EventArgs e)
	{
		listBoxVyssiOdbornaSkola.SelectedIndex = -1;
		zvolenySeznam = (ListBox?)sender;
	}

	private void ListBox_SelectedIndexChanged(object? sender, EventArgs e)
	{
		if (zmenaUzamcena) return;
		zmenaUzamcena = true;
		zvolenySeznam = (ListBox?)sender;
		if (zvolenySeznam == listBoxStredniSkola) listBoxVyssiOdbornaSkola.SelectedIndex = -1;
		else listBoxStredniSkola.SelectedIndex = -1;
		zmenaUzamcena = false;
	}

	private void HlavniOkno_Load(object? sender, EventArgs e)
	{
		ObnovitSeznamPrihlasek();
		listBoxStredniSkola.SelectedIndex = -1;
		listBoxVyssiOdbornaSkola.SelectedIndex = -1;
	}

	private void ButtonPridatPrihlasku_Click(object? sender, EventArgs e)
	{
		new OknoNovaPrihlaska(limits, NovaPrihlaska).Show();
	}

	private object? NovaPrihlaska(Prihlaska prihlaska)
	{
		/*
		*   Tento systém vypadá hroznì, dlouhodbì není udržitelný, ale funguje lol
		*/
		if (prihlaska is PrihlaskaStredniOdbornaSkola pStredni) prihlaskyStredni.Add(pStredni);
		else if (prihlaska is PrihlaskaVyssiOdbornaSkola pVyssi) prihlaskyVyssi.Add(pVyssi);
		ObnovitSeznamPrihlasek();
		return null;
	}

	private Prihlaska? ZiskatZvolenouPrihlasku()
	{
		if (zvolenySeznam is null || zvolenySeznam.SelectedIndex == -1) return null;
		Prihlaska p;
		if (zvolenySeznam == listBoxStredniSkola) p = prihlaskyStredni[zvolenySeznam.SelectedIndex];
		else p = prihlaskyVyssi[zvolenySeznam.SelectedIndex];
		return p;

	}

	private void ButtonUpravitPrihlasku_Click(object? sender, EventArgs e)
	{
		Prihlaska? p = ZiskatZvolenouPrihlasku();
		if(p is null) return;
		new OknoUpravitPrihlasku(p, limits, ObnovitSeznamPrihlasek).Show();
	}

	internal void ObnovitSeznamPrihlasek()
	{
		listBoxStredniSkola.DataSource = null;
		listBoxVyssiOdbornaSkola.DataSource = null;
		listBoxStredniSkola.Items.Clear();
		listBoxVyssiOdbornaSkola.Items.Clear();
		listBoxStredniSkola.DataSource = prihlaskyStredni;
		listBoxVyssiOdbornaSkola.DataSource = prihlaskyVyssi;

		listBoxStredniSkola.DisplayMember = "Informace";
		listBoxVyssiOdbornaSkola.DisplayMember = "Informace";
	}
}