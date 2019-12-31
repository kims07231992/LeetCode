using System;
using System.Collections.Generic;
using System.Linq;

namespace Find_and_Replace_Pattern
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var words = new string[] { "abc", "deq", "mee", "aqq", "dkd", "ccc" };
            var pattern = "abb";

            var result = FindAndReplacePattern(words, pattern);
        }

        /// <summary>
        /// Time Complexity: O(N * K) where N is the number of words, and K is the length of each word
        /// Space Complexity: O(N * K) the space used by the answer.
        /// </summary>
        private static IList<string> FindAndReplacePattern(string[] words, string pattern)
        {
            var result = new List<string>();
            var normalizedPattern = NormalizeString(pattern);
            foreach (string word in words)
            {
                if (NormalizeString(word).SequenceEqual(normalizedPattern))
                {
                    result.Add(word);
                }
            }

            return result;
        }

        private static int[] NormalizeString(string word)
        {
            var map = new Dictionary<char, int>();
            var n = word.Length;
            var normalizedString = new int[n];
            for (int i = 0; i < n; i++)
            {
                map.TryAdd(word[i], map.Count);
                normalizedString[i] = map[word[i]];
            }

            return normalizedString;
        }
    }
}
