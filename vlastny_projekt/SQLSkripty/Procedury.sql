USE projekt
GO
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

CREATE PROCEDURE ProduktyVTransakcii @hladaneID int
AS
SELECT tr.ID, pro.nazov, pro.cena, typ.nazov AS typTransakcie
FROM Transakcie AS tr
JOIN Transakcie_Produkty AS trp
ON tr.ID = trp.ID_Transakcie
JOIN Produkty AS pro
ON trp.ID_Produkty = pro.ID
JOIN Transakcie_Typ AS typ
ON tr.ID_Typ = typ.ID
WHERE tr.ID = @hladaneID;
GO

CREATE PROCEDURE PoctyPoloziekVTransakcii
AS
SELECT TOP (1000000) ID_Transakcie, COUNT(*) AS pocetPoloziek
FROM Transakcie_Produkty
GROUP BY ID_Transakcie
ORDER BY pocetPoloziek DESC;
GO

CREATE PROCEDURE PoctyTransakciiSRovnakymPoctomPoloziek
AS
SELECT poc.pocetPoloziek, COUNT(poc.pocetPoloziek) AS pocetTransakcii
FROM (SELECT COUNT(*) AS pocetPoloziek
FROM Transakcie_Produkty
GROUP BY ID_Transakcie) AS poc
GROUP BY poc.pocetPoloziek
ORDER BY poc.pocetPoloziek DESC;
GO

CREATE PROCEDURE TransakciaTypOsobaAZamestnanec @hladaneID int
AS
SELECT tr.ID AS IDTransakcie,
zam.meno AS prihlMeno,
zamudaj.meno AS menoZamestnanca,
zamudaj.priezvisko AS priezviskoZamestnanca,
os.meno AS menoZakaznika,
os.priezvisko AS priezviskoZakaznika,
typ.nazov AS typTransakcie
FROM Transakcie AS tr
INNER JOIN Zamestnanec AS zam
ON tr.ID_Zamestnanec = zam.ID
INNER JOIN Transakcie_Typ AS typ
ON tr.ID_Typ = typ.ID
INNER JOIN Osoba AS os
ON tr.ID_Osoba = os.ID
INNER JOIN Zamestnanec_udaje AS zamudaj
ON tr.ID_Zamestnanec = zamudaj.ID_Zamestnanec
WHERE tr.ID = @hladaneID;
GO

CREATE PROCEDURE ProduktSNazvomVyrobcu @hladanyNazov varchar(100)
AS
SELECT pr.ID, vy.meno AS vyrobcaMeno, pr.nazov, pr.cena, pr.dostupne
FROM Produkty AS pr
LEFT JOIN Vyrobca as vy ON pr.ID_vyrobca = vy.ID
WHERE pr.nazov LIKE '%' + @hladanyNazov + '%';
GO

CREATE PROCEDURE ZamestnanciPocetTransakciiARebricek
AS
SELECT pocet.ID_Zamestnanec, zam.meno AS prihlMeno, udaj.meno, udaj.priezvisko, pocet.pocetTransakcii, RANK() OVER
(ORDER BY pocet.pocetTransakcii DESC) AS rebricekPoctuTransakcii
FROM (SELECT tr.ID_Zamestnanec, COUNT(*) AS pocetTransakcii
FROM Transakcie AS tr
GROUP BY tr.ID_Zamestnanec) AS pocet
JOIN Zamestnanec AS zam 
ON pocet.ID_Zamestnanec = zam.ID
JOIN Zamestnanec_udaje AS udaj
ON pocet.ID_Zamestnanec = udaj.ID_Zamestnanec;
GO