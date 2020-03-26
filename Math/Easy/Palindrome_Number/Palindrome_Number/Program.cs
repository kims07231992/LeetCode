
namespace Palindrome_Number
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var x = 1001;
            var result = IsPalindrome(x);
        }

        /// <summary>
        /// Time Complexity: O(N) where N is number of digits
        /// Space Complexity: O(1)
        /// </summary>
        private static bool IsPalindrome(int x)
        {
            if (x < 0)
                return false;

            int reverse = 0;
            int temp = x;
            while (temp > 0)
            {
                reverse = reverse * 10 + temp % 10;
                temp /= 10;
            }

            return reverse == x;
        }
    }
}
