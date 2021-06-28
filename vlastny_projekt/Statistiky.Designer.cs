
namespace vlastny_projekt
{
    partial class Statistiky
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.backgroundWorkerRebricek = new System.ComponentModel.BackgroundWorker();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonRebricek = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonPocty = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonRovnake = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonPolozky = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonLudia = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.ButtonZrusit = new System.Windows.Forms.Button();
            this.labelProgres = new System.Windows.Forms.Label();
            this.backgroundWorkerPocty = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerRovnake = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerPolozky = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerLudia = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(13, 13);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(791, 418);
            this.dataGridView1.TabIndex = 0;
            // 
            // backgroundWorkerRebricek
            // 
            this.backgroundWorkerRebricek.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorkerRebricek.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorkerRebricek.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(811, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Rebríček zamestnancov";
            // 
            // buttonRebricek
            // 
            this.buttonRebricek.Location = new System.Drawing.Point(811, 30);
            this.buttonRebricek.Name = "buttonRebricek";
            this.buttonRebricek.Size = new System.Drawing.Size(124, 23);
            this.buttonRebricek.TabIndex = 2;
            this.buttonRebricek.Text = "Rebríček";
            this.buttonRebricek.UseVisualStyleBackColor = true;
            this.buttonRebricek.Click += new System.EventHandler(this.buttonRebricek_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(811, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Počty položiek";
            // 
            // buttonPocty
            // 
            this.buttonPocty.Location = new System.Drawing.Point(811, 73);
            this.buttonPocty.Name = "buttonPocty";
            this.buttonPocty.Size = new System.Drawing.Size(124, 23);
            this.buttonPocty.TabIndex = 4;
            this.buttonPocty.Text = "Počty položiek";
            this.buttonPocty.UseVisualStyleBackColor = true;
            this.buttonPocty.Click += new System.EventHandler(this.buttonPocty_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(811, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Rovnaký počet položiek";
            // 
            // buttonRovnake
            // 
            this.buttonRovnake.Location = new System.Drawing.Point(811, 115);
            this.buttonRovnake.Name = "buttonRovnake";
            this.buttonRovnake.Size = new System.Drawing.Size(124, 23);
            this.buttonRovnake.TabIndex = 6;
            this.buttonRovnake.Text = "Rovnaké počty";
            this.buttonRovnake.UseVisualStyleBackColor = true;
            this.buttonRovnake.Click += new System.EventHandler(this.buttonRovnake_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(811, 223);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Položky v transakcii*";
            // 
            // buttonPolozky
            // 
            this.buttonPolozky.Location = new System.Drawing.Point(811, 240);
            this.buttonPolozky.Name = "buttonPolozky";
            this.buttonPolozky.Size = new System.Drawing.Size(124, 23);
            this.buttonPolozky.TabIndex = 8;
            this.buttonPolozky.Text = "Položky";
            this.buttonPolozky.UseVisualStyleBackColor = true;
            this.buttonPolozky.Click += new System.EventHandler(this.buttonPolozky_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(811, 266);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Transakcie ľudia*";
            // 
            // buttonLudia
            // 
            this.buttonLudia.Location = new System.Drawing.Point(811, 282);
            this.buttonLudia.Name = "buttonLudia";
            this.buttonLudia.Size = new System.Drawing.Size(124, 23);
            this.buttonLudia.TabIndex = 10;
            this.buttonLudia.Text = "Ľudia";
            this.buttonLudia.UseVisualStyleBackColor = true;
            this.buttonLudia.Click += new System.EventHandler(this.button1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(811, 308);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "*treba zadať ID";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(811, 324);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(124, 20);
            this.numericUpDown1.TabIndex = 12;
            // 
            // ButtonZrusit
            // 
            this.ButtonZrusit.Location = new System.Drawing.Point(811, 381);
            this.ButtonZrusit.Name = "ButtonZrusit";
            this.ButtonZrusit.Size = new System.Drawing.Size(124, 23);
            this.ButtonZrusit.TabIndex = 13;
            this.ButtonZrusit.Text = "Zrušiť";
            this.ButtonZrusit.UseVisualStyleBackColor = true;
            this.ButtonZrusit.Click += new System.EventHandler(this.ButtonZrusit_Click);
            // 
            // labelProgres
            // 
            this.labelProgres.AutoSize = true;
            this.labelProgres.Location = new System.Drawing.Point(10, 440);
            this.labelProgres.Name = "labelProgres";
            this.labelProgres.Size = new System.Drawing.Size(90, 13);
            this.labelProgres.TabIndex = 14;
            this.labelProgres.Text = "Čaká sa na výber";
            // 
            // backgroundWorkerPocty
            // 
            this.backgroundWorkerPocty.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerPocty_DoWork);
            this.backgroundWorkerPocty.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerPocty_ProgressChanged);
            this.backgroundWorkerPocty.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerPocty_RunWorkerCompleted);
            // 
            // backgroundWorkerRovnake
            // 
            this.backgroundWorkerRovnake.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerRovnake_DoWork);
            this.backgroundWorkerRovnake.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerRovnake_ProgressChanged);
            this.backgroundWorkerRovnake.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerRovnake_RunWorkerCompleted);
            // 
            // backgroundWorkerPolozky
            // 
            this.backgroundWorkerPolozky.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerPolozky_DoWork);
            this.backgroundWorkerPolozky.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerPolozky_ProgressChanged);
            this.backgroundWorkerPolozky.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerPolozky_RunWorkerCompleted);
            // 
            // backgroundWorkerLudia
            // 
            this.backgroundWorkerLudia.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerLudia_DoWork);
            this.backgroundWorkerLudia.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerLudia_ProgressChanged);
            this.backgroundWorkerLudia.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerLudia_RunWorkerCompleted);
            // 
            // Statistiky
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 462);
            this.Controls.Add(this.labelProgres);
            this.Controls.Add(this.ButtonZrusit);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.buttonLudia);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.buttonPolozky);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonRovnake);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonPocty);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonRebricek);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Statistiky";
            this.Text = "Statistiky";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.ComponentModel.BackgroundWorker backgroundWorkerRebricek;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonRebricek;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonPocty;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonRovnake;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonPolozky;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonLudia;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button ButtonZrusit;
        private System.Windows.Forms.Label labelProgres;
        private System.ComponentModel.BackgroundWorker backgroundWorkerPocty;
        private System.ComponentModel.BackgroundWorker backgroundWorkerRovnake;
        private System.ComponentModel.BackgroundWorker backgroundWorkerPolozky;
        private System.ComponentModel.BackgroundWorker backgroundWorkerLudia;
    }
}