using System;

namespace Single_Number
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var nums = new int[] { 4, 1, 2, 1, 2 };
            var result = SingleNumber(nums);
        }

        /// <summary>
        /// Time Complexity: O(logN) where N is length of nums
        /// Space Complexity: O(0)
        /// </summary>
        private static int SingleNumber(int[] nums)
        {
            for (int i = 1; i < nums.Length; i++)
            {
                nums[i] ^= nums[i - 1];
            }

            return nums[nums.Length - 1];
        }
    }
}
