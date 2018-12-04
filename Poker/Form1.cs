using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Poker.Model;
using Poker.View;
using Poker.Controller;
namespace Poker
{
    public partial class Form1 : Form, IView
    {
        public Form1()
        {
            InitializeComponent();
            
        }
        IController controller;

        

        public int Poeni {
            set
            {
                pointsLabela.Text = value.ToString();
            }
        }

        public List<Karta> Karte
        {
            set
            {
                pb1.Image = value.ElementAt(0).Slika;
                pb2.Image = value.ElementAt(1).Slika;


                if (value.Count >= 3)
                {
                    pb3.Visible = true;
                    pb3.Image = value.ElementAt(2).Slika;
                }
                else
                {
                    pb3.Visible = false;
                }

                if (value.Count >= 4)
                {
                    pb4.Visible = true;
                    pb4.Image = value.ElementAt(3).Slika;
                }
                else
                {
                    pb4.Visible = false;
                }

                if (value.Count >= 5)
                {
                    pb5.Visible = true;
                    pb5.Image = value.ElementAt(4).Slika;
                }
                else
                {
                    pb5.Visible = false;
                }
            }
        }

        public void Add(IController controller)
        {
            this.controller = controller;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            
            Form3 f = new Form3();
            if(f.ShowDialog() == DialogResult.OK)
            {
                this.controller.zameni(f.List);
            }
            button1.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.controller.pocniIgru();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            this.controller.sledecaRunda();
           // controller.

        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this.controller.whatIs().ToString());

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.controller.vuci(1);
        }
    }
}
