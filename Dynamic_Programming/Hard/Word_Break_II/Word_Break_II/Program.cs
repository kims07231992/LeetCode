using System.Collections.Generic;

namespace Word_Break_II
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var s = "aaaa";
            var wordDict = new string[] { "a", "aa", "aaa", "aaaa" };

            var result = WordBreak(s, wordDict);
        }

        /// <summary>
        /// Time Complexity: O(2^N) where N is number of words in wordDict
        /// Space Complexity: O(2^N) 
        /// </summary>
        private static IList<string> WordBreak(string s, IList<string> wordDict)
        {
            return Backtracking(s, wordDict, new Dictionary<string, List<string>>());
        }

        private static List<string> Backtracking(string s, IList<string> wordDict, Dictionary<string, List<string>> mem)
        {
            if (mem.ContainsKey(s))
                return mem[s];

            var result = new List<string>();
            foreach (string word in wordDict)
            {
                if (s.StartsWith(word))
                {
                    var next = s.Substring(word.Length);
                    if (next.Length == 0)
                    {
                        result.Add(word);
                    }
                    else
                    {
                        var subWords = Backtracking(next, wordDict, mem);
                        foreach (string sub in subWords)
                        {
                            result.Add($"{word} {sub}");
                        }
                    }
                }
            }
            mem.Add(s, result);

            return result;
        }
    }
}