using System;
using System.Collections.Generic;

namespace _3Sum
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var nums = new int[] { -1, 0, 1, 2, -1, -4 };
            var result = ThreeSum(nums);
        }

        /// <summary>
        /// Time Complexity: O(N^2) where N is number of elements in nums
        /// Space Complexity: O(1)
        /// </summary>
        private static IList<IList<int>> ThreeSum(int[] nums)
        {
            var result = new List<IList<int>>();

            Array.Sort(nums);
            for (int i = 0; i < nums.Length - 2; i++)
            {
                if (i == 0 // first element case
                    || nums[i] != nums[i - 1]) // avoid duplicate element case
                {
                    int left = i + 1;
                    int right = nums.Length - 1;
                    int sum = 0 - nums[i];
                    while (left < right)
                    {
                        if (nums[left] + nums[right] == sum)
                        {
                            result.Add(new List<int> { nums[i], nums[left], nums[right] });
                            while (left < right && nums[left] == nums[left + 1]) // avoid duplicate element case
                                left++;

                            while (left < right && nums[right] == nums[right - 1]) // avoid duplicate element case
                                right--;

                            left++;
                            right--;
                        }
                        else if (nums[left] + nums[right] < sum)
                            left++;
                        else
                            right--;
                    }
                }
            }

            return result;
        }
    }
}
