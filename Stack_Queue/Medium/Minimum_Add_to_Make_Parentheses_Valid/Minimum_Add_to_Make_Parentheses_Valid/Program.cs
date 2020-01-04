using System.Collections.Generic;

namespace Minimum_Add_to_Make_Parentheses_Valid
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var S = "())";
            var result = MinAddToMakeValid(S);
        }

        /// <summary>
        /// Time Complexity: O(N) where N is length of S
        /// Space Complexity: O(N)
        /// </summary>
        private static int MinAddToMakeValid(string S)
        {
            if (string.IsNullOrEmpty(S))
                return 0;

            var stack = new Stack<char>();
            foreach (char c in S)
            {
                if (stack.Count != 0 && stack.Peek() == '(' && c == ')')
                {
                    stack.Pop();
                }
                else
                {
                    stack.Push(c);
                }
            }

            return stack.Count;
        }
    }
}
