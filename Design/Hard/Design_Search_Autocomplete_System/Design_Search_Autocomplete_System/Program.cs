using System;
using System.Collections.Generic;
using System.Linq;

namespace Design_Search_Autocomplete_System
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var sentences = new string[] { "i love you", "island", "iroman", "i love leetcode" };
            var times = new int[] { 5, 3, 2, 2 };
            var autocompleteSystem = new AutocompleteSystem(sentences, times);

            autocompleteSystem.Input('i');
            autocompleteSystem.Input(' ');
            autocompleteSystem.Input('a');
            autocompleteSystem.Input('#');
        }

        public class AutocompleteSystem
        {
            private Trie root;
            private Dictionary<string, int> map;
            private string prefix;

            public AutocompleteSystem(string[] sentences, int[] times)
            {
                map = new Dictionary<string, int>();
                root = new Trie();

                for (int i = 0; i < sentences.Length; i++)
                {
                    Add(sentences[i], times[i]);
                }
            }

            /// <summary>
            /// Time Complexity: O(N + ClogC) where N is length of prefix and C is counts of last Trie
            /// Space Complexity: O(ClogC) 
            /// </summary>
            public IList<string> Input(char c)
            {
                if (c == '#')
                {
                    Add(prefix, 1);
                    prefix = "";
                    return new List<string>();
                }

                prefix += c;
                var current = root;
                foreach (char ch in prefix)
                {
                    var next = current.children.GetValueOrDefault(ch);
                    if (next == null) // prefix not exist
                    {
                        return new List<string>();
                    }
                    current = next;
                }

                var result = new List<Tuple<string, int>>();
                foreach (string s in current.counts.Keys)
                {
                    result.Add(new Tuple<string, int>(s, current.counts[s]));
                }
                result.Sort((x, y) => {
                    return x.Item2 == y.Item2
                        ? x.Item1.CompareTo(y.Item1)
                        : y.Item2.CompareTo(x.Item2);
                });

                return result
                    .Take(3)
                    .Select(x => x.Item1)
                    .ToList();
            }

            /// <summary>
            /// Time Complexity: O(N) where N is length of key
            /// Space Complexity: O(N) 
            /// </summary>
            public void Add(string key, int time)
            {
                var current = root;
                foreach (char ch in key)
                {
                    var next = current.children.GetValueOrDefault(ch);
                    if (next == null)
                    {
                        next = new Trie();
                        current.children.Add(ch, next);
                    }
                    current = next;
                    if (current.counts.ContainsKey(key))
                        current.counts[key] += time;
                    else
                        current.counts.Add(key, time);
                }
            }
        }

        public class Trie
        {
            public Dictionary<char, Trie> children;
            public Dictionary<string, int> counts;

            public Trie()
            {
                children = new Dictionary<char, Trie>();
                counts = new Dictionary<string, int>();
            }
        }
    }
}
