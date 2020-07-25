using System;
using System.Collections.Generic;

namespace Word_Subsets
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var A = new string[] { "amazon", "apple", "facebook", "google", "leetcode" };
            var B = new string[] { "e", "o" };

            var result = WordSubsets(A, B);
        }

        /// <summary>
        /// Time Complexity: O(N^2) where N is given length of board
        /// Space Complexity: O(N^2) 
        /// </summary>
        private static IList<string> WordSubsets(string[] A, string[] B)
        {
            var result = new List<string>();
            var mapB = new int[26];
            foreach (var word in B)
            {
                var map = CountLetters(word);
                for (int i = 0; i < mapB.Length; i++)
                {
                    mapB[i] = Math.Max(mapB[i], map[i]);
                }
            }

            foreach (var word in A)
            {
                var mapA = CountLetters(word);
                for (int i = 0; i < mapB.Length; i++)
                {
                    if (mapA[i] < mapB[i])
                        break;

                    if (i == mapB.Length - 1) // last
                        result.Add(word);
                }
            }

            return result;
        }

        private static int[] CountLetters(string s)
        {
            var map = new int[26];
            foreach (var ch in s)
            {
                map[ch - 'a']++;
            }

            return map;
        }
    }
}
