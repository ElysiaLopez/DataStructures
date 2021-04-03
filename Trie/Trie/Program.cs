using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trie
{
    class Program
    {
        static void Main(string[] args)
        {
            var trie = new Trie();
            trie.Insert("word");
            trie.Insert("woman");
            trie.Insert("worm");
            trie.Insert("dollar");
            trie.Insert("phone");
            var words = trie.GetAllMatchingPrefix("wo");
        }
    }
}
