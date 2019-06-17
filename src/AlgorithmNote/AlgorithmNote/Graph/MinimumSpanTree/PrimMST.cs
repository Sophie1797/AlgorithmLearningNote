using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmNote.Graph
{
    public class PrimMST<TWeight> where TWeight : IComparable
    {
        private IGraph<TWeight> G;
        private IndexMinHeap<TWeight> ipq;
        public Edge<TWeight>[] EdgeTo { get; private set; }
        private bool[] marked;//记录节点是否被访问了
        public List<Edge<TWeight>> MSTEdges { get; private set; }//记录mst中的v-1条边
        public TWeight MSTWeight { get; private set; }

        public PrimMST(IGraph<TWeight> graph)
        {
            G = graph;
            ipq = new IndexMinHeap<TWeight>(G.V);
            marked = new bool[G.V];
            MSTEdges = new List<Edge<TWeight>>();
            EdgeTo = new Edge<TWeight>[G.V];

            // Prim
            Visit(0);
            while (!ipq.IsEmpty())
            {
                var v = ipq.ExtractMinIndex();
                if (EdgeTo[v] == null) continue;
                MSTEdges.Add(EdgeTo[v]);
                Visit(v);
            }

            var value = 0.0;
            var converter = TypeDescriptor.GetConverter(typeof(TWeight));
            foreach (var edge in MSTEdges)
            {
                value += (double)converter.ConvertTo(edge.Weight, typeof(double));
            }
            MSTWeight = (TWeight)converter.ConvertTo(value, typeof(TWeight));
        }

        private void Visit(int v)
        {
            if (!marked[v])
            {
                marked[v] = true;
                foreach (Edge<TWeight> e in G.GetAdjIterator(v))
                {
                    var w = e.Other(v);
                    if (!marked[w])
                    {
                        if (EdgeTo[w]==null)
                        {
                            ipq.Insert(w, e.Weight);
                            EdgeTo[w] = e;
                        }
                        else if (e.Weight.CompareTo(EdgeTo[w].Weight) < 0)
                        {
                            EdgeTo[w] = e;
                            ipq.Change(w, e.Weight);
                        }
                    }
                }
            }
        }
    }
}
