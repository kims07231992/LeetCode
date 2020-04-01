using System.Collections.Generic;

namespace Majority_Element
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }
        private static void Run()
        {
            var nums = new int[] { 2, 2, 1, 1, 1, 2, 2 };
            var result = MajorityElement(nums);
        }

        /// <summary>
        /// Time Complexity: O(N) where N is length of nums
        /// Space Complexity: O(N)
        /// </summary>
        private static int MajorityElement(int[] nums)
        {
            var map = new Dictionary<int, int>();
            foreach (int num in nums)
            {
                if (!map.TryAdd(num, 1))
                    map[num]++;

                if (map[num] > nums.Length / 2)
                    return num;
            }

            return -1;
        }
    }
}
