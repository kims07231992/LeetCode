using System.Collections.Generic;

namespace Valid_Parentheses
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var s = "()[]{}";
            var result = IsValid(s);
        }

        /// <summary>
        /// Time Complexity: O(N) where N is length of given string s
        /// Space Complexity: O(N)
        /// </summary>
        public static bool IsValid(string s)
        {
            if ((s.Length & 1) == 1) // odd case
                return false;

            var stack = new Stack<char>();
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                    stack.Push(')');
                else if (s[i] == '{')
                    stack.Push('}');
                else if (s[i] == '[')
                    stack.Push(']');
                else if (stack.Count == 0 || stack.Pop() != s[i])
                    return false;
            }

            return stack.Count == 0;
        }
    }
}
