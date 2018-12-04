using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Poker.Model
{
    public class Rank
    {
        #region singleton
        private static Rank _instace = null;
        public static Rank Instance
        {
            get
            {
                if(_instace == null)
                    return new Rank();
                return _instace;
            }
        }
        #endregion
        public int getRank(List<Karta> ruka)
        {
            if (isStrFlush(ruka))
                return 1;
            if (isFourOfaKind(ruka))
                return 2;
            if (isBigBobtail(ruka))
                return 3;
            if (isFullHouse(ruka))
                return 4;
            if (isFlush(ruka))
                return 5;
            if (isStr(ruka))
                return 6;
            if (isBlaze(ruka))
                return 7;
            if (isTreeOfaKind(ruka))
                return 8;
            if (isTwoPairs(ruka))
                return 9;
            if (isOnePair(ruka))
                return 10;
            return 0;
        }

        public bool isStrFlush(List<Karta> ruka)
        {
            if (ruka.Count < 5)
                return false;
            if (this.isFlush(ruka) && this.isStr(ruka))
                return true;
            return false;
        }

        public bool isFlush(List<Karta> ruka)
        {
            if (ruka.Count < 5)
                return false;
            bool temp = true;
            int i = 0;
            while (temp && i < ruka.Count - 1)
            {
                if (ruka[i].Znak != ruka[++i].Znak)
                    temp = false;
            }
            return temp;
        }

        public bool  isStr(List<Karta> ruka)
        {
            if (ruka.Count < 5)
                return false;
            bool temp = false;
            int i = 0;
            while(!temp && i < ruka.Count-1)
            {
                temp = strHelper(ruka, ruka[i++].Broj +1 , 0);
            }
            return temp;
        }
        bool strHelper(List<Karta> ruka, int next,int depth)
        {
            if (hasNumber(ruka, next))
            {
                if (depth == ruka.Count -2)
                    return true;
                return strHelper(ruka, next + 1, ++depth);
            }
            return false;
        }
        bool hasNumber(List<Karta> ruka, int broj)
        {
            foreach(Karta karta in ruka)
            {
                if (karta.Broj == broj)
                    return true;
            }
            return false;
        }
        public bool isBigBobtail(List<Karta> ruka)
        {

            if (ruka.Count < 4)
                return false;

            List<Karta> tempRuka;
            bool temp = false;
            int i = 0;
            while (!temp && i < ruka.Count)
            {
                tempRuka = new List<Karta>(ruka);
                tempRuka.RemoveAt(i++);
                if (isFlush(tempRuka) && isStr(tempRuka))
                    temp = true;
            }
            return temp;
        }
        public bool isFourOfaKind(List<Karta> ruka)
        {
            if (ruka.Count < 4)
                return false;
            bool temp = false;
            int i = 0;
            while(!temp && i < ruka.Count)
            {
                temp = this.fourHelper(ruka, i++);
            }
            return temp;
        }

        public bool fourHelper(List<Karta> ruka,int index) // proverava dali ima 4 iste bez karte sa prosledjenim indexom
        {
            bool temp = true;
            int i = 0;
            List<Karta> tempRuka = new List<Karta>(ruka);
            tempRuka.RemoveAt(index);
            while (temp && i < tempRuka.Count - 1)
            {
                if (tempRuka[i].Broj != tempRuka[++i].Broj)
                    temp = false;
            }
            return temp;
        }

        public bool isTreeOfaKind(List<Karta> ruka)
        {
            if (ruka.Count < 3)
                return false;
            bool temp = false;
            int i = 0;
            while (!temp && i < ruka.Count)
            {
                int count= 0;
                foreach(Karta karta in ruka)
                {
                    if(karta.Broj == ruka[i].Broj)
                        count++;
                }
                if (count == 3)
                    temp = true;
                i++;
            }
            return temp;
        }

        public bool isOnePair(List<Karta> ruka)
        {
            bool temp = false;
            int i = 0;
            while (!temp && i < ruka.Count)
            {
                int count = 0;
                foreach (Karta karta in ruka)
                {
                    if (karta.Broj == ruka[i].Broj)
                        count++;
                }
                if (count == 2)
                    temp = true;
                i++;
            }
            return temp;
        }
        public bool isTwoPairs(List<Karta> ruka)
        {
            if (ruka.Count < 4)
                return false;
            int i = 0;
            int bigCount = 0;
            while (i < ruka.Count)
            {
                int count = 0;
                foreach (Karta karta in ruka)
                {
                    if (karta.Broj == ruka[i].Broj)
                        count++;
                }
                if (count == 2)
                    bigCount++;
                i++;
            }
            if(bigCount == 4)
                return true;
            return false;
        }
        public bool isBlaze(List<Karta> ruka)
        {
            if (ruka.Count < 5)
                return false;
            bool temp = true;
            int i = 0;
            while (temp && i< ruka.Count)
            {
                if (ruka[i++].Broj < 12)
                    temp = false;
            }
            return temp;
        }
        public bool isFullHouse(List<Karta> ruka)
        {
            return this.isTreeOfaKind(ruka) && this.isTreeOfaKind(ruka);
        }
    }
}
