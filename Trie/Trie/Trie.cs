using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trie
{
    public class Trie
    {
        public Node Root { get; set; }

        public Trie()
        {
            Root = new Node('$');
        }
        public void Clear()
        => Root = new Node('$');

        public void Insert(string word)
        {
            var temp = Root;
            for(int i = 0; i < word.Length; i++)
            {
                if(!temp.Children.ContainsKey(word[i]))
                {
                    temp.Children.Add(word[i], new Node(word[i])); 
                }
                temp = temp.Children[word[i]];
            }
            temp.isWord = true;
        }

        public bool Contains(string word)
        {
            var node = SearchNode(word);
            return node != null && node.isWord; 
        }
        private Node SearchNode(string word)
        {
            var temp = Root;
            for(int i = 0; i < word.Length; i++)
            {
                if (!temp.Children.ContainsKey(word[i])) return null;
                temp = temp.Children[word[i]];
            }
            return temp;
        }

        public List<string> GetAllMatchingPrefix(string prefix)
        {
            var endOfPrefix = SearchNode(prefix);
            var words = new List<string>();

            void GetPrefixedWords(Node node, string word)
            {
                if (node.isWord) words.Add(word);
                foreach(var child in node.Children.Values)
                {
                    GetPrefixedWords(child, word + child.Letter);
                }
            }
            GetPrefixedWords(endOfPrefix, prefix);
            return words;
        }
        public bool Remove(string prefix)
        {
            var nodeToRemove = SearchNode(prefix);
            if (nodeToRemove == null) return false;
            nodeToRemove.isWord = false;
            return true;
        }
    }
}
