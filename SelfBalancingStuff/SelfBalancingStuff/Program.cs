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

            var list = new SortedDoublyLinkedList<int>();
            list.Insert(1);
            list.Insert(10);
            list.Insert(3);
            list.Insert(8);
            list.Insert(5);

            list.Remove(5);

        }
    }
}
