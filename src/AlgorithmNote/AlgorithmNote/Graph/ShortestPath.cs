using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmNote.Graph
{
    public class ShortestPath<TWeight> where TWeight : IComparable
    {
        private IGraph<TWeight> G;
        private int s;
        private bool[] visited;
        private int[] from;
        private int[] ord;//order,记录最短距离

        public ShortestPath(IGraph<TWeight> graph, int s)
        {
            //算法初始化
            G = graph;
            this.s = s;
            if (s < 0 || s >= G.V)
            {
                throw new ArgumentException("Vertex value invalid!");
            }
            visited = new bool[graph.V];
            @from = new int[graph.V];
            ord = new int[graph.V];
            for (var i = 0; i < graph.V; i++)
            {
                @from[i] = -1;
                ord[i] = -1;
            }

            var queue = new Queue<int>();
            //无向图最短路径算法
            queue.Enqueue(s);
            visited[s] = true;
            ord[s] = 0;
            while (queue.Count != 0)
            {
                var v = queue.Dequeue();
                var adjIter = G.GetAdjIterator(v);
                foreach (int w in adjIter)
                {
                    if (!visited[w])
                    {
                        queue.Enqueue(w);
                        visited[w] = true;
                        @from[w] = v;
                        ord[w] = ord[v] + 1;//注意此处要加一
                    }
                }
            }
        }

        /// <summary>
        /// 查看s到w是否有路径
        /// </summary>
        public bool HasPath(int w)
        {
            if (w < 0 || w >= G.V)
            {
                throw new ArgumentException("Vertex value invalid!");
            }

            return visited[w];
        }

        /// <summary>
        /// 得到路径序列
        /// </summary>
        public void GetPath(int w, List<int> vec)
        {
            if (w < 0 || w >= G.V)
            {
                throw new ArgumentException("Vertex value invalid!");
            }

            var stack = new Stack<int>();
            int p = w;
            while (p != -1)
            {
                stack.Push(p);
                p = from[p];
            }

            while (stack.Count != 0)
            {
                vec.Add(stack.Pop());
            }
        }

        /// <summary>
        /// 打印路径
        /// </summary>
        public void ShowPath(int w)
        {
            if (w < 0 || w >= G.V)
            {
                throw new ArgumentException("Vertex value invalid!");
            }

            var vec = new List<int>();
            GetPath(w, vec);
            for (var i = 0; i < vec.Count; i++)
            {
                if (i != vec.Count - 1)
                {
                    Console.Write(vec[i] + "->");
                }
                else
                {
                    Console.WriteLine(vec[i]);
                }
            }
        }

        /// <summary>
        /// 查询s到w的最短路径是多少
        /// </summary>
        public int Length(int w)
        {
            if (w < 0 || w >= G.V)
            {
                throw new ArgumentException("Vertex value invalid!");
            }

            return ord[w];
        }
    }
}
