using System.Collections.Generic;

namespace Find_Pair_With_Given_Sum
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var nums = new int[] { 20, 50, 40, 25, 30, 10 };
            var target = 90;
            var result = FindPairWithGivenSum(nums, target);
        }

        /// <summary>
        /// Time Complexity: O(N) where N is number of elements of nums
        /// Space Complexity: O(N)
        /// </summary>
        private static int[] FindPairWithGivenSum(int[] nums, int target)
        {
            if (nums == null)
                return null;

            target -= 30;
            var map = new Dictionary<int, int>(); // Key: num, Value: index
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                int remainder = target - nums[i];
                if (map.ContainsKey(remainder))
                    return new int[] { i, map[remainder] };

                if (!map.ContainsKey(nums[i]))
                    map.Add(nums[i], i);
            }

            return null;
        }
    }
}
