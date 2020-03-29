using System;
using System.Collections.Generic;

namespace Numbers_With_Equal_Digit_Sum
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var A = new int[] { 51, 71, 17, 42 };
            var result = Solution(A);
        }

        /// <summary>
        /// Time Complexity: O(N) where N is length of A
        /// Space Complexity: O(N)
        /// </summary>
        private static int Solution(int[] A)
        {
            var result = -1;
            if (A == null || A.Length < 2)
                return result;

            var map = new Dictionary<int, int>();
            foreach (int num in A)
            {
                int sum = 0;
                int temp = num;
                while (temp > 0)
                {
                    sum += temp % 10;
                    temp /= 10;
                }

                if (sum != 0)
                {
                    if (!map.ContainsKey(sum))
                    {
                        map.Add(sum, num);
                    }
                    else
                    {
                        result = Math.Max(result, num + map[sum]);
                        map[sum] = Math.Max(map[sum], num);
                    }
                }
            }

            return result;
        }
    }
}
