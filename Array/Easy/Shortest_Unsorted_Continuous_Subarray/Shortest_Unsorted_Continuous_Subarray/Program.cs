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
        /// Time Complexity: O(NlogN) where N is number of elements
        /// Space Complexity: O(1)
        /// </summary>
        private static int FindUnsortedSubarray(int[] nums)
        {
            int n = nums.Length;
            var temp = new int[n];
            nums.CopyTo(temp, 0);
            Array.Sort(temp);

            int start = 0;
            while (start < n && nums[start] == temp[start])
                start++;

            int end = n - 1;
            while (end > start && nums[end] == temp[end])
                end--;

            return end - start + 1;
        }
    }
}
