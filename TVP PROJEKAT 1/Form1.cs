using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TVP_PROJEKAT_1
{
    
    public partial class Form1 : Form
    {

        Admin admin = new Admin("admin", "admin", "HeadAdmin", "");
        List<Kupac> korisnici = new List<Kupac>();
        List<Ponuda> ponude = new List<Ponuda>();


        public Form1()
        {
            InitializeComponent();
            txtPassword.PasswordChar = '*';
            chkPassword.CheckedChanged += ChkPassword_CheckedChanged;
            ocistiIsteklePonude();
            podesiValidnePonude();
            AcceptButton = button1;
            headAdmin();

        }

        private void ChkPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPassword.Checked)
            {
                txtPassword.PasswordChar = '\0';
            }
            else txtPassword.PasswordChar = '*';
        }

        public void vratiLogin(object sender, FormClosingEventArgs e)
        {
            Visible = true;
            txtUsername.Clear();
            txtPassword.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ucitajKorisnike();
            Cpanel cp = new Cpanel();
            frmKupac formaKupac = new frmKupac();
            cp.FormClosing += vratiLogin;
            formaKupac.FormClosing += vratiLogin;
            bool f = false;
            if (korisnici.Any())
            {
                foreach (Kupac kor in korisnici)
                {
                    if (txtUsername.Text == kor.Username && txtPassword.Text == kor.Password)
                    {
                        if (!kor.Admin)
                        {
                            formaKupac.Show();
                            Visible = false;
                            return;
                        }
                        else if (kor.Admin)
                        {
                            dialogIzbor res = new dialogIzbor();
                            if (res.ShowDialog() == DialogResult.OK)
                            {
                                MessageBox.Show("Prijavili ste se kao Administrator");
                                cp.trenutnoUlogovan(kor.Ime, kor.Prezime);
                                cp.Show(); Visible = false;
                                return;
                            }
                           else 
                            {
                                MessageBox.Show("Prijavili ste se kao Kupac");
                                formaKupac.Show();
                                formaKupac.trenutniKupac(kor.Uid, kor.Ime, kor.Prezime);
                                Visible = false;
                                return;
                            }
                        }

                    }
                    else f = true;

                }
            }
            if (txtUsername.Text == admin.Password && txtPassword.Text == admin.Password)
            {
                cp.Show(); Visible = false;
                cp.trenutnoUlogovan(admin.Ime, admin.Prezime);
                return;
            }
            else f = true;
            if (f)  { MessageBox.Show("fail"); }
            chkPassword.Checked = false;
        }

        public void ucitajKorisnike()
        {
            FileStream fsKor = new FileStream("korisnici.xml", FileMode.OpenOrCreate);
            SoapFormatter sfKor = new SoapFormatter();
            while (true)
            {
                try
                {
                    korisnici.Add(sfKor.Deserialize(fsKor) as Kupac);
                }
                catch
                {
                    break;
                }
            }
            fsKor.Close();
        }
        public void ocistiIsteklePonude()
        {
            
            FileStream fs = new FileStream("ponude.xml", FileMode.OpenOrCreate);
            SoapFormatter sf = new SoapFormatter();
            while (true)
            {
                try
                {
                    ponude.Add(sf.Deserialize(fs) as Ponuda);
                }
                catch
                {
                    break;
                }
            }
            fs.Close();
            for(int i= 0;i<ponude.Count;i++)
            {
                if (ponude[i].DatumDo < DateTime.Now.Date)
                {
                    ponude.Remove(ponude[i]);
                }
            }
            fs = new FileStream("ponude.xml", FileMode.Create);
            sf = new SoapFormatter();
            foreach(Ponuda p in ponude)
            {
                sf.Serialize(fs, p);
            }
            fs.Close();
        }
        public void podesiValidnePonude()
        {

            FileStream fs = new FileStream("ponude.xml", FileMode.Create);
            SoapFormatter sf = new SoapFormatter();
            while (true)
            {
                try
                {
                    ponude.Add(sf.Deserialize(fs) as Ponuda);
                }
                catch
                {
                    break;
                }
            }
            fs.Close();
            for (int i = 0; i < ponude.Count; i++)
            {
                if (ponude[i].DatumOd < DateTime.Now.Date)
                {
                    ponude[i].DatumOd = DateTime.Now.Date;
                }
            }
            fs = new FileStream("ponude.xml", FileMode.Create);
            sf = new SoapFormatter();
            foreach (Ponuda p in ponude)
            {
                sf.Serialize(fs, p);
            }
            fs.Close();
        }

        public void headAdmin()
        {
            if (File.Exists("head.bin"))
            {
                FileStream fs = new FileStream("head.bin", FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();
                admin = bf.Deserialize(fs) as Admin;
                fs.Close();
            }
            else
            {
                Visible = false;
                frmPostavljanjeHeada Head = new frmPostavljanjeHeada();
                Head.Show();
                
                Head.FormClosing += Head_FormClosing;
            }
        }

        private void Head_FormClosing(object sender, FormClosingEventArgs e)
        {
            Visible = true;
            headAdmin();
        }
    }
}
