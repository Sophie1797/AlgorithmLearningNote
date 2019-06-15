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
            string fileName = @"Graph\testG2.txt";
            var g1 = new SparseGraph(7, false);
            var gr1 = new ReadGraph(g1, fileName);
            g1.Show();
            var path = new ShortestPath(g1, 0);
            Console.WriteLine("BFS: ");
            path.ShowPath(6);
        }        
    }
}
