using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIT_17621661_Exercise9
{
    class Node
    {
        public string data;
        public Node left { get; set; }
        public Node right { get; set; }

        public Node(string data)
        {
            this.data = data;
        }
    }
}
