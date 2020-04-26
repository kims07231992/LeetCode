using System;
using System.Collections.Generic;

namespace Number_of_Equivalent_Domino_Pairs
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var dominoes = new int[][]
            {
                new int[] {1, 2},
                new int[] {2, 1},
                new int[] {3, 4},
                new int[] {5, 6}
            };
            var reuslt = NumEquivDominoPairs(dominoes);
        }

        /// <summary>
        /// Time Complexity: O(N) where N is length of dominoes
        /// Space Complexity: O(N)
        /// </summary>
        private static int NumEquivDominoPairs(int[][] dominoes)
        {

            var count = 0;
            var map = new Dictionary<int, int>();
            for (int i = dominoes.Length - 1; i >= 0; i--)
            {
                int left = Math.Min(dominoes[i][0], dominoes[i][1]);
                int right = Math.Max(dominoes[i][0], dominoes[i][1]);
                int key = left * 10 + right; // 1 * 10 + 2 = 12

                if (map.ContainsKey(key))
                    count += map[key]++;
                else
                    map.Add(key, 1);
            }

            return count;
        }
    }
}
