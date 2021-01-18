using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3._2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {//допуска запетая, BackSpace Ascii 44 и запетая -  Ascii 8         
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != ',')
            {
                e.Handled = true;
                textBox1.Focus();
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            double pDDO1 = 0.089;
            double pDZPO1 = 0;
            double pDDO2 = 0.067;
            double pDZPO2 = 0.022;
            double osigurovki = 0.032;
            double zaplata, a, b, c, sum;
            zaplata = double.Parse(textBox1.Text);
            if (radioButton1.Checked)
            {
                a = zaplata * pDDO1;
                label5.Text = String.Format("{0:F2}{1}", a, " лв.");
                b = zaplata * pDZPO1;
                label6.Text = String.Format("{0:F2}{1}", b, " лв.");
                c = zaplata * osigurovki;
                label8.Text = String.Format("{0:F2}{1}", c, " лв.");
                sum = a + b + c;
                label10.Text = String.Format("{0:F2}{1}", sum, " лв.");
            }
            if (radioButton2.Checked)
            {
                a = zaplata * pDDO2;
                label5.Text = String.Format("{0:F2}{1}", a, " лв.");
                b = zaplata * pDZPO2;
                label6.Text = String.Format("{0:F2}{1}", b, " лв.");
                c = zaplata * osigurovki;
                label8.Text = String.Format("{0:F2}{1}", c, " лв.");
                sum = a + b + c;
                label10.Text = String.Format("{0:F2}{1}", sum, " лв.");
            }
        }
    }
}
