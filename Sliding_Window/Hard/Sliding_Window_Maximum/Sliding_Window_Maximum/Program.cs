using System.Collections.Generic;
using System.Linq;

namespace Sliding_Window_Maximum
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var nums = new int[] { 1, 3, -1, -3, 5, 3, 6, 7 };
            var k = 3;

            var result = MaxSlidingWindow(nums, k);
        }

        /// <summary>
        /// Time Complexity: O(N+K) = O(N) where N is number of elements in nums and K is given k
        /// K is always less than N and the total operations of 2nd dequeue are at most k
        /// Space Complexity: O(K) except the space for result
        /// </summary>
        private static int[] MaxSlidingWindow(int[] nums, int k)
        {
            if (nums == null || k <= 0)
            {
                return new int[0];
            }

            var n = nums.Length;
            var result = new int[n - k + 1];
            var index = 0;
            var queue = new List<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                // remove numbers out of range k
                while (queue.Count > 0 && queue.First() < i - k + 1)
                {
                    queue.RemoveAt(0);
                }

                // remove smaller numbers in k range as they are useless
                while (queue.Count > 0 && nums[queue.Last()] < nums[i])
                {
                    queue.RemoveAt(queue.Count - 1);
                }

                queue.Add(i); // contains index
                if (i >= k - 1) // after the window range is ready
                {
                    // contains first element in the queue which is the greatest value in the range
                    result[index++] = nums[queue.First()];
                }
            }

            return result;
        }
    }
}
