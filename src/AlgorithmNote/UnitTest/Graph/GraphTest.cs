using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgorithmNote;
using AlgorithmNote.Graph;

namespace UnitTest
{
    public class GraphTest
    {
        public static DenseGraph<double> GenerateGraph(int N, int M)
        {
            var random = new Random();
            var g1 = new DenseGraph<double>(N, false);
            //generate edges
            for (var i = 0; i < M; i++)
            {
                int a = random.Next() % N;
                int b = random.Next() % N;
                g1.AddEdge(a, b, 0);
            }

            return g1;
        }

        public static void TestIterator()
        {
            int N = 20;
            int M = 100;
            var g1 = GenerateGraph(N, M);
            for (var v = 0; v < M; v++)
            {
                Console.Write(v + " : ");
                var adj = new DenseGraph<double>.AdjIterator(g1, v);

                for (var w = adj.Begin(); !adj.End(); w = adj.Next())
                {
                    Console.Write(w + " ");
                }
                Console.WriteLine("");
            }

            for (var v = 0; v < M; v++)
            {
                Console.Write(v + " : ");
                var adj = new DenseGraph<double>.AdjIterator(g1, v);

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

            var g1 = new SparseGraph<double>(13, false);
            var rg1 = new ReadGraph<double>(g1, fileName);
            g1.Show();

            var g2 = new DenseGraph<double>(13, false);
            var rg2 = new ReadGraph<double>(g2, fileName);
            g2.Show();
        }

        public void ComponentTest()
        {
            string fileName = @"Graph\testG1.txt";
            var g1 = new SparseGraph<double>(13, false);
            var gr1 = new ReadGraph<double>(g1, fileName);
            var component1 = new Component<double>(g1);
            Console.WriteLine(component1.Count());
        }

        public void PathTest()
        {
            string fileName = @"Graph\testG2.txt";
            var g1 = new SparseGraph<double>(7, false);
            var gr1 = new ReadGraph<double>(g1, fileName);
            g1.Show();
            var path = new Path<double>(g1, 0);
            Console.WriteLine("DFS: ");
            path.ShowPath(6);
        }

        public void ShortestPathTest()
        {
            string fileName = @"Graph\testG2.txt";
            var g1 = new SparseGraph<double>(7, false);
            var gr1 = new ReadGraph<double>(g1, fileName);
            g1.Show();
            var path = new ShortestPath<double>(g1, 0);
            Console.WriteLine("BFS: ");
            path.ShowPath(6);
        }
    }
}
