CREATE PROCEDURE Registracia
@noveMeno varchar(100),
@noveHeslo varchar(100),
@novySalt varchar(100),
@vlozeneID int OUTPUT
AS
INSERT INTO Zamestnanec (meno, heslo, salt) OUTPUT INSERTED.ID VALUES (@noveMeno, @noveHeslo, @novySalt) ;
GO

CREATE PROCEDURE Prihlasenie_salt @prihlasMeno varchar(100)
AS
SELECT salt FROM Zamestnanec WHERE meno = @prihlasMeno;
GO

CREATE PROCEDURE Prihlasenie @prihlasMeno varchar(100), @prihlasHeslo varchar(100)
AS
SELECT ID FROM Zamestnanec WHERE meno = @prihlasMeno AND heslo = @prihlasHeslo;
GO

CREATE PROCEDURE ZiskajZamestnanec_udaje @zamID int
AS
SELECT * FROM Zamestnanec_udaje WHERE ID_Zamestnanec = @zamID;
GO

CREATE PROCEDURE VytvorZamestnanec_udaje @zamID int
AS
INSERT INTO Zamestnanec_udaje (ID_Zamestnanec) VALUES (@zamID)
GO

CREATE PROCEDURE UpdateZamestnanec_udaje @zmenaMena varchar(100), @zmenaPriezviska varchar(100), @zmenaDatumuNarodenia date, @zmenaMesta varchar(100), @zmenaAdresy varchar(100), @zmenaPsc varchar(20), @zmenaCisla varchar(20), @idZam int
AS
UPDATE Zamestnanec_udaje
SET meno = @zmenaMena, priezvisko = @zmenaPriezviska, datum_narodenia = @zmenaDatumuNarodenia, mesto = @zmenaMesta, adresa = @zmenaAdresy, psc = @zmenaPsc, telefonne_cislo = @zmenaCisla
WHERE ID_Zamestnanec = @idZam
GO

CREATE PROCEDURE UpdateBezAdrZamestnanec_udaje @zmenaMena varchar(100), @zmenaPriezviska varchar(100), @zmenaMesta varchar(100), @zmenaAdresy varchar(100), @zmenaPsc varchar(20), @zmenaCisla varchar(20), @idZam int
AS
UPDATE Zamestnanec_udaje
SET meno = @zmenaMena, priezvisko = @zmenaPriezviska, mesto = @zmenaMesta, adresa = @zmenaAdresy, psc = @zmenaPsc, telefonne_cislo = @zmenaCisla
WHERE ID_Zamestnanec = @idZam
GO

CREATE PROCEDURE RegistraciaDostupnost @meno varchar(100)
AS
SELECT ID FROM Zamestnanec WHERE meno = @meno
GO

CREATE PROCEDURE ZoznamOsob @priezvisko varchar(100)
AS
SELECT * FROM Osoba WHERE priezvisko LIKE '%' + @priezvisko + '%'
GO

CREATE PROCEDURE UpdateOsoba @zmenaDatumuNarodenia date, @zmenaMesta varchar(100), @zmenaAdresy varchar(100), @zmenaPsc varchar(20), @zmenaCisla varchar(20), @ID int
AS
UPDATE Osoba
SET datum_narodenia = @zmenaDatumuNarodenia, mesto = @zmenaMesta, adresa = @zmenaAdresy, psc = @zmenaPsc, telefonne_cislo = @zmenaCisla
WHERE ID = @ID
GO