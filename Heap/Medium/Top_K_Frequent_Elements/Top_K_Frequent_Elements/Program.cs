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
            var countMap = new Dictionary<int, int>(); // Key: num, Value: count
            var bucket = new List<int>[nums.Length + 1];
            foreach (int num in nums)
            {
                if (!countMap.TryAdd(num, 1))
                    countMap[num]++;
            }

            foreach (var count in countMap)
            {
                if (bucket[count.Value] == null)
                    bucket[count.Value] = new List<int>();

                bucket[count.Value].Add(count.Key);
            }

            for (int i = nums.Length; i >= 0; i--)
            {
                if (bucket[i] == null)
                    continue;

                for (int j = 0; j < bucket[i].Count; j++)
                {
                    result.Add(bucket[i][j]);
                    k--;

                    if (k == 0)
                        return result;
                }
            }

            return result;
        }
    }
}
