using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgorithmNote.Graph;

namespace AlgorithmNote
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = @"Graph\testG1.txt";
            var g1 = new SparseGraph<double>(8, false);
            var gr1 = new ReadGraph<double>(g1, fileName);
            g1.Show();

            // test lazy prim
            Console.WriteLine("Test Lazy Prim MST: ");
            var pq = new MinHeap<Edge<double>>();
            var lazyPrimMST = new LazyPrimMST<double>(g1, pq);
            var mst = lazyPrimMST.MSTEdges;
            foreach(var edge in mst)
            {
                Console.WriteLine(edge);
            }
            Console.WriteLine("The MST weight is: " + lazyPrimMST.MSTWeight);
        }        
    }
}
