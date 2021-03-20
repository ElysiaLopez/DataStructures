using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecursiveSorts
{
    class Program
    {
        static T[] MergeSort<T>(T[] array)
            where T:IComparable
        {
            if (array.Length < 2) return array;
            var left = new T[array.Length / 2];
            var right = new T[array.Length - left.Length];

            //split the array
            Array.Copy(array, 0, left, 0, left.Length);
            Array.Copy(array, left.Length, right, 0, right.Length);

            return Merge(MergeSort(left), MergeSort(right));
            
        }
        static T[] Merge<T>(T[] left, T[] right)
            where T:IComparable
        {
            var final = new T[left.Length + right.Length];
            int leftIndex = 0;
            int rightIndex = 0;
            for(int i = 0; i < final.Length; i++)
            {
                if(leftIndex.CompareTo(left.Length) >= 0)
                {
                    final[i] = right[rightIndex];
                    rightIndex++;
                    continue;
                }
                if(rightIndex.CompareTo(right.Length) >= 0)
                {
                    final[i] = left[leftIndex];
                    leftIndex++;
                    continue;
                }
                if(left[leftIndex].CompareTo(right[rightIndex]) < 0)
                {
                    final[i] = left[leftIndex];
                    leftIndex++;
                }
                else
                {
                    final[i] = right[rightIndex];
                    rightIndex++;
                }
            }
            return final;
        }

        static void Swap<T>(ref T first, ref T second)
        {
            T temp = first;
            first = second;
            second = temp;
        }

        static void QuickSortLomuto<T>(T[] array)
            where T : IComparable<T>
        {
            LomutoPartition(array)
        }

        static void LomutoPartition<T>(T[] array, int startIndex, int length)
            where T : IComparable<T>
        {
            if (length <= 1) return;
            int pivotIndex = startIndex + length - 1;
            var pivot = array[pivotIndex];
            int wallIndex = startIndex - 1;

            for(int i = startIndex; i < startIndex + length; i++)
            {
                if (array[i].CompareTo(pivot) < 0) 
                {
                    //swaps the current value with the value directly to the right of the wall
                    Swap(ref array[wallIndex + 1], ref array[i]);
                    wallIndex++;
                }
            }
            //swap pivot with wall
            Swap(ref array[wallIndex + 1], ref array[pivotIndex]);


            LomutoPartition(array, 0, wallIndex + 1);
            LomutoPartition(array, wallIndex + 2, length - (wallIndex + 2));
        }
        static void Main(string[] args)
        {
            var array = new int[] {5, 7, 6, 1, 2, 3, 4};
            LomutoPartition(array, 0, array.Length);
        }
    }
}
