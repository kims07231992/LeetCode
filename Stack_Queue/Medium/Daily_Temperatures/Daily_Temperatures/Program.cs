using System.Collections.Generic;

namespace Daily_Temperatures
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var T = new int[] { 34, 80, 80, 34, 34, 80, 80, 80, 80, 34 };
            var result = DailyTemperatures(T);
        }

        /// <summary>
        /// Time Complexity: O(N) where N is length of T
        /// Space Complexity: O(N)
        /// </summary>
        public static int[] DailyTemperatures(int[] T)
        {
            var result = new int[T.Length];
            var stack = new Stack<int>();
            for (int i = 0; i < T.Length; i++)
            {
                while (stack.Count != 0 && T[i] > T[stack.Peek()])
                {
                    int index = stack.Pop();
                    result[index] = i - index;
                }
                stack.Push(i);
            }

            return result;
        }
    }
}
