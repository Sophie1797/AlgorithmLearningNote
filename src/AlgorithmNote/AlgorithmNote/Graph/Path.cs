using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmNote.Graph
{
    public class Path
    {
        private IGraph G;
        private int s;//source节点
        private bool[] visited;//记录是否访问过
        private int[] from;//记录上一个访问的

        public Path(IGraph graph, int s)
        {
            // 算法初始化
            G = graph;
            this.s = s;
            if (s < 0 || s >= G.V())
            {
                throw new ArgumentException("Vertex value invalid!");
            }

            visited = new bool[G.V()];
            from = new int[G.V()];
            for (var i = 0; i < G.V(); i++)
            {
                from[i] = -1;
            }

            //寻路算法
            dfs(s);
        }

        private void dfs(int v)
        {
            visited[v] = true;
            var adj = G.GetAdjIterator(v);
            foreach (int w in adj)
            {
                if (!visited[w])
                {
                    from[w] = v;
                    dfs(w);
                }
            }
        }

        /// <summary>
        /// 查看s到w是否有路径
        /// </summary>
        public bool HasPath(int w)
        {
            if (w < 0 || w >= G.V())
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
            if (w < 0 || w >= G.V())
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
    }
}
