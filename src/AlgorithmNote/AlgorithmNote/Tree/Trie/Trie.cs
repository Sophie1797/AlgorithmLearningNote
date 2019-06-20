using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmNote
{
    public class Trie
    {
        private class TrieNode
        {
            public char Letter;
            public bool IsWord;
            public TrieNode[] Children;

            public TrieNode()
            {
                this.IsWord = false;
                this.Children = new TrieNode[26];
            }

            public TrieNode(char letter)
            {
                this.IsWord = false;
                this.Letter = letter;
                this.Children = new TrieNode[26];
            }

        }

        private TrieNode Root;

        /** Initialize your data structure here. */
        public Trie()
        {
            this.Root = new TrieNode();//set root to null val
        }

        /** Inserts a word into the trie. */
        public void Insert(string word)
        {
            var layer = this.Root;
            for (int i = 0; i < word.Length; i++)
            {
                if (layer.Children[word[i] - 'a'] == null)
                {
                    layer.Children[word[i] - 'a'] = new TrieNode(word[i]);
                }
                layer = layer.Children[word[i] - 'a'];
            }
            layer.IsWord = true;
        }

        /** Returns if the word is in the trie. */
        public bool Search(string word)
        {
            var layer = this.Root;
            for (int i = 0; i < word.Length; i++)
            {
                if (layer.Children[word[i] - 'a'] == null)
                {
                    return false;
                }
                layer = layer.Children[word[i] - 'a'];
            }
            if (layer.IsWord)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /** Returns if there is any word in the trie that starts with the given prefix. */
        public bool StartsWith(string prefix)
        {
            var layer = this.Root;
            for (int i = 0; i < prefix.Length; i++)
            {
                if (layer.Children[prefix[i] - 'a'] == null)
                {
                    return false;
                }
                layer = layer.Children[prefix[i] - 'a'];
            }
            return true;
        }
    }

    /**
     * Your Trie object will be instantiated and called as such:
     * Trie obj = new Trie();
     * obj.Insert(word);
     * bool param_2 = obj.Search(word);
     * bool param_3 = obj.StartsWith(prefix);
     */
}
