
namespace vlastny_projekt
{
    partial class Menu
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
            this.buttonPouzivatelia = new System.Windows.Forms.Button();
            this.buttonTovar = new System.Windows.Forms.Button();
            this.buttonStatistiky = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonPouzivatelia
            // 
            this.buttonPouzivatelia.Location = new System.Drawing.Point(12, 12);
            this.buttonPouzivatelia.Name = "buttonPouzivatelia";
            this.buttonPouzivatelia.Size = new System.Drawing.Size(199, 29);
            this.buttonPouzivatelia.TabIndex = 0;
            this.buttonPouzivatelia.Text = "Používatelia";
            this.buttonPouzivatelia.UseVisualStyleBackColor = true;
            this.buttonPouzivatelia.Click += new System.EventHandler(this.buttonPouzivatelia_Click);
            // 
            // buttonTovar
            // 
            this.buttonTovar.Location = new System.Drawing.Point(12, 47);
            this.buttonTovar.Name = "buttonTovar";
            this.buttonTovar.Size = new System.Drawing.Size(199, 29);
            this.buttonTovar.TabIndex = 1;
            this.buttonTovar.Text = "Tovar";
            this.buttonTovar.UseVisualStyleBackColor = true;
            this.buttonTovar.Click += new System.EventHandler(this.buttonTovar_Click);
            // 
            // buttonStatistiky
            // 
            this.buttonStatistiky.Location = new System.Drawing.Point(12, 82);
            this.buttonStatistiky.Name = "buttonStatistiky";
            this.buttonStatistiky.Size = new System.Drawing.Size(199, 29);
            this.buttonStatistiky.TabIndex = 2;
            this.buttonStatistiky.Text = "Štatistiky";
            this.buttonStatistiky.UseVisualStyleBackColor = true;
            this.buttonStatistiky.Click += new System.EventHandler(this.buttonStatistiky_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(223, 132);
            this.Controls.Add(this.buttonStatistiky);
            this.Controls.Add(this.buttonTovar);
            this.Controls.Add(this.buttonPouzivatelia);
            this.Name = "Menu";
            this.Text = "Menu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonPouzivatelia;
        private System.Windows.Forms.Button buttonTovar;
        private System.Windows.Forms.Button buttonStatistiky;
    }
}