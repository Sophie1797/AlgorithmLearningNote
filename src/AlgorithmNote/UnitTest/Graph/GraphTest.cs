using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgorithmNote;
using AlgorithmNote.Graph;

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

        public void ReadGraphTest()
        {
            string fileName = @"Graph\testG1.txt";

            var g1 = new SparseGraph(13, false);
            var rg1 = new ReadGraph(g1, fileName);
            g1.Show();

            var g2 = new DenseGraph(13, false);
            var rg2 = new ReadGraph(g2, fileName);
            g2.Show();
        }

        public void ComponentTest()
        {
            string fileName = @"Graph\testG1.txt";
            var g1 = new SparseGraph(13, false);
            var gr1 = new ReadGraph(g1, fileName);
            var component1 = new Component(g1);
            Console.WriteLine(component1.Count());
        }

        public void PathTest()
        {
            string fileName = @"Graph\testG2.txt";
            var g1 = new SparseGraph(7, false);
            var gr1 = new ReadGraph(g1, fileName);
            g1.Show();
            var path = new Path(g1, 0);
            Console.WriteLine("DFS: ");
            path.ShowPath(6);
        }
    }
}
