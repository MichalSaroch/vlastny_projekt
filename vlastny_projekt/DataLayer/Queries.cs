using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dapper;
using vlastny_projekt.DataLayer.Entities;

namespace vlastny_projekt.DataLayer
{
    public class Queries
    {
        private static int _pocetPokusov = 5;
        //Registracia dostava dva parametre a to meno registrovaneho a heslo
        //Najprv sa vygeneruje nahodny string (salt) a heslo sa s tymto saltom za hashuje
        //Nasledne vznikne query ktore skontroluje dostupnost mena kedze prihlasovacie meno musi byt unique
        //Ak sa meno nenachadza v databaze sa vlozi do tabulky Zamestnanec a zisti sa ID vytvoreneho zaznaku
        //Toto ID sa vyuzije na vytvorenie zaznamu do tabulky Zamestnanec_udaje
        public static void Registracia(string meno, string heslo)
        {
            string salt = Pomocky.NahodneZnaky(15);
            string hesloHash = Pomocky.VytvorSHA256(heslo+salt);
            for (int i = 0; i < _pocetPokusov; i++)
            {
                try
                {
                    using (DataPristup sql = new DataPristup())
                    {
                        try
                        {
                            sql.ZacatTransakciu("PIB");
                            var zisti_dostupnost = sql.NacitajDataTransakcia<int, dynamic>("dbo.RegistraciaDostupnost", new { meno = meno });
                            if (zisti_dostupnost.Count == 0)
                            {
                                int idZam = 0;
                                idZam = sql.NacitajDataTransakcia<int, dynamic>("dbo.Registracia", new { noveMeno = meno, noveHeslo = hesloHash, novySalt = salt, vlozeneID = idZam}).First();
                                //var idZam = sql.NacitajDataTransakcia<int, dynamic>($"dbo.Prihlasenie", null).First();
                                sql.UlozDataTransakcia("dbo.VytvorZamestnanec_udaje", new { zamID = idZam });
                                MessageBox.Show("Registracia prebehla uspesne");
                                return;
                            }
                            else
                            {
                                MessageBox.Show("Pouzivatel s tymto meno uz existuje");
                                return;
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            sql.RollbackTransakcia();
                        }
                    }
                }
                catch //(Exception ex)
                {
                    //MessageBox.Show(ex.Message);
                }
            }
            MessageBox.Show($"Nastala chyba pri komunikacii s databazou");
            return;
        }
        //Prihlasenie ma dva vstupne udaje a to meno a heslo prihlasovanej osoby
        //Ako prve sa vytvory query ktory podla mena vytiahne z databazy salt
        //Nasledne sa heslo aj so saltom za hashuje a nasledne sa pokusi o prihlasenie
        public static int Prihlasenie(string meno, string heslo)
        {
            for (int i = 0; i < _pocetPokusov; i++)
            {
                try
                {
                    using (DataPristup sql = new DataPristup())
                    {
                        try
                        {
                            sql.ZacatTransakciu("PIB");
                            string salt = sql.NacitajDataTransakcia<string, dynamic>("dbo.Prihlasenie_salt", new { prihlasMeno = meno }).First();
                            var hesloHash = Pomocky.VytvorSHA256(heslo + salt);
                            var nasiel = sql.NacitajDataTransakcia<int, dynamic>("dbo.Prihlasenie", new { prihlasMeno = meno, prihlasHeslo = hesloHash });
                            if (nasiel.Count == 1)
                            {
                                int vysledok = nasiel.First();
                                return vysledok;
                            }
                            else
                            {
                                MessageBox.Show("Nespravne udaje");
                                return -1;
                            }
                        }
                        catch
                        {
                            sql.RollbackTransakcia();
                        }
                    }
                    
                }
                catch //(Exception ex)
                {
                    //MessageBox.Show(ex.Message);
                }
            }
            MessageBox.Show("Nastala chyba pri komunikacii s databazou");
            return -1;
        }
        //Zamestnanec_udaje ma jeden vstupny parameter a jedna sa o id Zamesntnanca ktoreho udaje potrebujeme
        //Vrati zaznam v tabulke s tymto ID
        public static Zamestnanec_udaje ZiskajZamestnanecUdaje(int id)
        {
            for (int i = 0; i < _pocetPokusov; i++)
            {
                try
                {
                    DataPristup sql = new DataPristup();
                    var osoba = sql.NacitajData<Zamestnanec_udaje, dynamic>("dbo.ZiskajZamestnanec_udaje", new { zamID = id }, "PIB");
                    return osoba.First();
                }
                catch //(Exception ex)
                {
                    //MessageBox.Show(ex.Message);
                }
            }
            MessageBox.Show("Nastala chyba pri komunikacii s databazou");
            return null;
        }
        //UpdateZamestnanec_udaje ma jeden vstupny parameter ktory je znodny s jednym celym zaznamom v tabulke Zamestnanec_udaje
        //Vykona update v Zamestnanec_udaje kde sa ID_Zamestnanec zhoduje
        public static void UpdateZamestnanec_udaje(Zamestnanec_udaje zmena)
        {
            for (int i = 0; i < _pocetPokusov; i++)
            {
                try
                {
                    DataPristup sql = new DataPristup();
                    sql.UlozData("dbo.UpdateZamestnanec_udaje", new { zmenaMena = zmena.meno, zmenaPriezviska = zmena.priezvisko, zmenaDatumuNarodenia = zmena.datum_narodenia, zmenaMesta = zmena.mesto, zmenaAdresy = zmena.adresa, zmenaPsc = zmena.adresa, zmenaCisla = zmena.telefonne_cislo, idZam = zmena.ID_Zamestnanec },"PIB");
                    return;
                }
                catch //(Exception ex)
                {
                    //MessageBox.Show(ex.Message);
                }
            }
            MessageBox.Show("Nastala chyba pri komunikacii s databazou");
            return;
        }
        //ZoznamOsob ma jeden vstupny parameter a to priezvisko podla ktoreho filtrujeme zaznamy
        //vrati vsetky osoby ktorych priezvisko je zhodne s % priezvisko %
        public static List<Osoba> ZoznamOsob(string priezvisko)
        {
            for (int i = 0; i < _pocetPokusov; i++)
            {
                try
                {
                    DataPristup sql = new DataPristup();
                    List<Osoba> osoby = sql.NacitajData<Osoba,dynamic>("dbo.ZoznamOsob", new { priezvisko = priezvisko }, "PIB");
                    return osoby;
                }
                catch //(Exception ex)
                {
                    //MessageBox.Show(ex.Message);
                }
            }
            MessageBox.Show("Nastala chyba pri komunikacii s databazou");
            return null;
        }
        //UpdateOsoba ma jeden vstupny parameter ktory je znodny s jednym celym zaznamom v tabulke Osoba
        //Vykona update v Osoba kde sa ID zhoduje
        public static void UpdateOsoba(Osoba zmena)
        {
            for (int i = 0; i < _pocetPokusov; i++)
            {
                try
                {
                    DataPristup sql = new DataPristup();
                    sql.UlozData("dbo.UpdateOsoba", new { zmenaDatumuNarodenia = zmena.datum_narodenia, zmenaMesta = zmena.mesto, zmenaAdresy = zmena.adresa, zmenaPsc = zmena.adresa, zmenaCisla = zmena.telefonne_cislo, ID = zmena.ID }, "PIB");
                    return;
                }
                catch //(Exception ex)
                {
                    //MessageBox.Show(ex.Message);
                }
            }
            MessageBox.Show("Nastala chyba pri komunikacii s databazou");
            return;
        }
        //Rebricek nam vrati vsetkych zamestnancov a ich pocty vykonanych transakcii 
        public static List<ZamestnanecPocetTransak> Rebricek()
        {
            for (int i = 0; i < _pocetPokusov; i++)
            {
                try
                {
                    DataPristup sql = new DataPristup();
                    var zoznam = sql.NacitajData<ZamestnanecPocetTransak>("dbo.ZamestnanciPocetTransakciiARebricek", "PIB");
                    return zoznam;
                }
                catch //(Exception ex)
                {
                    //MessageBox.Show(ex.Message);
                }
            }
            MessageBox.Show("Nastala chyba pri komunikacii s databazou");
            return null;
        }

        public static List<Produkt> Produkt(string nazov)
        {
            for (int i = 0; i < _pocetPokusov; i++)
            {
                try
                {
                    DataPristup sql = new DataPristup();
                    var zoznam = sql.NacitajData<Produkt, dynamic>("dbo.ProduktSNazvomVyrobcu",new { hladanyNazov = nazov } , "PIB");
                    return zoznam;
                }
                catch //(Exception ex)
                {
                    //MessageBox.Show(ex.Message);
                }
            }
            MessageBox.Show("Nastala chyba pri komunikacii s databazou");
            return null;
        }
        //TransakciaOsoby ma jeden vstupny parameter a to id hladanej transakcie
        //Vrati nam transakciu aj s prihlasovacim menom zamestnanca, menom a priezviskom zamestnanca, menom a priezviskom zakaznika a typ transakcie
        public static List<TransakciaOsoby> TransakciaOsoby(int id)
        {
            for (int i = 0; i < _pocetPokusov; i++)
            {
                try
                {
                    DataPristup sql = new DataPristup();
                    var zoznam = sql.NacitajData<TransakciaOsoby, dynamic>("dbo.TransakciaTypOsobaAZamestnanec", new { hladaneID = id }, "PIB");
                    return zoznam;
                }
                catch //(Exception ex)
                {
                    //MessageBox.Show(ex.Message);
                }
            }
            MessageBox.Show("Nastala chyba pri komunikacii s databazou");
            return null;
        }
        //PoctyTransakciiSRovnakymPoctomPoloziek nam vrati vsetky rozne pocty poloziek v transakciach a aj pocet kolko transakcii malo takyto pocet
        public static List<PoctyTransakcii> PoctyTransakciiSRovnakymPoctomPoloziek()
        {
            for (int i = 0; i < _pocetPokusov; i++)
            {
                try
                {
                    DataPristup sql = new DataPristup();
                    var zoznam = sql.NacitajData<PoctyTransakcii>("dbo.PoctyTransakciiSRovnakymPoctomPoloziek", "PIB");
                    return zoznam;
                }
                catch //(Exception ex)
                {
                    //MessageBox.Show(ex.Message);
                }
            }
            MessageBox.Show("Nastala chyba pri komunikacii s databazou");
            return null;
        }
        //PoctyPoloziekVTransakcii vrati TOP(1000000) zaznamov kde sa nachadza ID transakcie a pocet poloziek v tejto transakcii
        public static List<PocetPoloziek> PoctyPoloziekVTransakcii()
        {
            for (int i = 0; i < _pocetPokusov; i++)
            {
                try
                {
                    DataPristup sql = new DataPristup();
                    var zoznam = sql.NacitajData<PocetPoloziek>("dbo.PoctyPoloziekVTransakcii", "PIB");
                    return zoznam;
                }
                catch //(Exception ex)
                {
                    //MessageBox.Show(ex.Message);
                }
            }
            MessageBox.Show("Nastala chyba pri komunikacii s databazou");
            return null;
        }
        //ProduktyVTransakcii ma jeden vstupny parameter a to ID hladanej transakcie
        //Vrati ID transakcie, nazov produktu, cenu produktu a typ transakcie pre kazdy produkt v transakcii
        public static List<ProduktyVTransakcii> ProduktyVTransakcii(int id)
        {
            for (int i = 0; i < _pocetPokusov; i++)
            {
                try
                {
                    DataPristup sql = new DataPristup();
                    var zoznam = sql.NacitajData<ProduktyVTransakcii, dynamic>("dbo.ProduktyVTransakcii", new { hladaneID = id }, "PIB");
                    return zoznam;
                }
                catch// (Exception ex)
                {
                    //MessageBox.Show(ex.Message);
                }
            }
            MessageBox.Show("Nastala chyba pri komunikacii s databazou");
            return null;
        }

    }
}
