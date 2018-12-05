using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Poker.Model;
using Poker.View;
using System.Windows.Forms;

namespace Poker.Controller
{
    class texasController : IController
    {
        private IModel model;
        private IView view;

        public texasController(IModel model, IView view)
        {
            this.model = model;
            this.view = view;
            this.view.Add(this);
        }

        public void RacunajPoene()
        {
            int ulog = this.view.Ulog;
            if(this.model.Ruka.Count == 2)
            {
                this.model.updatePoene(Dobitak()* ulog * 5);
            }
            else if(this.model.Ruka.Count == 3)
            {
                this.model.updatePoene(Dobitak() * ulog * 5);
            }
            else if (this.model.Ruka.Count == 4)
            {
                
                this.model.updatePoene((Dobitak() *5) -ulog);
            }
            else
            {
                this.model.updatePoene(Dobitak() - 2*ulog);
            }

        }

        public void prikaziRuku()
        {
            this.view.Karte = this.model.Ruka;
        }

        public void zameni(List<int> list)
        {
            MessageBox.Show("nema zamene u texasu, yeeehaa!!!");
        }

        public int Dobitak()
        {
            int temp = Rank.Instance.getRank(this.model.Ruka);
            switch (temp)
            {
                case 1:
                    return 100;
                case 2:
                    return 60;
                case 3:
                    return 40;
                case 4:
                    return 25;
                case 5:
                    return 16;
                case 6:
                    return 12;
                case 7:
                    return 9;
                case 8:
                    return 6;
                case 9:
                    return 4;
                case 10:
                    return 2;
                default:
                    break;
            }
            return 0;
        }
        public void sledecaRunda()
        {
            this.RacunajPoene();
            this.model.novaRuka(2);
            this.view.Karte = this.model.Ruka;
            this.view.Poeni = this.model.Poeni;
            this.pocetniUlog();
            this.postaviPoene();
        }
        public void postaviPoene()
        {
            this.view.Poeni = this.model.Poeni;
        }

        public int whatIs()
        {
            return Rank.Instance.getRank(this.model.Ruka);
        }

        public void pocniIgru()
        {
            this.model.Ruka.Clear();
            this.model.novaRuka(2);
            this.prikaziRuku();
            this.pocetniUlog();
            this.postaviPoene();

        }

        public void vuci(int broj)
        {
            this.model.vuci(broj);
            this.prikaziRuku();
        }

        private void pocetniUlog()
        {
            this.model.updatePoene(-5);
        }

    }
}
