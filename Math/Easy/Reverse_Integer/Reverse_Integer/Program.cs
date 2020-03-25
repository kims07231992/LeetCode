
namespace Reverse_Integer
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var x = -321;
            var result = Reverse(x);
        }

        /// <summary>
        /// Time Complexity: O(N) where N is number of digits
        /// Space Complexity: O(1)
        /// </summary>
        private static int Reverse(int x)
        {
            long result = 0;
            while (x != 0)
            {
                result = result * 10 + x % 10;
                x = x / 10;
                if (result > int.MaxValue || result < int.MinValue)
                    return 0;
            }

            return (int)result;
        }
    }
}
