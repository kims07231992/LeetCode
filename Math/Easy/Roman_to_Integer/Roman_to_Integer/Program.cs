using System.Collections.Generic;

namespace Roman_to_Integer
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var s = "MCMXCIV";
            var result = RomanToInt(s);
        }

        /// <summary>
        /// Time Complexity: O(N) where N is length of given string s
        /// Space Complexity: O(1)
        /// </summary>
        private static int RomanToInt(string s)
        {
            var map = new Dictionary<char, int>
            {
                { 'I', 1 },
                { 'V', 5 },
                { 'X', 10 },
                { 'L', 50 },
                { 'C', 100 },
                { 'D', 500 },
                { 'M', 1000 }
            };

            int sum = 0;
            for (int i = 0; i < s.Length - 1; i++)
            {
                int current = map[s[i]];
                int ahead = map[s[i + 1]];

                if (current >= ahead)
                    sum += current;
                else
                    sum -= current;
            }
            sum += map[s[s.Length - 1]];

            return sum;
        }
    }
}
