using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace SelfBalancingStuff
{
    class Program
    {
        public static void Draw<T>(SkipList<T> skipList)
            where T : IComparable<T>
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine();
            var temp = skipList.Head;
            var currLevel = skipList.Head.Height - 1;
            while (currLevel >= 0)
            {
                while(temp.Nexts[currLevel] != null)
                {
                    temp = temp.Nexts[currLevel];
                    Console.Write(temp.Value + "  ");
                }
                currLevel--;
                temp = skipList.Head;
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void BetterDraw<T>(BetterSkipList<T> skipList)
            where T : IComparable<T>
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine();
            var temp = skipList.Head;
            var currHeadNode = skipList.Head;
            while (temp != null)
            {
                while (temp.Next != null)
                {
                    temp = temp.Next;
                    Console.Write(temp.Value + "  ");
                }
                temp = currHeadNode.Bottom;
                currHeadNode = currHeadNode.Bottom;
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void Main(string[] args)
        {
            //Comparison<int> comparison = new Comparison<int>((x, y) => y.CompareTo(x));
            //var binaryHeap = new BinaryHeap<int>(Comparer<int>.Create(comparison));
            
            var skipList = new BetterSkipList<int>();
            skipList.Add(1);
            skipList.Add(6);
            skipList.Add(3);
            skipList.Add(4);
            skipList.Add(9);
            skipList.Add(2);

            BetterDraw(skipList);

            while(true)
            {
                var input = Console.ReadLine();
                var value = Convert.ToInt32(input.Substring(1));
                if(input[0] == 'r')
                {
                    var wasAbleToRemove = skipList.Remove(value);
                    Console.WriteLine(wasAbleToRemove);
                }
                else if(input[0] == 'a')
                {
                    skipList.Add(value);
                }
                BetterDraw(skipList);
            }
        }
    }
}
