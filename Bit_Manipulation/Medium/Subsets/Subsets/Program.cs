using System.Collections.Generic;

namespace Subsets
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        /// <summary>
        /// Time Complexity: O(2^N) where N is size of given array nums
        /// Space Complexity: O(N)
        /// </summary>
        private static void Run()
        {
            var nums = new int[] { 1, 2, 3, 4, 5 };
            var result = Subsets(nums);
        }

        private static IList<IList<int>> Subsets(int[] nums)
        {
            var result = new List<IList<int>>();
            RecursiveSubsets(result, new List<int>(), nums, 0);

            return result;
        }

        private static void RecursiveSubsets(IList<IList<int>> result, List<int> subset, int[] nums, int startIndex)
        {
            result.Add(new List<int>(subset));
            for (int i = startIndex; i < nums.Length; i++)
            {
                subset.Add(nums[i]);
                RecursiveSubsets(result, subset, nums, i + 1);
                subset.RemoveAt(subset.Count - 1);
            }
        }
    }
}
