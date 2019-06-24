using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmNote.Graph
{
    public class SetCount
    {
        public static int FindCircleNum(int[,] M)
        {
            var uf = new UnionFind(M.GetLength(0));
            for (var i = 0; i < M.GetLength(0); i++)
            {
                for (var j = 0; j < M.GetLength(1); j++)
                {
                    if (M[i,j] == 1)
                    {
                        uf.UnionElements(i, j);
                    }
                }
            }
            return uf.Count;
        }

        public int RegionsBySlashes(string[] grid)
        {
            int n = grid.Length;
            var unionSet = new UnionFind(4 * n * n);
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    int start = 4 * (i * n + j);
                    switch (grid[i][j])
                    {
                        case '/':
                            unionSet.UnionElements(start, start + 3);
                            unionSet.UnionElements(start + 1, start + 2);
                            break;
                        case '\\':
                            unionSet.UnionElements(start, start + 1);
                            unionSet.UnionElements(start + 2, start + 3);
                            break;
                        case ' ':
                            unionSet.UnionElements(start, start + 1);
                            unionSet.UnionElements(start + 1, start + 2);
                            unionSet.UnionElements(start + 2, start + 3);
                            break;
                    }
                    if (i > 0)
                    {
                        unionSet.UnionElements(start, start - 4 * n + 2);
                    }
                    if (j > 0)
                    {
                        unionSet.UnionElements(start + 3, start - 3);
                    }
                }
            }
            return unionSet.Count;
        }
    }
}
