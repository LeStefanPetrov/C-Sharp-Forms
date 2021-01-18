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

namespace SIT_17621661_Exercise5
{
    public partial class Form1 : Form
    {
        private List<string> listOfRemovedWords = new List<string>();

        public Form1()
        {
            InitializeComponent();
            listOfRemovedWords = File.ReadAllText(@"E:\Programming\Uni\ИИИ\SIT_17621661_Exercise5\removedWords.txt").Split(' ').ToList();
            listView1.View = View.Details;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            richTextBox1.Text = File.ReadAllText(@"E:\Programming\Uni\ИИИ\SIT_17621661_Exercise5\Text1.txt");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            richTextBox1.Text = File.ReadAllText(@"E:\Programming\Uni\ИИИ\SIT_17621661_Exercise5\Text2.txt");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            richTextBox1.Text = File.ReadAllText(@"E:\Programming\Uni\ИИИ\SIT_17621661_Exercise5\Text3.txt");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            richTextBox1.Text = File.ReadAllText(@"E:\Programming\Uni\ИИИ\SIT_17621661_Exercise5\Text4.txt");
        }
        private List<string> listOfWords = new List<string>();
        private void button5_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "") { MessageBox.Show("Въведдете текст!!!","Грешка!!!"); }
            else
            {
                listBox1.Items.Clear();
                listView1.Items.Clear();
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();
                listOfWords = richTextBox1.Text.ToLower().Split(' ', '.', ',', '(', ')', '/', '!', '?', ':', '\n', '\r', '[', ']', ';', '\t').ToList();
                for (int i = 0; i < listOfWords.Count(); i++)
                {
                    foreach (var parasite in listOfRemovedWords)
                    {
                        if (listOfWords[i] == parasite)
                        {
                            listOfWords.RemoveAll(item => item == parasite);
                        }
                    }
                }
                richTextBox2.Text = string.Join(" ", listOfWords);
                stopWatch.Stop();
                textBox1.Text = stopWatch.Elapsed.ToString();
                listOfWords.RemoveAll(string.IsNullOrWhiteSpace);

                for (int i = 0; i < listOfWords.Count(); i++)
                {
                    listBox1.Items.Add(listOfWords[i]);
                }
                textBox2.Text = listOfWords.Count.ToString();

                int countMul, countDiv, countPlus, countMinus, countStr, countInt, countText;
                countMul=countDiv=countPlus=countMinus=countStr=countInt=countText = 0;
                for (int i = 0; i < listOfWords.Count(); i++)
                {
                    if (listOfWords[i] == "*")
                    {
                        listView1.Items.Add(new ListViewItem(new string[] { listOfWords[i], "multiplication", }));
                        countMul++;
                    }
                    else if (listOfWords[i] == "%")
                    {
                        listView1.Items.Add(new ListViewItem(new string[] { listOfWords[i], "division", }));
                        countDiv++;
                    }
                    else if (listOfWords[i] == "+")
                    {
                        listView1.Items.Add(new ListViewItem(new string[] { listOfWords[i], "plus", }));
                        countPlus++;
                    }
                    else if (listOfWords[i] == "-")
                    {
                        listView1.Items.Add(new ListViewItem(new string[] { listOfWords[i], "minus", }));
                        countMinus++;
                    }
                    else if (listOfWords[i].Substring(0, 1) == '"'.ToString() || listOfWords[i].Substring(0, 1) == '“'.ToString())
                    {
                        listView1.Items.Add(new ListViewItem(new string[] { listOfWords[i], "String", }));
                        countStr++;
                    }
                    else if (!string.IsNullOrEmpty(listOfWords[i]) && listOfWords[i].All(Char.IsDigit))
                    {
                        listView1.Items.Add(new ListViewItem(new string[] { listOfWords[i], "intconst", }));
                        countInt++;
                    }
                    else
                    {
                        listView1.Items.Add(new ListViewItem(new string[] { listOfWords[i], "text", }));
                        countText++;
                    }
                }
                textBox3.Text = countMul.ToString();
                textBox4.Text = countDiv.ToString();
                textBox5.Text = countPlus.ToString();
                textBox6.Text = countMinus.ToString();
                textBox7.Text = countStr.ToString();
                textBox8.Text = countInt.ToString();
                textBox9.Text = countText.ToString();
            }
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
