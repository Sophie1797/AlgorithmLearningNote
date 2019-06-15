using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmNote.Graph
{
    public interface IGraph<TWeight>
    {
        int V { get; }
        int E { get; }

        void AddEdge(int v, int w, TWeight weight);
        bool HasEdge(int v, int w);
        IEnumerable GetAdjIterator(int v);
    }
}
