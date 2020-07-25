using System;

namespace Maximum_Points_You_Can_Obtain
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var cardPoints = new int[] { 1, 79, 80, 1, 1, 1, 200, 1 };
            var k = 3;

            var result = MaxScore(cardPoints, k);
        }

        /// <summary>
        /// Time Complexity: O(K) where K is given k
        /// Space Complexity: O(1)
        /// </summary>
        private static int MaxScore(int[] cardPoints, int k)
        {
            int max = 0;
            int sum = 0;
            for (int i = 0; i < k; i++)
            {
                sum += cardPoints[i];
            }

            max = sum;
            for (int i = cardPoints.Length - 1; i >= cardPoints.Length - k; i--)
            {
                sum += cardPoints[i];
                sum -= cardPoints[(i + k) % cardPoints.Length];
                max = Math.Max(max, sum);
            }

            return max;
        }
    }
}
