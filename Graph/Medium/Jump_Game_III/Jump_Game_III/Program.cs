using System.Collections.Generic;

namespace Jump_Game_III
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var arr = new int[] { 4, 2, 3, 0, 3, 1, 2 };
            var start = 5;

            var result = CanReachByRecursive(arr, start);
            //var result = CanReachByStack(arr, start);
        }

        /// <summary>
        /// Time Complexity: O(N) where N is length of given array
        /// Space Complexity: O(N)
        /// </summary>
        private static bool CanReachByStack(int[] arr, int start)
        {
            var stack = new Stack<int>();
            stack.Push(start);

            while (stack.Count != 0)
            {
                var i = stack.Pop();
                if (arr[i] == 0)
                    return true;

                var jump = arr[i];
                arr[i] = arr.Length; // marking as visited
                var left = i - jump;
                if (left >= 0 && arr[left] != arr.Length)
                {
                    stack.Push(left);
                }

                var right = i + jump;
                if (right < arr.Length && arr[right] != arr.Length)
                {
                    stack.Push(right);
                }
            }

            return false;
        }

        /// <summary>
        /// Time Complexity: O(N) where N is length of given array
        /// Space Complexity: O(N)
        /// </summary>
        private static bool CanReachByRecursive(int[] arr, int start)
        {
            if (start >= 0 && start < arr.Length && arr[start] != arr.Length)
            {
                int jump = arr[start];
                arr[start] = arr.Length; // marking as visited
                return jump == 0 || CanReachByRecursive(arr, start + jump) || CanReachByRecursive(arr, start - jump);
            }

            return false;
        }
    }
}
