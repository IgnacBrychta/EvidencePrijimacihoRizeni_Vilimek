using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvidencePrijimacihoRizeni_Vilimek;

public sealed class PrihlaskaStredniOdbornaSkola : Prihlaska
{
	public OborStredni obor;
	public PrihlaskaStredniOdbornaSkola(int id, string jmeno, string prijmeni, DateTime datumNarozeni, OborStredni obor, int bodyPrijimacihoRizeni, bool prijat)
		: base(id, jmeno, prijmeni, datumNarozeni, bodyPrijimacihoRizeni, prijat)
	{
		this.obor = obor;
	}

	public override int IndexOboru => (int)obor;

	public override string ZiskatZakladniInformace()
	{
		return base.ZiskatZakladniInformace() + $" - {obor}";
	}
}
