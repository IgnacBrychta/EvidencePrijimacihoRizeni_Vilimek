using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvidencePrijimacihoRizeni_Vilimek;

internal sealed class PrihlaskaVyssiOdbornaSkola : Prihlaska
{
	public decimal prumerZnamekMaturitniZkousky;
	public PrihlaskaVyssiOdbornaSkola(string jmeno, string prijmeni, DateTime datumNarozeni, Obor obor, int bodyPrijimacihoRizeni, bool prijat, decimal prumerZnamekMaturitniZkousky)
		: base(jmeno, prijmeni, datumNarozeni, obor, bodyPrijimacihoRizeni, prijat)
	{
		this.prumerZnamekMaturitniZkousky = prumerZnamekMaturitniZkousky;
	}
}
