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
    public partial class Registracia : Form
    {
        public Registracia()
        {
            InitializeComponent();
            buttonRegistrovat.Enabled = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonRegistrovat_Click(object sender, EventArgs e)
        {

            if (textBoxMeno.TextLength < 5)
            {
                MessageBox.Show("Meno musi obsahovat aspon 5 znakov");
            }
            else if (textBoxHeslo.TextLength < 8)
            {
                MessageBox.Show("Heslo musi obsahovat aspon 8 znakov");
            }
            else
            {
                DataLayer.Queries.Registracia(textBoxMeno.Text, textBoxHeslo.Text);
            }
        }

        private void textBoxMeno_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxHeslo_TextChanged(object sender, EventArgs e)
        {
            if (textBoxHeslo.TextLength < 8)
                buttonRegistrovat.Enabled = false;
            else
                buttonRegistrovat.Enabled = true;
        }
    }
}
