
namespace Toeplitz_Matrix
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }
        private static void Run()
        {
            var matrix = new int[][]
            {
                new int[] {1, 2, 3, 4},
                new int[] {5, 1, 2, 3},
                new int[] {9, 5, 1, 2}
            };
            var result = IsToeplitzMatrix(matrix);
        }

        /// <summary>
        /// Time Complexity: O(M*N) where M is length of row and N is length of column
        /// Space Complexity: O(1)
        /// </summary>
        private static bool IsToeplitzMatrix(int[][] matrix)
        {
            int m = matrix.Length; // col
            int n = matrix[0].Length; // row
            for (int i = 0; i < m - 1; i++)
            {
                for (int j = 0; j < n - 1; j++)
                {
                    if (matrix[i][j] != matrix[i + 1][j + 1])
                        return false;
                }
            }

            return true;
        }
    }
}
