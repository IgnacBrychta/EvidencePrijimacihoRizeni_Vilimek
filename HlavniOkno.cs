using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Web;

#warning GLOBAL: designer v mnohých souborech háže chyby asi protože mnohá okna nemají dostupný výchozí konstruktor (bez argumentù), proto se asi i to dìdictví v designeru nezobrazuje
namespace EvidencePrijimacihoRizeni_Vilimek;

public partial class HlavniOkno : Form
{
	List<PrihlaskaVyssiOdbornaSkola> prihlaskyVyssi = new();
	List<PrihlaskaStredniOdbornaSkola> prihlaskyStredni = new();
	List<Prihlaska> smazanePrihlasky = new();
	readonly DbValuesLimits limits = new DbValuesLimits
	{
		MaxCharacters = 255,
		MinAge = 15,
		Delimiter = ';',
		DateFormat = "dd.MM.yyyy",
		NejlepsiZnamka = 1.0m,
		NejhorsiZnamka = 5.0m,
		MaturitniPrumerProPrijeti = 1.5m,
		OborStredniNejvyssiIndex = Enum.GetValues<OborStredni>().Select(x => (int)x).Max(),
		OborVyssiOdbornaNejvyssiIndex = Enum.GetValues<OborVyssiOdborna>().Select(x => (int)x).Max()
	};
	ListBox? zvolenySeznam = null;
	bool zmenaUzamcena = false;
	string? cestaSouborStredni = null;
	string? cestaSouborVyssi = null;
	int nejvyssiIdStredni = -1;
	int nejvyssiIdVyssiOdborna = -1;
	Db db;
	const string vychoziNazevSouboruStredni = "prihlasky_stredni.txt";
	const string vychoziNazevSouboruVyssi = "prihlasky_vyssi.txt";
	public RectangleF resizedScreen;
	public static string IconFilePath => "../../../res/vilimek-s-kuretem.ico";
	const string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Ignác\\source\\repos\\IgnacBrychta\\EvidencePrijimacihoRizeni_Vilimek\\db\\db\\evidence.mdf;Integrated Security=True;Connect Timeout=30";
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
		buttonZobrazitPrihlasky.Click += ButtonZobrazitPrijate_Click;
		buttonVyhledatPrihlasku.Click += ButtonVyhledatPrihlasku_Click;
		buttonSynchronizovat.Click += ButtonSynchronizace_Click;

		listBoxStredniSkola.Click += ListBoxStredniSkola_Click;
		listBoxVyssiOdbornaSkola.Click += ListBoxVyssiOdbornaSkola_Click;

		Load += HlavniOkno_Load;
		FormClosing += HlavniOkno_FormClosing;
		FormClosed += HlavniOkno_FormClosed;

		toolStripMenuItemNacistStredni.Click += ButtonZvolitSouborStredni_Click;
		toolStripMenuItemNacistVyssi.Click += ButtonZvolitSouborVyssi_Click;
		toolStripMenuItemEditovatPrihlasku.Click += ButtonUpravitPrihlasku_Click;
		toolStripMenuItemNovaPrihlaska.Click += ButtonPridatPrihlasku_Click;
		toolStripMenuItemSmazatPrihlasku.Click += ButtonSmazatPrihlasku_Click;
		toolStripMenuItemVyhledatPodleId.Click += ButtonVyhledatPrihlasku_Click;
		toolStripMenuItemVypsatPrihlasku.Click += ButtonVypsatPrihlasku_Click;
		toolStripMenuItemZobrazitPrihlaskoveSoubory.Click += ButtonZobrazitPrihlasky_Click;
		toolStripMenuItemZavrit.Click += (s, e) => Close();
		toolStripMenuItemSynchronizovat.Click += ButtonSynchronizace_Click;
		toolStripMenuItemZobrazitPrijate.Click += ButtonZobrazitPrijate_Click;
		toolStripMenuItem_VytvoritSouborSS.Click += ToolStripMenuItem_VytvoritSouborSS_Click;
		toolStripMenuItem_VytvoritSouborVS.Click += ToolStripMenuItem_VytvoritSouborVS_Click;

		db = new Db(connectionString);
		Icon = new Icon(IconFilePath);

		SetColorTheme(this);
		SetControlTheme(this);
		MessageBox.Show(@"
			Tento program jsem vyvíjel jak na 10"" monitoru s 200% škálováním,
			tak na 25"" monitoru se 100% škálováním, kvùli èemuž se mi dosáhnout konzistentního vzhledu, proto
			doporuèuji tento program spouštìt se systémovým 100% škálováním, nebo nastavit jako primární systémový monitor ten se 100% škálováním. 
			Zároveò je nutné si pøepsat pøipojovací øetìzec do databáze ve zdrojovém kódu."
			.Replace("\t", "").Replace(Environment.NewLine, ""),
			"Informace ohlednì zobrazování",
			MessageBoxButtons.OK,
			MessageBoxIcon.Information
		);
		
#if development
		cestaSouborStredni = @"C:\Users\Ignác\source\repos\IgnacBrychta\EvidencePrijimacihoRizeni_Vilimek\data mock\mock prihlasky na stredni.txt";
		cestaSouborVyssi = @"C:\Users\Ignác\source\repos\IgnacBrychta\EvidencePrijimacihoRizeni_Vilimek\data mock\mock prihlasky na vyssi odbornou.txt";
		NacistPrihlasky(cestaSouborStredni, typeof(PrihlaskaStredniOdbornaSkola));
		textBoxCestaSouboruStredni.Text = cestaSouborStredni;

		NacistPrihlasky(cestaSouborVyssi, typeof(PrihlaskaVyssiOdbornaSkola));
		ObnovitSeznamPrihlasek();
		PovolitPrihlaskovaTlacitka();
		textBoxCestaVyssiSkoly.Text = cestaSouborVyssi;
#endif
	}

	private void ToolStripMenuItem_VytvoritSouborVS_Click(object? sender, EventArgs e)
	{
		FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog()
		{
			Description = "Zvolte složku pro vytvoøení souboru pro pøihlášky na VOŠ.",
			UseDescriptionForTitle = true,
			ShowNewFolderButton = true
		};
		DialogResult result = folderBrowserDialog.ShowDialog();
		if (result == DialogResult.OK)
		{
			VytvoritPrihlaskovySoubor(folderBrowserDialog.SelectedPath, typeof(PrihlaskaVyssiOdbornaSkola));
			_ = MessageBox.Show(
				"Soubor vytvoøen, ale nezvolen.",
				"Soubor vytvoøen.",
				MessageBoxButtons.OK,
				MessageBoxIcon.Information
				);
		}
		else
		{
			_ = MessageBox.Show(
				"Nebyla zvolena složka, soubor nevytvoøen.",
				"Soubor nevytvoøen",
				MessageBoxButtons.OK,
				MessageBoxIcon.Warning
				);
		}
	}

	private void ToolStripMenuItem_VytvoritSouborSS_Click(object? sender, EventArgs e)
	{
		FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog()
		{
			Description = "Zvolte složku pro vytvoøení souboru pro pøihlášky na SŠ.",
			UseDescriptionForTitle = true,
			ShowNewFolderButton = true
		};
		DialogResult result = folderBrowserDialog.ShowDialog();
		if (result == DialogResult.OK)
		{
			VytvoritPrihlaskovySoubor(folderBrowserDialog.SelectedPath, typeof(PrihlaskaStredniOdbornaSkola));
			_ = MessageBox.Show(
				"Soubor vytvoøen, ale nezvolen.",
				"Soubor vytvoøen.",
				MessageBoxButtons.OK,
				MessageBoxIcon.Information
				);
		}
		else
		{
			_ = MessageBox.Show(
				"Nebyla zvolena složka, soubor nevytvoøen.",
				"Soubor nevytvoøen",
				MessageBoxButtons.OK,
				MessageBoxIcon.Warning
				);
		}
	}

	private static void VytvoritPrihlaskovySoubor(string cesta, Type typ)
	{
		bool stredni = typ == typeof(PrihlaskaStredniOdbornaSkola);
		using FileStream fs = new FileStream(
			stredni
			? cesta + "/" + vychoziNazevSouboruStredni 
			: cesta + "/" + vychoziNazevSouboruVyssi,
			FileMode.CreateNew,
			FileAccess.ReadWrite
			);
		using StreamWriter sw = new StreamWriter(fs);
		sw.WriteLine("MaxId=0");
		sw.WriteLine(
			stredni
			? PrihlaskaStredniOdbornaSkola.ZiskatHeader()
			: PrihlaskaVyssiOdbornaSkola.ZiskatHeader()
			);
	}

	public static void SetColorTheme(Control parent)
	{
#if !ForceBlack
		return;
#else
		foreach (Control control in parent.Controls)
		{
			SetControlTheme(control);
			if (control.HasChildren) SetColorTheme(control);
		}
#endif
	}

	public static void SetControlTheme(Control control)
	{
#if ForceBlack
		control.BackColor = Color.Black;
		control.ForeColor = Color.White;
#endif
	}
	private void HlavniOkno_FormClosed(object? sender, FormClosedEventArgs e)
	{
		db.Dispose();
	}

	private void ButtonSynchronizace_Click(object? sender, EventArgs e)
	{
		DialogResult result = DialogResult.None;
		foreach (Prihlaska prihlaska in prihlaskyStredni)
		{
			if (prihlaska.DbStav != DbStav.Aktualni && prihlaska.DbStav != DbStav.Zadny)
				result |= db.SynchronizovatPrihlasku(prihlaska);
		}

		foreach (Prihlaska prihlaska in prihlaskyVyssi)
		{
			if (prihlaska.DbStav != DbStav.Aktualni && prihlaska.DbStav != DbStav.Zadny)
				result |= db.SynchronizovatPrihlasku(prihlaska);
		}

		foreach (Prihlaska prihlaska in smazanePrihlasky)
		{
			result |= db.SynchronizovatPrihlasku(prihlaska);
		}
		smazanePrihlasky.Clear();

		if (result.HasFlag(DialogResult.Abort))
		{
			MessageBox.Show(
				"Pøi synchronizace nastala chyba, databáze není správnì synchronizovaná",
				"Chyba synchronizace",
				MessageBoxButtons.OK,
				MessageBoxIcon.Error
				);
		}
		else if (result.HasFlag(DialogResult.OK))
		{
			MessageBox.Show(
				"Synchronizace byla úspìšná.",
				"OK",
				MessageBoxButtons.OK,
				MessageBoxIcon.Information
				);
		}
		else
		{
			MessageBox.Show(
				"Všechna data jsou aktuální.",
				"Není co synchronizovat",
				MessageBoxButtons.OK,
				MessageBoxIcon.Information
				);
		}
	}

	private void HlavniOkno_FormClosing(object? sender, FormClosingEventArgs e)
	{
		bool dbSynced = !prihlaskyVyssi.Any(x => x.DbStav != DbStav.Aktualni) &&
			!prihlaskyStredni.Any(x => x.DbStav != DbStav.Aktualni) &&
			smazanePrihlasky.Count == 0;
		e.Cancel = DialogResult.No == MessageBox.Show(
			$"Opravdu chcete aplikaci zavøít? {(dbSynced ? string.Empty : "\nNENÍ SYNCHRONIZOVANÁ DATABÁZE!")}",
			"Opravdu zavøít?",
			MessageBoxButtons.YesNo,
			MessageBoxIcon.Question
			);
	}

	private void ButtonVyhledatPrihlasku_Click(object? sender, EventArgs e)
	{
		Form okno = new OknoVyhledatPrihlasku(prihlaskyStredni, prihlaskyVyssi, AktualizovatZvolenyIndex);
		//ResizeAllControls(okno);
		SetColorTheme(okno);
		SetControlTheme(okno);
		okno.Show();
	}

	private object? AktualizovatZvolenyIndex(Prihlaska nalezenaPrihlaska)
	{
		foreach (Prihlaska prihlaska in prihlaskyStredni)
		{
			if (nalezenaPrihlaska == prihlaska)
			{
				zvolenySeznam = listBoxStredniSkola;
				listBoxVyssiOdbornaSkola.SelectedIndex = -1;
				listBoxStredniSkola.SelectedIndex = listBoxStredniSkola.Items.IndexOf(prihlaska);
				return null;
			}
		}

		foreach (Prihlaska prihlaska in prihlaskyVyssi)
		{
			if (nalezenaPrihlaska == prihlaska)
			{
				zvolenySeznam = listBoxVyssiOdbornaSkola;
				listBoxStredniSkola.SelectedIndex = -1;
				listBoxVyssiOdbornaSkola.SelectedIndex = listBoxVyssiOdbornaSkola.Items.IndexOf(prihlaska);
				return null;
			}
		}
		return null;
	}

	private void ButtonZobrazitPrijate_Click(object? sender, EventArgs e)
	{
		Form okno = new OknoPrijatePrihlasky(prihlaskyStredni, prihlaskyVyssi);
		okno.Show();
		SetColorTheme(okno);
		SetControlTheme(okno);
	}

	private void ButtonZobrazitPrihlasky_Click(object? sender, EventArgs e)
	{
		if (cestaSouborStredni is not null) Process.Start(new ProcessStartInfo(cestaSouborStredni) { UseShellExecute = true });
		if (cestaSouborVyssi is not null) Process.Start(new ProcessStartInfo(cestaSouborVyssi) { UseShellExecute = true });
	}

	private void PovolitPrihlaskovaTlacitka()
	{
		buttonUpravitPrihlasku.Enabled = true;
		buttonPridatPrihlasku.Enabled = true;
		buttonSmazatPrihlasku.Enabled = true;
		buttonVypsatPrihlasku.Enabled = true;
		buttonZobrazitPrihlasky.Enabled = true;
		buttonVyhledatPrihlasku.Enabled = true;
	}

	private void ZakazatPrihlaskovaTlacitka()
	{
		buttonUpravitPrihlasku.Enabled = false;
		buttonPridatPrihlasku.Enabled = false;
		buttonSmazatPrihlasku.Enabled = false;
		buttonVypsatPrihlasku.Enabled = false;
		buttonZobrazitPrihlasky.Enabled = false;
		buttonVyhledatPrihlasku.Enabled = false;
	}

	private void ButtonVypsatPrihlasku_Click(object? sender, EventArgs e)
	{
		Prihlaska? p = ZiskatZvolenouPrihlasku();
		if (p is null) return;
		Form okno = new OknoZobrazitPrihlasku(p);
		okno.Show();
		SetColorTheme(okno);
		SetControlTheme(okno);
	}

	private void ButtonSmazatPrihlasku_Click(object? sender, EventArgs e)
	{
		Prihlaska? p = ZiskatZvolenouPrihlasku();
		if (p is null) return;
		// nejvyssi mozne id se nesnizuje
		if (p is PrihlaskaStredniOdbornaSkola pStredni)
		{
			pStredni.DbStav = DbStav.NaSmazani;
			smazanePrihlasky.Add(pStredni);
			prihlaskyStredni.Remove(pStredni);
			SmazatPrihlasku(pStredni, cestaSouborStredni!);
		}
		else if (p is PrihlaskaVyssiOdbornaSkola pVyssi)
		{
			pVyssi.DbStav = DbStav.NaSmazani;
			smazanePrihlasky.Add(pVyssi);
			prihlaskyVyssi.Remove(pVyssi);
			SmazatPrihlasku(pVyssi, cestaSouborVyssi!);
		}
		ObnovitSeznamPrihlasek();
	}

	private void ButtonZvolitSouborVyssi_Click(object? sender, EventArgs e)
	{
		OpenFileDialog pfd = new OpenFileDialog()
		{
			FileName = vychoziNazevSouboruVyssi,
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
			FileName = vychoziNazevSouboruStredni,
			DefaultExt = "*.txt",
			InitialDirectory = Directory.GetCurrentDirectory(),
			Filter = "prihlasky_stredni.txt|*.txt",
			Title = "Zvolte soubor s pøihláškami pro støední školy pro naètení.",
			Multiselect = false
		};
		DialogResult result = pfd.ShowDialog();
		if (result == DialogResult.OK)
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
		if (!ZiskatNejvyssiId(sr.ReadLine(), stredni))
		{
			MessageBox.Show("Neplatná data.", "Neplatná data", MessageBoxButtons.OK, MessageBoxIcon.Error);
			return;
		}
		_ = sr.ReadLine(); // pøeèíst header
		while ((line = sr.ReadLine()) != null)
		{
			string[] data = line.Split(limits.Delimiter);
			if (stredni) PokusitPridatPrihlaskuStredni(data, line);
			else PokusitPridatPrihlaskuVyssi(data, line);
		}
	}

	private bool ZiskatNejvyssiId(string? text, bool stredni)
	{
		if (text is null) return false;

		int data = -1;
		try
		{
			data = int.Parse(text.Split("=")[1]);
		}
		catch (Exception) { }
		if (stredni) nejvyssiIdStredni = data;
		else nejvyssiIdVyssiOdborna = data;
		return true;
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
				DateTime.Parse(data[3]),
				(OborStredni)int.Parse(data[4]),
				int.Parse(data[5]),
				bool.Parse(data[6])
				);
			p.DbStav = DbStav.Aktualni;

			if (!Prihlaska.JsouUdajeSpravne(limits, p.jmeno, p.prijmeni, p.datumNarozeni) || p.IndexOboru > limits.OborStredniNejvyssiIndex)
				throw new Exception();
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
				DateTime.Parse(data[3]),
				(OborVyssiOdborna)int.Parse(data[4]),
				int.Parse(data[5]),
				bool.Parse(data[6]),
				decimal.Parse(data[7])
				);
			p.DbStav = DbStav.Aktualni;

			if (!PrihlaskaVyssiOdbornaSkola.JsouUdajeSpravne(limits, p.jmeno, p.prijmeni, p.datumNarozeni, p.prumerZnamekMaturitniZkousky) || p.IndexOboru > limits.OborVyssiOdbornaNejvyssiIndex)
				throw new Exception();
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
				$"Nebylo možné naèíst pøihlášku s tìmito údaji:\n{line}",
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
		MaximumSize = Size;
		MinimumSize = Size;
	}

	private void ButtonPridatPrihlasku_Click(object? sender, EventArgs e)
	{
		Form okno = new OknoNovaPrihlaska(limits, NovaPrihlaska, cestaSouborStredni, cestaSouborVyssi);
		if (okno.Disposing || okno.IsDisposed) return;
		SetColorTheme(okno);
		SetControlTheme(okno);
		okno.Show();
	}

	private object? NovaPrihlaska(Prihlaska prihlaska)
	{
		/*
		*   Tento systém vypadá hroznì, dlouhodbì není udržitelný, ale funguje lol
		*/

		if (prihlaskyStredni.Any(x => x.JsouPrihlaskyStejneKromeId(prihlaska)) ||
			prihlaskyVyssi.Any(x => x.JsouPrihlaskyStejneKromeId(prihlaska)))
		{
			MessageBox.Show(
				"Již existuje pøihláška s pøesnì stejnými údaji. Pøihláška nevytvoøena.",
				"Pøihláška nevytvoøena",
				MessageBoxButtons.OK,
				MessageBoxIcon.Warning
				);
			return null;
		}

		if (prihlaska is PrihlaskaStredniOdbornaSkola pStredni)
		{
			nejvyssiIdStredni++;
			pStredni.Id = nejvyssiIdStredni;
			prihlaskyStredni.Add(pStredni);
			PripsatNovouPrihlasku(pStredni, cestaSouborStredni!);
		}
		else if (prihlaska is PrihlaskaVyssiOdbornaSkola pVyssi)
		{
			nejvyssiIdVyssiOdborna++;
			pVyssi.Id = nejvyssiIdVyssiOdborna;
			prihlaskyVyssi.Add(pVyssi);
			PripsatNovouPrihlasku(pVyssi, cestaSouborVyssi!);
		}
		ObnovitSeznamPrihlasek();
		return null;
	}

	private void SmazatPrihlasku(Prihlaska p, string cesta)
	{
		if (cesta is null) throw new Exception("chyba");

		string tempFilePath = Path.GetTempFileName();

		using FileStream fs = new FileStream(cesta, FileMode.Open, FileAccess.ReadWrite);
		using StreamReader sr = new StreamReader(fs);
		using StreamWriter sw = new StreamWriter(tempFilePath);

		string? line;

		sw.WriteLine("MaxId=" + (p is PrihlaskaStredniOdbornaSkola ? nejvyssiIdStredni : nejvyssiIdVyssiOdborna));
		_ = sr.ReadLine(); // pøepis MaxId
		while ((line = sr.ReadLine()) is not null)
		{
			if (line.Split(limits.Delimiter)[0] != p.Id.ToString())
			{
				sw.WriteLine(line); // zapsat pouze vyhovujici radky
			}
		}

		sw.Close(); sr.Close(); fs.Close();
		File.Delete(cesta);
		File.Move(tempFilePath, cesta);
	}

	private void PripsatNovouPrihlasku(Prihlaska p, string cesta)
	{
		if (cesta is null) throw new Exception("chyba");

		string tempFilePath = Path.GetTempFileName();

		using FileStream fs = new FileStream(cesta, FileMode.Open, FileAccess.ReadWrite);
		using StreamReader sr = new StreamReader(fs);
		using StreamWriter sw = new StreamWriter(tempFilePath);

		string? line;

		sw.WriteLine("MaxId=" + (p is PrihlaskaStredniOdbornaSkola ? nejvyssiIdStredni : nejvyssiIdVyssiOdborna));
		_ = sr.ReadLine(); // pøepis MaxId
		while ((line = sr.ReadLine()) is not null)
		{
			sw.WriteLine(line);
		}
		sw.WriteLine(p.ZiskatTvarProZapsani(limits));

		sw.Close(); sr.Close(); fs.Close();
		File.Delete(cesta);
		File.Move(tempFilePath, cesta);
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
		if (p is null) return;
		Form okno = new OknoUpravitPrihlasku(p, limits, ObnovitSeznamPrihlasekUpravitInformace);
		okno.Show();
		SetColorTheme(okno);
		SetControlTheme(okno);
	}

	private void PrepsatJedenRadekPrepsanimCelehoSouboru(Prihlaska p, string? cesta)
	{
		if (cesta is null) throw new Exception("chyba");

		string tempFilePath = Path.GetTempFileName();

		using FileStream fs = new FileStream(cesta, FileMode.Open, FileAccess.ReadWrite);
		using StreamReader sr = new StreamReader(fs);
		using StreamWriter sw = new StreamWriter(tempFilePath);

		string? line;

		while ((line = sr.ReadLine()) is not null)
		{
			if (line.Split(limits.Delimiter)[0] != p.Id.ToString())
			{
				sw.WriteLine(line);
			}
			else
			{
				sw.WriteLine(p.ZiskatTvarProZapsani(limits));
			}
		}

		sw.Close(); sr.Close(); fs.Close();
		File.Delete(cesta);
		File.Move(tempFilePath, cesta);
	}

	private object? ObnovitSeznamPrihlasekUpravitInformace(Prihlaska p)
	{
		PrepsatJedenRadekPrepsanimCelehoSouboru(p, p is PrihlaskaStredniOdbornaSkola ? cestaSouborStredni : cestaSouborVyssi);
		ObnovitSeznamPrihlasek();
		return null;
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

		listBoxStredniSkola.SelectedIndex = -1;
		listBoxVyssiOdbornaSkola.SelectedIndex = -1;
		groupBox_prihlaskyStredni.Text = $"Pøihlášky na støední školu ({prihlaskyStredni.Count})";
		groupBox_prihlaskyVyssi.Text = $"Pøihlášky na vyšší odb. školu ({prihlaskyVyssi.Count})";
	}
}