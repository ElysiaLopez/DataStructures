using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trie
{
    public class Node
    {
        public char Letter { get; set; }
        public Dictionary<char, Node> Children { get; set; }
        public bool isWord { get; set; }
        public Node(char letter)
        {
            Letter = letter;
            isWord = false;
            Children = new Dictionary<char, Node>();
        }
    }
}
