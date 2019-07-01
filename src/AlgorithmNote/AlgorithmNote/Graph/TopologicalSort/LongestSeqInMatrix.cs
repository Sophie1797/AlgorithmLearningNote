using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmNote.Graph.TopologicalSort
{
    public class LongestSeqInMatrix
    {
        public int[][] dirs = { new int[] { 0, 1 }, new int[] { 1, 0 }, new int[] { 0, -1 }, new int[] { -1, 0 } };
        public int LongestIncreasingPath(int[,] matrix)
        {
            if (matrix.Length == 0) return 0;
            int m = matrix.GetLength(0), n = matrix.GetLength(1);
            var cache = new int[m, n];
            int max = 1;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    int len = dfs(matrix, i, j, m, n, cache);
                    max = Math.Max(max, len);
                }
            }
            return max;
        }

        public int dfs(int[,] matrix, int i, int j, int m, int n, int[,] cache)
        {
            if (cache[i, j] != 0) return cache[i, j];
            int max = 1;
            foreach (var dir in dirs)
            {
                int x = i + dir[0], y = j + dir[1];
                if (x < 0 || x >= m || y < 0 || y >= n || matrix[x, y] <= matrix[i, j]) continue;
                int len = 1 + dfs(matrix, x, y, m, n, cache);
                max = Math.Max(max, len);
            }
            cache[i, j] = max;
            return max;
        }
    }
}
