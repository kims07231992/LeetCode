
namespace Reorganize_String
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var S = "vvvlo";
            var result = ReorganizeString(S);
        }

        /// <summary>
        /// Time Complexity: O(N) where N is length of given string S
        /// Space Complexity: O(N + 26)
        /// </summary>
        private static string ReorganizeString(string S)
        {
            var hash = new int[26];
            for (int i = 0; i < S.Length; i++)
            {
                hash[S[i] - 'a']++;
            }

            int count = 0;
            int letterIndex = 0;
            for (int i = 0; i < hash.Length; i++)
            {
                if (hash[i] > count)
                {
                    count = hash[i];
                    letterIndex = i;
                }
            }

            if (count > (S.Length + 1) / 2)
                return string.Empty;

            var currentIndex = 0;
            var result = new char[S.Length];
            while (hash[letterIndex] > 0)
            {
                result[currentIndex] = (char)(letterIndex + 'a');
                currentIndex += 2;
                hash[letterIndex]--;
            }

            for (int i = 0; i < hash.Length; i++)
            {
                while (hash[i] > 0)
                {
                    if (currentIndex >= S.Length)
                        currentIndex = 1;

                    result[currentIndex] = (char)(i + 'a');
                    currentIndex += 2;
                    hash[i]--;
                }
            }

            return new string(result);
        }
    }
}
