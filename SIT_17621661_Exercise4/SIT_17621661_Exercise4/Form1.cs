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

namespace SIT_17621661_Exercise4
{
    public partial class Form1 : Form
    {
        private List<string> listOfRemovedWords = new List<string>();
        public Form1()
        {
            InitializeComponent();
            listOfRemovedWords= File.ReadAllText(@"E:\Programming\Uni\ИИИ\SIT_17621661_Exercise4\removedWords.txt").Split(' ').ToList();
        }
        private List<string> listOfWords = new List<string>();
        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            richTextBox1.Text = File.ReadAllText(@"E:\Programming\Uni\ИИИ\SIT_17621661_Exercise4\text1.txt");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            richTextBox1.Text = File.ReadAllText(@"E:\Programming\Uni\ИИИ\SIT_17621661_Exercise4\text2.txt");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            richTextBox1.Text = File.ReadAllText(@"E:\Programming\Uni\ИИИ\SIT_17621661_Exercise4\text3.txt");
        }
        Tree tree = new Tree();

        private void button6_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "")
            {
                MessageBox.Show("Трябва да изберете текст!", "Грешка!!!");
            }
            else
            {
                tree = new Tree();
                treeView1.Nodes.Clear();
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                listOfWords = richTextBox1.Text.ToLower().Split(' ', '“', '„', '.', ',', '(', ')', '-', '/', '!', '?', ':', '\n', '\r', '"', '+', '[', ']', ';').ToList();
                listOfWords.RemoveAll(x => x.Length == 0);
                for (int i = 0; i < listOfWords.Count(); i++)
                {
                    for (int j = 0; j < listOfRemovedWords.Count(); j++)
                    {
                        if (listOfWords[i].Equals(listOfRemovedWords[j]))
                        {
                            listOfWords.RemoveAt(i);
                        }
                    }
                }
                var groups = listOfWords.GroupBy(v => v);
                
                foreach (var group in groups)
                {
                    tree.insert(group.Key + "," + group.Count());
                }
                
                DisplayTree(tree);
                treeView1.ExpandAll();
                stopwatch.Stop();
                textBox1.Text = stopwatch.Elapsed.ToString();
               
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
        private void button7_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "")
            {
                MessageBox.Show("Трябва да изберете текст!", "Грешка!!!");
            }
            else
            {
                listBox1.Items.Clear();
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                InOrder(tree.root);
                stopwatch.Stop();
                textBox2.Text = stopwatch.Elapsed.ToString();
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
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                PreOrder(tree.root);
                stopwatch.Stop();
                textBox3.Text = stopwatch.Elapsed.ToString();
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
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                PostOrder(tree.root);
                stopwatch.Stop();
                textBox4.Text = stopwatch.Elapsed.ToString();
            }
        }
    }
}
