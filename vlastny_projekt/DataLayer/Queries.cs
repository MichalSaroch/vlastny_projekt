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
            throw new NotImplementedException();
        }

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
    }
}
