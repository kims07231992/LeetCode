using System.Collections.Generic;

namespace Shortest_Path_in_Binary_Matrix
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var grid = new int[][]
            {
                new int[] { 0, 0, 0 },
                new int[] { 1, 1, 0 },
                new int[] { 1, 1, 0 }
            };
        }

        /// <summary>
        /// Time Complexity: O(N) where N is number of elements in grid
        /// Space Complexity: O(N)
        /// </summary>
        private static int ShortestPathBinaryMatrix(int[][] grid)
        {
            if (grid == null
                || grid[0][0] == 1
                || grid[grid.Length - 1][grid.Length - 1] == 1)
                return -1;

            var directions = new List<int[]>
            {
                new int[] { -1, 0 }, new int[] { -1, 1 }, new int[] { 0, 1 }, new int[] { 1, 1 },
                new int[] { 1, 0 }, new int[] { 1, -1 }, new int[] { 0, -1 }, new int[] { -1, -1 },
            };
            var queue = new Queue<int[]>();
            queue.Enqueue(new int[] { 0, 0 });
            grid[0][0] = 1; // mark as visited

            int path = -1;
            while (queue.Count > 0)
            {
                path++;
                var count = queue.Count;
                for (int i = 0; i < count; i++)
                {
                    var coordinate = queue.Dequeue();
                    var row = coordinate[0];
                    var col = coordinate[1];

                    if (row == grid.Length - 1 && col == grid.Length - 1)
                        return ++path;
                
                    foreach (var direction in directions)
                    {
                        var nextRow = row + direction[0];
                        var nextCol = col + direction[1];
                        if (nextRow < 0 || nextRow >= grid.Length || nextCol < 0 || nextCol >= grid.Length || grid[nextRow][nextCol] == 1)
                            continue;

                        queue.Enqueue(new int[] { nextRow, nextCol });
                        grid[nextRow][nextCol] = 1; // mark as visited
                    }
                }
            }

            return -1;
        }
    }
}
