namespace TVP_PROJEKAT_1
{
    partial class frmKupac
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
            this.lsTrenutneRezervacije = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.lsTekuceRezervacije = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblIme = new System.Windows.Forms.Label();
            this.lblPrezime = new System.Windows.Forms.Label();
            this.lblVreme = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lsTrenutneRezervacije
            // 
            this.lsTrenutneRezervacije.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lsTrenutneRezervacije.FormattingEnabled = true;
            this.lsTrenutneRezervacije.ItemHeight = 16;
            this.lsTrenutneRezervacije.Location = new System.Drawing.Point(41, 59);
            this.lsTrenutneRezervacije.Name = "lsTrenutneRezervacije";
            this.lsTrenutneRezervacije.Size = new System.Drawing.Size(329, 196);
            this.lsTrenutneRezervacije.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button1.Location = new System.Drawing.Point(572, 333);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(175, 46);
            this.button1.TabIndex = 1;
            this.button1.Text = "Nova rezervacija";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnLogout.Location = new System.Drawing.Point(572, 437);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(175, 44);
            this.btnLogout.TabIndex = 2;
            this.btnLogout.Text = "Izloguj se";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // lsTekuceRezervacije
            // 
            this.lsTekuceRezervacije.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lsTekuceRezervacije.ForeColor = System.Drawing.Color.Green;
            this.lsTekuceRezervacije.FormattingEnabled = true;
            this.lsTekuceRezervacije.ItemHeight = 16;
            this.lsTekuceRezervacije.Location = new System.Drawing.Point(418, 59);
            this.lsTekuceRezervacije.Name = "lsTekuceRezervacije";
            this.lsTekuceRezervacije.Size = new System.Drawing.Size(329, 196);
            this.lsTekuceRezervacije.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(415, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Tekuće rezervacije:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(38, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Zakazani termini:";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button2.Location = new System.Drawing.Point(224, 261);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(146, 37);
            this.button2.TabIndex = 6;
            this.button2.Text = "Otkaži rezervaciju";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(110, 421);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 18);
            this.label3.TabIndex = 7;
            this.label3.Text = "Ime:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(79, 445);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 18);
            this.label4.TabIndex = 8;
            this.label4.Text = "Prezime:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(33, 467);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 18);
            this.label5.TabIndex = 9;
            this.label5.Text = "Vreme Pristupa:";
            // 
            // lblIme
            // 
            this.lblIme.AutoSize = true;
            this.lblIme.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblIme.Location = new System.Drawing.Point(161, 421);
            this.lblIme.Name = "lblIme";
            this.lblIme.Size = new System.Drawing.Size(46, 18);
            this.lblIme.TabIndex = 7;
            this.lblIme.Text = "label3";
            // 
            // lblPrezime
            // 
            this.lblPrezime.AutoSize = true;
            this.lblPrezime.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblPrezime.Location = new System.Drawing.Point(161, 445);
            this.lblPrezime.Name = "lblPrezime";
            this.lblPrezime.Size = new System.Drawing.Size(46, 18);
            this.lblPrezime.TabIndex = 8;
            this.lblPrezime.Text = "label4";
            // 
            // lblVreme
            // 
            this.lblVreme.AutoSize = true;
            this.lblVreme.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblVreme.Location = new System.Drawing.Point(161, 467);
            this.lblVreme.Name = "lblVreme";
            this.lblVreme.Size = new System.Drawing.Size(46, 18);
            this.lblVreme.TabIndex = 9;
            this.lblVreme.Text = "label5";
            // 
            // frmKupac
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 493);
            this.Controls.Add(this.lblVreme);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblPrezime);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblIme);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lsTekuceRezervacije);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lsTrenutneRezervacije);
            this.Name = "frmKupac";
            this.Text = "frmKupac";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lsTrenutneRezervacije;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.ListBox lsTekuceRezervacije;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblIme;
        private System.Windows.Forms.Label lblPrezime;
        private System.Windows.Forms.Label lblVreme;
    }
}