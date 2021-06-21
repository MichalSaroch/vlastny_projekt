using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using vlastny_projekt.DataLayer.Entities;

namespace vlastny_projekt
{
    public partial class ZmenaUdajovOsoba : Form
    {
        private Osoba _osoba;
        public ZmenaUdajovOsoba(Osoba osoba)
        {
            InitializeComponent();
            _osoba = osoba;
            dateTimePicker1.MaxDate = DateTime.Now;
            labelMeno.Text = _osoba.meno;
            labelPriezvisko.Text = _osoba.priezvisko;
            if (_osoba.datum_narodenia != null && !(_osoba.datum_narodenia < dateTimePicker1.MinDate))
                dateTimePicker1.Value = _osoba.datum_narodenia;
            else
                dateTimePicker1.Value = dateTimePicker1.MaxDate;
            textBoxMesto.Text = _osoba.mesto;
            textBoxAdresa.Text = _osoba.adresa;
            textBoxPSC.Text = _osoba.psc;
            textBoxCislo.Text = _osoba.telefonne_cislo?.Substring(5); ;
        }

        private void buttonUloz_Click(object sender, EventArgs e)
        {
            if (textBoxCislo.TextLength != 8 && textBoxCislo.TextLength != 0)
            {
                MessageBox.Show("Nespravny pocet cisiel v telefonnom cisle");
            }
            else if (!textBoxCislo.Text.All(char.IsDigit) && textBoxCislo.TextLength != 0)
            {
                MessageBox.Show("Telefonne cislo nemoze obsahovat ine znaky ako cisla");
            }
            Osoba temp = new Osoba();
            if (dateTimePicker1.Value != dateTimePicker1.MaxDate)
                temp.datum_narodenia = dateTimePicker1.Value;
            else
                temp.datum_narodenia = DateTime.Now;

            if (textBoxMesto.TextLength != 0)
                temp.mesto = textBoxMesto.Text;
            else
                temp.meno = null;

            if (textBoxAdresa.TextLength != 0)
                temp.adresa = textBoxAdresa.Text;
            else
                temp.adresa = null;

            if (textBoxPSC.TextLength != 0)
                temp.psc = textBoxPSC.Text;
            else
                temp.psc = null;

            if (textBoxCislo.TextLength != 0)
                temp.telefonne_cislo = "+4219" + textBoxCislo.Text;
            else
                temp.telefonne_cislo = null;

            temp.ID = _osoba.ID;
            DataLayer.Queries.UpdateOsoba(temp);
        }
    }
}
