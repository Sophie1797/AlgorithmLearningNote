using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmNote.String.Trie
{
    /// <summary>
    /// 677. 键值映射
    /// </summary>
    public class MapSum
    {
        private MapSumNode root = new MapSumNode();
        /** Initialize your data structure here. */
        public MapSum() { }

        public void Insert(string key, int val)
        {
            var cur = root;
            foreach (var c in key)
            {
                if (cur.Children[c - 'a'] == null)
                {
                    cur.Children[c - 'a'] = new MapSumNode();
                }
                cur = cur.Children[c - 'a'];
            }
            cur.Value = val;
            cur.IsWord = true;
        }

        public int Sum(string prefix)
        {
            var cur = root;
            foreach (var c in prefix)
            {
                if (cur.Children[c - 'a'] == null)
                {
                    return 0;
                }
                cur = cur.Children[c - 'a'];
            }
            return dfs(cur);
        }

        public int dfs(MapSumNode root)
        {
            var sum = root.Value;
            foreach (var child in root.Children)
            {
                if (child != null)
                {
                    sum += dfs(child);
                }
            }
            return sum;
        }
    }

    public class MapSumNode
    {
        public int Value { get; set; }
        public bool IsWord { get; set; }
        public MapSumNode[] Children { get; set; }

        public MapSumNode()
        {
            this.IsWord = false;
            this.Children = new MapSumNode[26];
        }

        public MapSumNode(int value)
        {
            this.Value = value;
            this.IsWord = false;
            this.Children = new MapSumNode[26];
        }
    }
}
