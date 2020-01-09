using System;

namespace Partition_Array_for_Maximum_Sum
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var A = new int[] { 1, 15, 7, 9, 2, 5, 10  };
            var K = 3;

            var result = MaxSumAfterPartitioning(A, K);
        }

        /// <summary>
        /// Time Complexity: O(N * K) where N is length of A and K is size of partition
        /// Space Complexity: O(N)
        /// </summary>
        private static int MaxSumAfterPartitioning(int[] A, int K)
        {
            var n = A.Length;
            var dp = new int[n];
            for (int i = 0; i < n; i++)
            {
                int max = 0;
                for (int k = 1; k <= K && i - k + 1 >= 0; k++)
                {
                    int index = i - k + 1;
                    max = Math.Max(max, A[i - k + 1]);
                    dp[i] = Math.Max(dp[i], (i >= k ? dp[i - k] : 0) + max * k);
                }
            }

            return dp[n - 1];
        }
    }
}
