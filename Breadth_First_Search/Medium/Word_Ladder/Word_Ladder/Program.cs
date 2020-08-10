using System.Collections.Generic;
using System.Linq;

namespace Word_LAdder
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var beginWord = "hit";
            var endWord = "cog";
            var wordList = new List<string> { "hot", "dot", "dog", "lot", "log", "cog" };

            var result = LadderLength(beginWord, endWord, wordList);
        }

        /// <summary>
        /// Time Complexity: O(N*L) where N is number of elements from wordList and L is length of word
        /// Space Complexity: O(N)
        /// </summary>
        private static int LadderLength(string beginWord, string endWord, IList<string> wordList)
        {
            var seen = wordList.ToHashSet();
            var length = 0;
            var queue = new Queue<string>();
            queue.Enqueue(beginWord);

            while (queue.Count != 0)
            {
                int n = queue.Count;
                for (int i = 0; i < n; i++)
                {
                    var target = queue.Dequeue();
                    if (target == endWord)
                        return ++length;

                    for (int j = 0; j < target.Length; j++)
                    {
                        var temp = target.ToCharArray();
                        for (char c = 'a'; c <= 'z'; c++)
                        {
                            temp[j] = c;
                            var changedTarget = new string(temp);
                            if (target != changedTarget && seen.Contains(changedTarget))
                            {
                                queue.Enqueue(changedTarget);
                                seen.Remove(changedTarget);
                            }
                        }
                    }
                }
                length++;
            }

            return 0;
        }
    }
}
