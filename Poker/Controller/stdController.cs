using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Poker.Model;
using Poker.View;
using System.Drawing;

namespace Poker.Controller
{
    class stdController : IController
    {
        private IModel model;
        private IView view;

        public stdController(IModel model, IView view)
        {
            this.model = model;
            this.view = view;
            this.view.Add(this);
        }

        public void ulog()
        {
            this.model.ulog(brojPoena() -5);
        }

        public void vuci5()
        {
            this.view.Karte = this.model.Ruka;
        }

        public void zameni(List<int> list)
        {
            this.model.zameniKarte(list);
            this.view.Karte = this.model.Ruka;
        }

        public int brojPoena()
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
            this.ulog();
            this.model.novaRuka();
            this.view.Karte = this.model.Ruka;
            this.view.Poeni = this.model.Poeni;
        }
        public void postaviPoene()
        {
            this.view.Poeni = this.model.Poeni;
        }

        public int whatIs()
        {
            return Rank.Instance.getRank(this.model.Ruka);
        }
    }
}
