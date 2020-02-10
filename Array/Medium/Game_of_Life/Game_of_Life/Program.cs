using System;
using System.Collections.Generic;

namespace Game_of_Life
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var board = new int[4][];
            board[0] = new int[] { 0, 1, 0 };
            board[1] = new int[] { 0, 0, 1 };
            board[2] = new int[] { 1, 1, 1 };
            board[3] = new int[] { 0, 0, 0 };

            GameOfLife(board);
        }

        /// <summary>
        /// Time Complexity: O(M*N) where M is length of 1D and N is length of 2D
        /// Space Complexity: O(1)
        /// </summary>
        private static void GameOfLife(int[][] board)
        {
            var directions = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(-1, 1),
                new Tuple<int, int>(0, 1),
                new Tuple<int, int>(1, 1),
                new Tuple<int, int>(1, 0),
                new Tuple<int, int>(1, -1),
                new Tuple<int, int>(0, -1),
                new Tuple<int, int>(-1, -1),
                new Tuple<int, int>(-1, 0),
            };
            for (int m = 0; m < board.Length; m++)
            {
                for (int n = 0; n < board[m].Length; n++)
                {
                    int count = 0;
                    directions.ForEach(x =>
                    {
                        int neighborM = m + x.Item1;
                        int neighborN = n + x.Item2;
                        if (!(neighborM < 0 || neighborM >= board.Length || neighborN < 0 || neighborN >= board[m].Length) // not out of range
                            && (board[neighborM][neighborN] == 1 || board[neighborM][neighborN] == 3)) // currently live
                            count++;
                    });

                    if (board[m][n] == 0 && count == 3)
                        board[m][n] = 2; // 0010 -> 0000 : death -> live
                    else if (board[m][n] == 1 && (count == 2 || count == 3))
                        board[m][n] = 3; // 0011 -> 0000 : live -> live
                }
            }

            // 0000 -> 0000 : death -> death
            // 0001 -> 0000 : live -> death
            // 0010 -> 0000 : death -> live
            // 0011 -> 0000 : live -> live
            for (int m = 0; m < board.Length; m++)
                for (int n = 0; n < board[m].Length; n++)
                    board[m][n] = board[m][n] >> 1;
        }
    }
}
