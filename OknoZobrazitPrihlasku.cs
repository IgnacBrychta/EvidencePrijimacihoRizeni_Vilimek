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

public partial class OknoZobrazitPrihlasku : VychoziPrihlaskoveOkno
{
	public OknoZobrazitPrihlasku(Prihlaska prihlaska) : base(prihlaska)
	{
		InitializeComponent();
		Text = prihlaska.Informace;
		button_ok.Click += (s, e) => { Close(); };
		prihlaskaNaStredni = prihlaska is PrihlaskaStredniOdbornaSkola;
		NaplnitComboBoxDostupnymiObory();

		ZobrazitUdajeUlozenaPrihlaska();

		ZakazatUpravovaniUdaju();
	}
}
