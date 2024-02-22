CREATE TABLE [dbo].[PrihlaskyStredni]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Jmeno] NVARCHAR(255) NOT NULL,
	[Prijmeni] NVARCHAR(255) NOT NULL,
	[DatumNarozeni] DATETIME NOT NULL,
	[BodyPrijimaciRizeni] INT NOT NULL,
	[Prijat] BINARY NOT NULL,
	[Obor] INT NOT NULL,
)
