using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmNote.Graph
{
    public class Edge<TWeight> where TWeight:IComparable
    {
        public int V { get; }
        public int W { get; }
        public TWeight Weight { get; }

        public Edge() { }

        public Edge(int a, int b, TWeight weight)
        {
            V = a;
            W = b;
            Weight = weight;
        }

        public int Other(int x)
        {
            if (x != V && x != W)
            {
                throw new ArgumentException("Vertex value invalid!");
            }

            return x == V ? W : V;
        }

        public override string ToString()
        {
            return V + " - " + W + ": " + Weight;
        }

        public bool CompareTo(Edge<TWeight> e)
        {
            return Weight.CompareTo(e.Weight) < 0;
        }
    }
}
