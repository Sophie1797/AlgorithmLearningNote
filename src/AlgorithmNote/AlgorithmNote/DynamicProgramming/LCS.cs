using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmNote.DynamicProgramming
{
    public class LCS
    {
        /// <summary>
        /// 72. Edit Distance https://leetcode.com/problems/edit-distance/
        /// 类似LCS，在dp矩阵中的查找过程很像
        /// </summary>
        /// <param name="word1"></param>
        /// <param name="word2"></param>
        /// <returns></returns>
        public int MinDistance(string word1, string word2)
        {
            var w1 = ("#" + word1).ToArray();
            var w2 = ("#" + word2).ToArray();
            var dp = new int[w1.Length + 1, w2.Length + 1];
            for (var i = 0; i < w1.Length; i++)
            {
                for (var j = 0; j < w2.Length; j++)
                {
                    if (i == 0)
                    {
                        dp[i, j] = j; continue;
                    }
                    if (j == 0)
                    {
                        dp[i, j] = i; continue;
                    }
                    if (w1[i] == w2[j])
                    {
                        dp[i, j] = dp[i - 1, j - 1];
                    }
                    else
                    {
                        dp[i, j] = Math.Min(dp[i, j - 1], Math.Min(dp[i - 1, j], dp[i - 1, j - 1])) + 1;
                    }
                }
            }
            return dp[word1.Length, word2.Length];
        }
    }
}
