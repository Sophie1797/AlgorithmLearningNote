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
    public class DenseGraph<TWeight> : IGraph<TWeight> where TWeight : IComparable
    {
        private List<List<Edge<TWeight>>> graph = new List<List<Edge<TWeight>>>();

        public int V { get; private set; }
        public int E { get; private set; }
        public bool Directed { get; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="n">顶点个数</param>
        /// <param name="directed">指示这个图是有向图还是无向图</param>
        public DenseGraph(int n, bool directed)
        {
            V = n;
            E = 0;
            Directed = directed;
            for (var i = 0; i < n; i++)
            {
                //这种写法可以在规定list长度而且后面可以直接用方括号索引
                graph.Add(new List<Edge<TWeight>>(new Edge<TWeight>[n]));
            }
        }

        /// <summary>
        /// 给图中添加一条边
        /// </summary>
        public void AddEdge(int v, int w, TWeight weight)
        {
            if (v < 0 || v >= V || w < 0 || w >= V)
            {
                throw new ArgumentException("Vertex value invalid!");
            }

            graph[v][w] = new Edge<TWeight>(v, w, weight);
            //如果是无向图，则反向边也需要设置
            if (!Directed)
            {
                graph[w][v] = new Edge<TWeight>(w, v, weight);
            }

            E++;
        }

        /// <summary>
        /// 判断是否有平行边
        /// </summary>
        public bool HasEdge(int v, int w)
        {
            if (v < 0 || v >= V || w < 0 || w >= V)
            {
                throw new ArgumentException("Vertex value invalid!");
            }

            return graph[v][w] != null;
        }

        public void Show()
        {
            for (var i = 0; i < V; i++)
            {
                for (var j = 0; j < V; j++)
                {
                    if (graph[i][j] != null)
                    {
                        Console.Write(graph[i][j].Weight + "\t");
                    }
                    else
                    {
                        Console.Write("NULL\t");
                    }
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
            private DenseGraph<TWeight> G;
            private int v;
            private int index;

            public AdjIterator(DenseGraph<TWeight> graph, int v)
            {
                G = graph;
                this.v = v;
                index = -1;
            }

            public Edge<TWeight> Begin()
            {
                index = -1;
                return Next();
            }

            public Edge<TWeight> Next()
            {
                for (index += 1; index < G.V; index++)
                {
                    if (G.graph[v][index] != null)
                    {
                        return G.graph[v][index];
                    }
                }

                return null;
            }

            public bool End()
            {
                return index >= G.V;
            }

            public IEnumerator GetEnumerator()
            {
                for (var i = 0; i < G.V; i++)
                {
                    if (G.graph[v][i] != null)
                    {
                        yield return G.graph[v][i];
                    }
                }
            }
        }
    }
}
