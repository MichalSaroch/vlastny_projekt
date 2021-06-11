
namespace vlastny_projekt
{
    partial class Registracia
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
            this.textBoxMeno = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxHeslo = new System.Windows.Forms.TextBox();
            this.buttonRegistrovat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxMeno
            // 
            this.textBoxMeno.Location = new System.Drawing.Point(28, 37);
            this.textBoxMeno.Name = "textBoxMeno";
            this.textBoxMeno.Size = new System.Drawing.Size(155, 20);
            this.textBoxMeno.TabIndex = 0;
            this.textBoxMeno.TextChanged += new System.EventHandler(this.textBoxMeno_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Prihlasovacie meno";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Prihlasovacie heslo";
            // 
            // textBoxHeslo
            // 
            this.textBoxHeslo.Location = new System.Drawing.Point(28, 87);
            this.textBoxHeslo.Name = "textBoxHeslo";
            this.textBoxHeslo.PasswordChar = '*';
            this.textBoxHeslo.Size = new System.Drawing.Size(155, 20);
            this.textBoxHeslo.TabIndex = 3;
            this.textBoxHeslo.TextChanged += new System.EventHandler(this.textBoxHeslo_TextChanged);
            // 
            // buttonRegistrovat
            // 
            this.buttonRegistrovat.Location = new System.Drawing.Point(37, 122);
            this.buttonRegistrovat.Name = "buttonRegistrovat";
            this.buttonRegistrovat.Size = new System.Drawing.Size(135, 31);
            this.buttonRegistrovat.TabIndex = 4;
            this.buttonRegistrovat.Text = "Registrovať sa";
            this.buttonRegistrovat.UseVisualStyleBackColor = true;
            this.buttonRegistrovat.Click += new System.EventHandler(this.buttonRegistrovat_Click);
            // 
            // Registracia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(209, 184);
            this.Controls.Add(this.buttonRegistrovat);
            this.Controls.Add(this.textBoxHeslo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxMeno);
            this.Name = "Registracia";
            this.Text = "Registrácia";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxMeno;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxHeslo;
        private System.Windows.Forms.Button buttonRegistrovat;
    }
}