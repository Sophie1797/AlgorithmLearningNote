using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmNote
{
    public class GraphNode
    {
        public int Vertex { get; set; }
        public int Weight { get; set; }
        public int Color { get; set; }
        public GraphNode Pre { get; set; }

        public GraphNode(int v, int w)
        {
            Vertex = v;
            Weight = w;
        }

        public GraphNode(int v, int w, int c)
        {
            Vertex = v;
            Weight = w;
            Color = c;
        }
    }

    public class UndirectedGraphNode
    {
        public int label;
        public IList<UndirectedGraphNode> neighbors;

        public UndirectedGraphNode(int x)
        {
            label = x;
            neighbors = new List<UndirectedGraphNode>();
        }
    };
}
