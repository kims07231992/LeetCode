using System;

namespace Best_Time_to_Buy_and_Sell_Stock
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var prices = new int[] { 7, 1, 0, 3, 6, 4, 10 };
            var result = MaxProfit(prices);
        }

        /// <summary>
        /// Time Complexity: O(N) where N is length of given array prices
        /// Space Complexity: O(1)
        /// </summary>
        private static int MaxProfit(int[] prices)
        {
            if (prices?.Length < 2)
                return 0;

            int profit = 0, minPriceSoFar = prices[0];
            for (int i = 1; i < prices.Length; i++)
            {
                profit = Math.Max(prices[i] - minPriceSoFar, profit);
                minPriceSoFar = Math.Min(prices[i], minPriceSoFar);
            }

            return profit;
        }
    }
}
