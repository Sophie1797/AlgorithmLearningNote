using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmNote.DynamicProgramming
{
    public class ClimbingStairs
    {
        /// <summary>
        /// 70. Climbing Stairs, https://leetcode.com/problems/climbing-stairs/
        /// Totally same as Fibonacci
        /// </summary>
        public int ClimbStairs(int n)
        {
            var dp = new int[n + 1];
            dp[0] = 1;
            dp[1] = 1;
            for (var i = 2; i <= n; i++)
            {
                dp[i] = dp[i - 1] + dp[i - 2];
            }
            return dp[n];
        }

        /// <summary>
        /// 91. Decode Ways, https://leetcode.com/problems/decode-ways/, facebook, MS, uber
        /// 类似爬楼梯，当前状态与i-1和i-2有关
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int NumDecodings(string s)
        {
            if (s == null || s.Length == 0)
            {
                return 0;
            }
            int n = s.Length;
            int[] dp = new int[n + 1];
            dp[0] = 1;
            dp[1] = s[0] != '0' ? 1 : 0;
            for (int i = 2; i <= n; i++)
            {
                int first = int.Parse(s.Substring(i - 1, 1));
                int second = int.Parse(s.Substring(i - 2, 2));
                if (first >= 1 && first <= 9)
                {
                    dp[i] += dp[i - 1];
                }
                if (second >= 10 && second <= 26)
                {
                    dp[i] += dp[i - 2];
                }
            }
            return dp[n];
        }
    }
}
