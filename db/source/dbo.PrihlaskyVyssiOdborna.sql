CREATE TABLE [dbo].[PrihlaskyVysiOdborna]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1), 
    [Jmeno] NVARCHAR(255) NOT NULL,
	[Prijmeni] NVARCHAR(255) NOT NULL,
	[DatumNarozeni] DATETIME NOT NULL,
	[BodyPrijimaciRizeni] INT NOT NULL,
	[Prijat] BINARY NOT NULL,
	[Obor] INT NOT NULL
)
