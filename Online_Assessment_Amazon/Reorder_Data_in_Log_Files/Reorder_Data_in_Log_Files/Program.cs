using System.Collections.Generic;

namespace Reorder_Data_in_Log_Files
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var logs = new string[] { "a1 9 2 3 1","g1 act car","zo4 4 7","ab1 off key dog","a8 act zoo","a2 act car" };
            var result = ReorderLogFiles(logs);
        }

        /// <summary>
        /// Time Complexity: O(L*NlogN) where L is the longest length of the log and N is number of logs
        /// Space Complexity: O(N)
        /// </summary>
        public static string[] ReorderLogFiles(string[] logs)
        {
            if (logs == null || logs.Length < 1)
                return new string[] { };

            var letterLogs = new List<string>();
            var digitLogs = new List<string>(); 
            for (int i = 0; i < logs.Length; i++)
            {
                var word = logs[i];
                var lastChar = word[word.Length - 1];
                if (lastChar >= '0' && lastChar <= '9')
                    digitLogs.Add(word);
                else
                    letterLogs.Add(word);
            }

            letterLogs.Sort((x, y) => {
                var startIndexX = x.IndexOf(' ');
                var idX = x.Substring(0, startIndexX);
                x = x.Remove(0, startIndexX);

                var startIndexY = y.IndexOf(' ');
                var idY = y.Substring(0, startIndexY);
                y = y.Remove(0, startIndexY);

                return x == y 
                    ? idX.CompareTo(idY) 
                    : x.CompareTo(y);
            });
            letterLogs.AddRange(digitLogs);

            return letterLogs.ToArray();
        }
    }
}
