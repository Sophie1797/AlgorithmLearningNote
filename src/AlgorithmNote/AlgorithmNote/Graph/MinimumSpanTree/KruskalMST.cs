using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmNote.Graph
{
    public class KruskalMST<TWeight> where TWeight : IComparable
    {
        private IGraph<TWeight> G;
        private IndexMinHeap<Edge<TWeight>> ipq;
        private bool[] marked; //记录节点是否被访问了

        public List<Edge<TWeight>> MSTEdges { get; private set; } //记录mst中的v-1条边
        public TWeight MSTWeight { get; private set; }

        public KruskalMST(IGraph<TWeight> graph)
        {
            G = graph;
            ipq = new IndexMinHeap<Edge<TWeight>>(2*G.E);
            marked = new bool[G.V];
            MSTEdges = new List<Edge<TWeight>>();

            for (var i = 0; i < G.V; i++)
            {
                foreach (Edge<TWeight> e in G.GetAdjIterator(i))
                {
                    ipq.Add(e);
                }
            }

            var uf = new UnionFind(G.V);
            while (!ipq.IsEmpty() && MSTEdges.Count < graph.V - 1)
            {
                var e = ipq.ExtractMin();
                if (uf.IsConnected(e.V, e.W))
                {
                    continue;
                }

                MSTEdges.Add(e);
                uf.UnionElements(e.V, e.W);
            }

            var value = 0.0;
            var converter = TypeDescriptor.GetConverter(typeof(TWeight));
            foreach (var edge in MSTEdges)
            {
                value += (double)converter.ConvertTo(edge.Weight, typeof(double));
            }
            MSTWeight = (TWeight)converter.ConvertTo(value, typeof(TWeight));
        }
    }
}
