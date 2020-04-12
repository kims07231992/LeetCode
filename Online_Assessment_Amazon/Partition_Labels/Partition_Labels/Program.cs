using System;
using System.Collections.Generic;

namespace Partition_Labels
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }
        private static void Run()
        {
            var S = "ababcbacadefegdehijhklij";
            var result = PartitionLabels(S);
        }

        /// <summary>
        /// Time Complexity: O(N) where N is length of S
        /// Space Complexity: O(1)
        /// </summary>
        private static IList<int> PartitionLabels(string S)
        {
            if (string.IsNullOrEmpty(S))
                return null;

            var result = new List<int>();
            var map = new int[26]; // mark last index of each letter
            for (int i = 0; i < S.Length; i++)
            {
                map[S[i] - 'a'] = i;
            }

            int last = 0;
            int start = 0;
            for (int i = 0; i < S.Length; i++)
            {
                last = Math.Max(last, map[S[i] - 'a']); // ignore the letters that behind 
                if (last == i) // last letter case
                {
                    result.Add(last - start + 1);
                    start = last + 1;
                }
            }

            return result;
        }
    }
}
