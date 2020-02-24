using System.Collections.Generic;

namespace Two_Sum_Unique_Pairs
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var nums = new int[] { 1, 1, 2, 45, 46, 46 };
            var target = 47;

            var result = TwoSumUniquePairs(nums, target);
        }

        /// <summary>
        /// Time Complexity: O(N) where N is length of given array nums
        /// Space Complexity: O(N)
        /// </summary>
        private static int TwoSumUniquePairs(int[] nums, int target)
        {
            var set = new HashSet<int>();
            var seen = new HashSet<int>();
            var count = 0;
            foreach (int num in nums)
            {
                int remain = target - num;
                set.Add(num);
                if (set.Contains(remain) && !seen.Contains(num))
                {
                    seen.Add(num);
                    seen.Add(remain);
                    count++;
                }
            }

            return count;
        }
    }
}
