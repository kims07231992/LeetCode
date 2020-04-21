using System;

namespace Reverse_String_II
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var s = "abcdefg";
            var k = 2;
            var result = ReverseStr(s, k);
        }

        /// <summary>
        /// Time Complexity: O(N) where N is length of s
        /// Space Complexity: O(N)
        /// </summary>
        private static string ReverseStr(string s, int k)
        {
            var word = s.ToCharArray();
            var n = word.Length;
            for (int i = 0; i < n; i += 2 * k)
            {
                int left = i;
                int right = Math.Min(i + k - 1, n - 1); // first k characters and left the other as original
                while (left < right) // swap
                {
                    char temp = word[left];
                    word[left++] = word[right];
                    word[right--] = temp;
                }
            }

            return new string(word);
        }
    }
}
