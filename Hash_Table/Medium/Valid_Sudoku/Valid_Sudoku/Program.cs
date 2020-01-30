using System.Collections.Generic;

namespace Valid_Sudoku
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var board = new char[9][];
            board[0] = new char[] { '5', '3', '.', '.', '7', '.', '.', '.', '.' };
            board[1] = new char[] { '6', '.', '.', '1', '9', '5', '.', '.', '.' };
            board[2] = new char[] { '.', '9', '8', '.', '.', '.', '.', '6', '.' };
            board[3] = new char[] { '8', '.', '.', '.', '6', '.', '.', '.', '3' };
            board[4] = new char[] { '4', '.', '.', '8', '.', '3', '.', '.', '1' };
            board[5] = new char[] { '7', '.', '.', '.', '2', '.', '.', '.', '6' };
            board[6] = new char[] { '.', '6', '.', '.', '.', '.', '2', '8', '.' };
            board[7] = new char[] { '.', '.', '.', '4', '1', '9', '.', '.', '5' };
            board[8] = new char[] { '.', '.', '.', '.', '8', '.', '.', '7', '9' };

            var result = IsValidSudoku(board);
        }

        /// <summary>
        /// Time Complexity: O(N^2) where N is length of given array board
        /// Space Complexity: O(N)
        /// </summary>
        private static bool IsValidSudoku(char[][] board)
        {
            int length = board.Length;
            var map = new HashSet<string>();
            for (int m = 0; m < length; m++)
            {
                for (int n = 0; n < length; n++)
                {
                    char num = board[m][n];
                    if (num != '.')
                    {
                        if (!map.Add($"row {m} {num}") || // check row
                            !map.Add($"col {n} {num}") || // check col
                            !map.Add($"block {m / 3} x {n / 3} {num}")) // check block
                            return false;
                    }
                }
            }

            return true;
        }
    }
}
