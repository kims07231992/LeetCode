using System.Collections.Generic;

namespace Two_Sum
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var nums = new int[] { 2, 7, 11, 15 };
            var target = 9;

            var result = TwoSum(nums, target);
        }

        /// <summary>
        /// Time Complexity: O(N) where N number of given array nums
        /// Space Complexity: O(N)
        /// </summary>
        private static int[] TwoSum(int[] nums, int target)
        {
            var result = new int[2];
            var map = new Dictionary<int, List<int>>(); // key: num, value: indices
            for (int i = 0; i < nums.Length; i++)
            {
                if (!map.TryAdd(nums[i], new List<int> { i }))
                    map[nums[i]].Add(i);
            }

            foreach (var num in map)
            {
                if (num.Key * 2 == target) // sum by same value case
                {
                    if (num.Value.Count != 2)
                        continue;

                    result[0] = num.Value[0];
                    result[1] = num.Value[1];
                    break;
                }
                else if (map.ContainsKey(target - num.Key))
                {
                    result[0] = num.Value[0];
                    result[1] = map[target - num.Key][0];
                    break;
                }
            }

            return result;
        }
    }
}
