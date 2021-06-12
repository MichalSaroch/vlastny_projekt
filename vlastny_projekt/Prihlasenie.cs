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
using System.Data;

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
            string connetionString;
            connetionString = @"Server=.\SQL_PIB;Database=PIB;Trusted_Connection=True;";
            SqlConnection cnn = new SqlConnection(connetionString);
            cnn.Open();
            MessageBox.Show("Connection Open  !");
            cnn.Close();
        }
    }
}
