using System.Collections.Generic;

namespace Spiral_Matrix
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
                new int[] { 1, 2, 3 },
                new int[] { 4, 5, 6 },
                new int[] { 7, 8, 9 }
            };
            var result = SpiralOrder(matrix);
        }

        /// <summary>
        /// Time Complexity: O(M*N) where M is number of rows and N is number of columns
        /// Space Complexity: O(1)
        /// </summary>
        private static IList<int> SpiralOrder(int[][] matrix)
        {
            var result = new List<int>();

            if (matrix == null || matrix.Length == 0)
            {
                return result;
            }

            int rowBegin = 0;
            int rowEnd = matrix.Length - 1;
            int colBegin = 0;
            int colEnd = matrix[0].Length - 1;
            while (rowBegin <= rowEnd && colBegin <= colEnd)
            {
                // Traverse Right
                for (int i = colBegin; i <= colEnd; i++)
                {
                    result.Add(matrix[rowBegin][i]);
                }
                rowBegin++;

                // Traverse Down
                for (int i = rowBegin; i <= rowEnd; i++)
                {
                    result.Add(matrix[i][colEnd]);
                }
                colEnd--;

                if (rowBegin <= rowEnd) // to avoid single row case
                {
                    // Traverse Left
                    for (int i = colEnd; i >= colBegin; i--)
                    {
                        result.Add(matrix[rowEnd][i]);
                    }
                }
                rowEnd--;

                if (colBegin <= colEnd) // to avoid single col case
                {
                    // Traver Up
                    for (int i = rowEnd; i >= rowBegin; i--)
                    {
                        result.Add(matrix[i][colBegin]);
                    }
                }
                colBegin++;
            }

            return result;
        }
    }
}
