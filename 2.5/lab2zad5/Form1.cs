using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab2zad5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label8.Text = br.ToString();
        }
        double np, sp, p,br=1;
        private void менюToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        void calc()
        {
            try
            {
               
                if (textBox1.Text != "" && textBox2.Text != "")

                    np = double.Parse(textBox2.Text);
                sp = double.Parse(textBox1.Text);
                p = np - sp;
                label5.Text = p.ToString();
                if (radioButton1.Checked) { 
                    p = p * 0.34;
                    label6.Text = p.ToString();
                } 
                else if (radioButton2.Checked)
                {
                    p = p * 0.44;
                    label6.Text = p.ToString();
                }
                else if (radioButton3.Checked)
                {
                    p = p * 0.54;
                    label6.Text = p.ToString();
                }
            }
            catch { }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            calc();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            calc();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            calc();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            calc();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            calc();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void новКлиентToolStripMenuItem_Click(object sender, EventArgs e)
        {
            br++;
            label8.Text = br.ToString();
            textBox1.Text = null;
            textBox2.Text = null;
            label6.Text = null;
            label5.Text = null;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
        }
    }
}



          