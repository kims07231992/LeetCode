using System;
using System.Collections.Generic;

namespace Treasure_Island_II
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var island = new char[5][];
            island[0] = new char[] { 'S', 'O', 'O', 'S', 'S' };
            island[1] = new char[] { 'D', 'O', 'D', 'O', 'D' };
            island[2] = new char[] { 'O', 'O', 'O', 'O', 'X' };
            island[3] = new char[] { 'X', 'D', 'D', 'O', 'O' };
            island[4] = new char[] { 'X', 'D', 'D', 'D', 'O' };

            var result = TreasureIslandII(island);
        }

        /// <summary>
        /// Time Complexity: O(M * N) where M is length of columns and N is length of rows
        /// Space Complexity: O(M * N)
        /// </summary>
        private static int TreasureIslandII(char[][] island)
        {
            int m = island.Length;
            int n = island[0].Length;
            var queue = new Queue<Tuple<int, int>>();
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (island[i][j] == 'S')
                        queue.Enqueue(new Tuple<int, int>(i, j));
                }
            }

            var steps = 0;
            var directions = new int[][] { new int[] { 0, 1 }, new int[] { 1, 0 }, new int[] { 0, -1 }, new int[] { -1, 0 } };
            while (queue.Count > 0)
            {
                int count = queue.Count;
                for (int c = 0; c < count; c++)
                {
                    var coordinate = queue.Dequeue();
                    foreach (var direction in directions)
                    {
                        int i = coordinate.Item1 + direction[0];
                        int j = coordinate.Item2 + direction[1];
                        if (i < 0
                            || i >= m
                            || j < 0
                            || j >= n
                            || island[i][j] == 'D'
                            || island[i][j] == 'S')
                            continue;

                        if (island[i][j] == 'X')
                            return ++steps;

                        island[i][j] = 'D';
                        queue.Enqueue(new Tuple<int, int>(i, j));
                    }
                }
                steps++;
            }

            return 0;
        }
    }
}
