using System.Collections.Generic;

namespace Permutations
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var nums = new int[] { 1, 2, 3 };
            var result = Permute(nums);
        }

        /// <summary>
        /// Time Complexity: O(N!) where N is length of given array nums
        /// Space Complexity: O(N)
        /// </summary>
        private static IList<IList<int>> Permute(int[] nums)
        {
            var result = new List<IList<int>>();
            PermuteBacktracking(nums, new List<int>(), new HashSet<int>(), result);

            return result;
        }

        private static void PermuteBacktracking(int[] nums, List<int> temp, HashSet<int> map, List<IList<int>> result)
        {
            if (temp.Count == nums.Length)
            {
                result.Add(temp);
                return;
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if (!map.Contains(nums[i]))
                    PermuteBacktracking(nums, new List<int>(temp) { nums[i] }, new HashSet<int>(map) { nums[i] }, result);
            }
        }
    }
}
