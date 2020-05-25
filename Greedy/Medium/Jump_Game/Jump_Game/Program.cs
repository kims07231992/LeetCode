using System;

namespace Jump_Game
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var nums = new int[] { 2, 3, 1, 1, 4 };
            var result = CanJump(nums);
        }

        /// <summary>
        /// Time Complexity: O(N) where N is length of nums
        /// Space Complexity: O(1)
        /// </summary>
        private static bool CanJump(int[] nums)
        {
            int endIndex = nums[0];
            for (int i = 0; i <= endIndex; i++)
            {
                endIndex = Math.Max(endIndex, i + nums[i]);
                if (endIndex >= nums.Length - 1)
                    return true;
            }

            return false;
        }
    }
}
