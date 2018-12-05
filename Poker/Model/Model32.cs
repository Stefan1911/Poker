using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Model
{
    class Model32 : IModel
    {
        private Spil spil;
        private List<Karta> ruka;
        private int poeni;

        public List<Karta> Ruka
        {
            get
            {
                return ruka;
            }

            set
            {
                ruka = value;
            }
        }

        public int Poeni
        {
            get
            {
                return poeni;
            }

            set
            {
                poeni = value;
            }
        }

        public Model32(int poeni)
        {
            this.spil = new Spil(false);
            this.Ruka = new List<Karta>();
            this.poeni = poeni;
            this.spil.MesajSpil();
            for (int i = 0; i < 5; i++)
            {
                this.izvuciPrvu();
            }
        }

        public void promesaj()
        {
            this.spil.MesajSpil();
        }

        public void izvuciPrvu()
        {
            Karta temp = spil.izvuci();
            this.Ruka.Add(temp);
        }

        public void vratiUSpil(List<Karta> karte)
        {
            this.spil.vrati(karte);
        }

        public void zameniKarte(List<int> intList)
        {

            List<Karta> temp = new List<Karta>();
            foreach (int index in intList)
            {
                temp.Add(this.ruka.ElementAt(index));
                this.ruka.Insert(index, this.spil.izvuci());
            }

            this.spil.vrati(temp);
        }

        public void updatePoene(int vrednost)
        {
            this.poeni += vrednost;
        }

        public void novaRuka(int broj)
        {
            this.vratiUSpil(ruka);
            this.ruka.Clear();
            this.promesaj();
            this.vuci(broj);
        }

        public void vuci(int broj)
        {
            for (int i = 0; i < broj; i++)
            {
                this.izvuciPrvu();
            }
        }
    }
}
