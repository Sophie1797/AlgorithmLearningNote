using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmNote
{
    public class LinkedListStack<T>: IStack<T>
    {
        private LinkedList<T> list;

        public LinkedListStack()
        {
            list = new LinkedList<T>();
        }

        public int GetSize()
        {
            return list.GetSize();
        }

        public bool IsEmpty()
        {
            return list.IsEmpty();
        }

        public void Push(T e)
        {
            list.AddFirst(e);
        }

        public T Pop()
        {
            return list.RemoveFirst();
        }

        public T Peek()
        {
            return list.GetFirst();
        }

        public override string ToString()
        {
            var res=  new StringBuilder();
            res.Append("Stack: top ");
            res.Append(list);
            return res.ToString();
        }
    }
}
