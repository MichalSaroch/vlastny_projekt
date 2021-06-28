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

namespace vlastny_projekt
{
    public partial class Statistiky : Form
    {
        private int _zapnuteHladanie = 0;
        public Statistiky()
        {
            InitializeComponent();
            ButtonZrusit.Enabled = false;

            backgroundWorkerLudia.WorkerReportsProgress = true;
            backgroundWorkerLudia.WorkerSupportsCancellation = true;

            backgroundWorkerRebricek.WorkerReportsProgress = true;
            backgroundWorkerRebricek.WorkerSupportsCancellation = true;

            backgroundWorkerPocty.WorkerReportsProgress = true;
            backgroundWorkerPocty.WorkerSupportsCancellation = true;

            backgroundWorkerRovnake.WorkerReportsProgress = true;
            backgroundWorkerRovnake.WorkerSupportsCancellation = true;

            backgroundWorkerPolozky.WorkerReportsProgress = true;
            backgroundWorkerPolozky.WorkerSupportsCancellation = true;
        }
        #region tlacitka
        private void ButtonZrusit_Click(object sender, EventArgs e)
        {
            switch(_zapnuteHladanie)
            {
                case 1:
                    backgroundWorkerRebricek.CancelAsync();
                    break;
                case 2:
                    backgroundWorkerPocty.CancelAsync();
                    break;
                case 3:
                    backgroundWorkerRovnake.CancelAsync();
                    break;
                case 4:
                    backgroundWorkerPolozky.CancelAsync();
                    break;
                case 5:
                    backgroundWorkerLudia.CancelAsync();
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(Decimal.ToInt32(numericUpDown1.Value) == 0)
            {
                MessageBox.Show("Nezadali ste ID!");
            }
            else if (backgroundWorkerLudia.IsBusy != true)
            {
                _zapnuteHladanie = 5;

                buttonLudia.Enabled = false;
                buttonPolozky.Enabled = false;
                buttonPocty.Enabled = false;
                buttonRebricek.Enabled = false;
                buttonRovnake.Enabled = false;

                ButtonZrusit.Enabled = true;
                backgroundWorkerLudia.RunWorkerAsync();
            }
        }

        private void buttonPolozky_Click(object sender, EventArgs e)
        {
            if (Decimal.ToInt32(numericUpDown1.Value) == 0)
            {
                MessageBox.Show("Nezadali ste ID!");
            }
            else if (backgroundWorkerPolozky.IsBusy != true)
            {
                _zapnuteHladanie = 4;

                buttonLudia.Enabled = false;
                buttonPolozky.Enabled = false;
                buttonPocty.Enabled = false;
                buttonRebricek.Enabled = false;
                buttonRovnake.Enabled = false;

                ButtonZrusit.Enabled = true;
                backgroundWorkerPolozky.RunWorkerAsync();
            }
        }

        private void buttonRovnake_Click(object sender, EventArgs e)
        {
            if (backgroundWorkerRovnake.IsBusy != true)
            {
                _zapnuteHladanie = 3;

                buttonLudia.Enabled = false;
                buttonPolozky.Enabled = false;
                buttonPocty.Enabled = false;
                buttonRebricek.Enabled = false;
                buttonRovnake.Enabled = false;

                ButtonZrusit.Enabled = true;
                backgroundWorkerRovnake.RunWorkerAsync();
            }
        }

        private void buttonPocty_Click(object sender, EventArgs e)
        {
            if (backgroundWorkerPocty.IsBusy != true)
            {
                _zapnuteHladanie = 2;

                buttonLudia.Enabled = false;
                buttonPolozky.Enabled = false;
                buttonPocty.Enabled = false;
                buttonRebricek.Enabled = false;
                buttonRovnake.Enabled = false;

                ButtonZrusit.Enabled = true;
                backgroundWorkerPocty.RunWorkerAsync();
            }
        }

        private void buttonRebricek_Click(object sender, EventArgs e)
        {
            if (backgroundWorkerRebricek.IsBusy != true)
            {
                _zapnuteHladanie = 1;

                buttonLudia.Enabled = false;
                buttonPolozky.Enabled = false;
                buttonPocty.Enabled = false;
                buttonRebricek.Enabled = false;
                buttonRovnake.Enabled = false;

                ButtonZrusit.Enabled = true;
                backgroundWorkerRebricek.RunWorkerAsync();
            }
        }
        #endregion

        #region rebricek
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            int i = 0;
            BackgroundWorker worker = sender as BackgroundWorker;
            worker.ReportProgress(0, "Začiatok načítavania dát");
            var rebricekDataTable = new DataTable();
            var rebricek = Queries.Rebricek();
            var pocetZanamov = rebricek.Count();
            var polovica = pocetZanamov / 2;
            worker.ReportProgress(25, $"Dáta stiahnuté - riadkov {pocetZanamov}");
            rebricekDataTable.Columns.Add("ID_Zamestnanec");
            rebricekDataTable.Columns.Add("prihlMeno");
            rebricekDataTable.Columns.Add("meno");
            rebricekDataTable.Columns.Add("priezvisko");
            rebricekDataTable.Columns.Add("pocetTransakcii");
            rebricekDataTable.Columns.Add("rebricekPoctuTransakcii");
            foreach (var osoba in rebricek)
            {
                if (worker.CancellationPending == true)
                {
                    e.Cancel = true;
                    break;
                }

                var row = rebricekDataTable.NewRow();

                row["ID_Zamestnanec"] = osoba.ID_Zamesntanec;
                row["prihlMeno"] = osoba.prihlMeno;
                row["meno"] = osoba.meno;
                row["priezvisko"] = osoba.priezvisko;
                row["pocetTransakcii"] = osoba.pocetTransakcii;
                row["rebricekPoctuTransakcii"] = osoba.rebricekPoctuTransakcii;


                rebricekDataTable.Rows.Add(row);
                if (++i == polovica)
                {
                    worker.ReportProgress(50, "GUI naplnené na polovicu");
                }
            }
            worker.ReportProgress(100, "Napĺňanie GUI hotové");
            e.Result = rebricekDataTable;
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            labelProgres.Text = $"{e.ProgressPercentage}% ... {e.UserState}";
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                label2.Text = "Zrušené!";

                buttonLudia.Enabled = true;
                buttonPolozky.Enabled = true;
                buttonPocty.Enabled = true;
                buttonRebricek.Enabled = true;
                buttonRovnake.Enabled = true;

                ButtonZrusit.Enabled = false;
            }
            else if (e.Error != null)
            {
                label2.Text = "Error: " + e.Error.Message;

                buttonLudia.Enabled = true;
                buttonPolozky.Enabled = true;
                buttonPocty.Enabled = true;
                buttonRebricek.Enabled = true;
                buttonRovnake.Enabled = true;

                ButtonZrusit.Enabled = false;
            }
            else
            {
                label2.Text = "Data načítané!";
                var vysledky = (DataTable)e.Result;
                dataGridView1.DataSource = vysledky;
                dataGridView1.Columns["ID_Zamestnanec"].Visible = false;

                buttonLudia.Enabled = true;
                buttonPolozky.Enabled = true;
                buttonPocty.Enabled = true;
                buttonRebricek.Enabled = true;
                buttonRovnake.Enabled = true;

                ButtonZrusit.Enabled = false;
            }
        }
        #endregion

        #region pocty
        private void backgroundWorkerPocty_DoWork(object sender, DoWorkEventArgs e)
        {
            int i = 0;
            BackgroundWorker worker = sender as BackgroundWorker;
            worker.ReportProgress(0, "Začiatok načítavania dát");
            var poctyDataTable = new DataTable();
            var pocty = Queries.PoctyPoloziekVTransakcii();
            var pocetZanamov = pocty.Count();
            var polovica = pocetZanamov / 2;
            worker.ReportProgress(25, $"Dáta stiahnuté - riadkov {pocetZanamov}");
            poctyDataTable.Columns.Add("ID_Transakcie");
            poctyDataTable.Columns.Add("pocetPoloziek");
            foreach (var zaznam in pocty)
            {
                if (worker.CancellationPending == true)
                {
                    e.Cancel = true;
                    break;
                }

                var row = poctyDataTable.NewRow();

                row["ID_Transakcie"] = zaznam.ID_Transakcie;
                row["pocetPoloziek"] = zaznam.pocetPoloziek;


                poctyDataTable.Rows.Add(row);
                if (++i == polovica)
                {
                    worker.ReportProgress(50, "GUI naplnené na polovicu");
                }
            }
            worker.ReportProgress(100, "Napĺňanie GUI hotové");
            e.Result = poctyDataTable;
        }

        private void backgroundWorkerPocty_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            labelProgres.Text = $"{e.ProgressPercentage}% ... {e.UserState}";
        }

        private void backgroundWorkerPocty_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                label2.Text = "Zrušené!";

                buttonLudia.Enabled = true;
                buttonPolozky.Enabled = true;
                buttonPocty.Enabled = true;
                buttonRebricek.Enabled = true;
                buttonRovnake.Enabled = true;

                ButtonZrusit.Enabled = false;
            }
            else if (e.Error != null)
            {
                label2.Text = "Error: " + e.Error.Message;

                buttonLudia.Enabled = true;
                buttonPolozky.Enabled = true;
                buttonPocty.Enabled = true;
                buttonRebricek.Enabled = true;
                buttonRovnake.Enabled = true;

                ButtonZrusit.Enabled = false;
            }
            else
            {
                label2.Text = "Data načítané!";
                var vysledky = (DataTable)e.Result;
                dataGridView1.DataSource = vysledky;

                buttonLudia.Enabled = true;
                buttonPolozky.Enabled = true;
                buttonPocty.Enabled = true;
                buttonRebricek.Enabled = true;
                buttonRovnake.Enabled = true;

                ButtonZrusit.Enabled = false;
            }
        }
        #endregion

        #region rovnake
        private void backgroundWorkerRovnake_DoWork(object sender, DoWorkEventArgs e)
        {
            int i = 0;
            BackgroundWorker worker = sender as BackgroundWorker;
            worker.ReportProgress(0, "Začiatok načítavania dát");
            var rovnakeDataTable = new DataTable();
            var rovnake = Queries.PoctyTransakciiSRovnakymPoctomPoloziek();
            var pocetZanamov = rovnake.Count();
            var polovica = pocetZanamov / 2;
            worker.ReportProgress(25, $"Dáta stiahnuté - riadkov {pocetZanamov}");
            rovnakeDataTable.Columns.Add("pocetPoloziek");
            rovnakeDataTable.Columns.Add("pocetTransakcii");
            foreach (var zaznam in rovnake)
            {
                if (worker.CancellationPending == true)
                {
                    e.Cancel = true;
                    break;
                }

                var row = rovnakeDataTable.NewRow();

                row["pocetPoloziek"] = zaznam.pocetPoloziek;
                row["pocetTransakcii"] = zaznam.pocetTransakcii;


                rovnakeDataTable.Rows.Add(row);
                if (++i == polovica)
                {
                    worker.ReportProgress(50, "GUI naplnené na polovicu");
                }
            }
            worker.ReportProgress(100, "Napĺňanie GUI hotové");
            e.Result = rovnakeDataTable;
        }

        private void backgroundWorkerRovnake_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            labelProgres.Text = $"{e.ProgressPercentage}% ... {e.UserState}";
        }

        private void backgroundWorkerRovnake_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                label2.Text = "Zrušené!";

                buttonLudia.Enabled = true;
                buttonPolozky.Enabled = true;
                buttonPocty.Enabled = true;
                buttonRebricek.Enabled = true;
                buttonRovnake.Enabled = true;

                ButtonZrusit.Enabled = false;
            }
            else if (e.Error != null)
            {
                label2.Text = "Error: " + e.Error.Message;

                buttonLudia.Enabled = true;
                buttonPolozky.Enabled = true;
                buttonPocty.Enabled = true;
                buttonRebricek.Enabled = true;
                buttonRovnake.Enabled = true;

                ButtonZrusit.Enabled = false;
            }
            else
            {
                label2.Text = "Data načítané!";
                var vysledky = (DataTable)e.Result;
                dataGridView1.DataSource = vysledky;

                buttonLudia.Enabled = true;
                buttonPolozky.Enabled = true;
                buttonPocty.Enabled = true;
                buttonRebricek.Enabled = true;
                buttonRovnake.Enabled = true;

                ButtonZrusit.Enabled = false;
            }
        }
        #endregion

        #region polozky
        private void backgroundWorkerPolozky_DoWork(object sender, DoWorkEventArgs e)
        {
            int i = 0;
            BackgroundWorker worker = sender as BackgroundWorker;
            worker.ReportProgress(0, "Začiatok načítavania dát");
            var polozkyDataTable = new DataTable();
            var polozky = Queries.ProduktyVTransakcii(Decimal.ToInt32(numericUpDown1.Value));
            var pocetZanamov = polozky.Count();
            var polovica = pocetZanamov / 2;
            worker.ReportProgress(25, $"Dáta stiahnuté - riadkov {pocetZanamov}");
            polozkyDataTable.Columns.Add("ID");
            polozkyDataTable.Columns.Add("nazov");
            polozkyDataTable.Columns.Add("cena");
            polozkyDataTable.Columns.Add("typTransakcie");
            foreach (var zaznam in polozky)
            {
                if (worker.CancellationPending == true)
                {
                    e.Cancel = true;
                    break;
                }

                var row = polozkyDataTable.NewRow();

                row["ID"] = zaznam.ID;
                row["nazov"] = zaznam.nazov;
                row["cena"] = zaznam.cena;
                row["typTransakcie"] = zaznam.typTransakcie;


                polozkyDataTable.Rows.Add(row);
                if (++i == polovica)
                {
                    worker.ReportProgress(50, "GUI naplnené na polovicu");
                }
            }
            worker.ReportProgress(100, "Napĺňanie GUI hotové");
            e.Result = polozkyDataTable;
        }

        private void backgroundWorkerPolozky_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            labelProgres.Text = $"{e.ProgressPercentage}% ... {e.UserState}";
        }

        private void backgroundWorkerPolozky_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                label2.Text = "Zrušené!";

                buttonLudia.Enabled = true;
                buttonPolozky.Enabled = true;
                buttonPocty.Enabled = true;
                buttonRebricek.Enabled = true;
                buttonRovnake.Enabled = true;

                ButtonZrusit.Enabled = false;
            }
            else if (e.Error != null)
            {
                label2.Text = "Error: " + e.Error.Message;

                buttonLudia.Enabled = true;
                buttonPolozky.Enabled = true;
                buttonPocty.Enabled = true;
                buttonRebricek.Enabled = true;
                buttonRovnake.Enabled = true;

                ButtonZrusit.Enabled = false;
            }
            else
            {
                label2.Text = "Data načítané!";
                var vysledky = (DataTable)e.Result;
                dataGridView1.DataSource = vysledky;
                dataGridView1.Columns["ID"].Visible = false;

                buttonLudia.Enabled = true;
                buttonPolozky.Enabled = true;
                buttonPocty.Enabled = true;
                buttonRebricek.Enabled = true;
                buttonRovnake.Enabled = true;

                ButtonZrusit.Enabled = false;
            }
        }
        #endregion

        #region ludia
        private void backgroundWorkerLudia_DoWork(object sender, DoWorkEventArgs e)
        {
            int i = 0;
            BackgroundWorker worker = sender as BackgroundWorker;
            worker.ReportProgress(0, "Začiatok načítavania dát");
            var osobyDataTable = new DataTable();
            var osoby = Queries.TransakciaOsoby(Decimal.ToInt32(numericUpDown1.Value));
            var pocetZanamov = osoby.Count();
            var polovica = pocetZanamov / 2;
            worker.ReportProgress(25, $"Dáta stiahnuté - riadkov {pocetZanamov}");
            osobyDataTable.Columns.Add("IDTransakcie");
            osobyDataTable.Columns.Add("prihlMeno");
            osobyDataTable.Columns.Add("menoZamestnanca");
            osobyDataTable.Columns.Add("priezviskoZamestnanca");
            osobyDataTable.Columns.Add("menoZakaznika");
            osobyDataTable.Columns.Add("priezviskoZakaznika");
            osobyDataTable.Columns.Add("typTransakcie");
            foreach (var osoba in osoby)
            {
                if (worker.CancellationPending == true)
                {
                    e.Cancel = true;
                    break;
                }

                var row = osobyDataTable.NewRow();

                row["IDTransakcie"] = osoba.IDTransakcie;
                row["prihlMeno"] = osoba.prihlMeno;
                row["menoZamestnanca"] = osoba.menoZamestnanca;
                row["priezviskoZamestnanca"] = osoba.priezviskoZamestnanca;
                row["menoZakaznika"] = osoba.menoZakaznika;
                row["priezviskoZakaznika"] = osoba.priezviskoZakaznika;
                row["typTransakcie"] = osoba.typTransakcie;

                osobyDataTable.Rows.Add(row);
                if (++i == polovica)
                {
                    worker.ReportProgress(50, "GUI naplnené na polovicu");
                }
            }
            worker.ReportProgress(100, "Napĺňanie GUI hotové");
            e.Result = osobyDataTable;
        }

        private void backgroundWorkerLudia_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            labelProgres.Text = $"{e.ProgressPercentage}% ... {e.UserState}";
        }

        private void backgroundWorkerLudia_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                label2.Text = "Zrušené!";

                buttonLudia.Enabled = true;
                buttonPolozky.Enabled = true;
                buttonPocty.Enabled = true;
                buttonRebricek.Enabled = true;
                buttonRovnake.Enabled = true;

                ButtonZrusit.Enabled = false;
            }
            else if (e.Error != null)
            {
                label2.Text = "Error: " + e.Error.Message;

                buttonLudia.Enabled = true;
                buttonPolozky.Enabled = true;
                buttonPocty.Enabled = true;
                buttonRebricek.Enabled = true;
                buttonRovnake.Enabled = true;

                ButtonZrusit.Enabled = false;
            }
            else
            {
                label2.Text = "Data načítané!";
                var vysledky = (DataTable)e.Result;
                dataGridView1.DataSource = vysledky;
                dataGridView1.Columns["IDTransakcie"].Visible = false;

                buttonLudia.Enabled = true;
                buttonPolozky.Enabled = true;
                buttonPocty.Enabled = true;
                buttonRebricek.Enabled = true;
                buttonRovnake.Enabled = true;

                ButtonZrusit.Enabled = false;
            }
        }
        #endregion
    }
}