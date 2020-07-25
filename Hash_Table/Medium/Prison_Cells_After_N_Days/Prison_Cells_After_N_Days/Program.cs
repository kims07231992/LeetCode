using System.Collections.Generic;
using System.Text;

namespace Prison_Cells_After_N_Days
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var cells = new int[] { 1, 0, 0, 1, 0, 0, 1, 0 };
            var N = 1000000000;

            var result = PrisonAfterNDays(cells, N);
        }

        /// <summary>
        /// Time Complexity: O(1) where we have fixed 8 length of cells which can be changed for 6 digts O(2^6)
        /// Space Complexity: O(1)
        /// </summary>
        private static int[] PrisonAfterNDays(int[] cells, int N)
        {
            if (cells == null || cells.Length == 0 || N <= 0)
                return cells;

            var hasCycle = false;
            var cycle = 0;
            var set = new HashSet<string>();
            for (int i = 0; i < N; i++)
            {
                var next = GetNextDay(cells);
                var sb = new StringBuilder();
                for (int j = 0; j < next.Length; j++) // build string based key
                    sb.Append(next[j]);

                var key = sb.ToString();
                if (!set.Contains(key))
                { 
                    set.Add(key);
                    cycle++;
                }
                else
                {
                    hasCycle = true;
                    break;
                }
                cells = next;
            }
            if (hasCycle)
            {
                N %= cycle;
                for (int i = 0; i < N; i++)
                {
                    cells = GetNextDay(cells);
                }
            }
            return cells;
        }

        private static int[] GetNextDay(int[] cells)
        {
            var temp = new int[cells.Length];
            for (int i = 1; i < cells.Length - 1; i++)
            {
                temp[i] = cells[i - 1] == cells[i + 1] ? 1 : 0;
            }

            return temp;
        }
    }
}
