using System;

namespace Max_Increase_to_Keep_City_Skyline
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
                new int[] {3, 0, 8, 4 },
                new int[]{ 2, 4, 5, 7 },
                new int[]{ 9, 2, 6, 3 },
                new int[] {0, 3, 1, 0 }
            };

            var result = MaxIncreaseKeepingSkyline(grid);
        }

        /// <summary>
        /// Time Complexity: O(N*M) where N number of rows and M is number of columns
        /// Space Complexity: O(N+M)
        /// </summary>
        private static int MaxIncreaseKeepingSkyline(int[][] grid)
        {
            var rows = new int[grid.Length];
            var cols = new int[grid[0].Length];
            for (int row = 0; row < grid.Length; row++)
            {
                for (int col = 0; col < grid[0].Length; col++)
                {
                    cols[row] = Math.Max(cols[row], grid[row][col]);
                    rows[col] = Math.Max(rows[col], grid[row][col]);
                }
            }

            int result = 0;
            for (int row = 0; row < grid.Length; row++)
            {
                for (int col = 0; col < grid[0].Length; col++)
                {
                    result += Math.Min(rows[col], cols[row]) - grid[row][col];
                }
            }

            return result;
        }
    }
}
