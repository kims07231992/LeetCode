using System.Collections.Generic;
using System.Text;

namespace Sort_Characters_By_Frequency
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var s = "tree";
            var result = FrequencySort(s);
        }

        /// <summary>
        /// Time Complexity: O(N) where N is length of given string s
        /// Space Complexity: O(N)
        /// </summary>
        public static string FrequencySort(string s)
        {
            var mapByNum = new Dictionary<char, int>();
            var mapByCount = new List<char>[s.Length + 1];

            foreach (char c in s)
                if (!mapByNum.TryAdd(c, 1))
                    mapByNum[c]++;

            foreach (var num in mapByNum)
                if (mapByCount[num.Value] == null)
                    mapByCount[num.Value] = new List<char> { num.Key };
                else
                    mapByCount[num.Value].Add(num.Key);

            var sb = new StringBuilder();
            for (int i = mapByCount.Length - 1; i >= 0; i--)
            {
                if (mapByCount[i] == null)
                    continue;

                foreach (char c in mapByCount[i])
                    sb.Append(new string(c, i));
            }

            return sb.ToString();
        }
    }
}
