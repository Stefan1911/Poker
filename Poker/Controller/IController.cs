using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Controller
{
    public interface IController
    {
        void vuci(int broj);
        void prikaziRuku();
        void zameni(List<int> list);
        void RacunajPoene();
        int Dobitak();
        void sledecaRunda();
        void postaviPoene();
        int whatIs();
        void pocniIgru();
    }
}
