namespace Remove_K_Digits
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var num = "1432219";
            var k = 3;
            var result = RemoveKdigits(num, k);
        }

        /// <summary>
        /// Time Complexity: O(N) where N is length of given string num
        /// Space Complexity: O(N)
        /// </summary>
        private static string RemoveKdigits(string num, int k)
        {
            var outputCount = num.Length - k;
            var stack = new char[num.Length];
            var topIndex = 0;
            for (int i = 0; i < num.Length; ++i)
            {
                char c = num[i];
                while (topIndex > 0 // not empty
                    && stack[topIndex - 1] > c  // peek > c
                    && k > 0) // can remove digit
                {
                    topIndex--;
                    k--;
                }
                stack[topIndex++] = c;
            }

            // Count 0 prefix
            int zeroCount = 0;
            while (zeroCount < outputCount && stack[zeroCount] == '0')
                zeroCount++;

            return zeroCount == outputCount 
                ? "0" 
                : new string(stack, zeroCount, outputCount - zeroCount); // from non-zero
        }
    }
}
