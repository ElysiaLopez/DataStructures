using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfBalancingStuff
{
    class SkipList<T> : ICollection<T>
        where T : IComparable<T>
    {
        public SkipListNode<T> Head {get;set;}
        public int Count
        {
            get
            {
                int count = 0;
                var temp = Head;
                while(temp.Nexts[0] != null)
                {
                    temp = temp.Nexts[0];
                    count++;
                }
                return count;
            }
        }

        bool ICollection<T>.IsReadOnly => false;

        public SkipList()
        {
            Head = new SkipListNode<T>(default, 1);
        }

        private int ChooseRandomHeight()
        {
            var random = new Random(5);
            int height = 1;
            while(random.Next(2) == 0 && height <= Head.Height)
            {
                height++;
            }
            return height;
        }

        public void Add(T item)
        {
            int newNodeHeight = ChooseRandomHeight();
            if(newNodeHeight > Head.Height)
            {
                var newHeadNexts = new SkipListNode<T>[newNodeHeight];
                Array.Copy(Head.Nexts, newHeadNexts, Head.Height);
                Head.Nexts = newHeadNexts;
            }
            var newNode = new SkipListNode<T>(item, newNodeHeight);

            int currLevel = Head.Height - 1;
            var temp = Head;
            while(currLevel >= 0)
            {
                //if the current temp's next is null, move down one
                //if the current temp's next is less than the item, set temp to current temp's next
                //if the current temp's next is greater than the item, set it to the new node's next and move down
                if(temp.Nexts[currLevel] != null && temp.Nexts[currLevel].Value.CompareTo(item) < 0)
                {
                    temp = temp.Nexts[currLevel];
                    continue;
                }
                if (currLevel < newNode.Height)
                {
                    newNode.Nexts[currLevel] = temp.Nexts[currLevel];
                    temp.Nexts[currLevel] = newNode;
                }
                currLevel--;
            }
        }

        public void Clear()
        {
            Head = new SkipListNode<T>(default, 1);
        }

        public bool Contains(T item)
        {
            var temp = Head.Nexts[0];
            while(temp != null)
            {
                if(temp.Value.CompareTo(item) == 0)
                {
                    return true;
                }
                temp = temp.Nexts[0];
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            var temp = Head.Nexts[0];
            while(temp != null)
            {
                yield return temp.Value;
                temp = temp.Nexts[0];
            }
        }

        public bool Remove(T item)
        {
            var temp = Head;
            int currLevel = Head.Height - 1;
            bool foundNode = false;
            while(currLevel >= 0)
            {
                if(temp.Nexts[currLevel] == null)
                {
                    currLevel--;
                    continue;
                }
                int compareResult = temp.Nexts[currLevel].Value.CompareTo(item);
                if(compareResult == 0)
                {
                    var nodeToDelete = temp.Nexts[currLevel];
                    temp.Nexts[currLevel] = nodeToDelete.Nexts[currLevel];
                    foundNode = true; 
                    currLevel--;
                }
                else if(compareResult < 0)
                {
                    temp = temp.Nexts[currLevel];
                }
                else
                {
                    currLevel--;
                }
                
            }
            return foundNode;
        }

        IEnumerator IEnumerable.GetEnumerator()
        => GetEnumerator();
    }
}
