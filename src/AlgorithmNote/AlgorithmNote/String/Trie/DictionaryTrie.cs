using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmNote
{
    public class DictionaryTrie
    {
        class TrieNode
        {
            public bool IsWord;
            public Dictionary<char, TrieNode> ChildrenMap = new Dictionary<char, TrieNode>();
        }

        private TrieNode root = new TrieNode();

        /** Initialize your data structure here. */
        public DictionaryTrie()
        { }

        /** Inserts a word into the trie. */
        public void Insert(string word)
        {
            TrieNode cur = root;
            foreach (var c in word)
            {
                if (!cur.ChildrenMap.ContainsKey(c))
                {
                    // insert a new node if the path does not exist
                    cur.ChildrenMap.Add(c, new TrieNode());
                }
                cur = cur.ChildrenMap[c];
            }
            cur.IsWord = true;
        }

        /** Returns if the word is in the trie. */
        public bool Search(string word)
        {
            TrieNode cur = root;
            foreach (var c in word)
            {
                if (!cur.ChildrenMap.ContainsKey(c))
                {
                    return false;
                }
                cur = cur.ChildrenMap[c];
            }
            return cur.IsWord;//注意此处
        }

        /** Returns if there is any word in the trie that starts with the given prefix. */
        public bool StartsWith(string prefix)
        {
            TrieNode cur = root;
            foreach (var c in prefix)
            {
                if (!cur.ChildrenMap.ContainsKey(c))
                {
                    return false;
                }
                cur = cur.ChildrenMap[c];
            }
            return true;
        }
    }
}
