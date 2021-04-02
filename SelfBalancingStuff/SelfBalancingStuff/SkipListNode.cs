using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfBalancingStuff
{
    class SkipListNode<T>
        where T : IComparable<T>
    {
        public SkipListNode<T>[] Nexts { get; set; }
        public SkipListNode<T> Previous { get; set; }
        public SkipListNode<T> Next { get; set; }
        public SkipListNode<T> Bottom { get; set; }

        public T Value { get; set; }

        //public int Height => Nexts.Length;
        public int Height
        {
            get
            {
                int count = 1;
                var temp = Bottom;
                while (temp != null)
                {
                    count++;
                    temp = temp.Bottom;
                }
                return count;
            }
        }

        public SkipListNode(T val, int height)
        {
            Value = val;
            Nexts = new SkipListNode<T>[height];

            var temp = this;
            for (int i = 1; i < height; i++)
            {
                var bottom = new SkipListNode<T>(val);
                temp.Bottom = bottom;
                temp = bottom;
            }
        }

        public SkipListNode(T val)
        {
            Value = val;
        }
    }
}
