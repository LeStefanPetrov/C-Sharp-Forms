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

namespace SIT_17621661_Exercise9
{
    public partial class Form1 : Form
    {
        private List<string> listOfRemovedWords = new List<string>();
        public Form1()
        {
            InitializeComponent();
            listOfRemovedWords = File.ReadAllText(@"E:\Programming\Uni\ИИИ\SIT_17621661_Exercise9\SIT_17621661_Exercise9\removedWords.txt").Split(' ').ToList();
        }
        private Dictionary<string, List<string>> listOfWords = new Dictionary<string, List<string>>();
       

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            richTextBox1.Text = File.ReadAllText(@"E:\Programming\Uni\ИИИ\SIT_17621661_Exercise9\SIT_17621661_Exercise9\text1.txt");
            textBox2.Text = "d1";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            richTextBox1.Text = File.ReadAllText(@"E:\Programming\Uni\ИИИ\SIT_17621661_Exercise9\SIT_17621661_Exercise9\text2.txt");
            textBox2.Text = "d2";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            richTextBox1.Text = File.ReadAllText(@"E:\Programming\Uni\ИИИ\SIT_17621661_Exercise9\SIT_17621661_Exercise9\text3.txt");
            textBox2.Text = "d3";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            richTextBox1.Text = File.ReadAllText(@"E:\Programming\Uni\ИИИ\SIT_17621661_Exercise9\SIT_17621661_Exercise9\text4.txt");
            textBox2.Text = "d4";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            richTextBox1.Text = File.ReadAllText(@"E:\Programming\Uni\ИИИ\SIT_17621661_Exercise9\SIT_17621661_Exercise9\text5.txt");
            textBox2.Text = "d5";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            richTextBox1.Text = File.ReadAllText(@"E:\Programming\Uni\ИИИ\SIT_17621661_Exercise9\SIT_17621661_Exercise9\text6.txt");
            textBox2.Text = "t1";
        }
        Tree tree = new Tree();
        private void button10_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "")
            {
                MessageBox.Show("Трябва да изберете текст!", "Грешка!!!");
            }
            else
            {
                treeView1.Nodes.Clear();
                tree = new Tree();
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();
                string tag = textBox2.Text;

                if (!listOfWords.ContainsKey(tag))
                {
                    listOfWords.Add(tag, new List<string>());
                }

                string buff = "";
                for (int i = 0; i < richTextBox1.Text.Length; i++)
                {
                    if (richTextBox1.Text[i] != '<' && richTextBox1.Text[i] != '>' && richTextBox1.Text[i] != ' ')
                    {
                        buff += richTextBox1.Text[i];
                        continue;
                    }
                    listOfWords[tag].Add(buff);
                    buff = "";
                }

                listOfWords[tag].RemoveAll(string.IsNullOrWhiteSpace);


                for (int i = 0; i < listOfWords[tag].Count(); i++)
                {
                    if (listOfWords[tag][i].Contains('/'))
                    {
                        listOfWords[tag][i] = listOfWords[tag][i].Substring(1);
                    }
                }

                Dictionary<string, string> listOfWordsTagsCounts = new Dictionary<string, string>();

                foreach (var list in listOfWords)
                {
                    string groupTag = list.Key;
                    var groups = list.Value.GroupBy(i => i);

                    foreach (var group in groups)
                    {
                        if (!listOfWordsTagsCounts.ContainsKey(group.Key))
                        {
                            listOfWordsTagsCounts.Add(group.Key, "");
                        }
                        listOfWordsTagsCounts[group.Key] += groupTag + ":" + group.Count() + ", ";
                    }
                }
                foreach (var group in listOfWordsTagsCounts)
                {
                    tree.insert(group.Key + " - " + group.Value);
                }

                DisplayTree(tree);
                treeView1.ExpandAll();
                stopWatch.Stop();
            }
        }

        void ShowNode(Node node, TreeNode treeNode)
        {
            treeNode.Text += node.data;
            if (node.left != null)
            {
                ShowNode(node.left, treeNode.Nodes.Add("Left: "));
            }
            if (node.right != null)
            {
                ShowNode(node.right, treeNode.Nodes.Add("Right: "));
            }
        }

        void DisplayTree(Tree tree)
        {
            ShowNode(tree.root, treeView1.Nodes.Add("Root: "));
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (treeView1.Nodes.Count != 0)
            {
                listBox1.Items.Clear();
                InOrder(tree.root);
            }
            else
            {
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show("Моля изберете някой от HTML бутоните или Text бутона първо!", "Грешка, Моля изберете текст!", buttons, MessageBoxIcon.Error);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "")
            {
                MessageBox.Show("Трябва да изберете текст!", "Грешка!!!");
            }
            else
            {
                listBox2.Items.Clear();
                PreOrder(tree.root);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "")
            {
                MessageBox.Show("Трябва да изберете текст!", "Грешка!!!");
            }
            else
            {
                listBox3.Items.Clear();
                PostOrder(tree.root);
            }
        }
        void PreOrder(Node node)
        {

            if (node != null)
            {
                listBox2.Items.Add(node.data.ToString());
                PreOrder(node.left);
                PreOrder(node.right);
            }
        }

        void InOrder(Node node)
        {
            if (node != null)
            {
                InOrder(node.left);
                listBox1.Items.Add(node.data.ToString());
                InOrder(node.right);
            }
        }

        void PostOrder(Node node)
        {
            if (node != null)
            {
                PostOrder(node.left);
                PostOrder(node.right);
                listBox3.Items.Add(node.data.ToString());
            }
        }
    }
}
