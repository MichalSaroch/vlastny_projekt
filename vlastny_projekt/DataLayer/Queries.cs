using System;
using System.Collections.Generic;
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
                    using (IDbConnection pripojenie = new System.Data.SqlClient.SqlConnection(Pomocky.ZiskajCnnString("PIB")))
                    {
                        var zisti_dostupnost = pripojenie.Query<int>($"SELECT ID FROM Zamestnanec WHERE meno = '{meno}'").ToList();
                        if (zisti_dostupnost.Count == 0)
                        {
                            pripojenie.Execute($"dbo.Registracia @noveMeno, @noveHeslo, @novySalt",new {noveMeno = meno, noveHeslo = hesloHash, novySalt = salt });
                            var idZam = pripojenie.Query<int>($"dbo.Prihlasenie @prihlasMeno, @prihlasHeslo", new { prihlasMeno = meno, prihlasHeslo = hesloHash }).ToList().First();
                            pripojenie.Execute("dbo.VytvorZamestnanec_udaje @zamID", new { zamID = idZam});
                            MessageBox.Show("Registracia prebehla uspesne");
                            return;
                        }
                        else
                        {
                            MessageBox.Show("Pouzivatel s tymto meno uz existuje");
                            return;
                        }
                    }
                }
                catch// (Exception ex)
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
                    using (IDbConnection pripojenie = new System.Data.SqlClient.SqlConnection(Pomocky.ZiskajCnnString("PIB")))
                    {
                        string salt = pripojenie.Query<string>($"dbo.Prihlasenie_salt @prihlasMeno",new { prihlasMeno = meno }).ToArray()[0];
                        var hesloHash = Pomocky.VytvorSHA256(heslo + salt);
                        var nasiel = pripojenie.Query<int>($"dbo.Prihlasenie @prihlasMeno, @prihlasHeslo", new { prihlasMeno = meno, prihlasHeslo = hesloHash }).ToList();
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
                }
                catch// (Exception ex)
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
                    using (IDbConnection pripojenie = new System.Data.SqlClient.SqlConnection(Pomocky.ZiskajCnnString("PIB")))
                    {
                        var osoba = pripojenie.Query<Zamestnanec_udaje>($"dbo.ZiskajZamestnanec_udaje @zamID", new { zamID = id }).ToList();
                        return osoba.First();
                    }
                }
                catch// (Exception ex)
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
                    using (IDbConnection pripojenie = new System.Data.SqlClient.SqlConnection(Pomocky.ZiskajCnnString("PIB")))
                    {
                        if(zmena.datum_narodenia != null)
                            pripojenie.Execute($"dbo.UpdateZamestnanec_udaje @zmenaMena, @zmenaPriezviska, @zmenaDatumuNarodenia, @zmenaMesta, @zmenaAdresy, @zmenaPsc, @zmenaCisla, @idZam", new { @zmenaMena = zmena.meno, @zmenaPriezviska = zmena.priezvisko, @zmenaDatumuNarodenia = DateTime.Parse(zmena.datum_narodenia), @zmenaMesta = zmena.mesto, @zmenaAdresy = zmena.adresa, @zmenaPsc = zmena.psc, @zmenaCisla = zmena.telefonne_cislo, @idZam = zmena.ID_Zamestnanec });
                        else
                            pripojenie.Execute($"dbo.UpdateBezAdrZamestnanec_udaje @zmenaMena, @zmenaPriezviska, @zmenaMesta, @zmenaAdresy, @zmenaPsc, @zmenaCisla, @idZam", new { @zmenaMena = zmena.meno, @zmenaPriezviska = zmena.priezvisko, @zmenaMesta = zmena.mesto, @zmenaAdresy = zmena.adresa, @zmenaPsc = zmena.psc, @zmenaCisla = zmena.telefonne_cislo, @idZam = zmena.ID_Zamestnanec });
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            MessageBox.Show("Nastala chyba pri komunikacii s databazou");
            return;
        }
    }
}
