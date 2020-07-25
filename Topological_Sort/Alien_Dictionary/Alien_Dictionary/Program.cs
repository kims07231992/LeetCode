using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Alien_Dictionary
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var words = new string[]
            {
                "wrt",
                "wrf",
                "er",
                "ett",
                "rftt"
            };

            var result = AlienOrder(words);
        }

        /// <summary>
        /// Time Complexity: O(N*L + V+E) => O(N*L) where N is number of words in wordList and L is length of the word
        /// V+E is for topological operation 
        /// Space Complexity: O(V+E) 
        /// </summary>
        private static string AlienOrder(string[] words)
        {
            if (words == null || words.Length == 0)
                return string.Empty;

            var result = new StringBuilder();
            var adjLists = new Dictionary<char, HashSet<char>>();
            var degree = new Dictionary<char, int>();
            foreach (string word in words)
            {
                foreach (char letter in word)
                {
                    if (!degree.ContainsKey(letter))
                        degree.Add(letter, 0);
                }
            }

            for (int i = 0; i < words.Length - 1; i++)
            {
                string current = words[i];
                string next = words[i + 1];
                if (current.Length > next.Length && current.StartsWith(next))
                {
                    return string.Empty;
                }

                int length = Math.Min(current.Length, next.Length);
                for (int j = 0; j < length; j++)
                {
                    char c1 = current[j];
                    char c2 = next[j];
                    if (c1 != c2)
                    {
                        var adjList = adjLists.ContainsKey(c1) 
                            ? adjLists[c1] 
                            : new HashSet<char>();

                        if (!adjList.Contains(c2))
                        {
                            adjList.Add(c2);
                            degree[c2]++;
                            if (adjLists.ContainsKey(c1))
                                adjLists[c1] = adjList;
                            else
                                adjLists.Add(c1, adjList);
                        }
                        break;
                    }
                }
            }
            var queue = new Queue<char>();
            foreach (char c in degree.Keys)
            {
                if (degree[c] == 0) // letter that doesn't have prerequisite
                    queue.Enqueue(c);
            }

            while (queue.Count > 0)
            {
                var from = queue.Dequeue();
                result.Append(from);
                if (adjLists.ContainsKey(from))
                {
                    foreach (char to in adjLists[from])
                    {
                        if (--degree[to] == 0)
                            queue.Enqueue(to);
                    }
                }
            }

            return result.Length == degree.Count 
                ? result.ToString() 
                : string.Empty;
        }
    }
}
