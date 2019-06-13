using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmNote
{
    public interface IGraph
    {
        void AddEdge(int v, int w);
        bool HasEdge(int v, int w);
        int V();
        int E();
        IEnumerable GetAdjIterator(int v);
    }
}
