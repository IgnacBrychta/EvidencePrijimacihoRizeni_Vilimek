using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvidencePrijimacihoRizeni_Vilimek;

internal sealed class PrihlaskaStredniOdbornaskola : Prihlaska
{
	public PrihlaskaStredniOdbornaskola(string jmeno, string prijmeni, DateTime datumNarozeni, Obor obor, int bodyPrijimacihoRizeni, bool prijat)
		: base(jmeno, prijmeni, datumNarozeni, obor, bodyPrijimacihoRizeni, prijat)
	{

	}
}
