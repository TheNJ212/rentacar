using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVP_PROJEKAT_1
{
    [Serializable]
    class Admin: Korisnik
    {
        private string ime;
        private string prezime;
        public Admin(string username,string password,string ime, string prezime):base(username,password)
        {
            this.ime = ime;
            this.prezime = prezime;
        }
        public Admin(Kupac k)
        {
            this.ime = k.Ime;
            this.prezime = k.Prezime;
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
    }
}
