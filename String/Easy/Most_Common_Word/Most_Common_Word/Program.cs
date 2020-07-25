using System.Collections.Generic;
using System.Linq;

namespace Most_Common_Word
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var paragraph = "Bob.hIt, baLl";
            var banned = new string[] { "bob", "hit" };
            var result = MostCommonWord(paragraph, banned);
        }

        /// <summary>
        /// Time Complexity: O(N) where N is number of words in paragraph
        /// Space Complexity: O(N)
        /// </summary>
        private static string MostCommonWord(string paragraph, string[] banned)
        {
            var banMap = banned.ToHashSet();
            var words = paragraph
                .ToLower()
                .Replace("!", " ")
                .Replace("?", " ")
                .Replace("'", " ")
                .Replace(",", " ")
                .Replace(";", " ")
                .Replace(".", " ")
                .Trim()
                .Split(" ");

            var wordMap = new Dictionary<string, int>();
            foreach (var word in words)
            {
                if (!banMap.Contains(word))
                {
                    if (!wordMap.TryAdd(word, 1))
                    {
                        wordMap[word]++;
                    }
                }
            }

            var maxCount = 0;
            var maxWord = "";
            foreach (var word in wordMap)
            {
                if (!string.IsNullOrEmpty(word.Key) && word.Value > maxCount)
                {
                    maxWord = word.Key;
                    maxCount = word.Value;
                }
            }

            return maxWord;
        }
    }
}
