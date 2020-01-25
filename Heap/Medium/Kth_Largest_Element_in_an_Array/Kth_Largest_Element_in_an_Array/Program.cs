using System;

namespace Kth_Largest_Element_in_an_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var nums = new int[] { 3, 2, 3, 1, 2, 4, 5, 5, 6 };
            var k = 4;

            var result = FindKthLargest(nums, k);
        }

        /// <summary>
        /// Time Complexity: O(NLogN) where N is length of given array nums 
        /// Space Complexity: O(1)
        /// </summary>
        private static int FindKthLargest(int[] nums, int k)
        {
            Array.Sort(nums);

            return nums[nums.Length - k];
        }
    }
}
