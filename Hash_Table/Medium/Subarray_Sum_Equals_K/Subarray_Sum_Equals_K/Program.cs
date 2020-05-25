
namespace Subarray_Sum_Equals_K
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var n = 4;
            var result = SumZero(n);
        }

        /// <summary>
        /// Time Complexity: O(N) where N is given integer n
        /// Space Complexity: O(1)
        /// </summary>
        private static int[] SumZero(int n)
        {
            var result = new int[n];
            if (n == 1)
                return result;

            for (int i = 0; i < n - 1; i++)
            {
                result[i] = i;
            }

            result[n - 1] = ((n * n) - (3 * n) + 2) / 2 * -1;

            return result;
        }
    }
}
