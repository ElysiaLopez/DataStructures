using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfBalancingStuff
{
    class BetterSkipListNode<T>
        where T : IComparable<T>
    {
        public T Value { get; set; }
        public BetterSkipListNode<T> Previous { get; set; }
        public BetterSkipListNode<T> Next { get; set; }
        public BetterSkipListNode<T> Bottom { get; set; }
        public int Height { get; set; }

        public BetterSkipListNode(T val, int height)
        {
            Value = val;
            Height = height;
        }

        public BetterSkipListNode(T val)
        {
            Value = val;
        }
    }
}
