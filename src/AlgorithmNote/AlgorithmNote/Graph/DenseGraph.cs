using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmNote
{
    /// <summary>
    /// 用邻接矩阵实现稠密图
    /// </summary>
    public class DenseGraph
    {
        private int n, m;
        private bool directed;//表示这个图是有向图还是无向图
        private List<List<bool>> graph;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="n">顶点个数</param>
        /// <param name="directed">指示这个图是有向图还是无向图</param>
        public DenseGraph(int n, bool directed)
        {
            this.n = n;
            this.directed = directed;
            for (var i = 0; i < n; i++)
            {
                graph.Add(new List<bool>(n));
            }
        }

        /// <summary>
        /// 得到图中顶点的个数
        /// </summary>
        /// <returns></returns>
        public int V()
        {
            return n;
        }

        /// <summary>
        /// 得到图中边的条数
        /// </summary>
        /// <returns></returns>
        public int E()
        {
            return m;
        }

        /// <summary>
        /// 给图中添加一条边
        /// </summary>
        /// <param name="v"></param>
        /// <param name="w"></param>
        public void AddEdge(int v, int w)
        {
            graph[v][w] = true;
        }
    }
}
