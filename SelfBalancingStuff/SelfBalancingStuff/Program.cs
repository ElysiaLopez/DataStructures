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
            Comparison<int> comparison = new Comparison<int>((x, y) => y.CompareTo(x));
            var binaryHeap = new BinaryHeap<int>(Comparer<int>.Create(comparison));
            binaryHeap.Insert(1);
            binaryHeap.Insert(9);
            binaryHeap.Insert(2);
            binaryHeap.Insert(13);
            binaryHeap.Insert(10);
            binaryHeap.Insert(3);
            binaryHeap.Insert(17);
            binaryHeap.Insert(5);
            binaryHeap.Insert(11);

            var numOfItems = binaryHeap.currIndex;

            for(int i = 0; i < numOfItems; i++)
            {
                Console.WriteLine(binaryHeap.Pop());
            }
        }
    }
}
