using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Poker.Controller;
using System.Drawing;
using Poker.Model;
namespace Poker.View

{
    public interface IView
    {
        void Add(IController controller);
        int Poeni { set; }
        int Ulog { get; }
        List<Karta> Karte
        {
            set;
        }
    }
}
