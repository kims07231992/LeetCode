using System.Collections.Generic;

namespace Concatenated_Words
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var words = new string[] { "cat", "cats", "catsdogcats", "dog", "dogcatsdog", "hippopotamuses", "rat", "ratcatdogcat" };
            var result = FindAllConcatenatedWordsInADict(words);
        }

        /// <summary>
        /// Time Complexity: O(N*L^2) where N is number of words in words and L is longest length of the given words
        /// Space Complexity: O(26*K*L + L) = O(K*L) 
        /// </summary>
        private static IList<string> FindAllConcatenatedWordsInADict(string[] words)
        {
            var result = new List<string>();
            var root = new TrieNode();
            foreach (string word in words)
            { 
                AddWord(word, root);
            }

            foreach (string word in words)
            { 
                if (IsConcatenated(root, word, 0, 0))
                {
                    result.Add(word);
                }
            }

            return result;
        }

        private static bool IsConcatenated(TrieNode root, string word, int index, int count)
        { 
            var current = root;
            var n = word.Length;
            for (int i = index; i < n; i++)
            {
                var key = word[i] - 'a';
                if (current.children[key] == null) // no next letter
                {
                    return false;
                }
                else if (current.children[key].isEnd)
                {
                    if (i == n - 1) // found a word that started from other words 
                    { 
                        return count >= 1;
                    }
                    else if (IsConcatenated(root, word, i + 1, count + 1)) // restart with in the middle of index but from root
                    {
                        return true;
                    }
                }
                current = current.children[key];
            }

            return false;
        }

        private static void AddWord(string word, TrieNode root)
        {
            var current = root;
            foreach (var ch in word)
            {
                if (current.children[ch - 'a'] == null)
                {
                    current.children[ch - 'a'] = new TrieNode();
                }
                current = current.children[ch - 'a'];
            }
            current.isEnd = true;
        }

        public class TrieNode
        {
            public TrieNode[] children;
            public bool isEnd;

            public TrieNode()
            {
                children = new TrieNode[26];
            }
        }
    }
}
