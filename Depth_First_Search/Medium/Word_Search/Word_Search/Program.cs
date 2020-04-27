using System.Collections.Generic;

namespace Word_Search
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var board = new char[3][];
            board[0] = new char[] { 'A', 'B', 'C', 'E' };
            board[1] = new char[] { 'S', 'F', 'C', 'S' };
            board[2] = new char[] { 'A', 'D', 'E', 'E' };
            var word = "ABCCED";

            var result = Exist(board, word);
        }

        /// <summary>
        /// Time Complexity: O(M * N * 3^L) where M is length of row and N is length of column and L is length of given string word
        /// 3^L can be 4^L either but since we skip the 'seen' part, it branches out to 3 different ways except the first case
        /// Space Complexity: O(L)
        /// </summary>
        public static bool Exist(char[][] board, string word)
        {
            for (int m = 0; m < board.Length; m++)
            {
                for (int n = 0; n < board[m].Length; n++)
                {
                    if (ExistRecursive(board, new HashSet<string>(), m, n, 0, word))
                        return true;
                }
            }

            return false;
        }

        private static bool ExistRecursive(char[][] board, HashSet<string> seen, int m, int n, int index, string word)
        {
            if (index == word.Length)
                return true;

            if (seen.Contains($"{m}x{n}") 
                || m < 0 || m >= board.Length
                || n < 0 || n >= board[m].Length 
                || board[m][n] != word[index])
                return false;

            seen.Add($"{m}x{n}");
            return
                ExistRecursive(board, new HashSet<string>(seen), m - 1, n, index + 1, word)
                || ExistRecursive(board, new HashSet<string>(seen), m, n + 1, index + 1, word)
                || ExistRecursive(board, new HashSet<string>(seen), m + 1, n, index + 1, word)
                || ExistRecursive(board, new HashSet<string>(seen), m, n - 1, index + 1, word);
        }
    }
}
