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
        public BetterSkipListNode<T> Head = new BetterSkipListNode<T>(default, 1);
        public int Count => throw new NotImplementedException();

        public bool IsReadOnly => throw new NotImplementedException();

        Random random { get; }

        public BetterSkipList(Random rand)
        {
            random = rand;
        }

        private int ChooseRandomHeight()
        {
            int height = 1;
            while (random.Next(2) == 0 && height <= Head.Height)
            {
                height++;
            }
            return height;
        }

        private void ConnectNodes(BetterSkipListNode<T> prev, BetterSkipListNode<T> curr, BetterSkipListNode<T> next)
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
                Head = new BetterSkipListNode<T>(default)
                {
                    Bottom = bottom,
                    Height = newNodeHeight
                };
            }
            var temp = Head;
            var node = new BetterSkipListNode<T>(val, newNodeHeight);

            while(temp != null)
            {
                while (temp.Next != null && temp.Next.Value.CompareTo(val) < 0)
                {
                    temp = temp.Next;
                }
                if (temp.Next != null && temp.Next.Value.CompareTo(val) == 0) throw new Exception("No duplicate values allowed");
                if (newNodeHeight >= temp.Height)
                {
                    ConnectNodes(temp, node, temp.Next);
                    if(temp.Height > 1)
                    {
                        var newBottom = new BetterSkipListNode<T>(val, temp.Height - 1);
                        node.Bottom = newBottom;
                    }
                    node = node.Bottom;
                }
                temp = temp.Bottom;
            }
        }

        public void Clear()
        {
            Head = new BetterSkipListNode<T>(default, 1);
        }

        private BetterSkipListNode<T> Find(T val)
        {
            var temp = Head;
            while (temp != null)
            {
                if (temp.Next == null)
                {
                    temp = temp.Bottom;
                    continue;
                }
                int compareVal = temp.Next.Value.CompareTo(val);
                if (compareVal == 0) return temp.Next;
                if (compareVal < 0) temp = temp.Next;
                else temp = temp.Bottom;
            }
            return null;
        }

        public bool Contains(T item)
        {
            return Find(item) != null;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            var temp = Head;
            while (temp.Bottom != null) temp = temp.Bottom;
            temp = temp.Next;
            for(int i = arrayIndex; i < array.Length && temp != null; i++)
            {
                array[i] = temp.Value;
                temp = temp.Next;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            var temp = Head;
            while (temp.Bottom != null) temp = temp.Bottom;
            while(temp.Next != null)
            {
                yield return temp.Next.Value;
                temp = temp.Next;
            }
        }

        public bool Remove(T val)
        {
            var nodeToRemove = Find(val);
            if (nodeToRemove == null) return false;
            RemoveConnections(nodeToRemove);
            return true;
        }
        public void RemoveConnections(BetterSkipListNode<T> node)
        {
            var temp = node;
            while (temp != null)
            {
                var prev = temp.Previous;
                var next = temp.Next;
                prev.Next = next;
                if (next != null) next.Previous = prev;

                temp = temp.Bottom;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        => GetEnumerator();
    }
}
