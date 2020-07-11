using System.Collections.Generic;
using System.Text;

namespace Number_of_Distinct_Islands
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

                new int [] { 0, 0, 1, 0, 1, 0, 1, 1, 1, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 1, 1, 1, 0, 1, 1, 1, 0, 0, 0, 1, 1, 0, 1, 1, 0, 1, 0, 1, 0, 1, 0, 0, 0, 0, 0, 1, 1, 1, 1, 0 },
                new int [] { 0, 0, 1, 0, 0, 1, 1, 1, 0, 0, 1, 0, 1, 0, 0, 1, 1, 0, 0, 1, 0, 0, 0, 1, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 1, 0, 1, 1, 0, 1, 0, 0, 0 },
                new int [] { 0, 1, 0, 1, 0, 1, 1, 1, 0, 0, 1, 1, 0, 0, 0, 0, 1, 0, 1, 0, 1, 1, 1, 0, 1, 1, 1, 0, 0, 0, 1, 0, 1, 0, 1, 0, 0, 0, 1, 1, 1, 1, 1, 0, 0, 1, 0, 0, 1, 0 },
                new int [] { 1, 0, 1, 0, 0, 1, 0, 1, 0, 0, 1, 0, 0, 1, 1, 1, 0, 1, 0, 0, 0, 0, 1, 0, 1, 0, 0, 1, 0, 1, 1, 1, 0, 1, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1 }
            };
            var result = NumDistinctIslands(grid);
        }

        /// <summary>
        /// Time Complexity: O(N*M) where N is number of rows and M is number of columns
        /// Space Complexity: O(N*M)
        /// </summary>
        private static int NumDistinctIslands(int[][] grid)
        {
            var seen = new HashSet<string>();
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        var sb = new StringBuilder();
                        Visit(grid, i, j, sb, "s"); // start
                        seen.Add(sb.ToString());
                    }
                }
            }

            return seen.Count;
        }

        private static void Visit(int[][] grid, int i, int j, StringBuilder sb, string direction)
        {
            if (i < 0 || i >= grid.Length || j < 0 || j >= grid[0].Length
                || grid[i][j] == 0)
                return;

            grid[i][j] = 0; // visited
            sb.Append(direction);
            Visit(grid, i, j + 1, sb, "r"); // right
            Visit(grid, i + 1, j, sb, "b"); // bottom
            Visit(grid, i, j - 1, sb, "l"); // left
            Visit(grid, i - 1, j, sb, "t"); // top
            sb.Append("e"); // end, without end marking, s,rr,b and s,rrb can be treated as same
        }
    }
}
