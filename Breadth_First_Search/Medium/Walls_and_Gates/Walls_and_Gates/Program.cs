using System;
using System.Collections.Generic;

namespace Walls_and_Gates
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var rooms = new int[][]
            {
                new int[] { int.MaxValue, -1, 0, int.MaxValue },
                new int[] { int.MaxValue, int.MaxValue, int.MaxValue, -1 },
                new int[] { int.MaxValue, -1, int.MaxValue, -1 },
                new int[] { 0, -1, int.MaxValue, int.MaxValue },
            };
            WallsAndGates(rooms);
        }

        /// <summary>
        /// Time Complexity: O(M * N)
        /// Space Complexity: O(M * N)
        /// </summary>
        private static void WallsAndGates(int[][] rooms)
        {
            if (rooms == null)
                return;

            var directions = new int[][]
            {
                new int[] { 0, 1 },
                new int[] { 1, 0 },
                new int[] { 0, -1 },
                new int[] { -1, 0 }
            };
            var queue = new Queue<int[]>();
            for (int m = 0; m < rooms.Length; m++)
            {
                for (int n = 0; n < rooms[m].Length; n++)
                {
                    if (rooms[m][n] == 0)
                        queue.Enqueue(new int[] { m, n });
                }
            }

            while (queue.Count > 0)
            {
                var coordinate = queue.Dequeue();
                var distance = rooms[coordinate[0]][coordinate[1]] + 1;
                foreach (var direction in directions)
                {
                    int m = coordinate[0] + direction[0];
                    int n = coordinate[1] + direction[1];
                    if (m < 0 || m >= rooms.Length || n < 0 || n >= rooms[m].Length || rooms[m][n] == -1 || rooms[m][n] == 0)
                        continue;

                    if (rooms[m][n] == int.MaxValue || rooms[m][n] > distance)
                    {
                        rooms[m][n] = distance;
                        queue.Enqueue(new int[] { m, n });
                    }
                    else
                    {
                        continue;
                    }
                }
            }
        }
    }
}
