using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVP_PROJEKAT_1
{
    [Serializable]
    class Rezervacija
    {
        private int idAuta;
        private int idKorisnika;
        private DateTime datumOd;
        private DateTime datumDo;
        private int cena;

        public Rezervacija(int idAuta, int idKorisnika, DateTime datumOd, DateTime datumDo, int cena)
        {
            this.idAuta = idAuta;
            this.idKorisnika = idKorisnika;
            this.datumOd = datumOd;
            this.datumDo = datumDo;
            this.cena = cena;
        }

        public int IdAuta
        {
            get
            {
                return idAuta;
            }

            set
            {
                idAuta = value;
            }
        }

        public int IdKorisnika
        {
            get
            {
                return idKorisnika;
            }

            set
            {
                idKorisnika = value;
            }
        }

        public DateTime DatumOd
        {
            get
            {
                return datumOd;
            }

            set
            {
                datumOd = value;
            }
        }

        public DateTime DatumDo
        {
            get
            {
                return datumDo;
            }

            set
            {
                datumDo = value;
            }
        }

        public int Cena
        {
            get
            {
                return cena;
            }

            set
            {
                cena = value;
            }
        }
        public override string ToString()
        {
            return "#" + IdKorisnika + "-" + IdAuta+"  "+ DatumOd.ToShortDateString()+". - "+DatumDo.ToShortDateString()+". cena: "+cena+" din.";
        }
    }
}
