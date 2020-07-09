using System.Collections.Generic;
using System.Linq;

namespace Word_Break
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var s = "applepenapple";
            var wordDict = new List<string> { "apple", "pen" };
            var result = WordBreak(s, wordDict);
        }

        /// <summary>
        /// Time Complexity: O(N^2 + M) where N is length of s and M is number of elements in wordDict
        /// Space Complexity: O(N + M)
        /// </summary>
        private static bool WordBreak(string s, IList<string> wordDict)
        {
            var dp = new bool[s.Length + 1];
            var wordMap = wordDict.ToHashSet();

            dp[0] = true;
            for (int i = 1; i < dp.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (dp[j] // 0 to j-1 is segmented
                        && wordMap.Contains(s.Substring(j, i - j))) // and j to i can be segmented
                    {
                        dp[i] = true; // then 0 to i can be segmented
                        break;
                    }
                }
            }

            // when last dp is true, since
            // dp[n] means 0 to n can be segmented
            return dp[dp.Length - 1];
        }
    }
}
