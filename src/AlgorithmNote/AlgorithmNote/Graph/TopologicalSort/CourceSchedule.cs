using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmNote
{
    /// <summary>
    /// 210. Course Schedule II
    /// </summary>
    public class CourceSchedule
    {
        public int[] Color;
        public List<int> Routinue = new List<int>();
        public int[] FindOrder(int numCourses, int[][] prerequisites)
        {
            var graph = new List<int>[numCourses];
            Color = new int[numCourses];
            for (var i = 0; i < numCourses; i++)
                graph[i] = new List<int>();
            for (var i = 0; i < prerequisites.Length; i++)
                graph[prerequisites[i][1]].Add(prerequisites[i][0]);
            for (var i = 0; i < numCourses; i++)
                if (!DFS(graph, i))
                    return new int[0];

            return Routinue.ToArray();
        }

        public bool DFS(List<int>[] graph, int i)
        {
            if (Color[i] != 0)
                return Color[i] == 2;
            Color[i] = 1;
            for (var j = 0; j < graph[i].Count; j++)
            {
                var u = graph[i][j];
                if (Color[u] == 2) continue;
                if (Color[u] == 1 || !DFS(graph, u))
                    return false;
            }
            Color[i] = 2;
            Routinue.Insert(0, i);
            return true;
        }
    }
}
