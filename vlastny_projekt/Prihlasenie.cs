using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace vlastny_projekt
{
    public partial class Prihlasenie : Form
    {
        public Prihlasenie()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var oknoRegistracia = new Registracia();
            oknoRegistracia.Location = this.Location;
            oknoRegistracia.StartPosition = FormStartPosition.Manual;
            oknoRegistracia.FormClosing += delegate { 
                this.Show();
                this.Location = oknoRegistracia.Location;
            };
            oknoRegistracia.Show();
            this.Hide();
        }

        private void buttonPrihlas_Click(object sender, EventArgs e)
        {
            var id = DataLayer.Queries.Prihlasenie(textBoxMeno.Text,textBoxHeslo.Text);
            if(id != -1)
            {
                var oknoMenu = new Menu(id);
                oknoMenu.Location = this.Location;
                oknoMenu.StartPosition = FormStartPosition.Manual;
                oknoMenu.FormClosing += delegate {
                    this.Show();
                    this.Location = oknoMenu.Location;
                };
                oknoMenu.Show();
                this.Hide();
            }
        }
    }
}
