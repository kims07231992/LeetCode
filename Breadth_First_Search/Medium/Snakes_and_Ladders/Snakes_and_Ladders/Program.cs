using System.Collections.Generic;

namespace Snakes_and_Ladders
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var board = new int[][]
            {
                new int[] { -1, -1, -1, -1, -1, -1 },
                new int[] { -1, -1, -1, -1, -1, -1 },
                new int[] { -1, -1, -1, -1, -1, -1 },
                new int[] { -1, 35, -1, -1, 13, -1 },
                new int[] { -1, -1, -1, -1, -1, -1 },
                new int[] { -1, 15, -1, -1, -1, -1 }
            };

            var result = SnakesAndLadders(board);
        }

        /// <summary>
        /// Time Complexity: O(N^2) where N is given length of board
        /// Space Complexity: O(N^2) 
        /// </summary>
        private static int SnakesAndLadders(int[][] board)
        {
            var n = board.Length;
            var result = 0;
            var visited = new HashSet<string>();
            var queue = new Queue<int>();
            queue.Enqueue(1);

            while (queue.Count > 0)
            {
                var count = queue.Count;
                for (int i = 0; i < count; i++)
                {
                    var position = queue.Dequeue();
                    var coordinate = GetCoordinate(position, n);
                    visited.Add($"{coordinate[0]}x{coordinate[1]}");

                    if (position == n * n)
                        return result;

                    for (int j = 1; j <= 6; j++)
                    {
                        var nextPosition = position + j;
                        if (nextPosition > n * n)
                            break;

                        var nextCoorinate = GetCoordinate(nextPosition, n);
                        if (board[nextCoorinate[0]][nextCoorinate[1]] != -1) // ladder case
                        {
                            nextPosition = board[nextCoorinate[0]][nextCoorinate[1]];
                            nextCoorinate = GetCoordinate(nextPosition, n);
                        }

                        if (!visited.Contains($"{nextCoorinate[0]}x{nextCoorinate[1]}"))
                        {
                            visited.Add($"{nextCoorinate[0]}x{nextCoorinate[1]}");
                            queue.Enqueue(nextPosition);
                        }
                    }
                }
                result++;
            }

            return -1;
        }

        private static int[] GetCoordinate(int position, int n)
        {
            int quotient = (position - 1) / n;
            int remainder = (position - 1) % n;
            int row = n - 1 - quotient;
            int col = row % 2 != n % 2
                ? remainder
                : n - 1 - remainder;

            return new int[] { row, col };
        }
    }
}
