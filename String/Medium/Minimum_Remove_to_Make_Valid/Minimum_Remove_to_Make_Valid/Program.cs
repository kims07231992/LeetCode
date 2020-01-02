using System.Collections.Generic;
using System.Text;

namespace Minimum_Remove_to_Make_Valid
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var s = "())()(((";
            var result = MinRemoveToMakeValid(s);
        }

        /// <summary>
        /// Time Complexity: O(N) where N is the length of s
        /// Space Complexity: O(N) the space used by the stack.
        /// </summary>
        private static string MinRemoveToMakeValid(string s)
        {
            var sb = new StringBuilder(s);
            var stack = new Stack<int>();
            for (int i = 0; i < sb.Length; ++i)
            {
                if (sb[i] == '(')
                {
                    stack.Push(i);
                }
                else if (sb[i] == ')')
                {
                    if (stack.Count != 0)
                        stack.Pop();
                    else
                        sb[i] = '*';
                }
            }
            while (stack.Count != 0)
                sb[stack.Pop()] = '*';

            return sb.ToString().Replace("*", "");
        }
    }
}
