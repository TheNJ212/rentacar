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
    public partial class frmKupac : Form
    {
        List<Ponuda> ponude = new List<Ponuda>();
        List<Rezervacija> rezervacije = new List<Rezervacija>();
        int uidKupca;
        public frmKupac()
        {
            InitializeComponent();
            ucitajRezervacije();
            ucitajPonude();
            lsTrenutneRezervacije.SelectedIndexChanged += LsTrenutneRezervacije_SelectedIndexChanged;
            
        }

        private void LsTrenutneRezervacije_SelectedIndexChanged(object sender, EventArgs e)
        {
            ponude.Clear();
            ucitajPonude();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmRezervacija novaRez = new frmRezervacija();
            novaRez.Show();
            novaRez.dohvatiId(uidKupca);
            novaRez.FormClosing += vratiFormuKupca;
            Visible = false;
        }



        private void vratiFormuKupca(object sender, FormClosingEventArgs e)
        {
            lsTrenutneRezervacije.Items.Clear();
            lsTekuceRezervacije.Items.Clear();
            Visible = true;
            rezervacije.Clear();
            ucitajRezervacije();
            refreshListe();
        }

        private void ucitajPonude()
        {
            ponude.Clear();
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
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Close();
        }
        public void trenutniKupac(int Uid, string ime, string prezime)
        {
            uidKupca = Uid;
            lblIme.Text = ime;
            lblPrezime.Text = prezime;
            lblVreme.Text = DateTime.Now.ToString();
            refreshListe();
        }
        private void refreshListe()
        {

            foreach (Rezervacija r in rezervacije)
            {
                if (uidKupca== r.IdKorisnika)
                {
                    if (r.DatumOd >= DateTime.Now.Date)
                    {
                        lsTrenutneRezervacije.Items.Add(r);
                    }
                    else if(r.DatumDo >= DateTime.Now.Date && r.DatumOd< DateTime.Now.Date)
                    {
                        lsTekuceRezervacije.Items.Add(r);
                    }
                }

            }
        }
        private void otkazivanjeRezervacije()
        {
            Rezervacija r = lsTrenutneRezervacije.SelectedItem as Rezervacija;
            int rCenaDana = (int)(r.Cena / ((r.DatumDo.Date - r.DatumOd.Date).TotalDays + 1));
            Ponuda spojena = new Ponuda(r.IdAuta, r.DatumOd, r.DatumDo, rCenaDana);
            for (int i = 0; i < ponude.Count; i++)
            {
                if (ponude[i].IdAuta == spojena.IdAuta && ponude[i].CenaDana == spojena.CenaDana)
                {
                    if (spojena.DatumOd.Date.AddDays(-1) == ponude[i].DatumDo.Date)
                    {
                        spojena.DatumOd = ponude[i].DatumOd;
                        ponude.RemoveAt(i);
                        i = -1;
                        continue;
                    }
                    if (spojena.DatumDo.Date.AddDays(1) == ponude[i].DatumOd.Date)
                    {
                        spojena.DatumDo = ponude[i].DatumDo;
                        ponude.RemoveAt(i);
                        i = -1;
                        continue;
                    }

                }

            }
            ponude.Add(spojena);
            FileStream fsp = new FileStream("ponude.xml", FileMode.Create);
            SoapFormatter sfp = new SoapFormatter();
            foreach (Ponuda ponuda in ponude)
            {
                sfp.Serialize(fsp, ponuda);
            }
            fsp.Close();
            rezervacije.Remove(r);
            FileStream fsr = new FileStream("rezervacije.xml", FileMode.Create);
            SoapFormatter sfr = new SoapFormatter();
            foreach (Rezervacija rez in rezervacije)
            {
                sfr.Serialize(fsr, rez);
            }
            fsr.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (lsTrenutneRezervacije.SelectedIndex == -1)
            {
                MessageBox.Show("Niste izabrali rezervaciju!");
                return;
            }
            otkazivanjeRezervacije();
            lsTrenutneRezervacije.Items.Clear();
            refreshListe();
            MessageBox.Show("Uspešno otkazana rezervacija!");
        }

        private void ucitajRezervacije()
        {
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
        }
    }
}
   
