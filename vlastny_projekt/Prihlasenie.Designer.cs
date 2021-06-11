
namespace vlastny_projekt
{
    partial class Prihlasenie
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
            this.buttonPrihlas = new System.Windows.Forms.Button();
            this.textBoxMeno = new System.Windows.Forms.TextBox();
            this.textBoxHeslo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // buttonPrihlas
            // 
            this.buttonPrihlas.Location = new System.Drawing.Point(37, 122);
            this.buttonPrihlas.Name = "buttonPrihlas";
            this.buttonPrihlas.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.buttonPrihlas.Size = new System.Drawing.Size(135, 31);
            this.buttonPrihlas.TabIndex = 0;
            this.buttonPrihlas.Text = "Prihlásiť sa";
            this.buttonPrihlas.UseVisualStyleBackColor = true;
            this.buttonPrihlas.Click += new System.EventHandler(this.buttonPrihlas_Click);
            // 
            // textBoxMeno
            // 
            this.textBoxMeno.Location = new System.Drawing.Point(28, 37);
            this.textBoxMeno.Name = "textBoxMeno";
            this.textBoxMeno.Size = new System.Drawing.Size(155, 20);
            this.textBoxMeno.TabIndex = 1;
            // 
            // textBoxHeslo
            // 
            this.textBoxHeslo.Location = new System.Drawing.Point(28, 87);
            this.textBoxHeslo.Name = "textBoxHeslo";
            this.textBoxHeslo.PasswordChar = '*';
            this.textBoxHeslo.Size = new System.Drawing.Size(155, 20);
            this.textBoxHeslo.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Prihlasovacie meno";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Prihlasovacie heslo";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(63, 162);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(76, 13);
            this.linkLabel1.TabIndex = 5;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Registrovať sa";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // Prihlasenie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(209, 184);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxHeslo);
            this.Controls.Add(this.textBoxMeno);
            this.Controls.Add(this.buttonPrihlas);
            this.Name = "Prihlasenie";
            this.Text = "Prihlásenie";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonPrihlas;
        private System.Windows.Forms.TextBox textBoxMeno;
        private System.Windows.Forms.TextBox textBoxHeslo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}

