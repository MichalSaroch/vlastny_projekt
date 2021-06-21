using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using vlastny_projekt.DataLayer;
using vlastny_projekt.DataLayer.Entities;

namespace vlastny_projekt
{
    public partial class Zakaznici : Form
    {
        private List<Osoba> _najdene;
        public Zakaznici()
        {
            InitializeComponent();
            backgroundWorkerQuery.WorkerReportsProgress = true;
        }

        private void listBoxOsoby_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (backgroundWorkerQuery.IsBusy != true)
            {
                // Start the asynchronous operation.
                backgroundWorkerQuery.RunWorkerAsync();
            }
        }

        private void backgroundWorkerQuery_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            worker.ReportProgress(1);
            _najdene = Queries.ZoznamOsob(textBox1.Text);
            worker.ReportProgress(2);
            worker.ReportProgress(3);
        }

        private void backgroundWorkerQuery_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            switch(e.ProgressPercentage)
            {
                case 1:
                    label2.Text = "Komunikácia s databázou.";
                    break;
                case 2:
                    label2.Text = "Prebieha zobrazovanie dát.";
                    break;
                case 3:
                    listBoxOsoby.DataSource = _najdene;
                    listBoxOsoby.DisplayMember = "Info";
                    listBoxOsoby.ValueMember = "Info";
                    break;
            }
            
        }

        private void backgroundWorkerQuery_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                label2.Text = "Zrušené!";
            }
            else if (e.Error != null)
            {
                label2.Text = "Error: " + e.Error.Message;
            }
            else
            {
                label2.Text = "Data načítané!";
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void buttonUpravit_Click(object sender, EventArgs e)
        {
            if (listBoxOsoby.SelectedIndex == -1)
                MessageBox.Show("Nie je zvoleny ziaden zaznam.");
            else
            {
                Osoba osoba = (Osoba)listBoxOsoby.SelectedItem;
                var oknoOsoba = new ZmenaUdajovOsoba(osoba);
                oknoOsoba.Location = this.Location;
                oknoOsoba.StartPosition = FormStartPosition.Manual;
                oknoOsoba.FormClosing += delegate {
                    this.Show();
                    this.Location = oknoOsoba.Location;
                };
                oknoOsoba.Show();
                this.Hide();
            }
        }
    }
}
