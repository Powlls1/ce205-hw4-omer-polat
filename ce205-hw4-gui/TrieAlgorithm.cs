using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ce205_hw4_gui
{
    public class TrieAlgorithm
    {

        /// <summary>
        /// Finds the largest common subsequence of two strings.
        /// </summary>
        public class TrieNode
        {
            public Dictionary<char, TrieNode> Children { get; set; }
            public bool IsEndOfWord { get; set; }

            public TrieNode()
            {
                Children = new Dictionary<char, TrieNode>();
                IsEndOfWord = false;
            }
        }
        /// <summary>
        /// Finds the largest common subsequence of two strings.
        /// </summary>
        public class Trie
        {
            public static TrieNode root;

            public Trie()
            {
                root = new TrieNode();
            }

            /// <summary>
            /// Inserts a word into the trie.
            /// </summary>
            /// <param name="word"></param>
            public static void Insert(string word)
            {
                TrieNode current = root;

                foreach (char c in word)
                {
                    if (!current.Children.ContainsKey(c))
                    {
                        current.Children[c] = new TrieNode();
                    }
                    current = current.Children[c];
                }

                current.IsEndOfWord = true;
            }

            /// <summary>
            /// Returns true if the word is in the trie.
            /// </summary>
            /// <param name="prefix"></param>
            /// <returns></returns>
            public List<string> SearchPrefix(string prefix)
            {
                TrieNode current = root;
                List<string> words = new List<string>();

                // Traverse the tree to find the prefix
                foreach (char c in prefix)
                {
                    if (!current.Children.ContainsKey(c))
                    {
                        // The prefix is not in the trie
                        return words;
                    }

                    current = current.Children[c];
                }

                // The prefix is in the trie, so search for words starting with the prefix
                SearchRecursive(current, prefix, words);

                return words;
            }

            /// <summary>
            /// Recursively searches the trie for words starting with the given prefix.
            /// </summary>
            /// <param name="current"></param>
            /// <param name="prefix"></param>
            /// <param name="words"></param>
            private void SearchRecursive(TrieNode current, string prefix, List<string> words)
            {
                if (current.IsEndOfWord)
                {
                    // Add the word to the list
                    words.Add(prefix);
                }

                // Recursively search for more words
                foreach (var child in current.Children)
                {
                    SearchRecursive(child.Value, prefix + child.Key, words);
                }
            }
        }

    }
}
