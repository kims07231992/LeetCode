using System.Collections.Generic;

namespace Letter_Combinations_of_a_Phone_Number
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var digits = "23";
            var result = LetterCombinations(digits);
        }

        /// <summary>
        /// Time Complexity: O(K^N) where K is number of letters per digit and N is number of digits
        /// Space Complexity: O(K^N)
        /// </summary>
        private static IList<string> LetterCombinations(string digits)
        {
            var result = new List<string>();
            if (string.IsNullOrEmpty(digits))
                return result;

            var map = new Dictionary<char, string>()
            {
                { '2', "abc" }, { '3', "def" },
                { '4', "ghi" }, { '5', "jkl" }, { '6', "mno" },
                { '7', "pqrs" }, { '8', "tuv" }, { '9', "wxyz" }
            };
            LetterCombinations(map, result, digits, string.Empty, 0);

            return result;
        }

        private  static void LetterCombinations(Dictionary<char, string> map,
                         IList<string> result, string digits, string word, int index)
        {
            if (word.Length == digits.Length)
            {
                result.Add(word);
                return;
            }

            char digit = digits[index];
            var letters = map[digit];
            foreach (var letter in letters)
            {
                LetterCombinations(map, result, digits, word + letter, index + 1);
            }
        }
    }
}
