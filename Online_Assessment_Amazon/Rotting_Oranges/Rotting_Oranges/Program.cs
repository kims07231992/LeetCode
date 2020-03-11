using System.Collections.Generic;
using System.Linq;

namespace Rotting_Oranges
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var grid = new int[][] {
                new int[] { 2, 1, 1 },
                new int[] { 1, 1, 0 },
                new int[] { 0, 1, 1 }
            };

            var result = OrangesRotting(grid);
        }

        /// <summary>
        /// Time Complexity: O(N * M) where N is number of rows and M is number of columns
        /// Space Complexity: O(N * M)
        /// </summary>
        private static int OrangesRotting(int[][] grid)
        {
            if (grid == null)
                return -1;

            var queue = new Queue<int[]>();
            int fresh = 0;
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == 2)
                        queue.Enqueue(new int[] { i, j });
                    else if (grid[i][j] == 1)
                        fresh++;
                }
            }

            if (fresh == 0)
                return 0;

            int time = -1;
            var directions = new int[][] {
                new int[] { 0, 1 },
                new int[] { 1, 0 },
                new int[] { 0, -1 },
                new int[] { -1, 0 }
            };

            while (queue.Count() > 0)
            {
                int n = queue.Count();
                for (int i = 0; i < n; i++)
                {
                    var orange = queue.Dequeue();
                    int x = orange[0];
                    int y = orange[1];

                    foreach (var dir in directions)
                    {
                        int offsetX = x + dir[0];
                        int offsetY = y + dir[1];
                        if (offsetX >= 0
                            && offsetX < grid.Length
                            && offsetY >= 0
                            && offsetY < grid[offsetX].Length
                            && grid[offsetX][offsetY] == 1)
                        {
                            grid[offsetX][offsetY] = 2;
                            queue.Enqueue(new int[] { offsetX, offsetY });
                            fresh--;
                        }
                    }
                }
                time++;
            }

            return fresh > 0 ? -1 : time;
        }
    }
}
