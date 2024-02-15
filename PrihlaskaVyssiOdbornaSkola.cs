using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvidencePrijimacihoRizeni_Vilimek;

public sealed class PrihlaskaVyssiOdbornaSkola : Prihlaska
{
	public decimal prumerZnamekMaturitniZkousky;
	public OborVyssiOdborna obor;
	public override int IndexOboru => (int)obor;

	public PrihlaskaVyssiOdbornaSkola(int id, string jmeno, string prijmeni, DateTime datumNarozeni, OborVyssiOdborna obor, int bodyPrijimacihoRizeni, bool prijat, decimal prumerZnamekMaturitniZkousky)
		: base(id, jmeno, prijmeni, datumNarozeni, bodyPrijimacihoRizeni, prijat)
	{
		this.prumerZnamekMaturitniZkousky = prumerZnamekMaturitniZkousky;
		this.obor = obor;
	}

	public override string ZiskatZakladniInformace()
	{
		return base.ZiskatZakladniInformace() + $" - {obor}";
	}

	public static bool JsouUdajeSpravne(DbValuesLimits limits, string jmeno, string prijmeni, DateTime datumNarozeni, decimal prumerZnamekMaturitniZkousky)
	{
		return JsouUdajeSpravne(limits, jmeno, prijmeni, datumNarozeni) &&
			prumerZnamekMaturitniZkousky >= limits.NejlepsiZnamka &&
			prumerZnamekMaturitniZkousky <= limits.NejhorsiZnamka;
	}
}
