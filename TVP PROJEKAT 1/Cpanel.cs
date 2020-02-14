using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TVP_PROJEKAT_1
{
    
    public partial class Cpanel : Form
    {
        BindingList<Automobil> vozila = new BindingList<Automobil>();
        BindingList<Kupac> korisnici = new BindingList<Kupac>();
        BindingList<Ponuda> ponude = new BindingList<Ponuda>();
        BindingList<Rezervacija> rezervacije = new BindingList<Rezervacija>();
        List<Stats> statistika = new List<Stats>();

        BindingSource bSourceAuto = new BindingSource();
        BindingSource bSourceKorisnik = new BindingSource();
        BindingSource bSourcePonuda = new BindingSource();
        BindingSource bSourceRezervacija = new BindingSource();
        Random rnd = new Random();
        static int id;
        static int uid;
        public Cpanel()
        {
            InitializeComponent();

            //podesavanje
            numGodisteDodavanje.Maximum = DateTime.Now.Year;
            numGodisteDodavanje.Value = DateTime.Now.Year;
            lblVremePristupa.Text = DateTime.Now.ToString();
            datKorRodj.MaxDate = DateTime.Now.AddYears(-21);
            datKorRodjIzmena.MaxDate = DateTime.Now.AddYears(-21);
            txtKorLozinkaIzmena.PasswordChar = '*';
            datPonudaDoDodavanje.MinDate = DateTime.Now.Date;
            datPonudaOdDodavanje.MinDate = DateTime.Now.Date;
            datPonudaDoIzmena.MinDate = DateTime.Now.Date;
            datPonudaOdIzmena.MinDate = DateTime.Now.Date;
            FormClosing += Cpanel_FormClosing;
            DoubleBuffered = true;
            cbRezervacijaKupacDodaj.SelectedIndex = -1;
            cbRezervacijaPonudaDodaj.SelectedIndex = -1;
            cbRezIzmenaKupac.SelectedIndexChanged += CbRezIzmenaKupac_SelectedIndexChanged;
            lsRezLista.SelectedIndexChanged += LsRezLista_SelectedIndexChanged;

            //lista automobili
            FileStream fs = new FileStream("automobili.xml", FileMode.OpenOrCreate);
            SoapFormatter sf = new SoapFormatter();
            while (true)
            {
                try
                {
                    vozila.Add(sf.Deserialize(fs) as Automobil);
                }
                catch
                {
                    break;
                }
            }
     

            //lista korisnika
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


            //lista ponuda
            FileStream fsPonuda = new FileStream("ponude.xml", FileMode.OpenOrCreate);
            SoapFormatter sfPonuda = new SoapFormatter();
            while (true)
            {
                try
                {
                    ponude.Add(sfPonuda.Deserialize(fsPonuda) as Ponuda);
                }
                catch
                {
                    break;
                }
            }


            //lista rezervacija
            FileStream fsRez = new FileStream("rezervacije.xml", FileMode.OpenOrCreate);
            SoapFormatter sfRez = new SoapFormatter();
            while (true)
            {
                try
                {
                    rezervacije.Add(sfRez.Deserialize(fsRez) as Rezervacija);
                }
                catch
                {
                    break;
                }
            }


            fsRez.Close();
            fsKor.Close();
            fsPonuda.Close();
            fs.Close();
            bSourceAuto.DataSource = vozila;
            cbIzbor.DataSource = bSourceAuto;
            cbIzmena.DataSource = bSourceAuto;
            cbPonudaDodavanje.DataSource = bSourceAuto;

            bSourceKorisnik.DataSource = korisnici;
            cbKorPregled.DataSource = bSourceKorisnik;
            cbKorIzmena.DataSource = bSourceKorisnik;
            cbRezervacijaKupacDodaj.DataSource = bSourceKorisnik;

            bSourcePonuda.DataSource = ponude;
            cbPonudaPregled.DataSource = bSourcePonuda;
            cbPonudaIzmena.DataSource = bSourcePonuda;
            cbRezervacijaPonudaDodaj.DataSource = bSourcePonuda;

            bSourceRezervacija.DataSource = rezervacije;
            cbRezervacijaPregled.DataSource = bSourceRezervacija;
            rezervacijeKorisnici();
        }



        private void Cpanel_FormClosing(object sender, FormClosingEventArgs e)
        {
            sacuvajLog();
        }

        //automobil
        private void btnDodajAuto_Click(object sender, EventArgs e)
        {
            if (vozila.Any())
            {
                id = vozila.Last().Id;
            }
            else id = 0;
            string provera = "";
            string marka = "", model = "", pogon = "", menjac = "", karoserija = "", gorivo = "", brojvrata = "";


            if (proveraUnosa(txtMarkaDodavanje))
            {
                marka = txtMarkaDodavanje.Text;
            }
            else { provera += "Niste uneli marku!" + Environment.NewLine; }

            if (proveraUnosa(txtModelDodavanje))
            {
                model = txtModelDodavanje.Text;
            }
            else { provera += "Niste uneli model!" + Environment.NewLine; }

            if (proveraUnosa(cbPogonDodavanje))
            {
                pogon = cbPogonDodavanje.Text;
            }
            else { provera += "Niste izabrali pogon!" + Environment.NewLine; }

            if (proveraUnosa(cbMenjacDodavanje))
            {
                menjac = cbMenjacDodavanje.Text;
            }
            else { provera += "Niste izabrali menjač!" + Environment.NewLine; }

            if (proveraUnosa(cbKaroserijaDodavanje))
            {
                karoserija = cbKaroserijaDodavanje.Text;
            }
            else { provera += "Niste izabrali karoseriju!" + Environment.NewLine; }

            if (proveraUnosa(cbGorivoDodavanje))
            {
                gorivo = cbGorivoDodavanje.Text;
            }
            else { provera += "Niste izabrali gorivo!" + Environment.NewLine; }

            if (proveraUnosa(cbBrVrataDodavanje))
            {
                brojvrata = cbBrVrataDodavanje.Text;
            }
            else { provera += "Niste izabrali broj vrata!" + Environment.NewLine; }




            if (provera == "")
            {
                Automobil auto = new Automobil(id + 1, marka, model, (int)numGodisteDodavanje.Value, (int)numKubikazaDodavanje.Value, pogon, menjac, karoserija, gorivo, brojvrata);
                vozila.Add(auto);
                vozila.ResetBindings();
                MessageBox.Show("Uspešno dodato vozilo!" + Environment.NewLine + auto);
                txtModelDodavanje.Clear();
                txtMarkaDodavanje.Clear();
                numGodisteDodavanje.Value = DateTime.Now.Year;
                numKubikazaDodavanje.Value = 1200;
                cbPogonDodavanje.SelectedIndex = -1;
                cbMenjacDodavanje.SelectedIndex = -1;
                cbKaroserijaDodavanje.SelectedIndex = -1;
                cbGorivoDodavanje.SelectedIndex = -1;
                cbBrVrataDodavanje.SelectedIndex = -1;
                FileStream fs = new FileStream("automobili.xml", FileMode.Create);
                SoapFormatter sf = new SoapFormatter();
                foreach(Automobil a in vozila)
                {
                    sf.Serialize(fs, a);
                }
                fs.Close();
            }
            else
            {
                MessageBox.Show(provera);
                provera = "";
            }



        }

        //za formu - pocetak
        private void btnLogout_Click(object sender, EventArgs e)
        {
            Close();
            
        }
        private bool proveraUnosa(TextBox tb)
        {
            if (tb.Text.Trim().Length != 0)
            {
                return true;
            }
            else return false;
        }
        private bool proveraUnosa(ComboBox cb)
        {
            if (cb.SelectedIndex != -1)
            {
                return true;
            }
            else return false;
        }
        public void trenutnoUlogovan(string ime, string prezime)
        {
            
            lblImeAdmina.Text = ime;
            lblPrezimeAdmina.Text = prezime;

        }
        private void sacuvajLog()
        {
            FileStream fs;
            if (File.Exists("AdminLog.txt"))
            {
                fs = new FileStream("AdminLog.txt", FileMode.Append, FileAccess.Write);
            }
            else
                fs = new FileStream("AdminLog.txt", FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.Write(lblImeAdmina.Text + " " + lblPrezimeAdmina.Text + "   " + lblVremePristupa.Text + " - " + DateTime.Now.ToString()+Environment.NewLine);
            sw.Flush();
            sw.Close();
            fs.Close();
        }
        //za formu - kraj

        private void cbIzbor_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (vozila.Any())
            {
                Automobil izabraniAuto = cbIzbor.SelectedItem as Automobil;
                txtIdPrikaz.Text = izabraniAuto.Id.ToString();
                txtMarkaPrikaz.Text = izabraniAuto.Marka;
                txtModelPrikaz.Text = izabraniAuto.Model;
                txtGodistePrikaz.Text = izabraniAuto.Godiste.ToString();
                txtKubikazaPrikaz.Text = izabraniAuto.Kubikaza.ToString();
                txtPogonPrikaz.Text = izabraniAuto.Pogon;
                txtMenjacPrikaz.Text = izabraniAuto.Menjac;
                txtKaroserijaPrikaz.Text = izabraniAuto.Karoserija;
                txtGorivoPrikaz.Text = izabraniAuto.Gorivo;
                txtBrVrataPrikaz.Text = izabraniAuto.Brojvrata;
            }
            else
            {
                txtIdPrikaz.Text = "";
                txtMarkaPrikaz.Text = "";
                txtModelPrikaz.Text = "";
                txtGodistePrikaz.Text = "";
                txtKubikazaPrikaz.Text = "";
                txtPogonPrikaz.Text = "";
                txtMenjacPrikaz.Text = "";
                txtKaroserijaPrikaz.Text = "";
                txtGorivoPrikaz.Text = "";
                txtBrVrataPrikaz.Text = "";

            }


        }

        private void btnSacuvajIzmene_Click(object sender, EventArgs e)
        {
            Automobil izabraniAuto = cbIzmena.SelectedItem as Automobil;
            string provera = "";
            string marka = "", model = "", pogon = "", menjac = "", karoserija = "", gorivo = "", brojvrata = "";
            if (!vozila.Any())
            {
                txtModelDodavanje.Clear();
                txtMarkaDodavanje.Clear();
                numGodisteDodavanje.Value = DateTime.Now.Year;
                numKubikazaDodavanje.Value = 1200;
                cbPogonDodavanje.SelectedIndex = -1;
                cbMenjacDodavanje.SelectedIndex = -1;
                cbKaroserijaDodavanje.SelectedIndex = -1;
                cbGorivoDodavanje.SelectedIndex = -1;
                cbBrVrataDodavanje.SelectedIndex = -1;
                MessageBox.Show("Nema vozila za izmenu");
                return;
            }
            if (proveraUnosa(txtMarkaIzmena))
            {
                marka = txtMarkaIzmena.Text;
            }
            else { provera += "Niste uneli marku!" + Environment.NewLine; }

            if (proveraUnosa(txtModelIzmena))
            {
                model = txtModelIzmena.Text;
            }
            else { provera += "Niste uneli model!" + Environment.NewLine; }
            pogon = cbPogonIzmena.Text;
            menjac = cbMenjacIzmena.Text;
            karoserija = cbKaroserijaIzmena.Text;
            gorivo = cbGorivoIzmena.Text;
            brojvrata = cbBrVrataIzmena.Text;
            if (provera == "" && vozila.Any())
            {
                izabraniAuto.Marka = marka;
                izabraniAuto.Model = model;
                izabraniAuto.Pogon = pogon;
                izabraniAuto.Menjac = menjac;
                izabraniAuto.Karoserija = karoserija;
                izabraniAuto.Gorivo = gorivo;
                izabraniAuto.Brojvrata = brojvrata;
                izabraniAuto.Godiste = (int)numGodisteIzmena.Value;
                izabraniAuto.Kubikaza = (int)numKubikazaIzmena.Value;
                vozila.ResetBindings();
                MessageBox.Show("Izmene uspešno sačuvane!");
                FileStream fs = new FileStream("automobili.xml", FileMode.Create);
                SoapFormatter sf = new SoapFormatter();
                foreach (Automobil a in vozila)
                {
                    sf.Serialize(fs, a);
                }
                fs.Close();
            }
            else
            {
                MessageBox.Show(provera);
                provera = "";
            }
        }

        private void cbIzmena_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (vozila.Any())
            {
                Automobil izabraniAuto = cbIzmena.SelectedItem as Automobil;
                txtMarkaIzmena.Text = izabraniAuto.Marka;
                txtModelIzmena.Text = izabraniAuto.Model;
                numGodisteIzmena.Value = izabraniAuto.Godiste;
                numKubikazaIzmena.Value = izabraniAuto.Kubikaza;
                cbPogonIzmena.Text = izabraniAuto.Pogon;
                cbMenjacIzmena.Text = izabraniAuto.Menjac;
                cbKaroserijaIzmena.Text = izabraniAuto.Karoserija;
                cbGorivoIzmena.Text = izabraniAuto.Gorivo;
                cbBrVrataIzmena.Text = izabraniAuto.Brojvrata;
                
            }
            else
            {
                txtModelDodavanje.Clear();
                txtMarkaDodavanje.Clear();
                numGodisteDodavanje.Value = DateTime.Now.Year;
                numKubikazaDodavanje.Value = 1200;
                cbPogonDodavanje.SelectedIndex = -1;
                cbMenjacDodavanje.SelectedIndex = -1;
                cbKaroserijaDodavanje.SelectedIndex = -1;
                cbGorivoDodavanje.SelectedIndex = -1;
                cbBrVrataDodavanje.SelectedIndex = -1;
            }
        }


        private void btnBrisanjeIzmena_Click(object sender, EventArgs e)
        {
            Automobil izabraniAuto = cbIzbor.SelectedItem as Automobil;
            vozila.Remove(izabraniAuto);
            if (vozila.Any())
            {
                FileStream fs = new FileStream("automobili.xml", FileMode.Create);
                SoapFormatter sf = new SoapFormatter();
                foreach (Automobil a in vozila)
                {
                    sf.Serialize(fs, a);
                }
                fs.Close();
            }
            else
            {
                MessageBox.Show("Nema vozila za brisanje");
                FileStream fs = new FileStream("automobili.xml", FileMode.Create);
                fs.Close();
            }
        }

        //korisnik
        private void btnDodajKor_Click(object sender, EventArgs e)
        {
            if (korisnici.Any())
            {
                uid = korisnici.Last().Uid;
            }
            else uid = 0;
            string provera = "";
            string ime = "", prezime = "", jmbg = "", telefon = "", username = "", lozinka = "";
            DateTime datumRodjenja;
            bool pravaPristupa;

            if (proveraUnosa(txtKorUser))
            {
                if (korisnici.Any())
                {
                    foreach (Kupac k in korisnici)
                    {
                        if (k.Username == txtKorUser.Text)
                        {
                            MessageBox.Show("Već postoji korisnik sa tim korisničkim imenom!");
                            return;
                        }
                    }
                }
                username = txtKorUser.Text;
            }
            else { provera += "Niste izabrali korisničko ime!" + Environment.NewLine; }
            if (proveraUnosa(txtKorLozinka))
            {
                lozinka = txtKorLozinka.Text;
            }
            else { provera += "Niste izabrali lozinku!" + Environment.NewLine; }

            if (proveraUnosa(txtKorIme))
            {
                ime = txtKorIme.Text;
            }
            else { provera += "Niste uneli ime!" + Environment.NewLine; }

            if (proveraUnosa(txtKorPrezime))
            {
                prezime = txtKorPrezime.Text;
            }
            else { provera += "Niste uneli prezime!" + Environment.NewLine; }

            if (proveraUnosa(txtKorJMBG))
            {
                jmbg = txtKorJMBG.Text;
            }
            else { provera += "Niste uneli JMBG!" + Environment.NewLine; }

            if (proveraUnosa(txtKorTel))
            {
                telefon = txtKorTel.Text;
            }
            else { provera += "Niste uneli broj telefona!" + Environment.NewLine; }

            if (rbAdminDodaj.Checked)
            {
                pravaPristupa = true;

            }
            else pravaPristupa = false;

            datumRodjenja = datKorRodj.Value;

            if (provera == "")
            {
                Kupac noviKorisnik = new Kupac(username, lozinka, uid + 1, ime, prezime, jmbg, datumRodjenja, telefon, pravaPristupa);
                korisnici.Add(noviKorisnik);
                MessageBox.Show("Uspešno dodat korisnik!" + Environment.NewLine + noviKorisnik);
                txtKorIme.Clear();
                txtKorJMBG.Clear();
                txtKorLozinka.Clear();
                txtKorUser.Clear();
                txtKorTel.Clear();
                txtKorPrezime.Clear();
                datKorRodj.Value = datKorRodj.MaxDate;
                rbKupacDodaj.Checked = true;
                FileStream fs = new FileStream("korisnici.xml", FileMode.Append);
                SoapFormatter sf = new SoapFormatter();
                sf.Serialize(fs, noviKorisnik);
                fs.Close();
                korisnici.ResetBindings();
            }
            else
            {
                MessageBox.Show(provera);
                provera = "";
            }

        }

        private void cbKorPregled_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbKorPregled.SelectedIndex!=-1)
            {
                Kupac izabraniKupac = cbKorPregled.SelectedItem as Kupac;
                txtKorUidPregled.Text = izabraniKupac.Uid.ToString();
                txtKorImePregled.Text = izabraniKupac.Ime;
                txtKorPrezimePregled.Text = izabraniKupac.Prezime;
                txtKorJmbgPregled.Text = izabraniKupac.Jmbg;
                txtKorUserPregled.Text = izabraniKupac.Username;
                txtKorDatRodjPregled.Text = izabraniKupac.DatumRodjenja.ToShortDateString();
                txtKorTelefonPregled.Text = izabraniKupac.Telefon;
                if (izabraniKupac.Admin) txtKorAdminPregled.Text = "Administrator";
                else txtKorAdminPregled.Text = "Kupac";
            }
            else
            {
                txtKorUidPregled.Text = "";
                txtKorImePregled.Text = "";
                txtKorPrezimePregled.Text = "";
                txtKorUserPregled.Text = "";
                txtKorDatRodjPregled.Text = "";
                txtKorTelefonPregled.Text = "";
                txtKorAdminPregled.Text = "";
                txtKorJmbgPregled.Text = "";
            }
        }


        private void btnSacuvajKorisnika_Click(object sender, EventArgs e)
        {
            Kupac izabraniKupac = cbKorIzmena.SelectedItem as Kupac;
            string provera = "";
            string ime = "", prezime = "", jmbg = "", telefon = "", username = "", lozinka = "";
            bool pravaPristupa;
            DateTime datumRodjenja;
            if (!korisnici.Any())
            {
                txtKorImeIzmena.Clear();
                txtKorPrezimeIzmena.Clear();
                txtKorJmbgIzmena.Clear();
                txtKorTelefonIzmena.Clear();
                txtKorUsernameIzmena.Clear();
                txtKorLozinkaIzmena.Clear();
                datKorRodjIzmena.Value = datKorRodjIzmena.MaxDate;
                chkPrikaziLozinku.Checked = false;
                MessageBox.Show("Nema korisnika za izmenu");
                return;
            }
            if (proveraUnosa(txtKorUsernameIzmena))
            {
                int i = 0;
                if (korisnici.Any())
                {
                    foreach (Kupac k in korisnici)
                    {
                        
                        if (k.Username == txtKorUsernameIzmena.Text)
                        {
                            i++;
                        }
                    }
                }
                if (i > 1)
                {
                    MessageBox.Show("Već postoji korisnik sa tim korisničkim imenom!");
                    return;
                }
                else { username = txtKorUsernameIzmena.Text; i = 0; }

            }
            else { provera += "Niste izabrali korisničko ime!" + Environment.NewLine; }
            if (proveraUnosa(txtKorLozinkaIzmena))
            {
                lozinka = txtKorLozinkaIzmena.Text;
            }
            else { provera += "Niste izabrali lozinku!" + Environment.NewLine; }

            if (proveraUnosa(txtKorImeIzmena))
            {
                ime = txtKorImeIzmena.Text;
            }
            else { provera += "Niste uneli ime!" + Environment.NewLine; }

            if (proveraUnosa(txtKorPrezimeIzmena))
            {
                prezime = txtKorPrezimeIzmena.Text;
            }
            else { provera += "Niste uneli prezime!" + Environment.NewLine; }

            if (proveraUnosa(txtKorJmbgIzmena))
            {
                jmbg = txtKorJmbgIzmena.Text;
            }
            else { provera += "Niste uneli JMBG!" + Environment.NewLine; }

            if (proveraUnosa(txtKorTelefonIzmena))
            {
                telefon = txtKorTelefonIzmena.Text;
            }
            else { provera += "Niste uneli broj telefona!" + Environment.NewLine; }
            if (rbAdministratorIzmena.Checked)
            {
                pravaPristupa = true;

            }
            else pravaPristupa = false;

            datumRodjenja = datKorRodjIzmena.Value;
            if (provera == "" && korisnici.Any())
            {
                izabraniKupac.Ime = ime;
                izabraniKupac.Prezime = prezime;
                izabraniKupac.Username = username;
                izabraniKupac.Password = lozinka;
                izabraniKupac.Jmbg = jmbg;
                izabraniKupac.Telefon = telefon;
                izabraniKupac.DatumRodjenja = datumRodjenja;
                izabraniKupac.Admin = pravaPristupa;
                vozila.ResetBindings();
                MessageBox.Show("Izmene uspešno sačuvane!");
                FileStream fs = new FileStream("korisnici.xml", FileMode.Create);
                SoapFormatter sf = new SoapFormatter();
                foreach (Kupac a in korisnici)
                {
                    sf.Serialize(fs, a);
                }
                korisnici.ResetBindings();
                fs.Close();
            }
            else
            {
                MessageBox.Show(provera);
                provera = "";
            }
        }

        private void cbKorIzmena_SelectedIndexChanged(object sender, EventArgs e)
        {
            {
                if (korisnici.Any())
                {
                    Kupac izabraniKupac = cbKorPregled.SelectedItem as Kupac;
                    txtKorImeIzmena.Text = izabraniKupac.Ime;
                    txtKorPrezimeIzmena.Text = izabraniKupac.Prezime;
                    txtKorJmbgIzmena.Text = izabraniKupac.Jmbg;
                    txtKorUsernameIzmena.Text = izabraniKupac.Username;
                    txtKorLozinkaIzmena.Text = izabraniKupac.Password;
                    datKorRodjIzmena.Value = izabraniKupac.DatumRodjenja;
                    txtKorTelefonIzmena.Text = izabraniKupac.Telefon;
                    if (izabraniKupac.Admin) rbAdministratorIzmena.Checked = true;
                    else rbKupacIzmena.Checked = true;
                }
                else
                {
                    txtKorImeIzmena.Clear();
                    txtKorPrezimeIzmena.Clear();
                    txtKorJmbgIzmena.Clear();
                    txtKorTelefonIzmena.Clear();
                    txtKorUsernameIzmena.Clear();
                    txtKorLozinkaIzmena.Clear();
                    datKorRodjIzmena.Value = datKorRodjIzmena.MaxDate;
                    chkPrikaziLozinku.Checked = false;
                }
            }
        }

        private void chkPrikaziLozinku_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPrikaziLozinku.Checked) txtKorLozinkaIzmena.PasswordChar = '\0';
            else txtKorLozinkaIzmena.PasswordChar = '*';
        }

        //ponude
        private void btnDodajPonud_Click(object sender, EventArgs e)
        {
            Automobil a = cbPonudaDodavanje.SelectedItem as Automobil;
            bool f = false ;
            if (numCenaPoDanu.Value == 0)
            {
                MessageBox.Show("Unesite cenu!");
                return;
            }

            if (proveraDatuma(datPonudaOdDodavanje.Value.Date, datPonudaDoDodavanje.Value.Date))
            {
                MessageBox.Show("Datumi nisu korektno popunjeni!");
                return;
            }
            if (ponude.Any())
            {
                foreach (Ponuda p in ponude)
                {

                    if (datPonudaOdDodavanje.Value.Date >= p.DatumOd && datPonudaOdDodavanje.Value.Date <= p.DatumDo && p.IdAuta == a.Id)
                    {
                        f = true;
                    }
                    if (datPonudaDoDodavanje.Value.Date >= p.DatumOd && datPonudaDoDodavanje.Value.Date <= p.DatumDo && p.IdAuta == a.Id)
                    {
                        f = true;
                    }
                    if (datPonudaOdDodavanje.Value.Date < p.DatumOd && datPonudaDoDodavanje.Value.Date > p.DatumDo && p.IdAuta == a.Id)
                    {
                        f = true;
                    }
                }
                foreach(Rezervacija r in rezervacije)
                {
                    if (datPonudaOdDodavanje.Value.Date >= r.DatumOd && datPonudaOdDodavanje.Value.Date <= r.DatumDo && r.IdAuta == a.Id)
                    {
                        f = true;
                    }
                    if (datPonudaDoDodavanje.Value.Date >= r.DatumOd && datPonudaDoDodavanje.Value.Date <= r.DatumDo && r.IdAuta == a.Id)
                    {
                        f = true;
                    }
                    if (datPonudaOdDodavanje.Value.Date < r.DatumOd && datPonudaDoDodavanje.Value.Date > r.DatumDo && r.IdAuta == a.Id)
                    {
                        f = true;
                    }
                }
                if (f)
                {
                    MessageBox.Show("Datumi su već zauzeti!");
                    return;
                }
            }
           
            

            ponude.Add(new Ponuda(a.Id, datPonudaOdDodavanje.Value.Date, datPonudaDoDodavanje.Value.Date,(int) numCenaPoDanu.Value));
            MessageBox.Show("Uspešno dodata ponuda!");
            FileStream fs = new FileStream("ponude.xml", FileMode.Append);
            SoapFormatter sf = new SoapFormatter();
            sf.Serialize(fs, ponude.Last());
            fs.Close();
            ponude.ResetBindings();
            datPonudaDoDodavanje.Value = datPonudaDoDodavanje.MinDate;
            datPonudaOdDodavanje.Value = datPonudaOdDodavanje.MinDate;
            numCenaPoDanu.Value = 0;
        }

        private void cbPonudaPregled_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            { 
                Ponuda trenutnaPonuda = cbPonudaPregled.SelectedItem as Ponuda;
                txtPonudaCenaPrikaz.Text = trenutnaPonuda.CenaDana.ToString()+" din.";
                txtPonudaDatOdPrikaz.Text = trenutnaPonuda.DatumOd.ToShortDateString();
                txtPonudaDatDoPrikaz.Text = trenutnaPonuda.DatumDo.ToShortDateString();
                foreach(Automobil a in vozila)
                {
                    if (trenutnaPonuda.IdAuta == a.Id) txtPonudaAutoPrikaz.Text = a.ToString();
                }
            }
            catch
            {
                txtPonudaAutoPrikaz.Text = "";
                txtPonudaCenaPrikaz.Text = "";
                txtPonudaDatOdPrikaz.Text = "";
                txtPonudaDatDoPrikaz.Text = "";
            }
        }
        public bool proveraDatuma(DateTime d1, DateTime d2)
        {
            //obrnuta logika
            if (d1.Date > d2.Date) return true;
            else return false;
        }

        private void cbPonudaIzmena_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Ponuda p = cbPonudaIzmena.SelectedItem as Ponuda;
                datPonudaOdIzmena.Value = p.DatumOd.Date;
                datPonudaDoIzmena.Value = p.DatumDo.Date;
                numCenaPoDanuIzmena.Value = p.CenaDana;
            }
            catch
            {
                datPonudaOdIzmena.Value = DateTime.Now.Date;
                datPonudaDoIzmena.Value = DateTime.Now.Date;
                numCenaPoDanuIzmena.Value = 0;
            }
        }

        private void btnPonudaIzbrisi_Click(object sender, EventArgs e)
        {
            Ponuda p = cbPonudaIzmena.SelectedItem as Ponuda;
            ponude.Remove(p);
            FileStream fs = new FileStream("ponude.xml", FileMode.Create);
            SoapFormatter sf = new SoapFormatter();
            foreach( Ponuda pon in ponude)
            {
                sf.Serialize(fs, pon);
            }
            fs.Close();
            MessageBox.Show("Uspešno izbrisana ponuda!");
        }

        private void btnPonudaIzmeni_Click(object sender, EventArgs e)
        {
            Ponuda pon = cbPonudaIzmena.SelectedItem as Ponuda;
            bool f = false;
            if (numCenaPoDanuIzmena.Value == 0)
            {
                MessageBox.Show("Unesite cenu!");
                return;
            }

            if (proveraDatuma(datPonudaOdIzmena.Value.Date, datPonudaDoIzmena.Value.Date))
            {
                MessageBox.Show("Datumi nisu korektno popunjeni!");
                return;
            }
            foreach (Ponuda p in ponude)
            {
                if (p == pon || p==null) continue;
                if (datPonudaOdIzmena.Value.Date >= p.DatumOd && datPonudaOdIzmena.Value.Date <= p.DatumDo && pon.IdAuta==p.IdAuta)
                {
                    f = true;
                }
                if (datPonudaDoIzmena.Value.Date >= p.DatumOd && datPonudaDoIzmena.Value.Date <= p.DatumDo && pon.IdAuta == p.IdAuta)
                {
                    f = true;
                }
                if (datPonudaOdIzmena.Value.Date < p.DatumOd && datPonudaDoIzmena.Value.Date > p.DatumDo && pon.IdAuta == p.IdAuta)
                {
                    f = true;
                }
            }
            foreach (Rezervacija r in rezervacije)
            {
                if (datPonudaOdIzmena.Value.Date >= r.DatumOd && datPonudaOdIzmena.Value.Date <= r.DatumDo && pon.IdAuta == r.IdAuta)
                {
                    f = true;
                }
                if (datPonudaDoIzmena.Value.Date >= r.DatumOd && datPonudaDoIzmena.Value.Date <= r.DatumDo && pon.IdAuta == r.IdAuta)
                {
                    f = true;
                }
                if (datPonudaOdIzmena.Value.Date < r.DatumOd && datPonudaDoIzmena.Value.Date > r.DatumDo && pon.IdAuta == r.IdAuta)
                {
                    f = true;
                }
            }
            if (f)
            {
                MessageBox.Show("Datumi su već zauzeti!");
                return;
            }
            pon.DatumOd = datPonudaOdIzmena.Value.Date;
            pon.DatumDo = datPonudaDoIzmena.Value.Date;
            pon.CenaDana = (int) numCenaPoDanuIzmena.Value;
            FileStream fs = new FileStream("ponude.xml", FileMode.Create);
            SoapFormatter sf = new SoapFormatter();
            foreach (Ponuda p in ponude)
            {
                if (p == null) continue;
                sf.Serialize(fs, p);
            }
            fs.Close();
            MessageBox.Show("Uspešno sačuvana izmena!");
        }

        //rezervacije
        private void cbRezervacijaPonudaDodaj_SelectedIndexChanged(object sender, EventArgs e)
        {
            Ponuda p = cbRezervacijaPonudaDodaj.SelectedItem as Ponuda;
            try
            {
                
                datRezervacijaOdDodaj.MinDate = new DateTime(1753, 1, 1);
                datRezervacijaOdDodaj.MaxDate = new DateTime(9888, 1, 1);
                datRezervacijaDoDodaj.MinDate = new DateTime(1753, 1, 1);
                datRezervacijaDoDodaj.MaxDate = new DateTime(9888, 1, 1);
                datRezervacijaOdDodaj.MinDate = p.DatumOd;
                datRezervacijaOdDodaj.MaxDate = p.DatumDo;
                datRezervacijaDoDodaj.MaxDate = p.DatumDo;
                datRezervacijaDoDodaj.MinDate = p.DatumOd;
                txtRezervacijaCenaInfoDodaj.Text = (p.CenaDana * brojDana(datRezervacijaOdDodaj.Value, datRezervacijaDoDodaj.Value)).ToString();
            }
            catch
            {
                datRezervacijaOdDodaj.Value = DateTime.Now.Date;
                datRezervacijaDoDodaj.Value = DateTime.Now.Date;
            }
            try
            {
                foreach (Automobil a in vozila)
                {
                    if (p.IdAuta == a.Id) txtRezervacijaAutoInfoDodaj.Text = a.ToString();
                }
            }
            catch
            {
                txtRezervacijaAutoInfoDodaj.Text = "";
            }

        }
        public int brojDana(DateTime d1, DateTime d2)
        {
            return (int)(d2.Date - d1.Date).TotalDays+1;
        }

        private void cenaRefresh(object sender, EventArgs e)
        {
            try
            {
                Ponuda p = cbRezervacijaPonudaDodaj.SelectedItem as Ponuda;
                if (proveraDatuma(datRezervacijaOdDodaj.Value, datRezervacijaDoDodaj.Value))
                {
                    txtRezervacijaCenaInfoDodaj.Text = "Greška!";
                    return;
                }
                txtRezervacijaCenaInfoDodaj.Text = (p.CenaDana * brojDana(datRezervacijaOdDodaj.Value, datRezervacijaDoDodaj.Value)).ToString();
            }
            catch
            {
                return;
            }

        }


        
        private void btnRezervacijaDodaj_Click(object sender, EventArgs e)
        {

            Kupac k = cbRezervacijaKupacDodaj.SelectedItem as Kupac;
            Ponuda p = cbRezervacijaPonudaDodaj.SelectedItem as Ponuda;
            int cena;
            try
            {
                cena = p.CenaDana * brojDana(datRezervacijaOdDodaj.Value, datRezervacijaDoDodaj.Value);
            }
            catch { return; }
            if (proveraDatuma(datRezervacijaOdDodaj.Value, datRezervacijaDoDodaj.Value))
            {
                MessageBox.Show("Datumi nisu korektno popunjeni!");
                txtRezervacijaCenaInfoDodaj.Text = "Greška!";
                return;
            }
            Ponuda p1 = new Ponuda(p.IdAuta,p.DatumOd,datRezervacijaOdDodaj.Value.Date.AddDays(-1),p.CenaDana);
            Ponuda p2 = new Ponuda(p.IdAuta,datRezervacijaDoDodaj.Value.Date.AddDays(1), p.DatumDo, p.CenaDana);
            
            if ((datRezervacijaOdDodaj.Value.Date - p.DatumOd).TotalDays > 0)
                ponude.Add(p1);
            if ((p.DatumDo - datRezervacijaDoDodaj.Value.Date).TotalDays > 0)
                ponude.Add(p2);
            ponude.Remove(p);
            FileStream fsp = new FileStream("ponude.xml", FileMode.Create);
            SoapFormatter sfp = new SoapFormatter();
            foreach (Ponuda ponuda in ponude)
            {
                sfp.Serialize(fsp, ponuda);
            }
            fsp.Close();
            Rezervacija r = new Rezervacija(p.IdAuta,k.Uid ,datRezervacijaOdDodaj.Value, datRezervacijaDoDodaj.Value, cena);
            rezervacije.Add(r);
            MessageBox.Show("Uspešno dodata rezervacija!");
            FileStream fs = new FileStream("rezervacije.xml", FileMode.Append);
            SoapFormatter sf = new SoapFormatter();
            sf.Serialize(fs, rezervacije.Last());
            fs.Close();
            rezervacije.ResetBindings();
            cbRezervacijaKupacDodaj.SelectedIndex = -1;
            cbRezervacijaPonudaDodaj.SelectedIndex = -1;
            rezervacijeKorisnici();
        }

        private void cbRezervacijaPregled_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Rezervacija r = cbRezervacijaPregled.SelectedItem as Rezervacija;
                foreach(Automobil a in vozila)
                {
                    if (a.Id == r.IdAuta && a != null) txtRezAutoPregled.Text = a.ToString();
                }
                foreach (Kupac k in korisnici)
                {
                    if (k.Uid == r.IdKorisnika && k!=null) txtRezKupacPregled.Text = k.ToString();
                }
                
                txtRezDatOdPregled.Text = r.DatumOd.ToShortDateString();
                txtRezDatDoPregled.Text = r.DatumDo.ToShortDateString();
                txtRezCenaPregled.Text = r.Cena.ToString();
            }
            catch
            {
                txtRezAutoPregled.Text = "";
                txtRezKupacPregled.Text = "";
                txtRezDatDoPregled.Text = "";
                txtRezDatOdPregled.Text = "";
                txtRezCenaPregled.Text = "";
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            statistika.Clear();
            if (proveraDatuma(datStatistikaOd.Value.Date, datStatistikaDo.Value.Date))
            {
                MessageBox.Show("Datumi nisu korektno popunjeni!");
                pictureBox1.Invalidate();
                return;
            }
            foreach (Automobil a in vozila)
            {
                Stats s = new Stats();
                int brojdanapoautu = 0;
                foreach (Rezervacija r in rezervacije)
                {
                    
                    if (r.IdAuta == a.Id) 
                    {
                        s.Auto = a.ToString();
                        if (datStatistikaOd.Value.Date <= r.DatumOd &&
                         r.DatumOd <= datStatistikaDo.Value.Date &&
                         datStatistikaDo.Value.Date >= r.DatumOd &&
                         r.DatumDo <= datStatistikaDo.Value.Date)
                        {
                            s.DatumOd = r.DatumOd;
                            s.DatumDo = r.DatumDo;
                        }
                        else if (datStatistikaOd.Value.Date <= r.DatumOd &&
                                r.DatumOd <= datStatistikaDo.Value.Date &&
                                r.DatumDo > datStatistikaDo.Value.Date)
                        {
                            s.DatumOd = r.DatumOd;
                            s.DatumDo = datStatistikaDo.Value.Date;
                        }
                        else if (datStatistikaOd.Value.Date <= r.DatumDo &&
                                r.DatumDo <= datStatistikaDo.Value.Date &&
                                r.DatumOd < datStatistikaOd.Value.Date)
                        {
                            s.DatumOd = datStatistikaOd.Value.Date;
                            s.DatumDo = r.DatumDo;
                        }

                        else continue;
                        brojdanapoautu += brojDana(s.DatumOd, s.DatumDo);
                    }
                 
                }
                s.BrDana = brojdanapoautu;
                if(brojdanapoautu>0) statistika.Add(s);
                brojdanapoautu = 0;
                
                
            }
            pictureBox1.Paint += crtajPitu;
            if (statistika.Count == 0)
            {
                pictureBox1.Invalidate();
                MessageBox.Show("Nema iznajmljenih vozila u zadatom intervalu!");
                return;
            }
            pictureBox1.Invalidate();

        }
        public void crtajPitu(object sender,PaintEventArgs e)
        {
            lwStatistika.Items.Clear();
            float ukupno = 0;
            foreach (Stats s in statistika)
            {
                ukupno += s.BrDana;
            }
            float pocetniUgao = -90;
            foreach (Stats s in statistika)
            {
                Color boja = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
                Brush cetka = new SolidBrush(boja);
                float ugao = (s.BrDana / ukupno) * 360;
                e.Graphics.FillPie(cetka, 0, 0, pictureBox1.Width, pictureBox1.Height, pocetniUgao, ugao);
                pocetniUgao += ugao;
                lwStatistika.Items.Add(s+ ": "+ s.BrDana.ToString()+" dan(a), "+ ((s.BrDana / ukupno)*100).ToString("F")+"%");
                lwStatistika.Items[lwStatistika.Items.Count - 1].BackColor = boja;
            }
        }


        private void rezervacijeKorisnici()
        {

            cbRezIzmenaKupac.Items.Clear();
            foreach(Kupac k in korisnici)
            {

                foreach(Rezervacija r in rezervacije)
                {

                    if (k.Uid == r.IdKorisnika)
                    {
                        if (r.DatumDo >= DateTime.Now.Date)
                        {
                            cbRezIzmenaKupac.Items.Add(k);
                            break;
                        }
                    }

                }


            }
        }


        private void CbRezIzmenaKupac_SelectedIndexChanged(object sender, EventArgs e)
        {
            refreshListe();
        }

        private void LsRezLista_SelectedIndexChanged(object sender, EventArgs e)
        {
            Rezervacija r = lsRezLista.SelectedItem as Rezervacija;
            datRezOdIzmena.Value = r.DatumOd;
            datRezDoIzmena.Value = r.DatumDo;
            txtCenaRezIzmena.Text = r.Cena.ToString();
            foreach(Automobil a in vozila)
            {
                if(a.Id == r.IdAuta)
                {
                    txtAutoOtkaz.Text = a.ToString();
                }
            }
        }

        private void btnOtkaziRezervaciju_Click(object sender, EventArgs e)
        {
            if (lsRezLista.SelectedIndex == -1) { MessageBox.Show("Nista izabrali rezervaciju!"); return; }
            otkazivanjeRezervacije();
            rezervacijeKorisnici();
            MessageBox.Show("Rezervacija uspešno otkazana!");
        }

        private void refreshListe()
        {
            if (cbRezIzmenaKupac.Items.Count == 0)
            {
                MessageBox.Show("Nema kupaca sa rezervacijama koje mogu da se menjaju!");
                return;
            }
            lsRezLista.Items.Clear();
            Kupac k = cbRezIzmenaKupac.SelectedItem as Kupac;
            foreach (Rezervacija r in rezervacije)
            {

                if (k.Uid == r.IdKorisnika)
                {
                    if (r.DatumDo >= DateTime.Now.Date)
                    {
                        lsRezLista.Items.Add(r);
                    }
                }

            }
        }
        private void otkazivanjeRezervacije()
        {
            Rezervacija r = lsRezLista.SelectedItem as Rezervacija;
            int rCenaDana = (int)(r.Cena / ((r.DatumDo.Date - r.DatumOd.Date).TotalDays + 1));
            Ponuda pp = new Ponuda(r.IdAuta, r.DatumOd, r.DatumDo, rCenaDana);
            for (int i = 0; i < ponude.Count; i++)
            {
                if (ponude[i].IdAuta == pp.IdAuta && ponude[i].CenaDana == pp.CenaDana)
                {
                    if (pp.DatumOd.Date.AddDays(-1) == ponude[i].DatumDo.Date)
                    {
                        pp.DatumOd = ponude[i].DatumOd;
                        ponude.RemoveAt(i);
                        i = -1;
                        continue;
                    }
                    if (pp.DatumDo.Date.AddDays(1) == ponude[i].DatumOd.Date)
                    {
                        pp.DatumDo = ponude[i].DatumDo;
                        ponude.RemoveAt(i);
                        i = -1;
                        continue;
                    }
                    
                }
                
            }
            ponude.Add(pp);
            FileStream fsp = new FileStream("ponude.xml", FileMode.Create);
            SoapFormatter sfp = new SoapFormatter();
            foreach (Ponuda ponuda in ponude)
            {
                sfp.Serialize(fsp, ponuda);
            }
            fsp.Close();
            rezervacije.Remove(r);
            FileStream fs = new FileStream("rezervacije.xml", FileMode.Create);
            SoapFormatter sf = new SoapFormatter();
            foreach (Rezervacija rez in rezervacije)
            {
                sf.Serialize(fs, rez);
            }
            fs.Close();
            refreshListe();
        }
    }
}
