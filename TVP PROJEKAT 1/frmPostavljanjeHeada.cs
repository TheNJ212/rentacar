using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TVP_PROJEKAT_1
{
    public partial class frmPostavljanjeHeada : Form
    {
        public frmPostavljanjeHeada()
        {

            InitializeComponent();
            txtHeadPassword.PasswordChar = '*';
            FormClosing += FrmPostavljanjeHeada_FormClosing;
        }

        private void FrmPostavljanjeHeada_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.TaskManagerClosing) Application.Exit();
        }

        private void btHeadOK_Click(object sender, EventArgs e)
        {

            if (txtHeadUsername.Text.Trim().Length == 0)
            {
                MessageBox.Show("Niste uneli korisničko ime!");
                return;
            }
            if (txtHeadPassword.Text.Trim().Length == 0)
            {
                MessageBox.Show("Niste uneli lozinku!");
                return;
            }
            Admin admin = new Admin(txtHeadUsername.Text,txtHeadPassword.Text,"HeadAdmin","");
            FileStream fs = new FileStream("head.bin", FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs,admin);
            fs.Close();
            Close();
        }
    }
}
