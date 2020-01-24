using System.Collections.Generic;

namespace Top_K_Frequent_Elements
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static  void Run()
        {
            var nums = new int[] { 1, 1, 1, 2, 2, 3 };
            var k = 2;

            var result = TopKFrequent(nums, k);
        }

        /// <summary>
        /// Time Complexity: O(N) where N is length of given array nums 
        /// Space Complexity: O(N)
        /// </summary>
        private static IList<int> TopKFrequent(int[] nums, int k)
        {
            var result = new List<int>();
            var sortedCountMap = new SortedList<int, List<int>>(new DescendComparer()); // key: count, Value: list of nums
            var countMap = new Dictionary<int, int>(); // Key: num, Value: count
            foreach (int num in nums)
            {
                if (!countMap.TryAdd(num, 1))
                    countMap[num]++;
            }

            foreach (var count in countMap)
            {
                if (!sortedCountMap.TryAdd(count.Value, new List<int> { count.Key }))
                    sortedCountMap[count.Value].Add(count.Key);
            }

            foreach (var count in sortedCountMap)
            {
                foreach (var num in count.Value)
                {
                    result.Add(num);
                    k--;

                    if (k == 0)
                        return result;
                }
            }


            return result;
        }

        private class DescendComparer : IComparer<int>
        {
            public int Compare(int x, int y)
            {
                return y.CompareTo(x);
            }
        }
    }
}
