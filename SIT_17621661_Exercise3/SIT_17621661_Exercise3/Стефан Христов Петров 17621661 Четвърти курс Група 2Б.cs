using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace SIT_17621661_Exercise3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            richTextBox1.Text = File.ReadAllText(@"E:\Programming\Uni\ИИИ\SIT_17621661_Exercise3\text.txt");
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            listBox1.Items.Clear();
            richTextBox1.SelectionStart = 0;
            richTextBox1.SelectAll();
            richTextBox1.SelectionBackColor = Color.White;
        }
        private List<string> listOfWords = new List<string>();
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Трябва да въведете дума", "Грешка!");
            }
            if (textBox1.Text.Length < 3) { }
            else
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                string textbox = textBox1.Text.ToLower();
                Collection<int> collection = new Collection<int>();

                if (radioButton2.Checked)
                {
                    listBox1.Items.Clear();
                    richTextBox1.SelectionStart = 0;
                    richTextBox1.SelectAll();
                    richTextBox1.SelectionBackColor = Color.White;
                    for (int i = 0; i < richTextBox1.TextLength - textBox1.TextLength; i++)
                    {
                        if (textbox.Equals(richTextBox1.Text.Substring(i, textBox1.TextLength).ToString().ToLower()))
                        {
                            richTextBox1.SelectionStart = i;
                            richTextBox1.SelectionLength = textBox1.TextLength;
                            richTextBox1.SelectionBackColor = Color.Red;
                            collection.Add(i);
                        }
                    }
                   
                }
                else if (radioButton1.Checked)
                {
                    richTextBox1.SelectionStart = 0;
                    richTextBox1.SelectAll();
                    richTextBox1.SelectionBackColor = Color.White;
                    listBox1.Items.Clear();
                    for (int i = 0; i < richTextBox1.TextLength - textBox1.TextLength; i++)
                    {
                        if (textbox.Equals(richTextBox1.Text.Substring(i, textBox1.TextLength).ToString().ToLower())
                            && (richTextBox1.Text.Substring(i - 1, 1) == " "
                            || richTextBox1.Text.Substring(i - 1, 1) == "("
                            || richTextBox1.Text.Substring(i - 1, 1) == ")"
                            || richTextBox1.Text.Substring(i - 1, 1) == ","
                            || richTextBox1.Text.Substring(i - 1, 1) == "."
                            )
                            &&
                            (richTextBox1.Text.Substring(i + textBox1.TextLength, 1) == " "
                            || richTextBox1.Text.Substring(i +textBox1.TextLength, 1) == "("
                            || richTextBox1.Text.Substring(i + textBox1.TextLength, 1) == ")"
                            || richTextBox1.Text.Substring(i + textBox1.TextLength, 1) == ","
                            || richTextBox1.Text.Substring(i + textBox1.TextLength, 1) == "."

                            )
                            
                            ){
                            richTextBox1.SelectionStart = i;
                            richTextBox1.SelectionLength = textBox1.TextLength;

                            richTextBox1.SelectionBackColor = Color.Yellow;
                            collection.Add(i);
                        }

                    }
                    

                    stopwatch.Stop();
                    textBox2.Text = stopwatch.Elapsed.ToString();
                }
                for (int i = 0; i < collection.Count(); i++)
                {
                    listBox1.Items.Add(collection[i]);
                }
                textBox3.Text = collection.Count().ToString();
            }
        }
    
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
