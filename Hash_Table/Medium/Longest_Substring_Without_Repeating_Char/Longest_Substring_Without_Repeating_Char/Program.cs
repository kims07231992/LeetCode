using System;
using System.Collections.Generic;

namespace Longest_Substring_Without_Repeating_Char
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var s = "pwwkew";
            var result = LengthOfLongestSubstring(s);
        }

        /// <summary>
        /// Time Complexity: O(N) where N is length of s
        /// Space Complexity: O(N)
        /// </summary>
        private static int LengthOfLongestSubstring(string s)
        {
            int i = 0, j = 0, max = 0;
            var seen = new HashSet<char>();

            while (j < s.Length)
            {
                if (!seen.Contains(s[j]))
                {
                    seen.Add(s[j++]);
                    max = Math.Max(max, seen.Count);
                }
                else
                {
                    seen.Remove(s[i++]);
                }
            }

            return max;
        }
    }
}
