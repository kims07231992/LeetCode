using System.Collections.Generic;

namespace Generate_Parentheses
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var n = 3;
            var result = GenerateParenthesis(n);
        }

        /// <summary>
        /// Time Complexity: O(2 ^ 2N) where N is given n
        /// Space Complexity: O(N)
        /// </summary>
        private static IList<string> GenerateParenthesis(int n)
        {

            var parenthesis = new List<string>();
            RecursiveGenerateParenthesis(n, n, n, string.Empty, parenthesis);

            return parenthesis;
        }

        private static void RecursiveGenerateParenthesis(int n, int leftCount, int rightCount, string s, List<string> parenthesis)
        {
            if (s.Length == n * 2)
            {
                parenthesis.Add(s);
                return;
            }

            if (leftCount > 0)
            {
                RecursiveGenerateParenthesis(n, leftCount - 1, rightCount, s + '(', parenthesis);
            }

            if (leftCount < rightCount)
            {
                RecursiveGenerateParenthesis(n, leftCount, rightCount - 1, s + ')', parenthesis);
            }
        }
    }
}
