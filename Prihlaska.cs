using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvidencePrijimacihoRizeni_Vilimek;

internal abstract class Prihlaska
{
	public int Id { init; get; }
	public string jmeno;
	public string prijmeni;
	public DateTime datumNarozeni;
	public Obor obor;
	public int bodyPrijimacihoRizeni;
	public bool prijat;
	public Prihlaska(string jmeno, string prijmeni, DateTime datumNarozeni, Obor obor, int bodyPrijimacihoRizeni, bool prijat)
	{
#warning id get
		this.jmeno = jmeno;
		this.prijmeni = prijmeni;
		this.datumNarozeni = datumNarozeni;
		this.obor = obor;
		this.bodyPrijimacihoRizeni = bodyPrijimacihoRizeni;
		this.prijat = prijat;
	}
}
