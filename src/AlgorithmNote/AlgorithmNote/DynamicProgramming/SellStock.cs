using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmNote
{
    public class SellStock
    {
        /// <summary>
        /// https://leetcode-cn.com/problems/best-time-to-buy-and-sell-stock/
        /// </summary>
        /// <param name="prices"></param>
        /// <returns></returns>
        public int MaxProfit(int[] prices)
        {
            if (prices == null || prices.Length == 0)
            {
                return 0;
            }
            var b = prices[0];
            var maxSoFar = 0;
            var maxcurr = 0;
            foreach (var p in prices)
            {
                maxcurr += p - b;
                maxcurr = Math.Max(maxcurr, 0);
                b = p;
                maxSoFar = Math.Max(maxcurr, maxSoFar);
            }
            return maxSoFar;
        }

        /// <summary>
        /// https://leetcode-cn.com/problems/best-time-to-buy-and-sell-stock-ii/
        /// </summary>
        /// <param name="prices"></param>
        /// <returns></returns>
        public int MaxProfitII(int[] prices)
        {
            if (prices == null || prices.Length == 0) return 0;
            var first = prices[0];
            var res = 0;
            for (var i = 1; i < prices.Length; i++)
            {
                var cur = prices[i] - first;
                first = prices[i];
                res += Math.Max(cur, 0);
            }
            return res;
        }

        /// <summary>
        /// https://leetcode-cn.com/problems/best-time-to-buy-and-sell-stock-iii/
        /// </summary>
        /// <param name="prices"></param>
        /// <returns></returns>
        public int MaxProfitIII(int[] prices)
        {
            if (prices.Length == 0) return 0;
            int s1 = -prices[0], s2 = int.MinValue, s3 = int.MinValue, s4 = int.MinValue;

            for (int i = 1; i < prices.Length; ++i)
            {
                s1 = Math.Max(s1, -prices[i]);
                s2 = Math.Max(s2, s1 + prices[i]);
                s3 = Math.Max(s3, s2 - prices[i]);
                s4 = Math.Max(s4, s3 + prices[i]);
            }
            return Math.Max(0, s4);
        }

        /// <summary>
        /// https://leetcode-cn.com/problems/best-time-to-buy-and-sell-stock-iv/
        /// </summary>
        /// <param name="k"></param>
        /// <param name="prices"></param>
        /// <returns></returns>
        public int MaxProfitIV(int k, int[] prices)
        {
            var n = prices.Length;
            if (n <= 1) return 0;

            if (k >= n / 2)
            {//same as unlimited times
                var sum = 0;
                for (var i = 1; i < n; i++)
                {
                    var cur = prices[i] - prices[i - 1];
                    if (cur > 0) sum += cur;
                }
                return sum;
            }

            var dp = new int[k + 1, n];
            for (var i = 1; i < k + 1; i++)
            {
                var lastBuy = -prices[0];
                for (var j = 1; j < n; j++)
                {
                    dp[i, j] = Math.Max(dp[i, j - 1], lastBuy + prices[j]);
                    lastBuy = Math.Max(lastBuy, dp[i - 1, j] - prices[j]);
                }
            }
            return dp[k, n - 1];
        }

        /// <summary>
        /// https://leetcode-cn.com/problems/best-time-to-buy-and-sell-stock-with-cooldown/
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public int MaxProfitWithCoolDown(int[] p)
        {
            //this is more easy to think
            if (p == null || p.Length < 2) return 0;
            var n = p.Length;
            var ownLast = -p[0];
            var notOwnLast = 0;
            var notOwnLast2 = 0;
            var res = 0;
            for (var i = 1; i < n; ++i)
            {
                var own = Math.Max(ownLast, notOwnLast2 - p[i]);
                var notOwn = Math.Max(ownLast + p[i], notOwnLast);

                notOwnLast2 = notOwnLast;
                ownLast = own;
                notOwnLast = notOwn;

                res = Math.Max(res, Math.Max(own, notOwn));
            }

            return res;
        }

        /// <summary>
        /// https://leetcode-cn.com/problems/best-time-to-buy-and-sell-stock-with-transaction-fee/
        /// </summary>
        /// <param name="prices"></param>
        /// <param name="fee"></param>
        /// <returns></returns>
        public int MaxProfitWithFee(int[] prices, int fee)
        {
            int cash = 0, hold = -prices[0];
            for (int i = 1; i < prices.Length; i++)
            {
                cash = Math.Max(cash, hold + prices[i] - fee);
                hold = Math.Max(hold, cash - prices[i]);
            }
            return cash;
        }
    }
}
