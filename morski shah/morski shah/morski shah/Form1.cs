using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace morski_shah
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
         
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            int newSize = 20;
            button1.Font = new Font(button1.Font.FontFamily, newSize);
            button2.Font = new Font(button2.Font.FontFamily, newSize);
            button3.Font = new Font(button3.Font.FontFamily, newSize);
            button4.Font = new Font(button4.Font.FontFamily, newSize);
            button5.Font = new Font(button5.Font.FontFamily, newSize);
            button6.Font = new Font(button6.Font.FontFamily, newSize);
            button7.Font = new Font(button7.Font.FontFamily, newSize);
            button8.Font = new Font(button8.Font.FontFamily, newSize);
            button9.Font = new Font(button9.Font.FontFamily, newSize);
            int newSize2 = 10;
            groupBox1.Font = new Font(groupBox1.Font.FontFamily, newSize2);
        }
        string klicker = "";
        void klick() { 
        
                         switch (MouseButtons) {

                        case MouseButtons.Left:
                                 klicker = "X";
                        break;

                        case MouseButtons.Right:
                                  klicker = "O";
                        break;
  
                    }
        
        
        
        }
        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            klick();
            button1.Text = klicker;
            equals();
        }

        private void button2_MouseDown(object sender, MouseEventArgs e)
        {
            klick();
            button2.Text = klicker;
            equals();
        }

        private void button3_MouseDown(object sender, MouseEventArgs e)
        {
            klick();
            button3.Text = klicker;
            equals();
        }

        private void button4_MouseDown(object sender, MouseEventArgs e)
        {
            klick();
            button4.Text = klicker;
            equals();
        }

        private void button5_MouseDown(object sender, MouseEventArgs e)
        {
            klick();
            button5.Text = klicker;
            equals();
        }

        private void button6_MouseDown(object sender, MouseEventArgs e)
        {
            klick();
            button6.Text = klicker;
            equals();
        }

        private void button7_MouseDown(object sender, MouseEventArgs e)
        {
            klick();
            button7.Text = klicker;
            equals();
        }

        private void button8_MouseDown(object sender, MouseEventArgs e)
        {
            klick();
            button8.Text = klicker;
            equals();
        }

        private void button9_MouseDown(object sender, MouseEventArgs e)
        {
            klick();
            button9.Text = klicker;
            equals();
        }

        void equals() {
            //HORIZONTALS

            if ((button1.Text == button2.Text) && (button2.Text == button3.Text))
            {
                MessageBox.Show("We have winner !");
                System.Windows.Forms.Application.ExitThread(); 
            }
            if ((button4.Text == button5.Text) && (button5.Text == button6.Text))
            {
                MessageBox.Show("We have winner !");
                System.Windows.Forms.Application.ExitThread(); 
            }
            if ((button7.Text == button8.Text) && (button8.Text == button9.Text))
            {
                MessageBox.Show("We have winner !");
                System.Windows.Forms.Application.ExitThread(); 
            }

            //VERTICALS
            if ((button1.Text == button4.Text) && (button4.Text == button7.Text))
            {
                MessageBox.Show("We have winner !");
                System.Windows.Forms.Application.ExitThread(); 
            }
            if ((button2.Text == button5.Text) && (button5.Text == button8.Text))
            {
                MessageBox.Show("We have winner !");
                System.Windows.Forms.Application.ExitThread(); 
            }
            if ((button3.Text == button6.Text) && (button6.Text == button9.Text))
            {
                MessageBox.Show("We have winner !");
                System.Windows.Forms.Application.ExitThread(); 
            }

            //DIAGONALS
            if ((button1.Text == button5.Text) && (button5.Text == button9.Text))
            {
                MessageBox.Show("We have winner !");
                System.Windows.Forms.Application.ExitThread(); 
            }
            if ((button3.Text == button5.Text) && (button5.Text == button7.Text))
            {
                MessageBox.Show("We have winner !");
                System.Windows.Forms.Application.ExitThread(); 
            }

            
                   
        }

      
       


        
        }

      

       
    }

