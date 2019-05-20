using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmNote
{
    public class ArrayStack<T> : IStack<T>
    {
        private ArrayList<T> array;

        public ArrayStack(int capacity)
        {
            array = new ArrayList<T>(capacity);
        }

        public ArrayStack()
        {
            array = new ArrayList<T>();
        }

        public int GetSize()
        {
            return array.GetSize();
        }

        public bool IsEmpty()
        {
            return array.IsEmpty();
        }

        /// <summary>
        /// 只有当栈是用数组实现的时候才有容积这个概念，所以是ArrayStack特有的方法
        /// </summary>
        /// <returns></returns>
        public int GetCapacity()
        {
            return array.GetCapacity();
        }

        public T Peek()
        {
            return array.GetLast();
        }

        public T Pop()
        {
            return array.RemoveLast();
        }

        public void Push(T e)
        {
            array.AddLast(e);
        }

        public override string ToString()
        {
            var res = new StringBuilder();
            res.Append("Stack: \n");
            res.Append('[');
            for (var i = 0; i < array.GetSize(); i++)
            {
                res.Append(array.Get(i));
                if (i != array.GetSize() - 1)
                {
                    res.Append(", ");
                }
            }

            res.Append("] top");
            return res.ToString();
        }
    }
}
