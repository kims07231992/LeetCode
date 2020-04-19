
namespace Find_Words_Can_Be_Formed_by_Characters
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }
        private static void Run()
        {
            var words = new string[] { "cat", "bt", "hat", "tree" };
            var chars = "atach";
            var result = CountCharacters(words, chars);
        }

        /// <summary>
        /// Time Complexity: O(N*M + K) where N is number of words and M is length of word and K is length of chars
        /// Space Complexity: O(1)
        /// </summary>
        private static int CountCharacters(string[] words, string chars)
        {
            var charMap = new int[26];
            for (int i = 0; i < chars.Length; i++)
                charMap[chars[i] - 'a']++;

            var count = 0;
            var temp = new int[26];
            foreach (var word in words)
            {
                charMap.CopyTo(temp, 0);
                var isGood = true;
                for (int i = 0; i < word.Length; i++)
                {
                    if (temp[word[i] - 'a'] > 0)
                    {
                        temp[word[i] - 'a']--;
                    }
                    else
                    {
                        isGood = false;
                        break;
                    }
                }

                if (isGood)
                    count += word.Length;
            }

            return count;
        }
    }
}
