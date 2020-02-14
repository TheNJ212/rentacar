using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVP_PROJEKAT_1
{
    [Serializable]
    class Kupac:Korisnik
    {
        private int uid;
        private string ime;
        private string prezime;
        private string jmbg;
        private DateTime datumRodjenja;
        private string telefon;
        private bool admin;

        public int Uid
        {
            get
            {
                return uid;
            }

            set
            {
                uid = value;
            }
        }

        public bool Admin
        {
            get
            {
                return admin;
            }

            set
            {
                admin = value;
            }
        }

        public string Ime
        {
            get
            {
                return ime;
            }

            set
            {
                ime = value;
            }
        }

        public string Prezime
        {
            get
            {
                return prezime;
            }

            set
            {
                prezime = value;
            }
        }

        public string Jmbg
        {
            get
            {
                return jmbg;
            }

            set
            {
                jmbg = value;
            }
        }

        public DateTime DatumRodjenja
        {
            get
            {
                return datumRodjenja;
            }

            set
            {
                datumRodjenja = value;
            }
        }

        public string Telefon
        {
            get
            {
                return telefon;
            }

            set
            {
                telefon = value;
            }
        }

        public Kupac(string username, string password, int uid, string ime, string prezime, string jmbg, DateTime datumRodjenja, string telefon,bool admin) : base(username, password)
        {
            this.admin = admin;
            this.uid = uid;
            this.ime = ime;
            this.prezime = prezime;
            this.jmbg = jmbg;
            this.datumRodjenja = datumRodjenja;
            this.telefon = telefon;
        }
        public Kupac(string username, string password, int uid, string ime, string prezime, string jmbg, DateTime datumRodjenja, string telefon) : base(username, password)
        {
            this.admin = false;
            this.uid = uid;
            this.ime = ime;
            this.prezime = prezime;
            this.jmbg = jmbg;
            this.datumRodjenja = datumRodjenja;
            this.telefon = telefon;
        }
        public override string ToString()
        {
            return ime + " " + prezime + ", " + datumRodjenja.ToShortDateString() + ", " + telefon;
        }
    }
}
