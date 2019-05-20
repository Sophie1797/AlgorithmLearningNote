
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmNote
{
    public class LoopQueue<T> : IQueue<T>
    {
        private T[] data;
        private int front, tail;
        private int size;

        public LoopQueue(int capacity)
        {
            data = new T[capacity + 1]; //loop queue need an extra space unit
        }

        public LoopQueue()
        {
            data = new T[11];
        }

        /// <summary>
        /// Get data array capacity, one unit needs to be empty, so the total capacity is length-1
        /// </summary>
        /// <returns></returns>
        public int GetCapacity()
        {
            return data.Length - 1;
        }

        public int GetSize()
        {
            return size;
        }

        public bool IsEmpty()
        {
            return front == tail;
        }

        public T Dequeue()
        {
            if (IsEmpty())
            {
                throw new ArgumentException("Cannot dequeue from an empty queue.");
            }

            var ret = data[front];
            data[front] = default(T);
            front = (front + 1) % data.Length;
            size--;
            if (size == GetCapacity() / 4 && GetCapacity() / 2 != 0)
            {
                Resize(GetCapacity() / 2);
            }
            return ret;
        }

        public void Enqueue(T e)
        {
            if ((tail + 1) % data.Length == front)
            {
                Resize(GetCapacity() * 2);
            }

            data[tail] = e;
            tail = (tail + 1) % data.Length;
            size++;
        }

        public T GetFront()
        {
            if (IsEmpty())
            {
                throw new ArgumentException("Cannot dequeue from an empty queue.");
            }

            return data[front];
        }

        private void Resize(int newCapacity)
        {
            var newData = new T[newCapacity + 1];
            for (var i = 0; i < size; i++)
            {
                newData[i] = data[(i + front) % data.Length];
            }

            data = newData;
            front = 0;
            tail = size;
        }

        public override string ToString()
        {
            var res = new StringBuilder();
            res.Append($"Queue: size = {size}, capacity = {GetCapacity()}\n");
            res.Append("front [");
            for (var i = front; i != tail; i = (i + 1) % data.Length)
            {
                res.Append(data[i]);
                if ((i + 1) % data.Length != tail)
                {
                    res.Append(", ");
                }
            }

            res.Append("] tail");
            return res.ToString();
        }
    }
}
