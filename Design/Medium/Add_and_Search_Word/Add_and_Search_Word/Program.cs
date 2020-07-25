
namespace Add_and_Search_Word
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var obj = new WordDictionary();
            obj.AddWord("bad");
            obj.AddWord("dad");
            obj.AddWord("mad");
            obj.Search("pad"); // false
            obj.Search("bad"); // true
            obj.Search(".ad"); // true
            obj.Search("b.."); // true
        }

        public class WordDictionary
        {
            private Trie root;

            /** Initialize your data structure here. */
            public WordDictionary()
            {
                root = new Trie();
            }

            /// <summary>
            /// Time Complexity: O(L) where L is length of given word
            /// Space Complexity: O(26*N*L) = O(N*L) where N number of keys and L is length
            /// </summary>
            /** Adds a word into the data structure. */
            public void AddWord(string word)
            {
                if (string.IsNullOrEmpty(word))
                    return;

                var current = root;
                for (int i = 0; i < word.Length; i++)
                {
                    int index = word[i] - 'a';
                    if (current.Children[index] == null)
                    {
                        current.Children[index] = new Trie();
                    }
                    current = current.Children[index];
                }

                current.IsEnd = true;
            }

            /// <summary>
            /// Time Complexity: O(L) where L is length of given word
            /// Space Complexity: O(L)
            /// </summary>
            /** Returns if the word is in the data structure. A word could contain the dot character '.' to represent any one letter. */
            public bool Search(string word)
            {
                return Search(word, 0, root);
            }

            private bool Search(string word, int index, Trie node)
            {
                if (index == word.Length)
                    return node.IsEnd;

                if (word[index] != '.') // letter case
                {
                    return node.Children[word[index] - 'a'] != null
                        && Search(word, index + 1, node.Children[word[index] - 'a']);
                }
                else // '.' all case
                {
                    for (int i = 0; i < node.Children.Length; i++) // check all letters
                    {
                        if (node.Children[i] != null)
                        {
                            if (Search(word, index + 1, node.Children[i]))
                            {
                                return true;
                            }
                        }
                    }
                }

                return false;
            }
        }

        public class Trie
        {
            public Trie()
            {
                Children = new Trie[26];
            }

            public Trie[] Children { get; set; }
            public bool IsEnd { get; set; }
        }
    }
}
