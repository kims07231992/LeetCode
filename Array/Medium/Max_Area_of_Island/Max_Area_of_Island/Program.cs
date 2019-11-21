using System;

namespace Max_Area_of_Island
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
                new int[] { 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 },
                new int[] { 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0 },
                new int[] { 0, 1, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0 },
                new int[] { 0, 1, 0, 0, 1, 1, 0, 0, 1, 0, 1, 0, 0 },
                new int[] { 0, 1, 0, 0, 1, 1, 0, 0, 1, 1, 1, 0, 0 },
                new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0 },
                new int[] { 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0 },
                new int[] { 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0 }
            };

            var count = MaxAreaOfIsland(grid);
        }

        public static int MaxAreaOfIsland(int[][] grid)
        {
            int count = 0;

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j <= grid[i].Length; j++)
                {
                    count = Math.Max(count, TraverseRecursive(grid, i, j));
                }
            }

            return count;
        }

        private static int TraverseRecursive(int[][] grid, int i, int j)
        {
            if (i >= 0 && i < grid.Length && j >= 0 && j < grid[0].Length && grid[i][j] == 1)
            {
                grid[i][j] = 0;
                return 1 + TraverseRecursive(grid, i - 1, j) + TraverseRecursive(grid, i, j + 1) + TraverseRecursive(grid, i + 1, j) + TraverseRecursive(grid, i, j - 1);
            }

            return 0;
        }
    }
}
