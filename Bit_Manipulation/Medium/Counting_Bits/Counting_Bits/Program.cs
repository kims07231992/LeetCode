
namespace Counting_Bits
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var result = CountBits(16);
        }

        /// <summary>
        /// Time Complexity: O(N) where N is size of given integer num
        /// Space Complexity: O(N)
        /// </summary>
        public static int[] CountBits(int num)
        {
            var counts = new int[num + 1];
            for (int i = 1; i <= num; i++)
            {
                // [i] = [isEven ? i / 2 : i / 2 + 1] + (isEven ? 0 : 1)
                counts[i] = counts[i >> 1] + (i & 1);
            }

            return counts;
        }
    }
}
