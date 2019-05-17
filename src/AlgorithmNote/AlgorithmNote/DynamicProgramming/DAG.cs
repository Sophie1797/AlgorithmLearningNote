using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmNote
{
    public class DAG
    {
        /// <summary>
        /// 139. Word Break https://leetcode.com/problems/word-break/ google, facebook, amazon, uber, bloomberg...
        /// 问题形式类似完全背包问题，dict中单词可以被用infinite次，但划分j的时候感觉有点像DAG最长路
        /// </summary>
        /// <param name="s"></param>
        /// <param name="dict"></param>
        /// <returns></returns>
        public bool WordBreak(string s, IList<string> dict)
        {
            var len = s.Length;
            var f = new bool[len + 1];
            f[0] = true;

            for (int i = 1; i <= len; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (f[j] && dict.Contains(s.Substring(j, i - j)))
                    {
                        f[i] = true;
                        break;
                    }
                }
            }

            return f[len];
        }
    }
}
