using System;
using System.Collections.Generic;

namespace UnionFind
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> words = new List<string>()
            {
                "hello",
                "hobby",
                "pencil",
                "pineapple",
                "hillbilly"
            };

            QuickFind<string> quickFind = new QuickFind<string>(words);

            quickFind.Union("hello", "hobby");
            
        }
    }
}
