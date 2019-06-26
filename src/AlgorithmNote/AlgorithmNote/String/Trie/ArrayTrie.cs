using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmNote
{
    public class ArrayTrie
    {
        class TrieNode
        {
            public bool IsWord { get; set; }
            public TrieNode[] Children = new TrieNode[26];
        }

        private TrieNode root = new TrieNode();

        /** Initialize your data structure here. */
        public ArrayTrie()
        { }

        /** Inserts a word into the trie. */
        public void Insert(string word)
        {
            var cur = root;
            foreach (var c in word)
            {
                if (cur.Children[c - 'a'] == null)
                {
                    cur.Children[c - 'a'] = new TrieNode();
                }

                cur = cur.Children[c - 'a'];
            }

            cur.IsWord = true;
        }

        /** Returns if the word is in the trie. */
        public bool Search(string word)
        {
            var cur = root;
            foreach (var c in word)
            {
                if (cur.Children[c - 'a'] == null)
                {
                    return false;
                }

                cur = cur.Children[c - 'a'];
            }

            return cur.IsWord;//注意此处
        }

        /** Returns if there is any word in the trie that starts with the given prefix. */
        public bool StartsWith(string prefix)
        {
            var cur = root;
            foreach (var c in prefix)
            {
                if (cur.Children[c - 'a'] == null)
                {
                    return false;
                }

                cur = cur.Children[c - 'a'];
            }

            return true;
        }
    }
}
