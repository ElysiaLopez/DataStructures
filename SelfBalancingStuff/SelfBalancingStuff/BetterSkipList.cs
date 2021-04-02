using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfBalancingStuff
{
    class BetterSkipList<T> : ICollection<T>
        where T : IComparable<T>
    {
        public SkipListNode<T> Head = new SkipListNode<T>(default, 1);
        public int Count => throw new NotImplementedException();

        public bool IsReadOnly => throw new NotImplementedException();

        private int ChooseRandomHeight()
        {
            var random = new Random(5);
            int height = 1;
            while (random.Next(2) == 0 && height <= Head.Height)
            {
                height++;
            }
            return height;
        }

        private void ConnectNodes(SkipListNode<T> prev, SkipListNode<T> curr, SkipListNode<T> next)
        {
            curr.Previous = prev;
            curr.Next = next;

            prev.Next = curr;
            if (next != null) next.Previous = curr;
        }

        public void Add(T val)
        {   
            var newNodeHeight = ChooseRandomHeight();
            if(newNodeHeight > Head.Height)
            {
                var bottom = Head;
                Head = new SkipListNode<T>(default);
                Head.Bottom = bottom;
            }
            var temp = Head;
            var currHeadNode = Head;
            var newNode = new SkipListNode<T>(val, newNodeHeight);


            while(currHeadNode != null)
            {
                while (temp.Next != null && temp.Next.Value.CompareTo(val) < 0)
                {
                    temp = temp.Next;
                }
                if(newNodeHeight >= currHeadNode.Height) ConnectNodes(temp, newNode, temp.Next);
                currHeadNode = currHeadNode.Bottom;
                temp = currHeadNode;
                newNode = newNode.Bottom;
            }
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
