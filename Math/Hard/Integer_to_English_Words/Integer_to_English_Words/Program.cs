
namespace Integer_to_English_Words
{
    internal class Program
    {
        private static string[] LESS_THAN_20 = {"", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen"};
        private static string[] TENS = {"", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety"};
        private static string[] THOUSANDS = {"", "Thousand", "Million", "Billion"};

        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            int num = 20;
            var result = NumberToWords(num);
        }

        /// <summary>
        /// Time Complexity: O(1)
        /// Space Complexity: O(1)
        /// </summary>
        private static string NumberToWords(int num)
        {
            if (num == 0)
                return "Zero";

            string words = "";
            int i = 0;
            while (num > 0)
            {
                if (num % 1000 != 0)
                    words = FourDigitsToWords(num % 1000) + THOUSANDS[i] + " " + words;
                num /= 1000;
                i++;
            }

            return words.Trim();
        }

        private static string FourDigitsToWords(int num)
        {
            if (num == 0)
                return "";
            else if (num < 20)
                return LESS_THAN_20[num] + " ";
            else if (num < 100)
                return TENS[num / 10] + " " + FourDigitsToWords(num % 10);
            else
                return LESS_THAN_20[num / 100] + " Hundred " + FourDigitsToWords(num % 100);
        }
    }
}
