using System;
using System.Collections.Generic;

namespace Merge_Intervals
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var intervals = new int[5][];
            intervals[0] = new int[] { 2, 3 };
            intervals[1] = new int[] { 4, 5 };
            intervals[2] = new int[] { 6, 7 };
            intervals[3] = new int[] { 8, 9 };
            intervals[4] = new int[] { 1, 10 };

            var result = Merge(intervals);
        }

        /// <summary>
        /// Time Complexity: O(NlogN) where N is length of given array intervals
        /// Space Complexity: O(1)
        /// </summary>
        private static int[][] Merge(int[][] intervals)
        {
            if (intervals?.Length == 0)
                return intervals;

            var result = new List<int[]>();
            Array.Sort(intervals, (x, y) => { return x[0] < y[0] ? -1 : (x[0] > y[0] ? 1 : 0); });

            var head = intervals[0];
            for (int i = 1; i < intervals.Length; i++)
            {
                var tail = intervals[i];
                if (head[1] >= tail[0])
                {
                    head[1] = Math.Max(head[1], tail[1]);
                }
                else
                {
                    result.Add(head);
                    head = tail;
                }
            }
            result.Add(head); // Add left over element

            return result.ToArray();
        }
    }
}
