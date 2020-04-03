using System;

namespace House_Robber
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }
        private static void Run()
        {
            var nums = new int[] { 2, 7, 9, 3, 1 };
            var result = Rob(nums);
        }

        /// <summary>
        /// Time Complexity: O(N) where N is length of nums
        /// Space Complexity: O(N)
        /// </summary>
        private static int Rob(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return 0;
            else if (nums.Length == 1)
                return nums[0];
            else if (nums.Length == 2)
                return Math.Max(nums[0], nums[1]);

            var dp = new int[nums.Length];
            dp[0] = nums[0];
            dp[1] = nums[1];
            dp[2] = nums[0] + nums[2];
            for (int i = 3; i < nums.Length; i++)
            {
                dp[i] = nums[i] + Math.Max(dp[i - 3], dp[i - 2]);
            }

            return Math.Max(dp[nums.Length - 1], dp[nums.Length - 2]);
        }
    }
}
