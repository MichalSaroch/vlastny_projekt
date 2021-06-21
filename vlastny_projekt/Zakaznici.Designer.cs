
namespace vlastny_projekt
{
    partial class Zakaznici
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
            this.listBoxOsoby = new System.Windows.Forms.ListBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.backgroundWorkerQuery = new System.ComponentModel.BackgroundWorker();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonUpravit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBoxOsoby
            // 
            this.listBoxOsoby.FormattingEnabled = true;
            this.listBoxOsoby.Location = new System.Drawing.Point(12, 12);
            this.listBoxOsoby.Name = "listBoxOsoby";
            this.listBoxOsoby.Size = new System.Drawing.Size(202, 420);
            this.listBoxOsoby.TabIndex = 0;
            this.listBoxOsoby.SelectedIndexChanged += new System.EventHandler(this.listBoxOsoby_SelectedIndexChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(220, 29);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(125, 20);
            this.textBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(221, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Hľadať podľa priezviska";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(220, 56);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(126, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Hľadať";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // backgroundWorkerQuery
            // 
            this.backgroundWorkerQuery.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerQuery_DoWork);
            this.backgroundWorkerQuery.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerQuery_ProgressChanged);
            this.backgroundWorkerQuery.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerQuery_RunWorkerCompleted);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(221, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 4;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // buttonUpravit
            // 
            this.buttonUpravit.Location = new System.Drawing.Point(224, 408);
            this.buttonUpravit.Name = "buttonUpravit";
            this.buttonUpravit.Size = new System.Drawing.Size(121, 23);
            this.buttonUpravit.TabIndex = 5;
            this.buttonUpravit.Text = "Upraviť";
            this.buttonUpravit.UseVisualStyleBackColor = true;
            this.buttonUpravit.Click += new System.EventHandler(this.buttonUpravit_Click);
            // 
            // Zakaznici
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 450);
            this.Controls.Add(this.buttonUpravit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.listBoxOsoby);
            this.Name = "Zakaznici";
            this.Text = "Zakaznici";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxOsoby;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.ComponentModel.BackgroundWorker backgroundWorkerQuery;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonUpravit;
    }
}