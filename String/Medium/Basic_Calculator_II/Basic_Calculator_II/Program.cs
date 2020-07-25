using System.Collections.Generic;

namespace Basic_Calculator_II
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var s = "3-2*2";
            var result = Calculate(s);
        }

        /// <summary>
        /// Time Complexity: O(N) where N is length of given s
        /// Space Complexity: O(N) 
        /// </summary>
        private static int Calculate(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
                return 0;

            var num = 0;
            var sign = '+'; // first number is always treated as +
            var stack = new Stack<int>();
            for (int i = 0; i < s.Length; i++)
            {
                if (char.IsDigit(s[i]))
                {
                    num = num * 10 + s[i] - '0';
                }
                if ((!char.IsDigit(s[i]) && s[i] != ' ') // operator case
                    || i == s.Length - 1)
                {
                    if (sign == '-')
                    {
                        stack.Push(-num);
                    }
                    else if (sign == '+')
                    {
                        stack.Push(num);
                    }
                    else if(sign == '*')
                    {
                        stack.Push(stack.Pop() * num);
                    }
                    else if(sign == '/')
                    {
                        stack.Push(stack.Pop() / num);
                    }
                    sign = s[i];
                    num = 0;
                }
            }

            int result = 0;
            while (stack.Count > 0)
            {
                result += stack.Pop();
            }
            return result;
        }
    }
}
