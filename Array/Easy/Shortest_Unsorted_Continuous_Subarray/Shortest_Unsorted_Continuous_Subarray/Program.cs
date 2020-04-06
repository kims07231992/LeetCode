using System;

namespace Shortest_Unsorted_Continuous_Subarray
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }
        private static void Run()
        {
            var nums = new int[] { 2, 6, 4, 8, 10, 9, 15 };
            var result = FindUnsortedSubarray(nums);
        }

        /// <summary>
        /// Time Complexity: O(N) where N is number of elements
        /// Space Complexity: O(1)
        /// </summary>
        private static int FindUnsortedSubarray(int[] nums)
        {
            int n = nums.Length;
            int start = -1;
            int end = -2;
            int min = nums[n - 1];
            int max = nums[0];
            for (int i = 1; i < n; i++)
            {
                max = Math.Max(max, nums[i]);
                min = Math.Min(min, nums[n - 1 - i]);
                if (nums[i] < max)
                    end = i;
                if (nums[n - 1 - i] > min)
                    start = n - 1 - i;
            }

            return end - start + 1;
        }
    }
}
