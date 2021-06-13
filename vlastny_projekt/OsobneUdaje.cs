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
    public partial class OsobneUdaje : Form
    {
        private int _idPrihlaseny;
        private Zamestnanec_udaje _prihlaseny;
        public OsobneUdaje(int zamestnanec)
        {
            InitializeComponent();
            _idPrihlaseny = zamestnanec;
            dateTimePicker1.MaxDate = DateTime.Now;
            _prihlaseny = DataLayer.Queries.ZiskajZamestnanecUdaje(_idPrihlaseny);
            textBoxMeno.Text = _prihlaseny.meno;
            textBoxPriezvisko.Text = _prihlaseny.priezvisko;
            if (_prihlaseny.datum_narodenia != null  &&  !(DateTime.Parse(_prihlaseny.datum_narodenia) < dateTimePicker1.MinDate))
                dateTimePicker1.Value = DateTime.Parse(_prihlaseny.datum_narodenia);
            else
                dateTimePicker1.Value = dateTimePicker1.MaxDate;
            textBoxMesto.Text = _prihlaseny.mesto;
            textBoxAdresa.Text = _prihlaseny.adresa;
            textBoxPSC.Text = _prihlaseny.psc;
            textBoxCislo.Text = _prihlaseny.telefonne_cislo.Substring(5); ;

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if(textBoxCislo.TextLength != 8  && textBoxCislo.TextLength != 0)
            {
                MessageBox.Show("Nespravny pocet cisiel v telefonnom cisle");
            }
            else if(!textBoxCislo.Text.All(char.IsDigit)  && textBoxCislo.TextLength != 0)
            {
                MessageBox.Show("Telefonne cislo nemoze obsahovat ine znaky ako cisla");
            }
            Zamestnanec_udaje temp = new Zamestnanec_udaje();
            if (textBoxMeno.TextLength != 0)
                temp.meno = textBoxMeno.Text;
            else
                temp.meno = null;

            if (textBoxPriezvisko.TextLength != 0)
                temp.priezvisko = textBoxPriezvisko.Text;
            else
                temp.priezvisko = null;

            if (dateTimePicker1.Value != dateTimePicker1.MaxDate)
                temp.datum_narodenia = dateTimePicker1.Value.ToShortDateString();
            else
                temp.datum_narodenia = null;

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

            temp.ID_Zamestnanec = _prihlaseny.ID_Zamestnanec;
            temp.ID = _prihlaseny.ID;

            DataLayer.Queries.UpdateZamestnanec_udaje(temp);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
