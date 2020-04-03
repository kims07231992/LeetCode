
namespace Climbing_Stairs
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }
        private static void Run()
        {
            var n = 5;
            var result = ClimbStairs(n);
        }

        /// <summary>
        /// Time Complexity: O(N) where N is length of nums
        /// Space Complexity: O(N)
        /// </summary>
        private static int ClimbStairs(int n)
        {
            if (n < 2)
                return n;

            var dp = new int[n];
            dp[0] = 1;
            dp[1] = 2;
            for (int i = 2; i < n; i++)
            {
                dp[i] = dp[i - 2] + dp[i - 1];
            }

            return dp[n - 1];
        }
    }
}
