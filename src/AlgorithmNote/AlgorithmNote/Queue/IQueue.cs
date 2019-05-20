using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmNote
{
    public interface IQueue<T>
    {
        int GetSize();
        bool IsEmpty();
        void Enqueue(T e);
        T Dequeue();
        T GetFront();
    }
}
