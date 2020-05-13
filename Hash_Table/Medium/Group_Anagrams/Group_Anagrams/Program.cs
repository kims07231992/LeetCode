using System.Collections.Generic;
using System.Text;

namespace Group_Anagrams
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var strs = new string[] { "eat", "tea", "tan", "ate", "nat", "bat" };
            var result = GroupAnagrams(strs);
        }

        /// <summary>
        /// Time Complexity: O(N*L) where N is number of strs and L is length of each str
        /// Space Complexity: O(N)
        /// </summary>
        private static IList<IList<string>> GroupAnagrams(string[] strs)
        {
            var result = new List<IList<string>>();
            var map = new Dictionary<string, List<string>>();
            foreach (var str in strs)
            {
                var bucket = new int[26];
                for (int i = 0; i < str.Length; i++)
                {
                    bucket[str[i] - 'a']++;
                }

                var sb = new StringBuilder();
                for (int i = 0; i < 26; i++)
                {
                    sb.Append($"{bucket[i]}x");
                }

                var key = sb.ToString();
                if (!map.TryAdd(key, new List<string> { str }))
                {
                    map[key].Add(str);
                }
            }

            foreach (var anagrams in map.Values)
            {
                result.Add(anagrams);
            }

            return result;
        }
    }
}
