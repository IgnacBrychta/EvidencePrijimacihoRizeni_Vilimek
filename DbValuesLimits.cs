namespace EvidencePrijimacihoRizeni_Vilimek;

public class DbValuesLimits
{
	public int MaxCharacters { init; get; }
	public int MinAge { init; get; }
	public static int DaysInYear => 365;
	public char Delimiter { init; get; }
	public string DateFormat { init; get; }
	public decimal NejlepsiZnamka { init; get; }
	public decimal NejhorsiZnamka { init; get; }
	public decimal MaturitniPrumerProPrijeti { init; get; }
}
