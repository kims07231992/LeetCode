using System;
using System.Collections.Generic;

namespace Find_All_Numbers_Disappeared_in_an_Array
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }
        private static void Run()
        {
            var nums = new int[] { 4, 3, 2, 7, 8, 2, 3, 1 };
            var result = FindDisappearedNumbers(nums);
        }

        /// <summary>
        /// Time Complexity: O(N) where N is length of nums
        /// Space Complexity: O(1)
        /// </summary>
        private static IList<int> FindDisappearedNumbers(int[] nums)
        {
            var result = new List<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                int index = Math.Abs(nums[i]) - 1;
                nums[index] = Math.Min(nums[index], -nums[index]);
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > 0)
                    result.Add(i + 1);
            }

            return result;
        }
    }
}
