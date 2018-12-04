using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Poker.Model;

namespace Poker
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            List<Karta> testList = new List<Karta>();
            testList.Add(new Karta(null, 9, znak.det));
            testList.Add(new Karta(null, 13, znak.det));
            testList.Add(new Karta(null, 1, znak.det));
            testList.Add(new Karta(null, 9, znak.det));
            testList.Add(new Karta(null, 6, znak.det));

           /* MessageBox.Show((Rank.Instance.isStr(testList)).ToString());
            MessageBox.Show((Rank.Instance.isStr(testList)).ToString());
            MessageBox.Show((Rank.Instance.isStr(testList)).ToString());
            MessageBox.Show((Rank.Instance.isStr(testList)).ToString());*/

            Application.Run(new Form2());

            Poker.Model.Model52 model = new Model.Model52(500);
            Form1 view = new Form1();
            Poker.Controller.IController cont = new Poker.Controller.stdController(model, view);
        }
    }
}
