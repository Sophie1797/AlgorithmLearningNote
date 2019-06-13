using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmNote
{
    /// <summary>
    /// 用邻接表实现稀疏图
    /// </summary>
    public class SparseGraph: IGraph
    {
        private int n, m;//n:顶点的个数，m:边的个数
        private bool directed;//表示这个图是有向图还是无向图
        private List<List<int>> graph = new List<List<int>>();

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="n">顶点个数</param>
        /// <param name="directed">指示这个图是有向图还是无向图</param>
        public SparseGraph(int n, bool directed)
        {
            this.n = n;
            this.directed = directed;
            for (var i = 0; i < n; i++)
            {
                graph.Add(new List<int>());
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
        public void AddEdge(int v, int w)
        {
            if (v < 0 || v >= n || w < 0 || w >= n)
            {
                throw new ArgumentException("Vertex value invalid!");
            }

            graph[v].Add(w);
            //如果是自环边，而且是无向图，不需要再添加一次反向的边
            if (v != w && !directed)
            {
                graph[w].Add(v);
            }

            m++;
        }

        /// <summary>
        /// 判断是否有平行边，O(n)
        /// </summary>
        public bool HasEdge(int v, int w)
        {
            if (v < 0 || v >= n || w < 0 || w >= n)
            {
                throw new ArgumentException("Vertex value invalid!");
            }

            for (var i = 0; i < graph[v].Count; i++)
            {
                if (graph[v][i] == w)
                {
                    return true;
                }
            }

            return false;
        }

        public void Show()
        {
            for (var i = 0; i < n; i++)
            {
                Console.Write($"vertex {i}:\t");
                for (var j = 0; j < graph[i].Count; j++)
                {
                    Console.Write(graph[i][j] + "\t");
                }
                Console.WriteLine();
            }
        }

        public IEnumerable GetAdjIterator(int v)
        {
            return new AdjIterator(this, v);
        }

        public class AdjIterator: IEnumerable
        {
            private SparseGraph G;
            private int v;
            private int index;

            public AdjIterator(SparseGraph graph, int v)
            {
                G = graph;
                this.v = v;
            }

            public int Begin()
            {
                index = 0;
                if (G.graph[v].Count != 0)
                {
                    return G.graph[v][index];
                }

                return -1;
            }

            public int Next()
            {
                index++;
                if (index < G.graph[v].Count)
                {
                    return G.graph[v][index];
                }

                return -1;
            }

            public bool End()
            {
                return index >= G.graph[v].Count;
            }

            public IEnumerator GetEnumerator()
            {
                foreach (var w in G.graph[v])
                {
                    yield return w;
                }
            }
        }
    }
}
