using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgorithmNote;

namespace UnitTest
{
    public class GraphTest
    {
        public static DenseGraph GenerateGraph(int N, int M)
        {
            var random = new Random();
            var g1 = new DenseGraph(N, false);
            //generate edges
            for (var i = 0; i < M; i++)
            {
                int a = random.Next() % N;
                int b = random.Next() % N;
                g1.AddEdge(a, b);
            }

            return g1;
        }

        public static void TestIterator()
        {
            int N = 20;
            int M = 100;
            DenseGraph g1 = GenerateGraph(N, M);
            for (var v = 0; v < M; v++)
            {
                Console.Write(v + " : ");
                var adj = new DenseGraph.AdjIterator(g1, v);

                for (var w = adj.Begin(); !adj.End(); w = adj.Next())
                {
                    Console.Write(w + " ");
                }
                Console.WriteLine("");
            }

            for (var v = 0; v < M; v++)
            {
                Console.Write(v + " : ");
                var adj = new DenseGraph.AdjIterator(g1, v);

                foreach (int g in adj)
                {
                    Console.Write(g + " ");
                }
                Console.WriteLine("");
            }
        }
    }
}
