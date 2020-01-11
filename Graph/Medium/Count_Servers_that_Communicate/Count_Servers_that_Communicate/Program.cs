
namespace Count_Servers_that_Communicate
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var grid = new int[3][];
            grid[0] = new int[5] { 1, 0, 0, 1, 0 };
            grid[1] = new int[5] { 0, 0, 0, 0, 0 };
            grid[2] = new int[5] { 0, 0, 0, 1, 0 };

            var result = CountServers(grid);
        }

        /// <summary>
        /// Time Complexity: O(M * N) where M is number of rows and N is number of columns
        /// Space Complexity: O(N * M)
        /// </summary>
        private static int CountServers(int[][] grid)
        {
            int count = 0;
            int row = grid.Length;
            int col = grid[0].Length;
            var rows = new int[row];
            var cols = new int[col];

            for (int m = 0; m < row; m++)
            {
                for (int n = 0; n < col; n++)
                {
                    if (grid[m][n] == 1)
                    {
                        rows[m]++;
                        cols[n]++;
                        count++;
                    }
                }
            }

            for (int m = 0; m < row; m++)
            {
                for (int n = 0; n < col; n++)
                {
                    if (grid[m][n] == 1 && rows[m] == 1 && cols[n] == 1) // server without connection case
                    {
                        count--;
                    }
                }
            }

            return count;
        }
    }
}
