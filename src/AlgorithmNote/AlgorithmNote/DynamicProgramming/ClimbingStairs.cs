﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmNote.DynamicProgramming
{
    public class ClimbingStairs
    {
        /// <summary>
        /// 70. Climbing Stairs https://leetcode.com/problems/climbing-stairs/
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


    }
}