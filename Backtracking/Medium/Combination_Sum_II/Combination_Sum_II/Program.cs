using System;
using System.Collections.Generic;

namespace Combination_Sum_II
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }
        private static void Run()
        {
            var candidates = new int[] { 10, 1, 2, 7, 6, 1, 5 };
            var target = 8;
            var result = CombinationSum2(candidates, target);
        }

        /// <summary>
        /// Time Complexity: O(N^2) where N is length of candidates
        /// Space Complexity: O(N)
        /// </summary>
        private static IList<IList<int>> CombinationSum2(int[] candidates, int target)
        {
            var result = new List<IList<int>>();
            if (candidates == null)
                return null;

            Array.Sort(candidates);
            CombinationSum2(result, new List<int>(), candidates, target, 0, 0, new HashSet<string>(), string.Empty);

            return result;
        }

        private static void CombinationSum2(IList<IList<int>> result,
            List<int> temp, int[] candidates, int target, int sum, int currentIndex, HashSet<string> seen, string s)
        {
            if (sum == target)
            {
                if (!seen.Contains(s))
                {
                    result.Add(temp);
                    seen.Add(s);
                }
                return;
            }

            for (int i = currentIndex; i < candidates.Length; i++)
            {
                int nextSum = sum + candidates[i]; // summation for target 
                if (nextSum <= target)
                {
                    CombinationSum2(result, new List<int>(temp) { candidates[i] }, candidates,
                                    target, nextSum, i + 1, seen, $"{s}x{candidates[i]}");
                }
            }
        }
    }
}
