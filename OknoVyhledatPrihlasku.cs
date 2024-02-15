using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EvidencePrijimacihoRizeni_Vilimek;

public partial class OknoVyhledatPrihlasku : VychoziPrihlaskoveOkno
{
	List<PrihlaskaStredniOdbornaSkola> prihlaskyStredni;
	List<PrihlaskaVyssiOdbornaSkola> prihlaskyVyssi;
	public int vyhledavaneId = 0;
	Func<Prihlaska, object?> AktualizovatZvolenyIndex;
	string vychoziText = "Vyhledávání";
	public OknoVyhledatPrihlasku(List<PrihlaskaStredniOdbornaSkola> prihlaskyStredni, List<PrihlaskaVyssiOdbornaSkola> prihlaskyVyssi, Func<Prihlaska, object?> aktualizovatZvolenyIndex) : base(null!)
	{
		InitializeComponent();
		ZakazatUpravovaniUdaju();
		Text = vychoziText;
		button_zvolit.Enabled = false;
		button_zrusit.Click += (s, e) => { Close(); };
		button_vyhledat.Click += Button_vyhledat_Click;
		textBox_hledaneId.TextChanged += TextBox_hledaneId_TextChanged;
		button_zvolit.Click += Button_zvolit_Click;
		this.prihlaskyStredni = prihlaskyStredni;
		this.prihlaskyVyssi = prihlaskyVyssi;
		AktualizovatZvolenyIndex = aktualizovatZvolenyIndex;

		List<Prihlaska> vsechnyPrihlasky = new List<Prihlaska>();
		vsechnyPrihlasky.AddRange(prihlaskyStredni);
		vsechnyPrihlasky.AddRange(prihlaskyVyssi);
		if (vsechnyPrihlasky.Select(x => x.Id).ToHashSet().Count != vsechnyPrihlasky.Count)
		{
			MessageBox.Show(
				"Existují přihlášky s duplicitním ID, takže vyhledávání zvolí první přihlášku, u které je zvolené ID stejné jako u první nalezené uložené přihlášky splňující tuto podmínku.",
				"Duplicitní ID",
				MessageBoxButtons.OK,
				MessageBoxIcon.Warning
				);
		}
	}

	private void Button_zvolit_Click(object? sender, EventArgs e)
	{
		AktualizovatZvolenyIndex(prihlaska);
		Close();
	}

	private void TextBox_hledaneId_TextChanged(object? sender, EventArgs e)
	{
		textBox_hledaneId.BackColor = int.TryParse(textBox_hledaneId.Text, out vyhledavaneId) ? Color.Green : Color.Red;
	}

	private void Button_vyhledat_Click(object? sender, EventArgs e)
	{
		foreach (var prihlaska in prihlaskyStredni)
		{
			if(prihlaska.Id == vyhledavaneId)
			{
				this.prihlaska = prihlaska;
				ZobrazitVyhledanouPrihlasku();
				return;
			}
		}

		foreach (var prihlaska in prihlaskyVyssi)
		{
			if (prihlaska.Id == vyhledavaneId)
			{
				this.prihlaska = prihlaska;
				ZobrazitVyhledanouPrihlasku();
				return;
			}
		}

		Text = vychoziText;
		button_zvolit.Enabled = false;
		VycistitVstupniPole();
	}

	private void ZobrazitVyhledanouPrihlasku()
	{
		button_zvolit.Enabled = true;
		Text = prihlaska.Informace;
		prihlaskaNaStredni = prihlaska is PrihlaskaStredniOdbornaSkola;
		comboBox_obor.Items.Clear();
		NaplnitComboBoxDostupnymiObory();
		ZobrazitUdajeUlozenaPrihlaska();
	} 
}
