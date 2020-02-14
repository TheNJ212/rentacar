using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVP_PROJEKAT_1
{
    [Serializable]
    class Automobil
    {
        private int id;
        private string marka;
        private string model;
        private int godiste;
        private int kubikaza;
        private string pogon;
        private string menjac;
        private string karoserija;
        private string gorivo;
        private string brojvrata;

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Marka
        {
            get
            {
                return marka;
            }

            set
            {
                marka = value;
            }
        }

        public string Model
        {
            get
            {
                return model;
            }

            set
            {
                model = value;
            }
        }

        public int Godiste
        {
            get
            {
                return godiste;
            }

            set
            {
                godiste = value;
            }
        }

        public int Kubikaza
        {
            get
            {
                return kubikaza;
            }

            set
            {
                kubikaza = value;
            }
        }

        public string Pogon
        {
            get
            {
                return pogon;
            }

            set
            {
                pogon = value;
            }
        }

        public string Menjac
        {
            get
            {
                return menjac;
            }

            set
            {
                menjac = value;
            }
        }

        public string Karoserija
        {
            get
            {
                return karoserija;
            }

            set
            {
                karoserija = value;
            }
        }

        public string Gorivo
        {
            get
            {
                return gorivo;
            }

            set
            {
                gorivo = value;
            }
        }

        public string Brojvrata
        {
            get
            {
                return brojvrata;
            }

            set
            {
                brojvrata = value;
            }
        }
        public Automobil()
        {
            this.id = 0;
            this.marka = "nepoznato";
            this.model = "nepoznato";
            this.godiste = 0;
            this.kubikaza = 0;
            this.pogon = "nepoznato";
            this.menjac = "nepoznato";
            this.karoserija = "nepoznato";
            this.gorivo = "nepoznato";
            this.brojvrata = "nepoznato";
        }
        public Automobil(int id,string marka,string model, int godiste,int kubikaza, string pogon,string menjac,string karoserija,string gorivo,string brojvrata )
        {
            this.id = id;
            this.marka = marka;
            this.model = model;
            this.godiste = godiste;
            this.kubikaza = kubikaza;
            this.pogon = pogon;
            this.menjac = menjac;
            this.karoserija = karoserija;
            this.gorivo = gorivo;
            this.brojvrata = brojvrata;
        }
        public override string ToString()
        {
            return Marka + " " + model + " " + godiste.ToString() + ", " + kubikaza + "ccm ";
        }
    }
}
