using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmNote
{
    public class Knapsack
    {
        /// <summary>
        /// 01背包问题原问题，该函数空间复杂度 n*C
        /// </summary>
        /// <param name="w"> weights </param>
        /// <param name="v"> values </param>
        /// <param name="C"> capacity </param>
        /// <returns></returns>
        public int Knapsack01(int[] w, int[] v, int C)
        {
            var n = w.Length;
            if (n == 0) return 0;
            var dp = new int[n, C+1];

            for (var i = 0; i <= C; i++)
                dp[0, i] = w[0] <= i ? v[0] : 0;

            for (var i = 1; i < n; i++)
            {
                for (var j = 0; j <= C; j++)
                {
                    dp[i, j] = dp[i - 1, j];
                    if (w[i] <= j)
                    {
                        dp[i, j] = Math.Max(dp[i - 1, j], dp[i - 1, j - w[i]] + v[i]);
                    }
                }
            }

            return dp[n - 1, C];
        }

        /// <summary>
        /// 01背包问题原问题，该函数空间复杂度 2*C
        /// </summary>
        /// <param name="w"> weights </param>
        /// <param name="v"> values </param>
        /// <param name="C"> capacity </param>
        /// <returns></returns>
        public int Knapsack01_modify1(int[] w, int[] v, int C)
        {
            var n = w.Length;
            if (n == 0) return 0;
            var dp = new int[2, C + 1];

            for (var i = 0; i <= C; i++)
                dp[0, i] = w[0] <= i ? v[0] : 0;

            for (var i = 1; i < n; i++)
            {
                for (var j = 0; j <= C; j++)
                {
                    dp[i % 2, j] = dp[(i - 1) % 2, j];
                    if (w[i] <= j)
                    {
                        dp[i % 2, j] = Math.Max(dp[(i - 1) % 2, j], dp[(i - 1) % 2, j - w[i]] + v[i]);
                    }
                }
            }

            return dp[(n - 1) % 2, C];
        }

        /// <summary>
        /// 01背包问题原问题，该函数空间复杂度 1*C
        /// </summary>
        /// <param name="w"> weights </param>
        /// <param name="v"> values </param>
        /// <param name="C"> capacity </param>
        /// <returns></returns>
        public int Knapsack01_modify2(int[] w, int[] v, int C)
        {
            var n = w.Length;
            if (n == 0) return 0;
            var dp = new int[C + 1];

            for (var i = 0; i <= C; i++)
                dp[i] = w[0] <= i ? v[0] : 0;

            for (var i = 1; i < n; i++)
            {
                for (var j = C; j >= w[i]; j--)
                {
                    dp[j] = Math.Max(dp[j], dp[j - w[i]] + v[i]);
                }
            }

            return dp[C];
        }

        /// <summary>
        /// 416. Partition Equal Subset Sum，https://leetcode.com/problems/partition-equal-subset-sum/，Uber
        /// 类似01背包问题，此题中dp表示前i个物品是否可以累加为j，j小于等于sum/2
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public bool CanPartition(int[] nums)
        {
            int sum = 0;
            for (var i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
            }
            if (sum % 2 != 0) return false;
            sum /= 2;

            int n = nums.Length;
            bool[] dp = new bool[sum + 1];
            dp[0] = true;

            for (int i = 0; i <= sum; i++)
            {
                dp[i] = nums[0] == i;
            }

            for (int i = 1; i < n; i++)
            {
                for (int j = sum; j >= nums[i]; j--)
                {
                    dp[j] = dp[j] || dp[j - nums[i]];
                }
            }

            return dp[sum];
        }

        /// <summary>
        /// 多重背包问题
        /// </summary>
        /// <param name="w"> weights </param>
        /// <param name="v"> values </param>
        /// <param name="C"> capacity </param>
        /// <returns></returns>
        public int KnapsackMulti(int[] w, int[] v, int C)
        {
            var n = w.Length;
            if (n == 0) return 0;
            var dp = new int[C + 1];

            for (var i = 0; i <= C; i++)
                dp[i] = w[i] <= i ? v[i] : 0;

            for (var i = 1; i < n; i++)
            {
                for (var j = C; j >= w[i]; j--)
                {
                    dp[j] = Math.Max(dp[j], dp[j - w[i]] + v[i]);
                }
            }

            return dp[C];
        }

        public int FindMaxForm(string[] strs, int m, int n)
        {
            int[][] dp = new int[m + 1][];
            for (int i = 0; i < m + 1; i++)
            {
                dp[i] = new int[n + 1];
            }
            foreach (string str in strs)
            {
                int ZeroCount = 0;
                int OneCount = 0;
                foreach (char c in str)
                {
                    if (c == '0')
                        ZeroCount++;
                    if (c == '1')
                        OneCount++;
                }
                for (int i = m; i >= ZeroCount; i--)
                {
                    for (int j = n; j >= OneCount; j--)
                    {
                        dp[i][j] = (int)Math.Max(dp[i][j], dp[i - ZeroCount][j - OneCount] + 1);
                    }
                }
            }
            return dp[m][n];
        }

        /// <summary>
        /// 完全背包问题
        /// </summary>
        /// <param name="w"> weights </param>
        /// <param name="v"> values </param>
        /// <param name="C"> capacity </param>
        /// <returns></returns>
        public int KnapsackTotal(int[] w, int[] v, int C)
        {
            var n = w.Length;
            if (n == 0) return 0;
            var dp = new int[C + 1];

            for (var i = 0; i <= C; i++)
                dp[i] = w[i] <= i ? v[i] : 0;

            for (var i = 1; i < n; i++)
            {
                for (var j = w[i]; j <= C; j++)
                {
                    dp[j] = Math.Max(dp[j], dp[j - w[i]] + v[i]);
                }
            }

            return dp[C];
        }

        /// <summary>
        /// 322. Coin Change https://leetcode.com/problems/coin-change/
        /// 类似完全背包问题
        /// </summary>
        /// <param name="coins"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public int CoinChange(int[] coins, int amount)
        {
            var dp = new int[amount + 1];
            for (var i = 0; i < amount + 1; i++)
            {
                dp[i] = int.MaxValue;
            }
            dp[0] = 0;//恰好一个面值等于amount的情况要用
            for (var i = 0; i < coins.Length; i++)
            {
                for (var j = coins[i]; j < amount + 1; j++)
                {
                    if (dp[j - coins[i]] != int.MaxValue)
                    {
                        dp[j] = Math.Min(dp[j], dp[j - coins[i]] + 1);
                    }
                }
            }
            return dp[amount] == int.MaxValue ? -1 : dp[amount];
        }

        /// <summary>
        /// 518. Coin Change II https://leetcode-cn.com/problems/coin-change-2/submissions/
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="coins"></param>
        /// <returns></returns>
        public int Change(int amount, int[] coins)
        {
            var dp = new int[amount + 1];
            dp[0] = 1;
            for (int i = 0; i < coins.Length; i++)
            {
                for (int j = coins[i]; j <= amount; j++)
                {
                    dp[j] += dp[j - coins[i]];
                }
            }
            return dp[amount];
        }

        /// <summary>
        /// 377. Combination Sum IV https://leetcode.com/problems/combination-sum-iv/, google, facebook
        /// 类似上一题，但这道题不同顺序算作不同的组合
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int CombinationSum4(int[] nums, int target)
        {
            var dp = new int[target + 1];
            //组成和为0的方法只有一种，就是啥都不选
            dp[0] = 1;

            for (int i = 1; i <= target; i++)
            {
                for (int j = 0; j < nums.Length; j++)
                {
                    if (nums[j] <= i)
                    {
                        dp[i] = dp[i] + dp[i - nums[j]];
                    }
                }
            }

            return dp[target];
        }

        /// <summary>
        /// 背包问题加入物品互斥
        /// </summary>
        /// <param name="w"> weights </param>
        /// <param name="v"> values </param>
        /// <param name="C"> capacity </param>
        /// <returns></returns>
        public int Knapsack_mul(int[] w, int[] v, int C)
        {
            var n = w.Length;
            if (n == 0) return 0;
            var dp = new int[C + 1];

            for (var i = 0; i <= C; i++)
                dp[i] = w[i] <= i ? v[i] : 0;

            for (var i = 1; i < n; i++)
            {
                for (var j = C; j >= w[i]; j--)
                {
                    dp[j] = Math.Max(dp[j], dp[j - w[i]] + v[i]);
                }
            }

            return dp[C];
        }

        /// <summary>
        /// 背包问题加入物品依赖
        /// </summary>
        /// <param name="w"> weights </param>
        /// <param name="v"> values </param>
        /// <param name="C"> capacity </param>
        /// <returns></returns>
        public int Knapsack_Rely(int[] w, int[] v, int C)
        {
            var n = w.Length;
            if (n == 0) return 0;
            var dp = new int[C + 1];

            for (var i = 0; i <= C; i++)
                dp[i] = w[i] <= i ? v[i] : 0;

            for (var i = 1; i < n; i++)
            {
                for (var j = C; j >= w[i]; j--)
                {
                    dp[j] = Math.Max(dp[j], dp[j - w[i]] + v[i]);
                }
            }

            return dp[C];
        }
    }
}
