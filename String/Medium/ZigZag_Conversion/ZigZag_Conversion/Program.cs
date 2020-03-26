using System.Text;

namespace ZigZag_Conversion
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var s = "PAYPALISHIRING";
            var numRows = 3;
            var result = Convert(s, numRows);
        }

        /// <summary>
        /// Time Complexity: O(N) where N length of s
        /// Space Complexity: O(M) where M is numRows
        /// </summary>
        private static string Convert(string s, int numRows)
        {
            if (string.IsNullOrEmpty(s) || numRows < 2)
                return s;

            var buffers = new StringBuilder[numRows];
            for (int k = 0; k < buffers.Length; k++)
            {
                buffers[k] = new StringBuilder();
            }

            int i = 0;
            while (i < s.Length)
            {
                int j = 0;
                while (i < s.Length && j < numRows)
                {
                    buffers[j].Append(s[i]);
                    i++;
                    j++;
                }

                j = numRows - 2;

                while (i < s.Length && j >= 0)
                {
                    buffers[j].Append(s[i]);
                    i++;
                    j--;
                }
            }

            var result = new StringBuilder();
            foreach (var buffer in buffers)
            {
                result.Append(buffer);
            }

            return result.ToString();
        }
    }
}
