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
            var visited = new bool[board.Length, board[0].Length];
            for (int m = 0; m < board.Length; m++)
            {
                for (int n = 0; n < board[m].Length; n++)
                {
                    if (ExistRecursive(board, visited, m, n, 0, word))
                        return true;
                }
            }

            return false;
        }

        private static bool ExistRecursive(char[][] board, bool[,] visited, int m, int n, int index, string word)
        {
            if (index == word.Length)
                return true;

            if (m < 0 || m >= board.Length
                || n < 0 || n >= board[m].Length
                || board[m][n] != word[index]
                || visited[m, n])
                return false;

            visited[m, n] = true;

            if (ExistRecursive(board, visited, m - 1, n, index + 1, word)
                || ExistRecursive(board, visited, m, n + 1, index + 1, word)
                || ExistRecursive(board, visited, m + 1, n, index + 1, word)
                || ExistRecursive(board, visited, m, n - 1, index + 1, word))
                return true;

            visited[m, n] = false;
            return false;
        }
    }
}
