using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmNote
{
    public class LIS
    {
        /// <summary>
        /// LIS原问题，300. Longest Increasing Subsequence，https://leetcode.com/problems/longest-increasing-subsequence/
        /// O(n^2)
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int LengthOfLIS(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                return 0;
            }
            var dp = new List<int>();
            foreach (var n in nums)
            {
                dp.Add(1);
            }
            var max = 1;
            for (var i = 0; i < nums.Length; i++)
            {
                for (var j = 0; j < i; j++)
                {
                    if (nums[i] > nums[j])
                    {
                        dp[i] = Math.Max(dp[i], dp[j] + 1);
                    }
                }
            }
            return dp.Max();
        }

        /// <summary>
        /// LIS原问题dp改进版解法，O(nlogn)
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int LengthOfLIS_modify(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                return 0;
            }
            int[] dp = new int[nums.Length];
            int len = 0;
            foreach (int num in nums)
            {
                int i = Array.BinarySearch(dp, 0, len, num);
                if (i < 0)
                {
                    i = -(i + 1);
                }
                dp[i] = num;
                if (i == len)
                {
                    len++;
                }
            }
            return len;
        }

        /// <summary>
        /// 343. Integer Break, https://leetcode.com/problems/integer-break/submissions/
        /// 类似LIS，都是对于小于i的每一个j判断
        /// </summary>
        public int IntegerBreak(int n)
        {
            var dp = new int[n + 1];
            dp[0] = 0;
            dp[1] = 1;
            for (var i = 2; i <= n; i++)
            {
                var max = 0;
                for (var j = 1; j < i; j++)
                {
                    //对于每个j有分割和不分割两个选项
                    max = Math.Max(max, Math.Max(dp[j] * (i - j), j * (i - j)));
                }
                dp[i] = max;
            }
            return dp[n];
        }

        /// <summary>
        /// 279. Perfect Squares,  https://leetcode.com/problems/perfect-squares/,  google
        /// 类似LIS，都是对于小于i的每一个j判断
        /// </summary>
        public int NumSquares(int n)
        {
            var dp = new int[n + 1];
            if (n < 1) return 0;
            dp[1] = 1;
            for (var i = 2; i <= n; i++)
            {
                //把后面的所有平方数下标的dp都设为1
                if (i * i <= n) dp[i * i] = 1;
                if (dp[i] == 1) continue;
                //从1开始每轮减j*j，找到最小的
                var min = int.MaxValue;
                for (var j = 1; j * j < i; j++)
                {
                    min = Math.Min(min, 1 + dp[i - j * j]);
                }
                dp[i] = min;
            }
            return dp[n];
        }

        /// <summary>
        /// 198. House Robber, https://leetcode.com/problems/house-robber/
        /// </summary>
        public int Rob(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                return 0;
            }
            var temp = new List<int>();
            for (var i = 0; i < nums.Length; i++)
            {
                if (i == 0)
                {
                    temp.Add(nums[0]);
                }
                else if (i == 1)
                {
                    temp.Add(Math.Max(nums[0], nums[1]));
                }
                else
                {
                    temp.Add(Math.Max(temp[i - 2] + nums[i], temp[i - 1]));
                }
            }
            return temp.Last();
        }

        /// <summary>
        /// 376. Wiggle Subsequence https://leetcode.com/problems/wiggle-subsequence/
        /// 类似LIS原理，该解法是一个优化了时间空间复杂度的
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int WiggleMaxLength(int[] nums)
        {
            if (nums.Length < 2)
                return nums.Length;
            int down = 1, up = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] > nums[i - 1])
                    up = down + 1;
                else if (nums[i] < nums[i - 1])
                    down = up + 1;
            }
            return Math.Max(down, up);
        }
    }
}
