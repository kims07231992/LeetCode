using System;

namespace Maximum_Subarray
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }
        private static void Run()
        {
            var nums = new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
        }

        /// <summary>
        /// Time Complexity: O(N) where N is length of nums
        /// Space Complexity: O(N)
        /// </summary>
        private static int MaxSubArray(int[] nums)
        {
            if (nums == null || nums.Length < 1)
                return 0;

            var dp = new int[nums.Length];
            dp[0] = nums[0];
            int max = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                dp[i] = Math.Max(nums[i], dp[i - 1] + nums[i]);
                max = Math.Max(max, dp[i]);
            }

            return max;
        }
    }
}
