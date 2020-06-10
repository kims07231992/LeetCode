
namespace Friend_Circles
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var M = new int[][]
            {
                new int[] { 1, 1, 0 },
                new int[] { 1, 1, 1 },
                new int[] { 0, 1, 1 }
            };
            var result = FindCircleNum(M);
        }

        /// <summary>
        /// Time Complexity: O(N^2) where N is N from N*N grid
        /// Space Complexity: O(N)
        /// </summary>
        private static int FindCircleNum(int[][] M)
        {
            int count = 0;
            var visited = new int[M.Length];
            for (int from = 0; from < M.Length; from++)
            {
                if (visited[from] == 0)
                {
                    Dfs(M, visited, from);
                    count++;
                }
            }
            return count;
        }

        private static void Dfs(int[][] M, int[] visited, int from)
        {
            for (int to = 0; to < M.Length; to++)
            {
                if (M[from][to] == 1 && visited[to] == 0)
                {
                    visited[to] = 1; // Mark as visited
                    Dfs(M, visited, to);
                }
            }
        }
    }
}
