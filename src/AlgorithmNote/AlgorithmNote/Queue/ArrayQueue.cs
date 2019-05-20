using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmNote
{
    public class ArrayQueue<T> : IQueue<T>
    {
        private ArrayList<T> array;

        public ArrayQueue(int capacity)
        {
            array = new ArrayList<T>(capacity);
        }

        public ArrayQueue()
        {
            array = new ArrayList<T>();
        }

        public int GetSize()
        {
            return array.GetSize();
        }

        public int GetCapacity()
        {
            return array.GetCapacity();
        }

        public bool IsEmpty()
        {
            return array.IsEmpty();
        }

        public T Dequeue()
        {
            return array.RemoveFirst();
        }

        public void Enqueue(T e)
        {
            array.AddLast(e);
        }

        public T GetFront()
        {
            return array.GetFirst();
        }

        public override string ToString()
        {
            var res = new StringBuilder();
            res.Append("Queue: \n");
            res.Append("front [");
            for (var i = 0; i < array.GetSize(); i++)
            {
                res.Append(array.Get(i));
                if (i != array.GetSize() - 1)
                {
                    res.Append(", ");
                }
            }

            res.Append("] tail");
            return res.ToString();
        }
    }
}
