using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmNote.Graph
{
    /// <summary>
    /// 用邻接矩阵实现稠密图
    /// </summary>
    public class DenseGraph: IGraph
    {
        private int n, m;//n:顶点的个数，m:边的个数
        private bool directed;//表示这个图是有向图还是无向图
        private List<List<bool>> graph = new List<List<bool>>();

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
                graph.Add(new List<bool>(new bool[n]));
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

            //如果v和w已经有一条边了，就直接return
            if (HasEdge(v, w))
            {
                return;
            }

            graph[v][w] = true;
            //如果是无向图，则反向边也需要设置
            if (!directed)
            {
                graph[w][v] = true;
            }

            m++;
        }

        /// <summary>
        /// 判断是否有平行边
        /// </summary>
        public bool HasEdge(int v, int w)
        {
            if (v < 0 || v >= n || w < 0 || w >= n)
            {
                throw new ArgumentException("Vertex value invalid!");
            }

            return graph[v][w];
        }

        public void Show()
        {
            for (var i = 0; i < n; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    var value = graph[i][j] ? 1 : 0;
                    Console.Write(value + "\t");
                }
                Console.WriteLine();
            }
        }

        public IEnumerable GetAdjIterator(int v)
        {
            return new AdjIterator(this, v);
        }

        public class AdjIterator : IEnumerable
        {
            private DenseGraph G;
            private int v;
            private int index;

            public AdjIterator(DenseGraph graph, int v)
            {
                G = graph;
                this.v = v;
                index = -1;
            }

            public int Begin()
            {
                index = -1;
                return Next();
            }

            public int Next()
            {
                for (index += 1; index < G.V(); index++)
                {
                    if (G.graph[v][index])
                    {
                        return index;
                    }
                }

                return -1;
            }

            public bool End()
            {
                return index >= G.V();
            }

            public IEnumerator GetEnumerator()
            {
                for (var i = 0; i < G.V(); i++)
                {
                    if (G.graph[v][i])
                    {
                        yield return i;
                    }
                }
            }
        }
    }
}
