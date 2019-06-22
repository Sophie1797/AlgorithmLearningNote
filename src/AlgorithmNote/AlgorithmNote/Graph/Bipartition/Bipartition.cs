using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmNote.Graph
{
    /// <summary>
    /// 785. 判断二分图
    /// </summary>
    public class BipartitionGraph
    {
        Dictionary<int, int> dict = new Dictionary<int, int>();
        public bool IsBipartite(int[][] graph)
        {
            for (var i = 0; i < graph.Length; i++)
            {
                if (!dict.ContainsKey(i) && !Visit(graph, 1, i))
                {
                    return false;
                }
            }
            return true;
        }

        public bool Visit(int[][] graph, int color, int v)
        {
            if (dict.ContainsKey(v))
            {
                return dict[v] == color;
            }

            dict.Add(v, color);
            foreach (var w in graph[v])
            {
                if (!Visit(graph, -color, w))
                    return false;
            }
            return true;
        }
    }

    /// <summary>
    /// 886. 可能的二分法
    /// </summary>
    public class PossibleBipartitionGraph
    {
        List<int>[] graph;
        Dictionary<int, int> color = new Dictionary<int, int>();

        public bool PossibleBipartition(int N, int[][] dislikes)
        {
            graph = new List<int>[N + 1];
            for (int i = 1; i <= N; ++i)
                graph[i] = new List<int>();

            foreach (int[] edge in dislikes)
            {
                graph[edge[0]].Add(edge[1]);
                graph[edge[1]].Add(edge[0]);
            }

            for (int node = 1; node <= N; ++node)
                if (!color.ContainsKey(node) && !dfs(node, 0))
                    return false;
            return true;
        }

        public bool dfs(int node, int c)
        {
            if (color.ContainsKey(node))
                return color[node] == c;
            color.Add(node, c);

            foreach (int nei in graph[node])
                if (!dfs(nei, c ^ 1))
                    return false;
            return true;
        }
    }
}
