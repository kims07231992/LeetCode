
namespace Longest_Palindromic_Substring
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var s = "babad";

            var result = LongestPalindrome(s);
        }

        /// <summary>
        /// Time Complexity: O(N^2) where N is length of given string s
        /// Space Complexity: O(1)
        /// </summary>
        private static string LongestPalindrome(string s)
        {
            int startIndex = 0, length = 0;
            for (int i = 0; i < s.Length; i++) // i is used as middle char
            {
                RecursiveLongestPalindrome(s, i, i, ref startIndex, ref length); // odd case
                RecursiveLongestPalindrome(s, i, i + 1, ref startIndex, ref length); // even case
            }

            return s.Substring(startIndex, length);
        }

        private static void RecursiveLongestPalindrome(string s, int left, int right, ref int startIndex, ref int length)
        {
            while (left >= 0 && right < s.Length && s[left] == s[right])
            {
                left--;
                right++;
            }

            if (length < right - left - 1)
            {
                startIndex = left + 1;
                length = right - left - 1;
            }
        }
    }
}
