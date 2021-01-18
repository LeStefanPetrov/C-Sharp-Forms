using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIT_17621661_Exercise9
{
    class Tree
    {
        public Node root;
        public Tree()
        {
            root = null;
        }
        public void insert(string data)
        {
            Node newItem = new Node(data);
            if (root == null)
            {
                root = newItem;
            }
            else
            {
                TreeNode sub = new TreeNode();
                Node current = root;
                Node parent = null;
                while (current != null)
                {
                    parent = current;

                    if (String.Compare(data, current.data) < 0)
                    {
                        current = current.left;
                        if (current == null)
                        {
                            parent.left = newItem;
                        }
                    }
                    else
                    {
                        current = current.right;
                        if (current == null)
                        {
                            parent.right = newItem;
                        }
                    }
                }
            }
         }
    }
}
