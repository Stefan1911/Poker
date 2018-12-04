using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Poker.Model
{
    public class Spil
    {
        private List<Karta> _spilKarata;

        public List<Karta> SpilKarata
        {
            get
            {
                return _spilKarata;
            }

            set
            {
                _spilKarata = value;
            }
        }

        public Spil(bool francuski)
        {
            _spilKarata = new List<Karta>();

            Karta temp;
            Image slika;
            for(int i=7;i<15;i++)
            {
                slika = (Image)Properties.Resources.ResourceManager.GetObject("" + i + "_srce");
                temp = new Karta(slika, i, znak.srce);
                SpilKarata.Add(temp);

                slika = (Image)Properties.Resources.ResourceManager.GetObject("" + i + "_det");
                temp = new Karta(slika, i, znak.det);
                SpilKarata.Add(temp);

                slika = (Image)Properties.Resources.ResourceManager.GetObject("" + i + "_kocka");
                temp = new Karta(slika, i, znak.kocka);
                SpilKarata.Add(temp);

                slika = (Image)Properties.Resources.ResourceManager.GetObject("" + i + "_list");
                temp = new Karta(slika, i, znak.list);
                SpilKarata.Add(temp);
            }

            if (!francuski)
            {
                for(int i = 2; i < 7; i++)
                {
                    slika = (Image)Properties.Resources.ResourceManager.GetObject("" + i + "_srce");
                    temp = new Karta(slika, i, znak.srce);
                    SpilKarata.Add(temp);

                    slika = (Image)Properties.Resources.ResourceManager.GetObject("" + i + "_det");
                    temp = new Karta(slika, i, znak.det);
                    SpilKarata.Add(temp);

                    slika = (Image)Properties.Resources.ResourceManager.GetObject("" + i + "_kocka");
                    temp = new Karta(slika, i, znak.kocka);
                    SpilKarata.Add(temp);

                    slika = (Image)Properties.Resources.ResourceManager.GetObject("" + i + "_list");
                    temp = new Karta(slika, i, znak.list);
                    SpilKarata.Add(temp);

                }
            }   
        }

        public Karta izvuci()
        {
            Karta temp = this._spilKarata.First();
            this._spilKarata.RemoveAt(0);
            return temp;
        }



        public void MesajSpil()
        {
            Random rand = new Random();
            List<Karta> temp = new List<Karta>();
            while(this._spilKarata.Count > 0)
            {
                int rng = rand.Next(0, this._spilKarata.Count);
                temp.Add(this._spilKarata.ElementAt(rng));
                this._spilKarata.RemoveAt(rng);
            }
            this._spilKarata = temp; 
        }

        public void vrati(List<Karta> vracene)
        {
            foreach(Karta karta in vracene)
            {
                this._spilKarata.Add(karta);
            }
        }
    }
}
