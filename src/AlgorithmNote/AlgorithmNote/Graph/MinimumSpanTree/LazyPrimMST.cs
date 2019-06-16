using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmNote.Graph
{
    public class LazyPrimMST<TWeight> where TWeight:IComparable
    {
        private IGraph<TWeight> G;
        private MinHeap<Edge<TWeight>> pq;
        private bool[] marked;//记录节点是否被访问了
        public List<Edge<TWeight>> MSTEdges { get; private set; }//记录mst中的v-1条边
        public TWeight MSTWeight { get; private set; }

        public LazyPrimMST(IGraph<TWeight> graph, MinHeap<Edge<TWeight>> pq)
        {
            G = graph;
            this.pq = pq;
            marked = new bool[G.V];
            MSTEdges = new List<Edge<TWeight>>();

            // Lazy Prim
            Visit(0);
            while (!pq.IsEmpty())
            {
                var e = pq.ExtractMin();
                // 如果都访问过了，说明不是横切边
                if (marked[e.V] == marked[e.W])
                {
                    continue;
                }

                MSTEdges.Add(e);
                if (!marked[e.V])
                {
                    Visit(e.V);
                }
                else
                {
                    Visit(e.W);
                }
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
                    if (!marked[e.Other(v)])
                    {
                        pq.Add(e);
                    }
                }
            }
        }
    }
}
