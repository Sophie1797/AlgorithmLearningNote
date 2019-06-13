using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmNote
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = @"Graph\testG1.txt";

            var g1 = new SparseGraph(13, false);
            var rg1 = new ReadGraph(g1, fileName);
            g1.Show();

            var g2 = new DenseGraph(13, false);
            var rg2 = new ReadGraph(g2, fileName);
            g2.Show();
        }        
    }
}
