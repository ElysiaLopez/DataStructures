using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfBalancingStuff
{
    class BinaryHeap<T>
    {
        Comparer<T> Comparer;
        public T[] items = new T[5];
        public int currIndex = 0;

        public BinaryHeap(Comparer<T> comparer)
        {
            Comparer = comparer;
        }

        public void Insert(T val)
        {
            if(currIndex >= items.Length)
            {
                var newArray = new T[items.Length * 2];
                Array.Copy(items, newArray, items.Length);
                items = newArray;
            }
            items[currIndex] = val;
            HeapifyUp(currIndex);
            currIndex++;
        }

        public void Swap(ref T first, ref T second)
        {
            T temp = first;
            first = second;
            second = temp;
        }

        public void HeapifyUp(int index)
        {
            int parentIndex = (index + 1) / 2 - 1;
            while(parentIndex >= 0 && Comparer.Compare(items[parentIndex], items[index]) > 0)
            {
                Swap(ref items[parentIndex], ref items[index]);
                index = parentIndex;
                parentIndex = (index + 1) / 2 - 1;
            }
        }

        public T Pop()
        {
            if (currIndex == 0) throw new Exception("No items in array");
            T root = items[0];
            items[0] = items[currIndex - 1];
            currIndex--;

            HeapifyDown(0);

            return root;
        }

        public void HeapifyDown(int index)
        {
            while(true)
            {
                int leftIndex = index * 2 + 1;
                int rightIndex = index * 2 + 2;
                int smallerValIndex = 0;
                if (leftIndex < currIndex)
                {
                    if (rightIndex < currIndex)
                    {
                        if (Comparer.Compare(items[leftIndex], items[rightIndex]) < 0) smallerValIndex = leftIndex;
                        else smallerValIndex = rightIndex;
                    }
                    else smallerValIndex = leftIndex;
                }
                else break; //no children
                if (Comparer.Compare(items[smallerValIndex], items[index]) > 0) break;

                Swap(ref items[index], ref items[smallerValIndex]);
                index = smallerValIndex;
            }

        }
    }
}
