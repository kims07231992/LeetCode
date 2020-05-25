using System.Collections.Generic;

namespace Find_N_Unique_Integers_Sum_up_to_Zero
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var nums = new int[] { 1, 1, 1 };
            var k = 2;
            var result = SubarraySum(nums, k);
        }

        /// <summary>
        /// Time Complexity: O(N) where N is length of given array nums
        /// Space Complexity: O(N)
        /// </summary>
        private static int SubarraySum(int[] nums, int k)
        {
            int result = 0;
            int sum = 0;
            var map = new Dictionary<int, int>();
            map.Add(0, 1);

            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
                if (map.ContainsKey(sum - k))
                    result += map[sum - k];

                if (map.ContainsKey(sum))
                    map[sum]++;
                else
                    map.Add(sum, 1);
            }

            return result;
        }
    }
}
