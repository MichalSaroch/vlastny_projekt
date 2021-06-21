using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vlastny_projekt
{
    public partial class Menu : Form
    {
        private int _idPrihlaseny;
        public Menu(int zamestnanec)
        {
            InitializeComponent();
            _idPrihlaseny = zamestnanec;
        }

        private void buttonPouzivatelia_Click(object sender, EventArgs e)
        {
            var oknoZakaznici = new Zakaznici();
            oknoZakaznici.Location = this.Location;
            oknoZakaznici.StartPosition = FormStartPosition.Manual;
            oknoZakaznici.FormClosing += delegate {
                this.Show();
                this.Location = oknoZakaznici.Location;
            };
            oknoZakaznici.Show();
            this.Hide();
        }

        private void buttonTovar_Click(object sender, EventArgs e)
        {

        }

        private void buttonStatistiky_Click(object sender, EventArgs e)
        {

        }

        private void buttonUdaje_Click(object sender, EventArgs e)
        {
            var oknoUdaje = new OsobneUdaje(_idPrihlaseny);
            oknoUdaje.Location = this.Location;
            oknoUdaje.StartPosition = FormStartPosition.Manual;
            oknoUdaje.FormClosing += delegate {
                this.Show();
                this.Location = oknoUdaje.Location;
            };
            oknoUdaje.Show();
            this.Hide();
        }
    }
}
