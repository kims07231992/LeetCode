
namespace Integer_to_Roman
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var num = 9;
            var result = IntToRoman(num);
        }

        /// <summary>
        /// Time Complexity: O(1)
        /// Space Complexity: O(1)
        /// </summary>
        private static string IntToRoman(int num)
        {
            var M = new string[] { "", "M", "MM", "MMM" }; // 0, 1000, 2000, 3000
            var C = new string[] { "", "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM" }; // 0, 100, 200, 300, 400, 500, 600, 700, 800, 900
            var X = new string[] { "", "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC" }; // 0, 10, 20, 30, 40, 50, 60, 70, 80, 90
            var I = new string[] { "", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX" }; // 0, 1, 2, 3, 4, 5, 6, 7, 8, 9

            return M[num / 1000] + C[(num % 1000) / 100] + X[(num % 100) / 10] + I[num % 10];
        }
    }
}
