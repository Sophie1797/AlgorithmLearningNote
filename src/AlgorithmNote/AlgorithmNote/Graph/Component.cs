using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmNote
{
    public class Component
    {
        private IGraph G;
        private bool[] visited;//记录每个节点是否被访问过
        private int cCount;//记录有多少个连通分量
        private int[] id;//记录每个节点所属连通分量的编号

        public Component(IGraph graph)
        {
            G = graph;
            visited = new bool[G.V()];
            id = new int[G.V()];

            for (var i = 0; i < G.V(); i++)
            {
                id[i] = -1;
            }

            for (var i = 0; i < G.V(); i++)
            {
                if (!visited[i])
                {
                    dfs(i);
                    cCount++; //一次dfs把连接的都访问了，没访问的就是在别的连通分量里面，所以一次dfs后就可以把cCount++
                }
            }
        }

        private void dfs(int v)
        {
            visited[v] = true;
            id[v] = cCount;//给v加上连通分量编号
            var adj = G.GetAdjIterator(v);
            foreach (int w in adj)
            {
                if (!visited[w])
                {
                    dfs(w);
                }
            }
        }

        public int Count()
        {
            return cCount;
        }

        public bool IsConnected(int v, int w)
        {
            if (v < 0 || v >= G.V() || w < 0 || w >= G.V())
            {
                throw new ArgumentException("Vertex value invalid!");
            }

            return id[v] == id[w];
        }
    }
}
