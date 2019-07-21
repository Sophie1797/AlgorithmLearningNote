using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmNote.DynamicProgramming
{
    public class GridDP
    {
        /// <summary>
        /// https://leetcode-cn.com/problems/unique-paths/
        /// </summary>
        public int UniquePaths(int m, int n)
        {
            var dp = new int[m, n];
            for (var i = 0; i < m; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    if (i == 0 || j == 0)
                    {
                        dp[i, j] = 1;
                    }
                    else
                    {
                        dp[i, j] = dp[i - 1, j] + dp[i, j - 1];
                    }
                }
            }
            return dp[m - 1, n - 1];
        }

        /// <summary>
        /// https://leetcode-cn.com/problems/unique-paths-ii/
        /// </summary>
        public int UniquePathsWithObstacles(int[][] obstacleGrid)
        {
            var m = obstacleGrid.Length;
            var n = obstacleGrid[0].Length;
            var dp = new int[m, n];
            dp[0, 0] = 1;
            for (var i = 0; i < m; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    if (obstacleGrid[i][j] == 1)
                    {
                        dp[i, j] = 0;
                    }
                    else
                    {
                        if (i == 0 && j == 0)
                        {
                            dp[i, j] = 1;
                        }
                        else if (i == 0)
                        {
                            dp[i, j] = dp[i, j - 1];
                        }
                        else if (j == 0)
                        {
                            dp[i, j] = dp[i - 1, j];
                        }
                        else
                        {
                            dp[i, j] = dp[i - 1, j] + dp[i, j - 1];
                        }
                    }
                }
            }
            return dp[m - 1, n - 1];
        }

        /// <summary>
        /// https://leetcode-cn.com/problems/bomb-enemy/
        /// </summary>
        public int MaxKilledEnemies(char[][] grid)
        {
            // 每个位置能炸到的人为4个方向的人的总和
            int m = grid.Length; if (m <= 0) return 0;
            int n = grid[0].Length; if (n <= 0) return 0;

            var dp = new int[m, n];
            for (int i = 0; i < m; i++)
            {
                // 计算当前行相邻两个墙壁之间人的个数
                int s = -1;
                int j = s + 1;
                while (j < n)
                {
                    int count = 0;
                    while (j < n && grid[i][j] != 'W')
                    {
                        count += (grid[i][j] == 'E' ? 1 : 0);
                        j++;
                    }
                    for (int k = s + 1; k < j; k++)
                    {
                        if (grid[i][k] == '0')
                        {
                            dp[i, k] += count;
                        }
                    }
                    s = j;
                    j = s + 1;
                }
            }
            for (int i = 0; i < n; i++)
            {
                int s = -1;
                int j = s + 1;
                while (j < m)
                {
                    int count = 0;
                    while (j < m && grid[j][i] != 'W')
                    {
                        count += (grid[j][i] == 'E' ? 1 : 0);
                        j++;
                    }
                    for (int k = s + 1; k < j; k++)
                    {
                        if (grid[k][i] == '0')
                        {
                            dp[k, i] += count;
                        }
                    }
                    s = j;
                    j = s + 1;
                }
            }
            int ans = -1;
            foreach (var val in dp)
            {
                ans = Math.Max(ans, val);
            }
            return ans;
        }
    }
}
