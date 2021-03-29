using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfBalancingStuff
{
    class SortedDoublyLinkedList<T>
        where T: IComparable<T>
    {
        public LinkedListNode<T> Head { get; }
        public SortedDoublyLinkedList()
        {
            Head = new LinkedListNode<T>(default);
        }

        private void ConnectNodes(LinkedListNode<T> prev, LinkedListNode<T> curr, LinkedListNode<T> next)
        {
            curr.Previous = prev;
            curr.Next = next;

            prev.Next = curr;
            if(next != null) next.Previous = curr;
        }

        public void Insert(T val)
        {
            var temp = Head;
            var newNode = new LinkedListNode<T>(val);
            while(temp.Next != null && temp.Next.Value.CompareTo(val) < 0)
            {
                temp = temp.Next;
            }
            ConnectNodes(temp, newNode, temp.Next);
        }

        public bool Remove(T val)
        {
            var temp = Head;
            while(temp.Value.CompareTo(val) != 0)
            {
                temp = temp.Next;
                if (temp == null) return false;
            }
            RemoveConnections(temp);
            return true;
        }

        public void RemoveConnections(LinkedListNode<T> node)
        {
            var prev = node.Previous;
            var next = node.Next;
            prev.Next = next;
            if (next != null) next.Previous = prev;
        }
    }
}
