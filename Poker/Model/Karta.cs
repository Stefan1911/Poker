using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Poker.Model
{
    public enum znak
    {
        list,
        srce,
        det,
        kocka
    }
    public class Karta
    {
        private Image slika;
        private int broj;
        private znak znak;

        public Image Slika
        {
            get
            {
                return slika;
            }

            set
            {
                slika = value;
            }
        }

        public int Broj
        {
            get
            {
                return broj;
            }

            set
            {
                broj = value;
            }
        }

        public znak Znak
        {
            get
            {
                return znak;
            }

            set
            {
                znak = value;
            }
        }

        public Karta(Image slika, int broj, znak znak)
        {
            this.Znak = znak;
            this.Slika = slika;
            this.Broj = broj;
        }


    }
}
