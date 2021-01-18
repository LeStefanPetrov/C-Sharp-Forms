using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIT_17621661_Exercise2
{
    public partial class Form1 : Form
    {
        string text = "Обща постановка Процесът на извличане на информация започва с въвеждането от потребителя на заявка към системата. Заявките са формални описания на информационната потребност, например низ въведен в полето на търсачката. При извличането на информация с една заявка не се идентифицира по уникален начин един-единствен обект от съвкупността. Напротив, обикновено на заявката отговарят повече от един обекта, вероятно с различни степени на релевантност. Под „обект“ се разбира запис, който съхранява определен обем от информация в базата данни, като в зависимост от приложението, обектът може да е текстов, графичен, аудио- или видео-документ.Повечето системи за извличане на информация изчисляват числов коефициент на релевантност на всеки от документите в базата по отношение на изпратената от потребителя заявка, и ранжират (подреждат в намаляващ ред) така оценените документи според техния коефициент. Най-високо ранжираните обекти са тези, които се връщат като резултат на потребителя. Процесът може да претърпи и повече от една итерация, ако потребителят не е удовлетворен от резултата и желае да прецизира заявката си.Оценки на резултата Съществуват различни техники за измерване и оценка на резултата от работата на системите за извличане на информация. Всяка от тях изисква съвкупност от документи и потребителска заявка.Важни показатели за оценка и управление на качеството са:Наличност / Достъпност на данните (Availability) Пълнота на данните (Completeness) — параметър, измерващ съществуването или отсъствието на данни.Съгласуваност на данни (Consistency) Съгласувани данни са тези, при които при възможно наличие на дублиране на данни, те са с еднакво и налично съдържание.Релевантност / Съответност на данни (Relevance) Този показател изисква стойностите на данните да попадат в приемлив обсег или да са от определена типизирана съвкупност.Навременност / Свежест на данни (Timeliness/Freshness) Този параметър използва времето за записване на данните и времето, когато данните се смятат актуални. Разликата между тези времена би показала дали данните са свежи, или са стари.";
        private List<string> listOfWords = new List<string>();
        public Form1()
        {
            InitializeComponent();
            listView1.View = View.Details;
            listOfWords = text.Split(' ', '“', '„', '.', ',', '(', ')', '-', '/', '!', '?', ':', '\n', '\r', '"', '+').ToList();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            listBox1.Items.Clear();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int i = 0; i < listOfWords.Count(); i++)
            {
                if (listOfWords[i].Length < 3)
                {
                    listOfWords.RemoveAt(i);
                    i--;
                }
                else listBox1.Items.Add(listOfWords[i].ToLower()); 
            }

            stopwatch.Stop();
            textBox1.Text = stopwatch.Elapsed.ToString();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count == 0)
            {
                MessageBox.Show("You must Parse the text first!", "Error!");
            }
            else
            {
                listBox2.Items.Clear();
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                string temp;
                bool flag = true;
                while (flag) { 
                    flag = false;
                    for (int j = 0; j < listOfWords.Count() - 1; j++)
                    {
                        if (listOfWords[j].CompareTo(listOfWords[j + 1]) > 0)
                        {
                            temp = listOfWords[j];
                            listOfWords[j] = listOfWords[j + 1];
                            listOfWords[j + 1] = temp;
                            flag = true;
                        }
                       
                    }
                }


                stopwatch.Stop();
                textBox2.Text = stopwatch.Elapsed.ToString();
               
                for (int i = 0; i < listOfWords.Count(); i++)
                {
                   
                    listBox2.Items.Add(listOfWords[i].ToLower());
                }

                textBox4.Text = (listOfWords.Count+1).ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count == 0)
            {
                MessageBox.Show("You must Parse the text first!", "Error!");
            }
            else
            {
                listView1.Items.Clear();
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                int j = 1;
                for (int i = 0; i < listOfWords.Count() - 1; i++)
                {
                    
                    if (listOfWords[i] == listOfWords[i + 1])
                    {
                        j++;
                    }

                    else
                    {
                        string[] row = { listOfWords[i].ToString(), j.ToString() };
                        var listViewItem = new ListViewItem(row);
                        listView1.Items.Add(listViewItem);
                        j = 1;
                    }

                }

                stopwatch.Stop();
                textBox3.Text = stopwatch.Elapsed.ToString();
                textBox5.Text = (listView1.Items.Count -2).ToString();
            }
        }
    }
    }

