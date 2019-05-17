using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmNote
{
    public class LPS
    {
        /// <summary>
        /// 516. Longest Palindromic Subsequence https://leetcode.com/problems/longest-palindromic-subsequence/
        /// 经典LPS(longest palindrome subsequence)原问题
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int LongestPalindromeSubseq(string s)
        {
            var len = s.Length;
            var dp = new int[len, len];
            for (var i = len - 1; i >= 0; i--)
            {
                dp[i, i] = 1;
                for (var j = i + 1; j < len; j++)
                {
                    if (s[i] == s[j])
                    {
                        dp[i, j] = dp[i + 1, j - 1] + 2;
                    }
                    else
                    {
                        dp[i, j] = Math.Max(dp[i + 1, j], dp[i, j - 1]);
                    }
                }
            }
            return dp[0, len - 1];
        }
    }
}
