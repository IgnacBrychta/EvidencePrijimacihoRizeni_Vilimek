using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvidencePrijimacihoRizeni_Vilimek;

public abstract class Prihlaska
{
	public int Id { init; get; }
	public string jmeno;
	public string prijmeni;
	public DateTime datumNarozeni;
	public int bodyPrijimacihoRizeni;
	public bool prijat;
	public abstract int IndexOboru { get; }
	public string Informace => ZiskatZakladniInformace();
	public Prihlaska(int id, string jmeno, string prijmeni, DateTime datumNarozeni, int bodyPrijimacihoRizeni, bool prijat)
	{
#warning id get how?
		this.jmeno = jmeno;
		this.prijmeni = prijmeni;
		this.datumNarozeni = datumNarozeni;
		this.bodyPrijimacihoRizeni = bodyPrijimacihoRizeni;
		this.prijat = prijat;
		Id = id;
	}

	public override string ToString()
	{
		return $"id: {Id}";
	}

	public virtual string ZiskatZakladniInformace()
	{
		return $"{prijmeni} {jmeno}";
	}

	public static bool JsouUdajeSpravne(DbValuesLimits limits, string jmeno, string prijmeni, DateTime datumNarozeni)
	{
		return jmeno.Length <= limits.MaxCharacters &&
			!jmeno.Contains(limits.Delimiter) &&
			prijmeni.Length <= limits.MaxCharacters &&
			!prijmeni.Contains(limits.Delimiter) &&
			(DateTime.Now - datumNarozeni).Days >= DbValuesLimits.DaysInYear * limits.MinAge;
	}
}
