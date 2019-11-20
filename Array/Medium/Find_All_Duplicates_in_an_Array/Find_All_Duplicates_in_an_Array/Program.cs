using System;
using System.Collections.Generic;

namespace Find_All_Duplicates_in_an_Array
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
            var duplicates = FindDuplicates(nums);
        }

        /// <summary>
        /// Time Complexity: O(N) where N is length of nums
        /// Space Complexity => X
        /// </summary>
        private static IList<int> FindDuplicates(int[] nums)
        {
            var result = new List<int>();

            for (int i = 0; i < nums.Length; ++i)
            {
                int index = Math.Abs(nums[i]) - 1;
                if (nums[index] < 0)
                    result.Add(index + 1);

                nums[index] = -nums[index];
            }

            return result;
        }
    }
}
