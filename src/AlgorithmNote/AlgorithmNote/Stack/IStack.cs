using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmNote
{
    public interface IStack<T>
    {
        int GetSize();
        bool IsEmpty();
        void Push(T e);
        T Pop();
        T Peek();
    }
}
