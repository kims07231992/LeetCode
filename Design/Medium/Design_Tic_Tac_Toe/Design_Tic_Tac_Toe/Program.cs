using System;

namespace Design_Tic_Tac_Toe
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var size = 3;
            var ticTacToe = new TicTacToe(size);
            ticTacToe.Move(0, 0, 2); // return 0
            ticTacToe.Move(2, 0, 2); // return 0
            ticTacToe.Move(1, 0, 2); // return 2
        }
    }

    public class TicTacToe
    {
        private int[] _vertical;
        private int[] _horizontal;
        private int _diagonal;
        private int _antiDiagonal;
        private int _n;

        public TicTacToe(int n)
        {
            _n = n;
            _vertical = new int[_n];
            _horizontal = new int[_n];
        }

        /** Player {player} makes a move at ({row}, {col}).
            @param row The row of the board.
            @param col The column of the board.
            @param player The player, can be either 1 or 2.
            @return The current winning condition, can be either:
                    0: No one wins.
                    1: Player 1 wins.
                    2: Player 2 wins. */
        public int Move(int row, int col, int player)
        {
            int add = player == 1 ? 1 : -1;

            _vertical[row] += add; // vertical

            _horizontal[col] += add; // horizontal

            if (row == col) // diagonal
                _diagonal += add;

            if (row + col == _n - 1) // anti-diagonal
                _antiDiagonal += add;

            return (Math.Abs(_vertical[row]) == _n)
                || (Math.Abs(_horizontal[col]) == _n)
                || (Math.Abs(_diagonal) == _n)
                || (Math.Abs(_antiDiagonal) == _n) ? player : 0;
        }
    }
}
