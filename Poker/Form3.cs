using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Poker
{
    public partial class Form3 : Form
    {
        List<int> list;

        public List<int> List
        {
            get
            {
                return list;
            }
        }

        public Form3()
        {
            InitializeComponent();
            CBX.Items.Add("1");
            CBX.Items.Add("2");
            CBX.Items.Add("3");
            lbl1.Visible = false; lbl2.Visible = false; lbl3.Visible = false;
            textBox1.Visible = false; textBox2.Visible = false; textBox3.Visible = false;
            this.list = new List<int>();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBX.SelectedItem.ToString() == "1")
            {
                lbl1.Visible =true; lbl2.Visible = false; lbl3.Visible = false;
                textBox1.Visible = true; textBox2.Visible = false; textBox3.Visible = false;
            }
            if (CBX.SelectedItem.ToString() == "2")
            {
                lbl1.Visible = true; lbl2.Visible = true;
                lbl3.Visible = false; lbl2.Text = "i";
                textBox1.Visible = true; textBox2.Visible = true; textBox3.Visible = false;
            }
            if (CBX.SelectedItem.ToString() == "3")
            {
                lbl1.Visible = true; lbl2.Visible = true; lbl2.Text = ", ";
                lbl3.Visible = true; lbl3.Text = "i";
                textBox1.Visible = true; textBox2.Visible = true; textBox3.Visible = true;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Visible == true)
                List.Add(Int32.Parse(textBox1.Text));
            if (textBox2.Visible == true)
                List.Add(Int32.Parse(textBox2.Text));
            if (textBox3.Visible == true)
                List.Add(Int32.Parse(textBox3.Text));

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
