using System.Text;

namespace Custom_Sort_String
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var S = "cba";
            var T = "abcd";
            var result = CustomSortString(S, T);
        }

        /// <summary>
        /// Time Complexity: O(S + T) where S is length of S and T is length of T
        /// Space Complexity: O(K) where K is 26
        /// </summary>
        public static string CustomSortString(string S, string T)
        {
            int[] count = new int[26];
            foreach (char c in T) // count each char in T.
            {
                ++count[c - 'a'];
            } 

            var sb = new StringBuilder();
            foreach (char c in S)
            {
                while (count[c - 'a']-- > 0) // sort chars both in T and S by the order of S.
                {
                    sb.Append(c);
                } 
            }

            // group chars in T but not in S.
            for (char c = 'a'; c <= 'z'; ++c)
            {
                while (count[c - 'a']-- > 0)
                {
                    sb.Append(c);
                } 
            }

            return sb.ToString();
        }
    }
}
