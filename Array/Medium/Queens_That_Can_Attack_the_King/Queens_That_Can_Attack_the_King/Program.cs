using System.Collections.Generic;

namespace Queens_That_Can_Attack_the_King
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var queens = new int[][]
            {
                new int[]{ 0, 1 },
                new int[]{ 1, 0 },
                new int[]{ 4, 0 },
                new int[]{ 0, 4 },
                new int[]{ 3, 3 },
                new int[]{ 2, 4 }
            };
            var king = new int[] { 0, 0 };

            var result = QueensAttacktheKing(queens, king);
        }

        /// <summary>
        /// Time Complexity: O(N + mn) => where N is the length of queens and m is length of rows and n is length of columns
        /// Space Complexity => O(mn)
        /// </summary>
        private static IList<IList<int>> QueensAttacktheKing(int[][] queens, int[] king)
        {
            int maxX = 8, maxY = 8;
            var flagMatrix = new bool[maxX, maxY];
            var result = new List<IList<int>>();

            foreach (var queen in queens)
                flagMatrix[queen[0], queen[1]] = true;

            int[] directions = { -1, 0, 1 };
            foreach (int dx in directions)
            {
                foreach (int dy in directions)
                {
                    if (dx == 0 && dy == 0)
                        continue;

                    int x = king[0], y = king[1];
                    while (x + dx >= 0 && x + dx < maxX && y + dy >= 0 && y + dy < maxY)
                    {
                        x += dx;
                        y += dy;
                        if (flagMatrix[x, y])
                        {
                            result.Add(new List<int> { x, y });
                            break;
                        }
                    }
                }
            }
            return result;
        }
    }
}
