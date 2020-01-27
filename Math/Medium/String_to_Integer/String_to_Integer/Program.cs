using System;
using System.Numerics;

namespace String_to_Integer
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var str = "+-2";

            var result = MyAtoi(str);

        }

        /// <summary>
        /// Time Complexity: O(N) where N is length of given string str
        /// Space Complexity: O(1)
        /// </summary>
        private static int MyAtoi(string str)
        {
            if (string.IsNullOrEmpty(str))
                return 0;

            int startIndex = 0;
            int i = 0;
            while (i < str.Length)
            {
                if (str[i] == ' ')
                {
                    i++;
                    continue;
                }
                else if (str[i] == '-' || str[i] == '+')
                {
                    startIndex = i++;
                    break;
                }
                else if (str[i] >= '0' && str[i] <= '9')
                {
                    startIndex = i;
                    break;
                }
                else
                {
                    return 0;
                }
            }

            if (startIndex != i && i >= str.Length)
            {
                return 0;
            }
            else if (str[i] < '0' || str[i] > '9')
            {
                return 0;
            }

            while (i < str.Length && str[i] >= '0' && str[i] <= '9')
            {
                i++;
            }

            var number = BigInteger.Parse(str.Substring(startIndex, i - startIndex));
            if (number > Int32.MaxValue)
                return Int32.MaxValue;
            else if (number < Int32.MinValue)
                return Int32.MinValue;
            else
                return (int)number;
        }
    }
}
