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

public partial class OknoNovaPrihlaska : VychoziPrihlaskoveOkno
{
	DbValuesLimits limits;
	Func<Prihlaska, object?> NovaPrihlaskaMetoda;
	bool prednostnePrijat = false;
	public OknoNovaPrihlaska(DbValuesLimits limits, Func<Prihlaska, object?> NovaPrihlaskaMetoda, string? cestaStredni, string? cestaVyssi) : base(null!)
	{
		InitializeComponent();
		this.limits = limits;
		this.NovaPrihlaskaMetoda = NovaPrihlaskaMetoda;
		
		if(cestaStredni is null || cestaVyssi is null)
		{
			MessageBox.Show(
				"Neexistuje platná cesta pro soubory pro uložení",
				"Nelze pokračovat",
				MessageBoxButtons.OK,
				MessageBoxIcon.Error
				);
			Close();
			return;
		}

		Text = "Vytvořit novou přihlášku";
		prihlaskaNaStredni = true;
		button_vytvorit.Click += Button_vytvorit_Click;
		NaplnitComboBoxDostupnymiObory();
		groupBox_bodyMatZkouska.Visible = !prihlaskaNaStredni;
		button_zrusit.Click += (s, e) => { Close(); };
	}

	private void Button_vytvorit_Click(object? sender, EventArgs e)
	{
		bool bodyPrijimaciRizeniOK = int.TryParse(textBox_bodyPrijimaciRizeni.Text, out int bodyPrijimaciRizeni);
		bool maturitniZkouskaOK = decimal.TryParse(textBox_prumerZnamekMatZkouska.Text, out decimal prumerMatZkouska) || prihlaskaNaStredni;
		bool udajeOK;
		prednostnePrijat = prumerMatZkouska < limits.MaturitniPrumerProPrijeti;
		if (prihlaskaNaStredni)
		{
			PrihlaskaStredniOdbornaSkola p = new(
				-1,
				textBox_jmeno.Text,
				textBox_prijmeni.Text,
				monthCalendar_datumNarozeni.SelectionStart,
				(OborStredni)comboBox_obor.SelectedIndex,
				bodyPrijimaciRizeni,
				radioButton_prijat.Checked
				);
			prihlaska = p;
			p.DbStav = DbStav.Nova;

			udajeOK = Prihlaska.JsouUdajeSpravne(limits, textBox_jmeno.Text, textBox_prijmeni.Text, monthCalendar_datumNarozeni.SelectionStart);
		}
		else
		{
			PrihlaskaVyssiOdbornaSkola p = new(
				-1,
				textBox_jmeno.Text,
				textBox_prijmeni.Text,
				monthCalendar_datumNarozeni.SelectionStart,
				(OborVyssiOdborna)comboBox_obor.SelectedIndex,
				bodyPrijimaciRizeni,
				prednostnePrijat || radioButton_prijat.Checked,
				prumerMatZkouska
				);
			prihlaska = p;
			p.DbStav = DbStav.Nova;

			udajeOK = PrihlaskaVyssiOdbornaSkola.JsouUdajeSpravne(limits, textBox_jmeno.Text, textBox_prijmeni.Text, monthCalendar_datumNarozeni.SelectionStart, prumerMatZkouska);
		}
		udajeOK &= prihlaska.IndexOboru != -1;
		if (bodyPrijimaciRizeniOK && maturitniZkouskaOK && udajeOK)
		{
			_ = NovaPrihlaskaMetoda(prihlaska);
			if (prednostnePrijat && prihlaska is PrihlaskaVyssiOdbornaSkola && !radioButton_prijat.Checked) _ = MessageBox.Show(
				$"Uchazeč byl kvůli svému maturitnímu průměru ({textBox_prumerZnamekMatZkouska.Text}) automaticky přijat, jelikož je nižší než limit ({limits.MaturitniPrumerProPrijeti}), přihlášku však lze stále upravit.",
				"Uchazeč automaticky přijat",
				MessageBoxButtons.OK,
				MessageBoxIcon.Information
				);
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
