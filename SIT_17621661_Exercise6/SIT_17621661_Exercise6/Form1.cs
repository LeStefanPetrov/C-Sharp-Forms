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

namespace SIT_17621661_Exercise6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            listView1.View = View.Details;
            linkLabel1.Text = "";
        }
        private List<string> listOfWords = new List<string>();
        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            textBox2.Text = File.ReadAllText(@"E:\Programming\Uni\ИИИ\SIT_17621661_Exercise6\Test1.txt");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            textBox2.Text = File.ReadAllText(@"E:\Programming\Uni\ИИИ\SIT_17621661_Exercise6\Test2.txt");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            textBox2.Text = File.ReadAllText(@"E:\Programming\Uni\ИИИ\SIT_17621661_Exercise6\Test3.txt");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            textBox2.Text = File.ReadAllText(@"E:\Programming\Uni\ИИИ\SIT_17621661_Exercise6\Test4.txt");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            textBox2.Text = File.ReadAllText(@"E:\Programming\Uni\ИИИ\SIT_17621661_Exercise6\Test5.txt");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            textBox2.Text = File.ReadAllText(@"E:\Programming\Uni\ИИИ\SIT_17621661_Exercise6\Test6.txt");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            if (textBox2.Text == "")
            {
                MessageBox.Show("Моля изберете файл от Тест 1 до Тест 6.", "Празна текстова кутия !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();
                string buff = "";
                for (int i = 0; i < textBox2.Text.Length; i++)
                {
                    if (textBox2.Text[i] != '<' && textBox2.Text[i] != '>')
                    {
                        buff = buff + textBox2.Text[i];
                        continue;
                    }
                    listOfWords.Add(buff);
                    buff = "";
                }

                listOfWords.RemoveAll(string.IsNullOrWhiteSpace);

                for (int i = 0; i < listOfWords.Count(); i++)
                {
                    if(listOfWords[i]=="html")
                        listView1.Items.Add(new ListViewItem(new string[] { (i + 1).ToString(),"<"+listOfWords[i]+">", "Start" }));
                    else if (listOfWords[i] == "/html")
                        listView1.Items.Add(new ListViewItem(new string[] { (i + 1).ToString(), "<" + listOfWords[i] + ">", "End" }));
                    else if(listOfWords[i] == "b")
                        listView1.Items.Add(new ListViewItem(new string[] { (i + 1).ToString(), "<" + listOfWords[i] + ">", "Start" }));
                    else if(listOfWords[i] == "/b")
                        listView1.Items.Add(new ListViewItem(new string[] { (i + 1).ToString(), "<" + listOfWords[i] + ">", "End" }));
                    else if (listOfWords[i] == "p")
                        listView1.Items.Add(new ListViewItem(new string[] { (i + 1).ToString(), "<" + listOfWords[i] + ">", "Start" }));
                    else if (listOfWords[i] == "/p")
                        listView1.Items.Add(new ListViewItem(new string[] { (i + 1).ToString(), "<" + listOfWords[i] + ">", "End" }));
                    else if (listOfWords[i] == "h1")
                        listView1.Items.Add(new ListViewItem(new string[] { (i + 1).ToString(), "<" + listOfWords[i] + ">", "Start" }));
                    else if (listOfWords[i] == "/h1")
                        listView1.Items.Add(new ListViewItem(new string[] { (i + 1).ToString(), "<" + listOfWords[i] + ">", "End" }));
                    else if (listOfWords[i] == "h2")
                        listView1.Items.Add(new ListViewItem(new string[] { (i + 1).ToString(), "<" + listOfWords[i] + ">", "Start" }));
                    else if (listOfWords[i] == "/h2")
                        listView1.Items.Add(new ListViewItem(new string[] { (i + 1).ToString(), "<" + listOfWords[i] + ">", "End" }));
                    else if (listOfWords[i] == "h3")
                        listView1.Items.Add(new ListViewItem(new string[] { (i + 1).ToString(), "<" + listOfWords[i] + ">", "Start" }));
                    else if (listOfWords[i] == "/h3")
                        listView1.Items.Add(new ListViewItem(new string[] { (i + 1).ToString(), "<" + listOfWords[i] + ">", "End" }));
                    else if (listOfWords[i] == "h4")
                        listView1.Items.Add(new ListViewItem(new string[] { (i + 1).ToString(), "<" + listOfWords[i] + ">", "Start" }));
                    else if (listOfWords[i] == "/h4")
                        listView1.Items.Add(new ListViewItem(new string[] { (i + 1).ToString(), "<" + listOfWords[i] + ">", "End" }));
                    else if (listOfWords[i] == "h5")
                        listView1.Items.Add(new ListViewItem(new string[] { (i + 1).ToString(), "<" + listOfWords[i] + ">", "Start" }));
                    else if (listOfWords[i] == "/h5")
                        listView1.Items.Add(new ListViewItem(new string[] { (i + 1).ToString(), "<" + listOfWords[i] + ">", "End" }));
                    else if (listOfWords[i] == "h6")
                        listView1.Items.Add(new ListViewItem(new string[] { (i + 1).ToString(), "<" + listOfWords[i] + ">", "Start" }));
                    else if (listOfWords[i] == "/h6")
                        listView1.Items.Add(new ListViewItem(new string[] { (i + 1).ToString(), "<" + listOfWords[i] + ">", "End" }));
                    else if (listOfWords[i] == "head")
                        listView1.Items.Add(new ListViewItem(new string[] { (i + 1).ToString(), "<" + listOfWords[i] + ">", "Start" }));
                    else if (listOfWords[i] == "/head")
                        listView1.Items.Add(new ListViewItem(new string[] { (i + 1).ToString(), "<" + listOfWords[i] + ">", "End" }));
                    else if (listOfWords[i] == "i")
                        listView1.Items.Add(new ListViewItem(new string[] { (i + 1).ToString(), "<" + listOfWords[i] + ">", "Start" }));
                    else if (listOfWords[i] == "/i")
                        listView1.Items.Add(new ListViewItem(new string[] { (i + 1).ToString(), "<" + listOfWords[i] + ">", "End" }));
                    else if (listOfWords[i] == "ol")
                        listView1.Items.Add(new ListViewItem(new string[] { (i + 1).ToString(), "<" + listOfWords[i] + ">", "Start" }));
                    else if (listOfWords[i] == "/ol")
                        listView1.Items.Add(new ListViewItem(new string[] { (i + 1).ToString(), "<" + listOfWords[i] + ">", "End" }));
                    else if (listOfWords[i] == "ul")
                        listView1.Items.Add(new ListViewItem(new string[] { (i + 1).ToString(), "<" + listOfWords[i] + ">", "Start" }));
                    else if (listOfWords[i] == "/ul")
                        listView1.Items.Add(new ListViewItem(new string[] { (i + 1).ToString(), "<" + listOfWords[i] + ">", "End" }));
                    else if (listOfWords[i] == "meta")
                        listView1.Items.Add(new ListViewItem(new string[] { (i + 1).ToString(), "<" + listOfWords[i] + ">", "Start" }));
                    else if (listOfWords[i] == "/meta")
                        listView1.Items.Add(new ListViewItem(new string[] { (i + 1).ToString(), "<" + listOfWords[i] + ">", "End" }));
                    else if (listOfWords[i] == "li")
                        listView1.Items.Add(new ListViewItem(new string[] { (i + 1).ToString(), "<" + listOfWords[i] + ">", "Start" }));
                    else if (listOfWords[i] == "/li")
                        listView1.Items.Add(new ListViewItem(new string[] { (i + 1).ToString(), "<" + listOfWords[i] + ">", "End" }));
                    else if (listOfWords[i] == "title")
                        listView1.Items.Add(new ListViewItem(new string[] { (i + 1).ToString(), "<" + listOfWords[i] + ">", "Start" }));
                    else if (listOfWords[i] == "/title")
                        listView1.Items.Add(new ListViewItem(new string[] { (i + 1).ToString(), "<" + listOfWords[i] + ">", "End" }));
                    else if (listOfWords[i] == "tr")
                        listView1.Items.Add(new ListViewItem(new string[] { (i + 1).ToString(), "<" + listOfWords[i] + ">", "Start" }));
                    else if (listOfWords[i] == "/tr")
                        listView1.Items.Add(new ListViewItem(new string[] { (i + 1).ToString(), "<" + listOfWords[i] + ">", "End" }));
                    else if (listOfWords[i] == "td")
                        listView1.Items.Add(new ListViewItem(new string[] { (i + 1).ToString(), "<" + listOfWords[i] + ">", "Start" }));
                    else if (listOfWords[i] == "/td")
                        listView1.Items.Add(new ListViewItem(new string[] { (i + 1).ToString(), "<" + listOfWords[i] + ">", "End" }));
                    else if (listOfWords[i] == "body")
                        listView1.Items.Add(new ListViewItem(new string[] { (i + 1).ToString(), "<" + listOfWords[i] + ">", "Start" }));
                    else if (listOfWords[i] == "/body")
                        listView1.Items.Add(new ListViewItem(new string[] { (i + 1).ToString(), "<" + listOfWords[i] + ">", "End" }));
                    else if (listOfWords[i] == "a")
                        listView1.Items.Add(new ListViewItem(new string[] { (i + 1).ToString(), "<" + listOfWords[i] + ">", "Start" }));
                    else if (listOfWords[i] == "/a")
                        listView1.Items.Add(new ListViewItem(new string[] { (i + 1).ToString(), "<" + listOfWords[i] + ">", "End" }));
                    else if (listOfWords[i] == "div")
                        listView1.Items.Add(new ListViewItem(new string[] { (i + 1).ToString(), "<" + listOfWords[i] + ">", "Start" }));
                    else if (listOfWords[i] == "/div")
                        listView1.Items.Add(new ListViewItem(new string[] { (i + 1).ToString(), "<" + listOfWords[i] + ">", "End" }));
                    else if (listOfWords[i] == "!DOCTYPEhtml")
                        listView1.Items.Add(new ListViewItem(new string[] { (i + 1).ToString(), "<" + listOfWords[i] + ">", "Start" }));
                    else if (listOfWords[i].Contains("microsoft"))
                    {
                        linkLabel1.Text = "https://www.microsoft.com/";
                    }
                    else if (listOfWords[i].Contains("href"))
                    {
                        listView1.Items.Add(new ListViewItem(new string[] { (i + 1).ToString(), "<a> URL:" + listOfWords[i].Substring(8, listOfWords[i].Length - 9), "Start" }));
                        linkLabel1.Text = listOfWords[i].Substring(8, listOfWords[i].Length - 9);
                    }
                    else if (listOfWords[i].Contains(" "))
                        listView1.Items.Add(new ListViewItem(new string[] { (i + 1).ToString(), listOfWords[i], "Text" }));
                    else MessageBox.Show("Неразпознат таг: "+ listOfWords[i] + " на ред: "+ i,"!!!!");
                }

                stopWatch.Stop();
                textBox1.Text = stopWatch.Elapsed.ToString();
                listOfWords.Clear();

            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            listView1.Items.Clear();
            textBox2.Clear();
            linkLabel1.Text = "";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count==0)
            {
                MessageBox.Show("Моля парснете текст!", "Грешка !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int counter = 0;
                foreach (ListViewItem item in listView1.Items)
                {
                    if (item.SubItems[2].Text == "Start")
                    {
                        counter++;
                    }
                    else if (item.SubItems[2].Text == "End")
                    {
                        counter--;
                    }
                }
                if (counter == 0) MessageBox.Show("Равен брой Start/End тагове!", "!!!");
                if (counter < 0) MessageBox.Show("По-голям брой End тагове!", "!!!");
                if (counter > 0) MessageBox.Show("По-голям брой  Start тагове!", "!!!");
            }
        }
        private void linkLabel1_MouseClick(object sender, MouseEventArgs e)
        {
            Process.Start(linkLabel1.Text);
        }
    }
}
