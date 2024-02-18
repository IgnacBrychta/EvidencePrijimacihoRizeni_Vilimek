using System.Runtime.Serialization;

namespace EvidencePrijimacihoRizeni_Vilimek;

public partial class OknoUpravitPrihlasku : VychoziPrihlaskoveOkno
{
	DbValuesLimits limits;
	Func<Prihlaska, object?> ObnovitSeznamPrihlasekUpravitInformace;
	public OknoUpravitPrihlasku(Prihlaska prihlaska, DbValuesLimits limits, Func<Prihlaska, object?> ObnovitSeznamPrihlasekUpravitInformace) : base(prihlaska)
	{
		InitializeComponent();
		Text = prihlaska.Informace;
		zakazatReakciNaZmenu = true;
		button_potvrditZmeny.Click += Button_potvrditZmeny_Click;
		button_zrusit.Click += Button_zrusit_Click;
		this.limits = limits;
		this.ObnovitSeznamPrihlasekUpravitInformace = ObnovitSeznamPrihlasekUpravitInformace;

		prihlaskaNaStredni = prihlaska is PrihlaskaStredniOdbornaSkola;
		radioButton_stredni.Checked = prihlaskaNaStredni;
		radioButton_vyssiOdborna.Checked = !prihlaskaNaStredni;
		radioButton_stredni.Enabled = false;
		radioButton_vyssiOdborna.Enabled = false;

		textBox_jmeno.Text = prihlaska.jmeno;
		textBox_prijmeni.Text = prihlaska.prijmeni;
		monthCalendar_datumNarozeni.SelectionStart = prihlaska.datumNarozeni;
		NaplnitComboBoxDostupnymiObory();
		comboBox_obor.SelectedIndex = prihlaska.IndexOboru;
		textBox_bodyPrijimaciRizeni.Text = prihlaska.bodyPrijimacihoRizeni.ToString();
		if (!prihlaskaNaStredni) textBox_prumerZnamekMatZkouska.Text = ((PrihlaskaVyssiOdbornaSkola)prihlaska).prumerZnamekMaturitniZkousky.ToString();
		else groupBox_bodyMatZkouska.Visible = false;
		radioButton_prijat.Checked = prihlaska.prijat;
		radioButton_neprijat.Checked = !prihlaska.prijat;

		zakazatReakciNaZmenu = false;
	}

	private void Button_zrusit_Click(object? sender, EventArgs e)
	{
		Close();
	}

	private void Button_potvrditZmeny_Click(object? sender, EventArgs e)
	{
		bool bodyPrijimaciRizeniOK = int.TryParse(textBox_bodyPrijimaciRizeni.Text, out int bodyPrijimaciRizeni);
		bool maturitniZkouskaOK = decimal.TryParse(textBox_prumerZnamekMatZkouska.Text, out decimal bodyMaturitniZkouska) || prihlaskaNaStredni;
		bool nastalaZmena = false;
		if (bodyPrijimaciRizeniOK && maturitniZkouskaOK && Prihlaska.JsouUdajeSpravne(limits, textBox_jmeno.Text, textBox_prijmeni.Text, monthCalendar_datumNarozeni.SelectionStart))
		{
			nastalaZmena |= prihlaska!.jmeno != textBox_jmeno.Text;
			prihlaska.jmeno = textBox_jmeno.Text;
			nastalaZmena |= prihlaska.prijmeni != textBox_prijmeni.Text;
			prihlaska.prijmeni = textBox_prijmeni.Text;
			nastalaZmena |= prihlaska.datumNarozeni != monthCalendar_datumNarozeni.SelectionStart;
			prihlaska.datumNarozeni = monthCalendar_datumNarozeni.SelectionStart;
			nastalaZmena |= prihlaska.bodyPrijimacihoRizeni != bodyPrijimaciRizeni;
			prihlaska.bodyPrijimacihoRizeni = bodyPrijimaciRizeni;
			nastalaZmena |= prihlaska.prijat != radioButton_prijat.Checked;
			prihlaska.prijat = radioButton_prijat.Checked;
			nastalaZmena |= prihlaska.IndexOboru != comboBox_obor.SelectedIndex;
			if (!prihlaskaNaStredni)
			{
				PrihlaskaVyssiOdbornaSkola p = (PrihlaskaVyssiOdbornaSkola)prihlaska;
				nastalaZmena |= p.prumerZnamekMaturitniZkousky != bodyMaturitniZkouska;
				p.prumerZnamekMaturitniZkousky = bodyMaturitniZkouska;
				p.obor = (OborVyssiOdborna)comboBox_obor.SelectedIndex;
			}
			else
			{
				PrihlaskaStredniOdbornaSkola p = (PrihlaskaStredniOdbornaSkola)prihlaska;
				p.obor = (OborStredni)comboBox_obor.SelectedIndex;
			}
			prihlaska.DbStav = nastalaZmena ? DbStav.Upravena : prihlaska.DbStav;
			ObnovitSeznamPrihlasekUpravitInformace(prihlaska);
			Close();
		}
		else
		{
			_ = MessageBox.Show(
				"Vložené údaje jsou nesprávné, zkontrolujte, zda jsou všechny ve správném formátu a rozsahu.",
				"Nesprávné vložené údaje",
				MessageBoxButtons.OK,
				MessageBoxIcon.Error);
		}
	}
}
