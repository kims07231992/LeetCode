using System;

namespace Find_First_and_Last_Position_of_Element
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var nums = new int[] { 5, 7, 7, 8, 8, 10 };
            var target = 8;
            var result = SearchRange(nums, target);
        }

        /// <summary>
        /// Time Complexity: O(logN) where N is length of nums
        /// Space Complexity: O(logN)
        /// </summary>
        private static int[] SearchRange(int[] nums, int target)
        {
            int start = BinarySearchTarget(nums, target);
            if (start == nums.Length || nums[start] != target) // target doesn't exist
            {
                return new int[] { -1, -1 };
            }

            int end = BinarySearchTarget(nums, target + 1) - 1; // search one above
            return new int[] { start, end };
        }

        private static int BinarySearchTarget(int[] nums, int target)
        {
            int left = 0;
            int right = nums.Length;
            while (left < right)
            {
                int middle = (left + right) / 2;
                if (nums[middle] < target)
                {
                    left = middle + 1;
                }
                else
                {
                    right = middle;
                }
            }

            return left;
        }
    }
}
