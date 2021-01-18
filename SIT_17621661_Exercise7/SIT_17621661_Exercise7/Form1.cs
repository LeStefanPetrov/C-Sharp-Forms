using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIT_17621661_Exercise7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            radioButton1.Checked = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox1.Text = File.ReadAllText(@"E:\Programming\Uni\ИИИ\SIT_17621661_Exercise7\Test1.txt");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox1.Text = File.ReadAllText(@"E:\Programming\Uni\ИИИ\SIT_17621661_Exercise7\Test2.txt");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox1.Text = File.ReadAllText(@"E:\Programming\Uni\ИИИ\SIT_17621661_Exercise7\Test3.txt");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox1.Text = File.ReadAllText(@"E:\Programming\Uni\ИИИ\SIT_17621661_Exercise7\Test4.txt");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox1.Text = File.ReadAllText(@"E:\Programming\Uni\ИИИ\SIT_17621661_Exercise7\Test5.txt");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Stopwatch stopWatch = new Stopwatch();
            if (textBox1.Text == "")
            {
                MessageBox.Show("Моля изберете Тест1-Тест5.", "Грешка!!!");
            }
            else
            {
                if (radioButton1.Checked) 
                {
                    HTTP_Request request = new HTTP_Request(textBox1.Text, HTTP_Request.HTTP_Method.GET);

                    stopWatch.Start();

                    richTextBox1.Text = request.HeadContent;
                    richTextBox2.Text = request.HtmlContent;

                    stopWatch.Stop();
                    textBox2.Text = stopWatch.Elapsed.ToString();
                }
                else 
                {
                    HTTP_Request request = new HTTP_Request(textBox1.Text, HTTP_Request.HTTP_Method.HEAD);

                    stopWatch.Start();

                    richTextBox1.Text = request.HeadContent;
                    richTextBox2.Text = "";

                    stopWatch.Stop();
                    textBox2.Text = stopWatch.Elapsed.ToString();
                }
            }
        }
    }
}
