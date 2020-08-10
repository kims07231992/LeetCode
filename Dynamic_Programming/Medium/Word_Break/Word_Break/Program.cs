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
            return WordBreak(s, wordDict.ToHashSet());
        }

        private static bool WordBreak(string s, HashSet<string> wordDict)
        {
            int length = s.Length;
            if (length == 0)
            {
                return true;
            }

            for (int i = 1; i <= length; i++)
            {
                if (wordDict.Contains(s.Substring(0, i)) 
                    && WordBreak(s.Substring(i), wordDict))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
