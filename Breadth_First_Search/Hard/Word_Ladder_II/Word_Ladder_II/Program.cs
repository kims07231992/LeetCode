using System.Collections.Generic;
using System.Linq;

namespace Word_Ladder_II
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
            var wordList = new string[] { "hot", "dot", "dog", "lot", "log", "cog" };

            var result = FindLAdders(beginWord, endWord, wordList);
        }

        /// <summary>
        /// Time Complexity: O(N*L) where N is number of words in wordList and L is length of beginWord
        /// Space Complexity: O(N) 
        /// </summary>
        private static IList<IList<string>> FindLAdders(string beginWord, string endWord, IList<string> wordList)
        {
            var result = new List<IList<string>>();
            var seen = wordList.ToHashSet();
            seen.Add(beginWord);
            var adjLists = new Dictionary<string, List<string>>(); // Key: word, Value: adjacent words
            foreach (string word in seen)
            {
                adjLists.Add(word, new List<string>());
            }
            var distanceMap = new Dictionary<string, int>(); // Key: word, Value: distance from beginWord
            distanceMap.Add(beginWord, 0);

            Bfs(beginWord, endWord, seen, adjLists, distanceMap);
            Dfs(beginWord, endWord, seen, adjLists, distanceMap, new List<string>(), result);

            return result;
        }

        private static void Bfs(string beginWord, string endWord, HashSet<string> seen,
            Dictionary<string, List<string>> adjLists, Dictionary<string, int> distanceMap)
        {
            var queue = new Queue<string>();
            queue.Enqueue(beginWord);

            while (queue.Count > 0)
            {
                var count = queue.Count;
                for (int i = 0; i < count; i++)
                {
                    var currentWord = queue.Dequeue();
                    var currentDistance = distanceMap[currentWord];
                    var adjList = new List<string>();
                    for (int j = 0; j < currentWord.Length; j++)
                    {
                        var temp = currentWord.ToCharArray();
                        for (char c = 'a'; c <= 'z'; c++)
                        {
                            temp[j] = c;
                            var changedTarget = new string(temp);
                            if (currentWord != changedTarget && seen.Contains(changedTarget))
                            {
                                adjList.Add(changedTarget);
                            }
                        }
                    }

                    foreach (string adjWord in adjList)
                    {
                        adjLists[currentWord].Add(adjWord);
                        if (!distanceMap.ContainsKey(adjWord)) // To include next words only
                        {
                            distanceMap.Add(adjWord, currentDistance + 1);
                            queue.Enqueue(adjWord);
                        }
                    }
                }
            }
        }

        private static void Dfs(string currentWord, string endWord, HashSet<string> dict,
            Dictionary<string, List<string>> adjLists, Dictionary<string, int> distance, List<string> temp, List<IList<string>> result)
        {
            temp.Add(currentWord);
            if (currentWord == endWord)
            {
                result.Add(temp);
                return;
            }

            foreach (var adjWord in adjLists[currentWord])
            {
                if (distance[adjWord] == distance[currentWord] + 1)
                {
                    Dfs(adjWord, endWord, dict, adjLists, distance, new List<string>(temp), result);
                }
            }
        }
    }
}
