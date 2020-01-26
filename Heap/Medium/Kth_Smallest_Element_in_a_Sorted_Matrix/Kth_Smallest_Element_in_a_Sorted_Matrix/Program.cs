using System;
using System.Collections.Generic;

namespace Kth_Smallest_Element_in_a_Sorted_Matrix
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var matrix = new int[2][];
            matrix[0] = new int[] { 1, 2 };
            matrix[1] = new int[] { 1, 3 };
            var k = 3;

            var result = KthSmallest(matrix, k);
        }

        /// <summary>
        /// Time Complexity: O(NLogK) where N is length of given length of matrix and K is given number k
        /// Space Complexity: O(N)
        /// </summary>
        public static int KthSmallest(int[][] matrix, int k)
        {
            int min = 0;
            int n = matrix.Length;
            var heap = new Heap();
            for (int i = 0; i < n; i++)
            {
                heap.Insert(new Tuple<int, int, int>(matrix[i][0], i, 0));
            }

            while (k > 0)
            {
                var minTuple = heap.Pop();
                min = minTuple.Item1;
                k--;

                if (minTuple.Item3 + 1 < n)
                    heap.Insert(new Tuple<int, int, int>(matrix[minTuple.Item2][minTuple.Item3 + 1], minTuple.Item2, minTuple.Item3 + 1));
            }

            return min;
        }

        public class Heap
        {
            private List<Tuple<int, int, int>> _elements; // value, m, n

            public Heap()
            {
                _elements = new List<Tuple<int, int, int>> { new Tuple<int, int, int>(0, 0, 0) };
            }

            public bool IsEmpty { get { return _elements.Count == 1; } }

            public void Insert(Tuple<int, int, int> tuple)
            {
                _elements.Add(tuple);

                int currentIndex = _elements.Count - 1;
                while (currentIndex > 1)
                {
                    int parentIndex = currentIndex / 2;
                    if (_elements[currentIndex].Item1 < _elements[parentIndex].Item1)
                    {
                        Swap(currentIndex, parentIndex);
                        currentIndex = parentIndex;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            public Tuple<int, int, int> Pop()
            {
                int parentIndex = 1;
                var value = _elements[parentIndex];
                int lastIndex = _elements.Count - 1;
                _elements[parentIndex] = _elements[lastIndex];
                _elements.RemoveAt(lastIndex);

                while (parentIndex < lastIndex)
                {
                    int leftChildIndex = parentIndex * 2;
                    int rightChildIndex = leftChildIndex + 1;
                    int targetChildIndex = rightChildIndex < lastIndex && _elements[leftChildIndex].Item1 > _elements[rightChildIndex].Item1
                        ? rightChildIndex 
                        : leftChildIndex;

                    if (targetChildIndex < lastIndex && _elements[parentIndex].Item1 > _elements[targetChildIndex].Item1)
                    {
                        Swap(parentIndex, targetChildIndex);
                        parentIndex = targetChildIndex;
                    }
                    else
                    {
                        break;
                    }
                }

                return value;
            }

            private void Swap(int i, int j)
            {
                var temp = _elements[i];
                _elements[i] = _elements[j];
                _elements[j] = temp;
            }
        }
    }
}
