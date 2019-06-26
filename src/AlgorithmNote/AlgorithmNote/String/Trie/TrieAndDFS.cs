using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmNote.String.Trie
{
    /// <summary>
    /// 212. 单词搜索 II
    /// </summary>
    public class FindWords_TrieAndDFS
    {
        public IList<string> FindWords(char[,] board, string[] words)
        {
            var res = new List<string>();
            var root = Build(words);
            for (var i = 0; i < board.GetLength(0); i++)
            {
                for (var j = 0; j < board.GetLength(1); j++)
                {
                    dfs(board, i, j, root, res);
                }
            }
            return res;
        }

        public void dfs(char[,] board, int i, int j, TrieNode p, List<string> res)
        {
            char c = board[i, j];
            if (c == '0' || p.next[c - 'a'] == null) return;
            p = p.next[c - 'a'];
            if (!string.IsNullOrEmpty(p.word))
            {
                res.Add(p.word);
                p.word = null;
            }

            board[i, j] = '0';
            if (i > 0) dfs(board, i - 1, j, p, res);
            if (j > 0) dfs(board, i, j - 1, p, res);
            if (i < board.GetLength(0) - 1) dfs(board, i + 1, j, p, res);
            if (j < board.GetLength(1) - 1) dfs(board, i, j + 1, p, res);
            board[i, j] = c;
        }

        public TrieNode Build(string[] words)
        {
            var root = new TrieNode();
            for (var i = 0; i < words.Length; i++)
            {
                TrieNode p = root;
                for (var j = 0; j < words[i].Length; j++)
                {
                    if (p.next[words[i][j] - 'a'] == null) p.next[words[i][j] - 'a'] = new TrieNode();
                    p = p.next[words[i][j] - 'a'];
                }
                p.word = words[i];
            }
            return root;
        }

        public class TrieNode
        {
            public TrieNode[] next = new TrieNode[26];
            public string word;
        }
    }
}
