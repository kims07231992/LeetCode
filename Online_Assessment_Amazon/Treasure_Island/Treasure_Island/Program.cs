using System;
using System.Collections.Generic;

namespace Treasure_Island
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var island = new char[4][];
            island[0] = new char[] { 'O', 'O', 'O', 'O' };
            island[1] = new char[] { 'D', 'O', 'D', 'O' };
            island[2] = new char[] { 'O', 'O', 'O', 'O' };
            island[3] = new char[] { 'O', 'D', 'D', 'X' };

            var result = TreasureIsland(island);
        }

        /// <summary>
        /// Time Complexity: O(M * N) where M is length of columns and N is length of rows
        /// Space Complexity: O(M * N)
        /// </summary>
        private static int TreasureIsland(char[][] island)
        {
            int steps = 0;
            var queue = new Queue<Tuple<int, int>>();
            queue.Enqueue(new Tuple<int, int>(0, 0));
            while (queue.Count > 0)
            {
                int count = queue.Count;
                for (int i = 0; i < count; i++)
                {
                    var coorinate = queue.Dequeue();
                    int m = coorinate.Item1;
                    int n = coorinate.Item2;
                    if (TraverseTreasureIsland(queue, island, m, n + 1) || TraverseTreasureIsland(queue, island, m + 1, n)
                        || TraverseTreasureIsland(queue, island, m, n - 1) || TraverseTreasureIsland(queue, island, m - 1, n))
                        return ++steps;
                }
                steps++;
            }
                
             return 0;
        }

        private static bool TraverseTreasureIsland(Queue<Tuple<int, int>> queue, char[][] island, int m, int n)
        {
            if (m < 0 || m >= island.Length || n < 0 || n >= island[m].Length || island[m][n] == 'D')
                return false;

            if (island[m][n] == 'X')
                return true;

            queue.Enqueue(new Tuple<int, int>(m, n));
            island[m][n] = 'D';

            return false;
        }
    }
}
