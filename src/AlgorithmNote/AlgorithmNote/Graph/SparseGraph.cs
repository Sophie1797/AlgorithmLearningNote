using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmNote.Graph
{
    /// <summary>
    /// 用邻接表实现稀疏图
    /// </summary>
    public class SparseGraph<TWeight> : IGraph<TWeight> where TWeight : IComparable
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
        public SparseGraph(int n, bool directed)
        {
            V = n;
            E = 0;
            Directed = directed;
            for (var i = 0; i < n; i++)
            {
                graph.Add(new List<Edge<TWeight>>());
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

            graph[v].Add(new Edge<TWeight>(v, w, weight));
            //如果是自环边，而且是无向图，不需要再添加一次反向的边
            if (v != w && !Directed)
            {
                graph[w].Add(new Edge<TWeight>(v, w, weight));
            }

            E++;
        }

        /// <summary>
        /// 判断是否有平行边，O(n)
        /// </summary>
        public bool HasEdge(int v, int w)
        {
            if (v < 0 || v >= V || w < 0 || w >= V)
            {
                throw new ArgumentException("Vertex value invalid!");
            }

            for (var i = 0; i < graph[v].Count; i++)
            {
                if (graph[v][i].W == w)
                {
                    return true;
                }
            }

            return false;
        }

        public void Show()
        {
            for (var i = 0; i < V; i++)
            {
                Console.Write($"vertex {i}:\t");
                for (var j = 0; j < graph[i].Count; j++)
                {
                    Console.Write($"to:{graph[i][j].Other(i)},wt:{graph[i][j].Weight}\t");
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
            private SparseGraph<TWeight> G;
            private int v;
            private int index;

            public AdjIterator(SparseGraph<TWeight> graph, int v)
            {
                G = graph;
                this.v = v;
            }

            public Edge<TWeight> Begin()
            {
                index = 0;
                if (G.graph[v].Count != 0)
                {
                    return G.graph[v][index];
                }

                return null;
            }

            public Edge<TWeight> Next()
            {
                index++;
                if (index < G.graph[v].Count)
                {
                    return G.graph[v][index];
                }

                return null;
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
