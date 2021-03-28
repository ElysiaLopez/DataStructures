using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfBalancingStuff
{
    class Program
    {
        static void Main(string[] args)
        {
            //Comparison<int> comparison = new Comparison<int>((x, y) => y.CompareTo(x));
            //var binaryHeap = new BinaryHeap<int>(Comparer<int>.Create(comparison));

            var tree = new AVLTree<int>();
            tree.Insert(1);
            tree.Insert(3);
            tree.Insert(2);
            tree.Insert(6);
            tree.Insert(4);
            tree.Insert(5);

            tree.Delete(4);

        }
    }
}
