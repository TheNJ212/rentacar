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
    public partial class frmRezervacija : Form
    {
        public delegate void provera(bool f);
        provera zaPonude;
        List<Automobil> automobili = new List<Automobil>();
        List<Automobil> radna = new List<Automobil>();
        List<Ponuda> ponude = new List<Ponuda>();
        List<Ponuda> ponudeRadna = new List<Ponuda>();
        List<Rezervacija> rezervacije = new List<Rezervacija>();
        int idKupca = 0;
        public frmRezervacija()
        {
            InitializeComponent();
            ucitajPonude();
            ucitajVozila();
            zaPonude+=ispisPonuda;
            datOd.Enabled = false;
            datDo.Enabled = false;

            foreach (Automobil a in automobili)
            {
                if (!cbMarka.Items.Contains(a.Marka))
                {
                    cbMarka.Items.Add(a.Marka);
                }
            }

            cbMarka.SelectedIndexChanged += CbMarka_SelectedIndexChanged;
            cbModeli.SelectedIndexChanged += CbModeli_SelectedIndexChanged;
            cbGodiste.SelectedIndexChanged += CbGodiste_SelectedIndexChanged;
            cbKubikaza.SelectedIndexChanged += CbKubikaza_SelectedIndexChanged;
            cbBrVrata.SelectedIndexChanged += CbBrVrata_SelectedIndexChanged;
            cbGorivo.SelectedIndexChanged += CbGorivo_SelectedIndexChanged;
            cbKaroserija.SelectedIndexChanged += CbKaroserija_SelectedIndexChanged;
            cbMenjac.SelectedIndexChanged += CbMenjac_SelectedIndexChanged;
            cbPogon.SelectedIndexChanged += CbPogon_SelectedIndexChanged;
            
        }

        private void CbPogon_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            cb.Enabled = false;
            ukloniSveEnabled();
            for (int i = 0; i < radna.Count; i++)
            {
                if (!cb.SelectedItem.Equals(radna[i].Pogon))
                {
                    radna.RemoveAt(i);
                    i = -1;
                }
            }
            dodajSveEnabled();
            ukloniIsteSve();
            popuni();
        }

        private void CbMenjac_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            cb.Enabled = false;
            ukloniSveEnabled();
            for (int i = 0; i < radna.Count; i++)
            {
                if (!cb.SelectedItem.Equals(radna[i].Menjac))
                {
                    radna.RemoveAt(i);
                    i = -1;
                }
            }
            dodajSveEnabled();
            ukloniIsteSve();
            popuni();
        }

        private void CbKaroserija_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            cb.Enabled = false;
            ukloniSveEnabled();
            for (int i = 0; i < radna.Count; i++)
            {
                if (!cb.SelectedItem.Equals(radna[i].Karoserija))
                {
                    radna.RemoveAt(i);
                    i = -1;
                }
            }
            dodajSveEnabled();
            ukloniIsteSve();
            popuni();
        }

        private void CbGorivo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            cb.Enabled = false;
            ukloniSveEnabled();
            for (int i = 0; i < radna.Count; i++)
            {
                if (!cb.SelectedItem.Equals(radna[i].Gorivo))
                {
                    radna.RemoveAt(i);
                    i = -1;
                }
            }
            dodajSveEnabled();
            ukloniIsteSve();
            popuni();
        }

        private void CbBrVrata_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            cb.Enabled = false;
            ukloniSveEnabled();
            for (int i = 0; i < radna.Count; i++)
            {
                if (!cb.SelectedItem.Equals(radna[i].Brojvrata))
                {
                    radna.RemoveAt(i);
                    i = -1;
                }
            }
            dodajSveEnabled();
            ukloniIsteSve();
            popuni();
        }

        private void CbKubikaza_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbKubikaza.Enabled = false;
            ukloniSveEnabled();
            for (int i = 0; i < radna.Count; i++)
            {
                if (!cbKubikaza.SelectedItem.Equals(radna[i].Kubikaza))
                {
                    radna.RemoveAt(i);
                    i = -1;
                }
            }
            dodajSveEnabled();
            ukloniIsteSve();
            popuni();
        }

        private void CbGodiste_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbGodiste.Enabled = false;
            ukloniSveEnabled();
            for (int i = 0; i < radna.Count; i++)
            {
                if (!cbGodiste.SelectedItem.Equals(radna[i].Godiste))
                {
                    radna.RemoveAt(i);
                    i = -1;
                }
            }
            dodajSveEnabled();
            ukloniIsteSve();
            popuni();
        }

        private void CbModeli_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbModeli.Enabled = false;
            ukloniSveEnabled();
            for (int i = 0; i < radna.Count; i++)
            {
                if (!cbModeli.SelectedItem.Equals(radna[i].Model))
                {
                    radna.RemoveAt(i);
                    i = -1;
                }
            }
            dodajSveEnabled();
            ukloniIsteSve();
            popuni();
        }

        private void CbMarka_SelectedIndexChanged(object sender, EventArgs e)
        {
            datOd.Enabled = false;
            datDo.Enabled = false;
            ocistiPolja();
            radna.Clear();
            cbModeli.Enabled = true;
            cbGodiste.Enabled = true;
            cbKubikaza.Enabled = true;
            cbKaroserija.Enabled = true;
            cbGorivo.Enabled = true;
            cbPogon.Enabled = true;
            cbMenjac.Enabled = true;
            cbBrVrata.Enabled = true;
            foreach (Automobil a in automobili)
            {
                if (a.Marka.Equals(cbMarka.SelectedItem))
                {
                    radna.Add(a);
                }
            }
            
            dodajSveEnabled();
            ukloniIsteSve();
            popuni();
        }


        private void btnOdustani_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void ucitajVozila()
        {
            FileStream fs = new FileStream("automobili.xml", FileMode.OpenOrCreate);
            SoapFormatter sf = new SoapFormatter();
            while (true)
            {
                try
                {
                    Automobil a = sf.Deserialize(fs) as Automobil;
                    foreach(Ponuda p in ponude)
                    {
                        if(a.Id==p.IdAuta) automobili.Add(a);
                    }
                    
                }
                catch
                {
                    break;
                }
            }
            fs.Close();
            if (automobili.Count == 0)
            {
                MessageBox.Show("Trenutno nema automobila u ponudi!");
            }
        }
        private void ucitajPonude()
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
        }

        private void ucitajRezervacije()
        {
            FileStream fs = new FileStream("rezervacije.xml", FileMode.OpenOrCreate);
            SoapFormatter sf = new SoapFormatter();
            while (true)
            {
                try
                {
                    rezervacije.Add(sf.Deserialize(fs) as Rezervacija);
                }
                catch
                {
                    break;
                }
            }
            fs.Close();
        }

        private void ocistiPolja()
        {
            cbModeli.Items.Clear();
            cbGodiste.Items.Clear();
            cbKubikaza.Items.Clear();
            cbKaroserija.Items.Clear();
            cbGorivo.Items.Clear();
            cbPogon.Items.Clear();
            cbMenjac.Items.Clear();
            cbBrVrata.Items.Clear();
        }
        private void ukloniIste(ComboBox cb)
        {
            if (cb.Enabled)
            {
                for (int i = 0; i < cb.Items.Count; i++)
                {

                    for (int j = 0; j < cb.Items.Count; j++)
                    {
                        if (j != i && cb.Items[i].ToString() == cb.Items[j].ToString())
                        {
                            cb.Items.RemoveAt(i);
                            i = -1;
                            break;

                        }
                    }
                }

            }
        }

        private void ukloniIsteSve()
        {
            ukloniIste(cbModeli);
            ukloniIste(cbGodiste);
            ukloniIste(cbKubikaza);
            ukloniIste(cbKaroserija);
            ukloniIste(cbGorivo);
            ukloniIste(cbPogon);
            ukloniIste(cbMenjac);
            ukloniIste(cbBrVrata);
        }

        private void dodajEnabled(ComboBox cb,string add)
        {
            if (cb.Enabled)
            {

                cb.Items.Add(add);

            }

        }
        private void dodajEnabled(ComboBox cb, int add)
        {
            if (cb.Enabled)
            {

                cb.Items.Add(add);

            }

        }
        private void dodajSveEnabled()
        {
            for (int i = 0; i < radna.Count; i++)
            {
                dodajEnabled(cbModeli, radna[i].Model);
                dodajEnabled(cbGodiste, radna[i].Godiste);
                dodajEnabled(cbKubikaza, radna[i].Kubikaza);
                dodajEnabled(cbGorivo, radna[i].Gorivo);
                dodajEnabled(cbPogon, radna[i].Pogon);
                dodajEnabled(cbKaroserija, radna[i].Karoserija);
                dodajEnabled(cbMenjac, radna[i].Menjac);
                dodajEnabled(cbBrVrata, radna[i].Brojvrata);
            }
        }
        private void ukloniEnabled(ComboBox cb)
        {
            if (cb.Enabled)
            {
                cb.Items.Clear();
            }

        }

        private void ukloniSveEnabled()
        {
            ukloniEnabled(cbModeli);
            ukloniEnabled(cbGodiste);
            ukloniEnabled(cbKubikaza);
            ukloniEnabled(cbGorivo);
            ukloniEnabled(cbPogon);
            ukloniEnabled(cbKaroserija);
            ukloniEnabled(cbGodiste);
            ukloniEnabled(cbMenjac);
            ukloniEnabled(cbBrVrata);
        }

        private void popuni()
        {
            bool flag = false;
            for (int i = 0; i < Controls.Count; i++)
            {
                if(Controls[i] is ComboBox && Controls[i]!=cbMarka)
                {
                    if (((ComboBox)Controls[i]).Enabled && ((ComboBox)Controls[i]).Items.Count == 1)
                    {
                        ((ComboBox)Controls[i]).SelectedIndex = 0;
                    }
                }

            }
            int popunjeno = 0;
            lsPonude.Items.Clear();
            for (int i = 0; i < Controls.Count; i++)
            {
                if (Controls[i] is ComboBox)
                {
                    if (((ComboBox)Controls[i]).SelectedIndex > -1)
                    {
                        popunjeno++;
                    }
                }
            }
            if (popunjeno == 9)
            {
                flag = true;
                zaPonude(flag);
                flag = false;
            }

        }

        private void ispisPonuda(bool f)
        {
            ponudeRadna.Clear();
            foreach (Ponuda p in ponude)
            {
                if (radna[0].Id == p.IdAuta && f)
                {
                    ponudeRadna.Add(p);
                    lsPonude.Items.Add(p.IspisPonude());
                }
            }
        }
        private void cenaRefresh(object sender, EventArgs e)
        {
            if (datOd.Value.Date > datDo.Value.Date)
            {
                txtCena.Text = "Greška!";
                return;
            }
            txtCena.Text =  (ponudeRadna[lsPonude.SelectedIndex].CenaDana*((datDo.Value.Date - datOd.Value.Date).TotalDays + 1)).ToString();
        }

        private void lsPonude_SelectedIndexChanged(object sender, EventArgs e)
        {

            datOd.MinDate = new DateTime(1753, 1, 1);
            datOd.MaxDate = new DateTime(9888, 1, 1);
            datDo.MinDate = new DateTime(1753, 1, 1);
            datDo.MaxDate = new DateTime(9888, 1, 1);
            datOd.MinDate = ponudeRadna[lsPonude.SelectedIndex].DatumOd;
            datDo.MaxDate = ponudeRadna[lsPonude.SelectedIndex].DatumDo;
            datDo.MinDate = ponudeRadna[lsPonude.SelectedIndex].DatumOd;
            datOd.MaxDate = ponudeRadna[lsPonude.SelectedIndex].DatumDo;
            datDo.Value = datDo.MaxDate;
            datOd.Value = datOd.MinDate;
            datOd.Enabled = true;
            datDo.Enabled = true;
        }

        private void btnRezervisi_Click(object sender, EventArgs e)
        {
            if (cbMarka.SelectedIndex == -1)
            {
                MessageBox.Show("Izaberite automobil!");
                return;
            }
            if (!datDo.Enabled && cbMarka.SelectedIndex != -1)
            {
                MessageBox.Show("Izaberite ponudu iz liste!");
                return;
            } 
            Ponuda p = ponudeRadna[lsPonude.SelectedIndex];
            if (datOd.Value.Date > datDo.Value.Date)
            {
                MessageBox.Show("Datumi nisu korektno popunjeni!");
                txtCena.Text = "Greška!";
                return;
            }
            Ponuda p1 = new Ponuda(p.IdAuta, p.DatumOd, datOd.Value.Date.AddDays(-1), p.CenaDana);
            Ponuda p2 = new Ponuda(p.IdAuta, datDo.Value.Date.AddDays(1), p.DatumDo, p.CenaDana);

            if ((datOd.Value.Date - p.DatumOd).TotalDays > 0)
                ponude.Add(p1);
            if ((p.DatumDo - datDo.Value.Date).TotalDays > 0)
                ponude.Add(p2);
            ponude.Remove(p);
            FileStream fsp = new FileStream("ponude.xml", FileMode.Create);
            SoapFormatter sfp = new SoapFormatter();
            foreach (Ponuda ponuda in ponude)
            {
                sfp.Serialize(fsp, ponuda);
            }
            fsp.Close();
            Rezervacija r = new Rezervacija(p.IdAuta, idKupca, datOd.Value, datDo.Value, int.Parse(txtCena.Text));
            rezervacije.Add(r);
            MessageBox.Show("Uspešna rezervacija!");
            FileStream fs = new FileStream("rezervacije.xml", FileMode.Append);
            SoapFormatter sf = new SoapFormatter();
            sf.Serialize(fs, rezervacije.Last());
            fs.Close();
            Close();
        }
        public void dohvatiId(int id)
        {
            idKupca = id;
        }
    } 
}
