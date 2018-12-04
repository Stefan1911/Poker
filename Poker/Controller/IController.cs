using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Controller
{
    public interface IController
    {
        void vuci5();
        void zameni(List<int> list);
        void ulog();
        int brojPoena();
        void sledecaRunda();
        void postaviPoene();
        int whatIs();
    }
}
