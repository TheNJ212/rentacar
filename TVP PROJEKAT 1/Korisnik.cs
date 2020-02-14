using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVP_PROJEKAT_1
{
    [Serializable]
    abstract class Korisnik
    {
        protected string username;
        protected string password;

        public string Username
        {
            get
            {
                return username;
            }

            set
            {
                username = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
            }
        }
       public Korisnik(string username,string password)
        {
            this.username = username;
            this.password = password;
        }

        public Korisnik()
        {
            this.username = "nepoznato";
            this.password = "nepoznato";
        }

    }
}
