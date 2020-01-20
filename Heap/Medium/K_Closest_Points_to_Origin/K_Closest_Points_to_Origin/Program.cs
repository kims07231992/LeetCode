using System;
using System.Collections.Generic;

namespace K_Closest_Points_to_Origin
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var K = 5;
            var points = new int[10][];
            points[0] = new int[] { 68, 97 };
            points[1] = new int[] { 34, -84 };
            points[2] = new int[] { 60, 100 };
            points[3] = new int[] { 2, 31 };
            points[4] = new int[] { -27, -38 };
            points[5] = new int[] { -73, -74 };
            points[6] = new int[] { -55, -39 };
            points[7] = new int[] { 62, 91 };
            points[8] = new int[] { 62, 92 };
            points[9] = new int[] { -57, -67 };

            var result = KClosest(points, K);
        }

        /// <summary>
        /// Time Complexity: O(NlogK) where N is size of given integer num and K is given integer K
        /// Space Complexity: O(N)
        /// </summary>
        private static int[][] KClosest(int[][] points, int K)
        {
            var heap = new Heap();
            foreach (var point in points)
                heap.Insert(point);

            var result = new int[K][];
            for (int i = 0; i < K; i++)
                result[i] = heap.Remove();

            return result;
        }

        public class Heap
        {
            private List<Tuple<int, int[]>> _heap;

            public Heap()
            {
                _heap = new List<Tuple<int, int[]>>();
                _heap.Add(new Tuple<int, int[]>(0, new int[2]));
            }

            public void Insert(int[] point)
            {
                int key = (int)Math.Pow(point[0], 2) + (int)Math.Pow(point[1], 2);
                int[] value = point;

                _heap.Add(new Tuple<int, int[]>(key, value));

                int index = _heap.Count - 1;
                while (index > 1)
                {
                    int parentIndex = index / 2;
                    if (_heap[parentIndex].Item1 > _heap[index].Item1)
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
            public int[] Remove()
            {
                int rootIndex = 1;
                int lastIndex = _heap.Count - 1;
                int[] max = _heap[rootIndex].Item2;
                _heap[rootIndex] = _heap[lastIndex];
                _heap.RemoveAt(lastIndex);
                while (rootIndex < lastIndex)
                {
                    int childIndex = rootIndex * 2;
                    if (childIndex + 1 < lastIndex && _heap[childIndex].Item1 > _heap[childIndex + 1].Item1)
                    {
                        childIndex++;
                    }
                    
                    if (childIndex < lastIndex && _heap[rootIndex].Item1 > _heap[childIndex].Item1)
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
