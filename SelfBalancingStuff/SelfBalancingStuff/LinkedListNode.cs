using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfBalancingStuff
{
    class LinkedListNode<T>
        where T : IComparable<T>
    {
        public T Value { get; set; }
        public LinkedListNode<T> Previous { get; set; }
        public LinkedListNode<T> Next { get; set; }
        public LinkedListNode(T val)
        {
            Value = val;
        }
    }
}
