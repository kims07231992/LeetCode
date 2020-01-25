using System;
using System.Collections.Generic;

namespace Kth_Largest_Element_in_an_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var nums = new int[] { 3, 2, 3, 1, 2, 4, 5, 5, 6 };
            var k = 4;

            //var result = FindKthLargest(nums, k);
            var result = FindKthLargestByHeap(nums, k);
        }

        /// <summary>
        /// Time Complexity: O(NLogN) where N is length of given array nums 
        /// Space Complexity: O(1)
        /// </summary>
        private static int FindKthLargestByQuickSort(int[] nums, int k)
        {
            Array.Sort(nums);

            return nums[nums.Length - k];
        }

        /// <summary>
        /// Time Complexity: O(NLogK) where N is length of given array nums and K is given number k
        /// Space Complexity: O(N)
        /// </summary>
        private static int FindKthLargestByHeap(int[] nums, int k)
        {
            var heap = new Heap();
            foreach (int num in nums)
                heap.Insert(num);

            var result = 0;
            for (int i = 0; i < k; i++)
                result = heap.Remove();

            return result;
        }

        public class Heap
        {
            private List<int> _heap;

            public Heap()
            {
                _heap = new List<int>();
                _heap.Add(0);
            }

            public void Insert(int num)
            {
                _heap.Add(num);

                int index = _heap.Count - 1;
                while (index > 1)
                {
                    int parentIndex = index / 2;
                    if (_heap[parentIndex] < _heap[index])
                    {
                        Swap(parentIndex, index);
                        index = parentIndex;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            public int Remove()
            {
                int rootIndex = 1;
                int lastIndex = _heap.Count - 1;
                int max = _heap[rootIndex];
                _heap[rootIndex] = _heap[lastIndex];
                _heap.RemoveAt(lastIndex);
                while (rootIndex < lastIndex)
                {
                    int childIndex = rootIndex * 2;
                    if (childIndex + 1 < lastIndex && _heap[childIndex] < _heap[childIndex + 1])
                    {
                        childIndex++;
                    }

                    if (childIndex < lastIndex && _heap[rootIndex] < _heap[childIndex])
                    {
                        Swap(rootIndex, childIndex);
                        rootIndex = childIndex;
                    }
                    else
                    {
                        break;
                    }
                }

                return max;
            }

            private void Swap(int i, int j)
            {
                var temp = _heap[i];
                _heap[i] = _heap[j];
                _heap[j] = temp;
            }
        }
    }
}
