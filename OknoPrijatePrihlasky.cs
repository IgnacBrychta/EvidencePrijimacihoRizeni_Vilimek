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

public partial class OknoPrijatePrihlasky : Form
{
	readonly List<PrihlaskaStredniOdbornaSkola>? prihlaskyStredni;
	readonly List<PrihlaskaVyssiOdbornaSkola>? prihlaskyVyssi;
	public OknoPrijatePrihlasky(List<PrihlaskaStredniOdbornaSkola> prihlaskyStredni, List<PrihlaskaVyssiOdbornaSkola> prihlaskyVyssi)
	{
		InitializeComponent();
		radioButtonStredni.CheckedChanged += RadioButtonStredni_CheckedChanged;
		this.prihlaskyVyssi = prihlaskyVyssi;
		this.prihlaskyStredni = prihlaskyStredni;
		this.Load += (s, e) => { MaximumSize = Size; MinimumSize = Size; };
		Text = "Přijaté přihlášky";
		Icon = new Icon(HlavniOkno.IconFilePath);
	}

	public OknoPrijatePrihlasky() { }

	private void RadioButtonStredni_CheckedChanged(object? sender, EventArgs e)
	{
		listBoxPrijati.Items.Clear();
		int pocet = -1;
		if(radioButtonStredni.Checked)
		{
			var prijati = prihlaskyStredni!.FindAll(x => x.prijat);
			pocet = prijati.Count;
			foreach (Prihlaska prihlaska in prijati)
			{
				listBoxPrijati.Items.Add(prihlaska.ZiskatZakladniInformace());
			}
		}
		else
		{
			var prijati = prihlaskyVyssi!.FindAll(x => x.prijat);
			pocet = prijati.Count;
			foreach (Prihlaska prihlaska in prijati)
			{
				listBoxPrijati.Items.Add(prihlaska.ZiskatZakladniInformace());
			}
		}
		groupBox3.Text = $"Seznam ({pocet})";
	}
}
