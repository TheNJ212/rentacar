namespace TVP_PROJEKAT_1
{
    partial class frmPostavljanjeHeada
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
            this.txtHeadUsername = new System.Windows.Forms.TextBox();
            this.txtHeadPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btHeadOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtHeadUsername
            // 
            this.txtHeadUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtHeadUsername.Location = new System.Drawing.Point(73, 39);
            this.txtHeadUsername.Name = "txtHeadUsername";
            this.txtHeadUsername.Size = new System.Drawing.Size(211, 22);
            this.txtHeadUsername.TabIndex = 0;
            // 
            // txtHeadPassword
            // 
            this.txtHeadPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtHeadPassword.Location = new System.Drawing.Point(73, 104);
            this.txtHeadPassword.Name = "txtHeadPassword";
            this.txtHeadPassword.Size = new System.Drawing.Size(211, 22);
            this.txtHeadPassword.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(70, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Korisničko ime HeadAdmina";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(70, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Lozinka HeadAdmina";
            // 
            // btHeadOK
            // 
            this.btHeadOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btHeadOK.Location = new System.Drawing.Point(125, 152);
            this.btHeadOK.Name = "btHeadOK";
            this.btHeadOK.Size = new System.Drawing.Size(103, 35);
            this.btHeadOK.TabIndex = 4;
            this.btHeadOK.Text = "Potvrdi";
            this.btHeadOK.UseVisualStyleBackColor = true;
            this.btHeadOK.Click += new System.EventHandler(this.btHeadOK_Click);
            // 
            // frmPostavljanjeHeada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 199);
            this.Controls.Add(this.btHeadOK);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtHeadPassword);
            this.Controls.Add(this.txtHeadUsername);
            this.Name = "frmPostavljanjeHeada";
            this.Text = "frmPostavljanjeHeada";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtHeadUsername;
        private System.Windows.Forms.TextBox txtHeadPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btHeadOK;
    }
}