using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvidencePrijimacihoRizeni_Vilimek;

public abstract class Prihlaska : IDbStav
{
	public int Id { set; get; }
	public string jmeno;
	public string prijmeni;
	public DateTime datumNarozeni;
	public int bodyPrijimacihoRizeni;
	public bool prijat;
	public abstract int IndexOboru { get; }
	public string Informace => ZiskatZakladniInformace();
	public DbStav DbStav { get; set; }

	public Prihlaska(int id, string jmeno, string prijmeni, DateTime datumNarozeni, int bodyPrijimacihoRizeni, bool prijat)
	{
		this.jmeno = jmeno;
		this.prijmeni = prijmeni;
		this.datumNarozeni = datumNarozeni;
		this.bodyPrijimacihoRizeni = bodyPrijimacihoRizeni;
		this.prijat = prijat;
		Id = id;
	}

	public override string ToString()
	{
		return $"id: {Id} | {DbStav} | {ZiskatZakladniInformace()}";
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

	public virtual bool JsouPrihlaskyStejneKromeId(Prihlaska p)
	{
		return 
			jmeno == p.jmeno &&
			prijmeni == p.prijmeni &&
			datumNarozeni == p.datumNarozeni &&
			bodyPrijimacihoRizeni == p.bodyPrijimacihoRizeni &&
			prijat == p.prijat;
	}

	public virtual string ZiskatTvarProZapsani(DbValuesLimits limits)
	{
		return string.Join(limits.Delimiter, new[] { Id.ToString(), jmeno, prijmeni, datumNarozeni.ToString(limits.DateFormat), IndexOboru.ToString(), bodyPrijimacihoRizeni.ToString(), prijat.ToString() });
	}
}
