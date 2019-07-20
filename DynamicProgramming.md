# Dynamic Programming
## Problem Summary
* **爬楼梯（Fibonacci序列同理）**
    $dp[i]$表示从最开始到达第i阶的方法种数
    $$ dp[i] = dp[i-1] + dp[i-2] $$
    边界
    $$ dp[0] = 1， dp[1] = 1 $$
    leetcode中类似题目：
    * [70. Climbing Stairs](https://leetcode.com/problems/climbing-stairs/)
    * [91. Decode Ways](https://leetcode.com/problems/decode-ways/submissions/)

* **最大连续子序列和**
	$dp[i]$表示以$A[i]$作为末尾的连续序列的最大和
    $$ dp[i] = max\{A[i], dp[i-1]+A[i]\} $$
    边界
    $$ dp[0]=A[0] $$
    leetcode中类似题目：
    * [53. Maximum Subarray](https://leetcode-cn.com/problems/maximum-subarray/)
* **最长不下降子序列（LIS）**
	$dp[i]$表示以$A[i]$结尾的最长不下降子序列长度
    $$ dp[i] = max\{1, dp[j]+1\},\ (j=1,2,...,i-1 and A[j]<A[i]) $$
    边界
    $$ dp[i]=1\ (1{\leq}i{\leq}n)$$
    leetcode中类似题目：
    * [300. Longest Increasing Subsequence](https://leetcode.com/problems/longest-increasing-subsequence/)
    * [343. Integer Break](https://leetcode.com/problems/integer-break/submissions/)
    * [279. Perfect Squares](https://leetcode.com/problems/perfect-squares/)
    * [198. House Robber](https://leetcode.com/problems/house-robber/)
    * [376. Wiggle Subsequence](https://leetcode.com/problems/wiggle-subsequence/)
* **最长公共子序列（LCS）**
	$dp[i][j]$表示字符串$A$的$i$号位和字符串$B$的$j$号位之前的LCS长度
    $$ dp[i][j]=
    \begin{cases}
    dp[i-1][j-1]+1,A[i]==B[j]\\
    max\{dp[i-1][j], dp[i][j-1]\},A[i]!=B[j]\\
    \end{cases}
    $$
    边界
    $$dp[i][0]=dp[0][j]=0\ (0{\leq}i{\leq}n,0{\leq}j{\leq}m)$$
    leetcode中类似题目：
    * [72. Edit Distance](https://leetcode.com/problems/edit-distance/)
* **最长回文子串（LPS）**
	$dp[i][j]$表示$S[i]$到$S[j]$所表示的子串是否是回文子串
    $$ dp[i][j]=
    \begin{cases}
    dp[i+1][j-1],\ S[i]==S[j]\\
    \ 0,\ S[i]!=S[j]\\
    \end{cases}
    $$
    边界
    $$dp[i][i]=0,\ dp[i][i+1]=(S[i]==S[i+1]?1:0)$$
    leetcode中类似题目：
    * [516. Longest Palindromic Subsequence](https://leetcode.com/problems/longest-palindromic-subsequence/)
* **数塔DP**
	$dp[i][j]$表示从第$i$行第$j$个数字出发的到达最底层的所有路径上所能得到的最大和，$f$是存放数字的数组
    $$ dp[i][j] = max(dp[i+1][j], dp[i+1][j+1])+f[i][j] $$
    边界
    $$ dp[n][j]==f[n][j]\ (1{\leq}j{\leq}n) $$
    leetcode中类似题目：
    * [120. Triangle](https://leetcode.com/problems/triangle/)
    * [64. Minimum Path Sum](https://leetcode.com/problems/minimum-path-sum/)
    * [62. Unique Paths](https://leetcode.com/problems/unique-paths/)
    * [63. Unique Paths II](https://leetcode.com/problems/unique-paths-ii/)
* **DAG最长路**
	$dp[i]$表示从$i$号顶点出发所能获得的最长路经长度
    leetcode中类似题目：
    * [139. Word Break](https://leetcode.com/problems/word-break/)
* **01背包**
	$dp[i][j]$表示前$i$件物品恰好装入容量为$v$的背包中所能获得的最大价值，共$n$件物品，每件物品的重量$w[i]$，价值$c[i]$，背包容量$V$
    $$ dp[i][v] = max\{dp[i-1][v],dp[i-1][v-w[i]]+c[i]\} $$
    边界
    $$ dp[0][v]=0\ (0{\leq}v{\leq}V)$$
    leetcode中类似题目：
    * [416. Partition Equal Subset Sum](https://leetcode.com/problems/partition-equal-subset-sum/)
    * [322. Coin Change](https://leetcode.com/problems/coin-change/)
* **完全背包**
	$dp[i][j]$表示前$i$件物品恰好装入容量为$v$的背包中所能获得的最大价值
    $$ dp[i][v] = max\{dp[i-1][v],dp[i][v-w[i]]+c[i]\} $$
    边界
    $$ dp[0][v]=0\ (0{\leq}v{\leq}V)$$
    leetcode中类似题目：
    * [518. Coin Change II](https://leetcode-cn.com/problems/coin-change-2/)
    * [377. Combination Sum IV](https://leetcode-cn.com/problems/combination-sum-iv/)

* **词语分割系列**
    * [139. Word Break](https://leetcode.com/problems/word-break/)
    * [140. Word Break II](https://leetcode.com/problems/word-break-ii/)

* **卖股票系列**
    * [121. Best Time to Buy and Sell Stock](https://leetcode.com/problems/best-time-to-buy-and-sell-stock/)
    * [122. Best Time to Buy and Sell Stock II](https://leetcode.com/problems/best-time-to-buy-and-sell-stock-ii/)
    * [123. Best Time to Buy and Sell Stock III](https://leetcode.com/problems/best-time-to-buy-and-sell-stock-iii/)
    * [188. Best Time to Buy and Sell Stock IV](https://leetcode.com/problems/best-time-to-buy-and-sell-stock-iv/)
    * [309. Best Time to Buy and Sell Stock with Cooldown](https://leetcode.com/problems/best-time-to-buy-and-sell-stock-with-cooldown/)
    * [714. Best Time to Buy and Sell Stock with Transaction Fee](https://leetcode.com/problems/best-time-to-buy-and-sell-stock-with-transaction-fee/)

* **Two pass DP**
    * [542. 01 Matrix](https://leetcode.com/problems/01-matrix/)