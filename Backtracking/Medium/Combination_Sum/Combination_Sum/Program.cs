using System.Collections.Generic;

namespace Combination_Sum
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var candidates = new int[] { 2, 3, 6, 7 };
            var target = 7;

            var result = CombinationSum(candidates, target);
        }

        /// <summary>
        /// Time Complexity: O(N^T) where N is length of given array candidates and T ig given integer target
        /// Space Complexity: O(T) where T is given integer target
        /// </summary>
        private static IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            var result = new List<IList<int>>();
            CombinationSumBacktracking(candidates, target, 0, 0, new List<int>(), result);

            return result;
        }

        private static void CombinationSumBacktracking(int[] candidates, 
            int target, int sum, int startIndex, List<int> temp, List<IList<int>> result)
        {
            if (sum == target)
            {
                result.Add(temp);
                return;
            }

            for (int i = startIndex; i < candidates.Length; i++)
            {
                int nextSum = sum + candidates[i]; // summation for target 
                if (nextSum <= target)
                {
                    CombinationSumBacktracking(candidates,
                        target, nextSum, i, new List<int>(temp) { candidates[i] }, result);
                }
            }
        }
    }
}
