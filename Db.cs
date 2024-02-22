using System.Data.SqlClient;

namespace EvidencePrijimacihoRizeni_Vilimek;

internal class Db : IDisposable
{
	private bool disposedValue;
	readonly SqlConnection pripojeni;
	public Db(string pripojovaciRetezec)
	{
		pripojeni = new SqlConnection(pripojovaciRetezec);
		pripojeni.Open();
	}
	public DialogResult SynchronizovatPrihlasku(Prihlaska prihlaska)
	{
		string textPrikazu;
		using SqlCommand prikaz = new SqlCommand();
		int ovlivneneRadky = 0;
		switch((prihlaska is PrihlaskaStredniOdbornaSkola, prihlaska.DbStav))
		{
			case (true, DbStav.Nova):
				textPrikazu = @"
				INSERT INTO PrihlaskyStredni (Id, Jmeno, Prijmeni, DatumNarozeni, BodyPrijimaciRizeni, Prijat, Obor)
				--OUTPUT INSERTED.Id				
				VALUES (@Id, @Jmeno, @Prijmeni, @DatumNarozeni, @BodyPrijimaciRizeni, @Prijat, @Obor)
				";
				NastavitSpolecneParametry(prikaz, prihlaska, textPrikazu);
				try
				{
					ovlivneneRadky = prikaz.ExecuteNonQuery();
				}
				catch (Exception) { }
				//int idStredni = (int)prikaz.ExecuteScalar();
				//prihlaska.Id = idStredni;
				prihlaska.DbStav = DbStav.Aktualni;
				break;
			case (false, DbStav.Nova):
				textPrikazu = @"
				INSERT INTO PrihlaskyVyssiOdborna (Id, Jmeno, Prijmeni, DatumNarozeni, BodyPrijimaciRizeni, Prijat, Obor, PrumerZnamekMaturitniZkousky)
				--OUTPUT INSERTED.Id				
				VALUES (@Id, @Jmeno, @Prijmeni, @DatumNarozeni, @BodyPrijimaciRizeni, @Prijat, @Obor, @PrumerZnamekMaturitniZkousky)
				";
				NastavitSpolecneParametry(prikaz, prihlaska, textPrikazu);
				prikaz.Parameters.AddWithValue("PrumerZnamekMaturitniZkousky", ((PrihlaskaVyssiOdbornaSkola)prihlaska).prumerZnamekMaturitniZkousky);
				try
				{
					ovlivneneRadky = prikaz.ExecuteNonQuery();
				}
				catch (Exception) { }
				//int idVyssi = (int)prikaz.ExecuteScalar();
				//prihlaska.Id = idVyssi;
				prihlaska.DbStav = DbStav.Aktualni;
				break;
			case (true, DbStav.NaSmazani):
				textPrikazu = @"
				DELETE FROM PrihlaskyStredni WHERE Id=@Id
				";
				prikaz.CommandText = textPrikazu;
				prikaz.Parameters.AddWithValue("Id", prihlaska.Id);
				prikaz.Connection = pripojeni;
				ovlivneneRadky = prikaz.ExecuteNonQuery(); 
				prihlaska.DbStav = DbStav.Zadny;
#warning odstraněno?
				break;
			case (false, DbStav.NaSmazani):
				textPrikazu = @"
				DELETE FROM PrihlaskyVyssiOdborna WHERE Id=@Id
				";
				prikaz.CommandText = textPrikazu;
				prikaz.Parameters.AddWithValue("Id", prihlaska.Id);
				prikaz.Connection = pripojeni;
				try
				{
					ovlivneneRadky = prikaz.ExecuteNonQuery();
				}
				catch (Exception) { }
				prihlaska.DbStav = DbStav.Zadny;
#warning odstraněno?
				break;
			case (true, DbStav.Upravena):
				textPrikazu = @"
				UPDATE PrihlaskyStredni
				SET 
					Jmeno = @Jmeno,
					Prijmeni = @Prijmeni,
					DatumNarozeni = @DatumNarozeni,
					BodyPrijimaciRizeni = @BodyPrijimaciRizeni,
					Prijat = @Prijat,
					Obor = @Obor
				WHERE Id = @Id
				";
				NastavitSpolecneParametry(prikaz, prihlaska, textPrikazu);
				try
				{
					ovlivneneRadky = prikaz.ExecuteNonQuery();
				}
				catch (Exception) { }
				prihlaska.DbStav = DbStav.Aktualni;
#warning aktualizováno?
				break;
			case (false, DbStav.Upravena):
				textPrikazu = @"
				UPDATE PrihlaskyVyssiOdborna 
				SET 
					Jmeno = @Jmeno,
					Prijmeni = @Prijmeni,
					DatumNarozeni = @DatumNarozeni,
					BodyPrijimaciRizeni = @BodyPrijimaciRizeni,
					Prijat = @Prijat,
					Obor = @Obor,
					PrumerZnamekMaturitniZkousky = @PrumerZnamekMaturitniZkousky
				WHERE Id = @Id
				";
				NastavitSpolecneParametry(prikaz, prihlaska, textPrikazu);
				prikaz.Parameters.AddWithValue("PrumerZnamekMaturitniZkousky", ((PrihlaskaVyssiOdbornaSkola)prihlaska).prumerZnamekMaturitniZkousky);
				try
				{
					ovlivneneRadky = prikaz.ExecuteNonQuery();
				}
				catch (Exception) { }
				prihlaska.DbStav = DbStav.Aktualni;
#warning aktualizováno?
				break;
		}
		return ovlivneneRadky == 1 ? DialogResult.OK : DialogResult.Abort;
	}
#warning změnit rozsah id u přihlášek
	private void NastavitSpolecneParametry(SqlCommand prikaz, Prihlaska prihlaska, string textPrikazu)
	{
		prikaz.CommandText = textPrikazu;
		prikaz.Connection = pripojeni;
		prikaz.Parameters.AddWithValue("Id", prihlaska.Id);
		prikaz.Parameters.AddWithValue("Jmeno", prihlaska.jmeno);
		prikaz.Parameters.AddWithValue("Prijmeni", prihlaska.prijmeni);
		prikaz.Parameters.AddWithValue("DatumNarozeni", prihlaska.datumNarozeni);
		prikaz.Parameters.AddWithValue("BodyPrijimaciRizeni", prihlaska.bodyPrijimacihoRizeni);
		prikaz.Parameters.AddWithValue("Prijat", prihlaska.prijat);
		prikaz.Parameters.AddWithValue("Obor", prihlaska.IndexOboru);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (!disposedValue)
		{
			if (disposing)
			{
				// TODO: dispose managed state (managed objects)
				pripojeni.Close();
				pripojeni.Dispose();
			}

			// TODO: free unmanaged resources (unmanaged objects) and override finalizer
			// TODO: set large fields to null
			disposedValue = true;
		}
	}

	// // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
	// ~Db()
	// {
	//     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
	//     Dispose(disposing: false);
	// }

	public void Dispose()
	{
		// Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}
}
