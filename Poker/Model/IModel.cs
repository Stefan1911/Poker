﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Poker.Model
{
    public interface IModel
    {
        void promesaj();
        void izvuciPrvu();
        void vratiUSpil(List<Karta> karte);
        List<Karta> Ruka { get; set; }
        void zameniKarte(List<int> intList);
        void ulog(int broj);
        int Poeni{ get; set; }
        void novaRuka();

    }
}