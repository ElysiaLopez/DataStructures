using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RecursiveSorts
{
    class Program
    {
        static T[] MergeSort<T>(T[] array)
            where T:IComparable<T>
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
            where T:IComparable<T>
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

        static void QuickSort<T>(T[] array, int left, int right)
            where T : IComparable<T>
        {
            if(left < right)
            {
                //var pivot = LomutoPartition(array, left, right);

                //QuickSort(array, left, pivot - 1);
                //QuickSort(array, pivot + 1, right);
                var pivot = HoarePartition(array, left, right);
                QuickSort(array, left, pivot);
                QuickSort(array, pivot + 1, right);
            }
        }

        static void QuickSortLomuto<T>(T[] array)
            where T : IComparable<T>
        {
            QuickSort(array, 0, array.Length - 1);
        }

        static int LomutoPartition<T>(T[] array, int left, int right)
            where T : IComparable<T>
        {
            var pivot = array[right];
            int wallIndex = left - 1;

            for(int i = left; i < right; i++)
            {
                if (array[i].CompareTo(pivot) < 0) 
                {
                    //swaps the current value with the value directly to the right of the wall
                    Swap(ref array[wallIndex + 1], ref array[i]);
                    wallIndex++;
                }
            }
            //swap pivot with wall
            Swap(ref array[wallIndex + 1], ref array[right]);

            return wallIndex + 1;
        }

        static void QuickSortHoare<T>(T[] array)
            where T : IComparable<T>
        {
            QuickSort(array, 0, array.Length - 1);
        }

        static int HoarePartition<T>(T[] array, int leftIndex, int rightIndex)
            where T : IComparable<T>
        {
            int left = leftIndex;
            int right = rightIndex;
            var pivot = array[leftIndex];
            while (rightIndex > leftIndex)
            {
                while (array[leftIndex].CompareTo(pivot) < 0)
                {
                    leftIndex++;
                    if(leftIndex == rightIndex)
                    {
                        rightIndex--;
                        break;
                    }
                }
                while (rightIndex > leftIndex && array[rightIndex].CompareTo(pivot) > 0)
                {
                    rightIndex--;
                }
                if (rightIndex <= leftIndex) break;
                Swap(ref array[leftIndex], ref array[rightIndex]);
            }
            return rightIndex;
        }
        static void Main(string[] args)
        {
            var array = new int[] {7, 1, 9, 2, 5, 4, 3};
            QuickSortHoare(array);
        }
    }
}
