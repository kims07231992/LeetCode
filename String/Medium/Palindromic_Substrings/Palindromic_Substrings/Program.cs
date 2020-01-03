
namespace Palindromic_Substrings
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var s = "abccba";
            var result = CountSubstrings(s);
        }


        /// <summary>
        /// Time Complexity: O(N^2) where N is length of s
        /// Space Complexity: O(1)
        /// </summary>
        private static int CountSubstrings(string s)
        {
            if (string.IsNullOrEmpty(s) || s.Length == 0)
                return 0;

            int count = 0;
            for (int i = 0; i < s.Length; i++) // i for middle
            { 
                FindPalindrome(s, i, i, ref count); // odd length case
                FindPalindrome(s, i, i + 1, ref count); // even length case
            }

            return count;
        }

        private static void FindPalindrome(string s, int left, int right, ref int count)
        {
            while ((left >= 0) && (right < s.Length) && (s[left] == s[right]))
            {
                left--;
                right++;
                count++;
            }
        }
    }
}
