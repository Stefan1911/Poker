using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Poker.View;

namespace Poker
{
    public partial class Form2 : Form
    {
        Poker.Model.IModel model;
        public Form2()
        {
            InitializeComponent();
            cbx.Items.Add("standardni-52 karte");
            cbx.Items.Add("francuski-32 karte");
            btnok.Enabled = false;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            IView view = new Form1();
            if (stdRadio.Checked)
            {
                Poker.Controller.IController cont = new Poker.Controller.stdController(this.model, view);
            }
            else
            {
                Poker.Controller.IController cont = new Poker.Controller.texasController(this.model, view);
            }
                

            ((Form)view).ShowDialog();
            this.Close();

        }


        private void cbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbx.SelectedItem.ToString() == "standardni-52 karte")
            {
                btnok.Enabled = true;
                model = new Model.Model52(Int32.Parse(poeniBox.Text));

            }
            if (String.Compare(cbx.SelectedItem.ToString(), "francuski-32 karte") == 0)
            {
                btnok.Enabled = true;
                model = new Model.Model32(Int32.Parse(poeniBox.Text));
            }
        }
    }
}
