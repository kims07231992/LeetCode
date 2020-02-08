
namespace Number_of_Islands
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var grid = new char[4][];
            grid[0] = new char[] { '1', '1', '1', '1', '0' };
            grid[1] = new char[] { '1', '1', '0', '1', '0' };
            grid[2] = new char[] { '1', '1', '0', '0', '0' };
            grid[3] = new char[] { '0', '0', '0', '0', '0' };

            var result = NumIslands(grid);
        }

        /// <summary>
        /// Time Complexity: O(N*M) where N is length of 1D and M is length of 2D
        /// Space Complexity: O(N*M)
        /// </summary>
        private static int NumIslands(char[][] grid)
        {
            int count = 0;
            for (int n = 0; n < grid.Length; n++)
            {
                for (int m = 0; m < grid[n].Length; m++)
                {
                    if (grid[n][m] == '1')
                    {
                        Visit(grid, n, m);
                        count++;
                    }
                }
            }

            return count;
        }

        private static void Visit(char[][] grid, int n, int m)
        {
            if (n >= grid.Length
                || n < 0
                || m >= grid[n].Length
                || m < 0
                || grid[n][m] == '0')
                return;

            grid[n][m] = '0'; // mark as visit

            Visit(grid, n, m + 1);
            Visit(grid, n + 1, m);
            Visit(grid, n, m - 1);
            Visit(grid, n - 1, m);
        }
    }
}
