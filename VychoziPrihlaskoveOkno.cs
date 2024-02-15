namespace EvidencePrijimacihoRizeni_Vilimek;

public partial class VychoziPrihlaskoveOkno : Form
{
	protected Prihlaska prihlaska;
	protected bool zakazatReakciNaZmenu = false;
	public bool prihlaskaNaStredni = false;
	public VychoziPrihlaskoveOkno(Prihlaska prihlaska)
	{
		InitializeComponent();
		this.prihlaska = prihlaska;
		radioButton_stredni.Checked = true;
		radioButton_stredni.CheckedChanged += RadioButton_stredni_CheckedChanged;
		monthCalendar_datumNarozeni.MaxSelectionCount = 1;
		Load += VychoziPrihlaskoveOkno_Load;
	}

	public VychoziPrihlaskoveOkno() { }

	private void VychoziPrihlaskoveOkno_Load(object? sender, EventArgs e)
	{
		MinimumSize = Size;
		MaximumSize = Size;
	}

	protected void RadioButton_stredni_CheckedChanged(object? sender, EventArgs e)
	{
		if (zakazatReakciNaZmenu) return;
		prihlaskaNaStredni = radioButton_stredni.Checked;
		groupBox_bodyMatZkouska.Visible = !prihlaskaNaStredni;
		comboBox_obor.Text = string.Empty;
		comboBox_obor.Items.Clear();
		NaplnitComboBoxDostupnymiObory();
	}

	protected void NaplnitComboBoxDostupnymiObory()
	{
		Type obory = prihlaskaNaStredni ? typeof(OborStredni) : typeof(OborVyssiOdborna);
		foreach (object obor in Enum.GetValues(obory))
		{
			comboBox_obor.Items.Add(obor.ToString());
		}
	}

	protected void ZakazatUpravovaniUdaju()
	{
		textBox_jmeno.Enabled = false;
		textBox_prijmeni.Enabled = false;
		monthCalendar_datumNarozeni.Enabled = false;
		radioButton_stredni.Enabled = false;
		radioButton_vyssiOdborna.Enabled = false;
		comboBox_obor.Enabled = false;
		textBox_bodyPrijimaciRizeni.Enabled = false;
		groupBox_bodyMatZkouska.Enabled = false;
		radioButton_prijat.Enabled = false;
		radioButton_neprijat.Enabled = false;
	}

	protected void ZobrazitUdajeUlozenaPrihlaska()
	{
		textBox_jmeno.Text = prihlaska.jmeno;
		textBox_prijmeni.Text = prihlaska.prijmeni;
		monthCalendar_datumNarozeni.SelectionStart = prihlaska.datumNarozeni;
		radioButton_stredni.Checked = prihlaskaNaStredni;
		radioButton_vyssiOdborna.Checked = !prihlaskaNaStredni;
		comboBox_obor.SelectedIndex = prihlaska.IndexOboru;
		textBox_bodyPrijimaciRizeni.Text = prihlaska.bodyPrijimacihoRizeni.ToString();
		textBox_prumerZnamekMatZkouska.Text = !prihlaskaNaStredni ? ((PrihlaskaVyssiOdbornaSkola)prihlaska).prumerZnamekMaturitniZkousky.ToString() : string.Empty;
		radioButton_prijat.Checked = prihlaska.prijat;
		radioButton_neprijat.Checked = !prihlaska.prijat;
	}

	protected void VycistitVstupniPole()
	{
		textBox_jmeno.Text = string.Empty;
		textBox_prijmeni.Text = string.Empty;
		monthCalendar_datumNarozeni.SelectionStart = DateTime.Now;
		radioButton_stredni.Checked = prihlaskaNaStredni;
		radioButton_vyssiOdborna.Checked = !prihlaskaNaStredni;
		comboBox_obor.SelectedIndex = -1;
		textBox_bodyPrijimaciRizeni.Text = string.Empty;
		textBox_prumerZnamekMatZkouska.Text = string.Empty;
		radioButton_prijat.Checked = false;
		radioButton_neprijat.Checked = false;
	}
}
