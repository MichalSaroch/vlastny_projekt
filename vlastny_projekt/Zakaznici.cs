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
        public Zakaznici()
        {
            InitializeComponent();
            backgroundWorkerQuery.WorkerReportsProgress = true;
            backgroundWorkerQuery.WorkerSupportsCancellation = true;
            buttonZrusit.Enabled = false;
        }

        private void listBoxOsoby_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (backgroundWorkerQuery.IsBusy != true)
            {
                // Start the asynchronous operation.
                button1.Enabled = false;
                buttonZrusit.Enabled = true;
                backgroundWorkerQuery.RunWorkerAsync();
            }
        }

        private void backgroundWorkerQuery_DoWork(object sender, DoWorkEventArgs e)
        {
            int i = 0;
            BackgroundWorker worker = sender as BackgroundWorker;
            worker.ReportProgress(0, "Začiatok načítavania dát");
            var osobyDataTable = new DataTable();
            var najdeneOsoby = Queries.ZoznamOsob(textBox1.Text);
            var pocetOsob = najdeneOsoby.Count();
            var polovica = pocetOsob / 2;
            worker.ReportProgress(25, $"Dáta stiahnuté - riadkov {pocetOsob}");
            osobyDataTable.Columns.Add("ID");
            osobyDataTable.Columns.Add("meno");
            osobyDataTable.Columns.Add("priezvisko");
            osobyDataTable.Columns.Add("datum_narodenia");
            osobyDataTable.Columns.Add("mesto");
            osobyDataTable.Columns.Add("adresa");
            osobyDataTable.Columns.Add("psc");
            osobyDataTable.Columns.Add("telefonne_cislo");
            foreach (var osoba in najdeneOsoby)
            {
                if (worker.CancellationPending == true)
                {
                    e.Cancel = true;
                    break;
                }

                var row = osobyDataTable.NewRow();

                row["ID"] = osoba.ID;
                row["meno"] = osoba.meno;
                row["priezvisko"] = osoba.priezvisko;
                row["datum_narodenia"] = osoba.datum_narodenia;
                row["mesto"] = osoba.mesto;
                row["adresa"] = osoba.adresa;
                row["psc"] = osoba.psc;
                row["telefonne_cislo"] = osoba.telefonne_cislo;

                osobyDataTable.Rows.Add(row);
                if (++i == polovica)
                {
                    worker.ReportProgress(50, "GUI naplnené na polovicu");
                }
            }
            worker.ReportProgress(100, "Napĺňanie GUI hotové");
            e.Result = osobyDataTable;

        }

        private void backgroundWorkerQuery_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            label2.Text = $"{e.ProgressPercentage}% ... {e.UserState}";
        }

        private void backgroundWorkerQuery_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                label2.Text = "Zrušené!";
                button1.Enabled = true;
                buttonZrusit.Enabled = false;
            }
            else if (e.Error != null)
            {
                label2.Text = "Error: " + e.Error.Message;
            }
            else
            {
                label2.Text = "Data načítané!";
                var books = (DataTable)e.Result;
                dataGridViewOsoba.DataSource = books;
                dataGridViewOsoba.Columns["ID"].Visible = false;
                button1.Enabled = true;
                buttonZrusit.Enabled = false;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void buttonUpravit_Click(object sender, EventArgs e)
        {
            if (dataGridViewOsoba.CurrentRow == null)
                MessageBox.Show("Nie je zvoleny ziaden zaznam.");
            else
            {
                var zvolenaOsobaIndex = dataGridViewOsoba.CurrentRow.Index;
                var osoba = new Osoba();
                var zvolenaOsoba = dataGridViewOsoba.Rows[zvolenaOsobaIndex];
                osoba.ID = Convert.ToInt32(zvolenaOsoba.Cells["ID"].Value);
                osoba.meno = zvolenaOsoba.Cells["meno"].Value.ToString();
                osoba.priezvisko = zvolenaOsoba.Cells["priezvisko"].Value.ToString();
                osoba.datum_narodenia = Convert.ToDateTime(zvolenaOsoba.Cells["datum_narodenia"].Value);
                osoba.mesto = zvolenaOsoba.Cells["mesto"].Value.ToString();
                osoba.adresa = zvolenaOsoba.Cells["adresa"].Value.ToString();
                osoba.psc = zvolenaOsoba.Cells["psc"].Value.ToString();
                osoba.telefonne_cislo = zvolenaOsoba.Cells["telefonne_cislo"].Value.ToString();
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

        private void buttonZrusit_Click(object sender, EventArgs e)
        {
            backgroundWorkerQuery.CancelAsync();
        }
    }
}
