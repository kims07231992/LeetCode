
namespace Min_Moves_3_Consecutive_Letters
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var s = "aaaaaabbbbbaaaaaabbbbbbbbb";
            var result = Solution(s);
        }

        /// <summary>
        /// Time Complexity: O(N) where N is length of s
        /// Space Complexity: O(N)
        /// </summary>
        private static int Solution(string s)
        {
            if (string.IsNullOrEmpty(s) || s.Length < 3)
                return 0;

            int count = 0;
            var letters = s.ToCharArray();
            for (int i = 1; i < letters.Length - 1; i++)
            {
                if (letters[i - 1] == letters[i] && letters[i] == letters[i + 1])
                {
                    if (i + 2 < s.Length && s[i + 2] == letters[i + 1]) // more than 3 consecutive case
                        letters[i + 1] = letters[i + 1] == 'a' ? 'b' : 'a'; // change 3rd letter
                    else // 3 consecutive case
                        letters[i] = letters[i] == 'a' ? 'b' : 'a'; // change 2nd letter

                    count++;
                }
            }

            return count;
        }
    }
}
