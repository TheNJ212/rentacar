using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVP_PROJEKAT_1
{
    [Serializable]
    class Ponuda
    {
        private int idAuta;
        private DateTime datumOd;
        private DateTime datumDo;
        private int cenaDana;

        public Ponuda(int idAuta, DateTime datumOd, DateTime datumDo, int cenaDana)
        {
            this.idAuta = idAuta;
            this.datumOd = datumOd;
            this.datumDo = datumDo;
            this.cenaDana = cenaDana;
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

        public int CenaDana
        {
            get
            {
                return cenaDana;
            }

            set
            {
                cenaDana = value;
            }
        }

        public override string ToString()
        {
            return "ID #"+idAuta + " cena za dan: " + cenaDana+" din.";
        }

        public  string IspisPonude()
        {
            return datumOd.ToShortDateString()+". - "+datumDo.ToShortDateString()+".  Cena: "+cenaDana.ToString()+" din po danu";
        }

    }
}
