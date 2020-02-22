
namespace Search_a_2D_Matrix_II
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var matrix = new int[,]
            {
                { 1, 4, 7, 11, 15 },
                { 2, 5, 8, 12, 19 },
                { 3, 6, 9, 16, 22 },
                { 10, 13, 14, 17, 24 },
                { 18, 21, 23, 26, 30 }
            };
            var target = 20;

            var result = SearchMatrix(matrix, target);
        }

        /// <summary>
        /// Time Complexity: O(M + N) where M is number of rows and N is number of columns
        /// Space Complexity: O(1)
        /// </summary>
        private static bool SearchMatrix(int[,] matrix, int target)
        {
            if (matrix == null || matrix.Length < 1)
                return false;

            var m = matrix.GetLength(0);
            var n = matrix.Length / m;

            int i = 0;
            int j = n - 1;
            while (i < m && j >= 0)
            {
                int current = matrix[i, j];
                if (current == target)
                    return true;
                else if (current < target)
                    i++;
                else if (current > target)
                    j--;
            }

            return false;
        }
    }
}
