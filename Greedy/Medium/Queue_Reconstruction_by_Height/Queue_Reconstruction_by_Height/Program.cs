using System;
using System.Collections.Generic;

namespace Queue_Reconstruction_by_Height
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var people = new int[][] 
            {
                new int[] { 7, 0 },
                new int[] { 4, 4 },
                new int[] { 7, 1 },
                new int[] { 5, 0 },
                new int[] { 6, 1 },
                new int[] { 5, 2 }
            };

            var result = ReconstructQueue(people);
        }

        /// <summary>
        /// Time Complexity: O(N^2) where N is number of people
        /// Space Complexity: O(N)
        /// </summary>
        private static int[][] ReconstructQueue(int[][] people)
        {
            Array.Sort(people, (x, y) => {
                return x[0] != y[0]
                    ? y[0].CompareTo(x[0])
                    : x[1].CompareTo(y[1]);
            });

            var result = new List<int[]>();
            foreach (var current in people)
            {
                result.Insert(current[1], current);
            }

            return result.ToArray();
        }
    }
}
