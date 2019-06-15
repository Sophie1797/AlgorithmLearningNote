using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmNote.Graph
{
    public class ReadGraph<TWeight> where TWeight : IComparable
    {
        public int V, E;
        public ReadGraph(IGraph<TWeight> graph, string fileName)
        {
            var converter = TypeDescriptor.GetConverter(typeof(TWeight));
            var lines = File.ReadAllLines(fileName);
            V = int.Parse(lines[0].Split(' ').First());
            E = int.Parse(lines[0].Split(' ').Last());
            for (var i = 1; i < lines.Length; i++)
            {
                var arr = lines[i].Split(' ');
                var v = int.Parse(arr.First());
                var w = int.Parse(arr[1]);

                var weight = (TWeight)converter.ConvertFrom(arr.Last());
                if (v < 0 || v >= V || w < 0 || w >= V)
                {
                    throw new ArgumentException("Vertex value invalid!");
                }

                graph.AddEdge(v, w, weight);
            }
        }
    }
}
