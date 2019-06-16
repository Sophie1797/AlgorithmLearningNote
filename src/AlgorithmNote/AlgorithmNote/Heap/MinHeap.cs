using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmNote
{
    public class MinHeap<T> where T : IComparable
    {
        private ArrayList<T> data;

        public MinHeap(int capacity)
        {
            data = new ArrayList<T>(capacity);
        }

        public MinHeap()
        {
            data = new ArrayList<T>();
        }

        public MinHeap(T[] arr)
        {
            data = new ArrayList<T>(arr);
            for (var i = Parent(arr.Length - 1); i >= 0; i--)
            {
                SiftDown(i);
            }
        }

        /// <summary>
        /// 返回堆中元素个数
        /// </summary>
        /// <returns></returns>
        public int GetSize()
        {
            return data.GetSize();
        }

        /// <summary>
        /// 返回一个布尔值，表示堆中是否为空
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return data.IsEmpty();
        }

        /// <summary>
        /// 返回完全二叉树的数组表示中，一个索引所表示的元素的父亲节点的索引
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private int Parent(int index)
        {
            if (index == 0)
            {
                throw new ArgumentException("Index-0 doesn't have parent.");
            }
            return (index - 1) / 2;
        }

        /// <summary>
        /// 返回完全二叉树的数组表示中，一个索引所表示的元素的左孩子节点的索引
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private int LeftChild(int index)
        {
            return index * 2 + 1;
        }

        /// <summary>
        /// 返回完全二叉树的数组表示中，一个索引所表示的元素的右孩子节点的索引
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private int RightChild(int index)
        {
            return index * 2 + 2;
        }

        /// <summary>
        /// 向堆中添加函数
        /// </summary>
        /// <param name="e"></param>
        public void Add(T e)
        {
            data.AddLast(e);
            SiftUp(data.GetSize() - 1);
        }

        private void SiftUp(int k)
        {
            while (k > 0 && data.Get(Parent(k)).CompareTo(data.Get(k)) > 0)
            {
                data.Swap(k, Parent(k));
                k = Parent(k);
            }
        }

        /// <summary>
        /// 看一眼堆中最小的元素
        /// </summary>
        /// <returns></returns>
        public T FindMin()
        {
            if (data.GetSize() == 0)
            {
                throw new ArgumentException("Can not FindMax when heap is empty..");
            }

            return data.Get(0);
        }

        /// <summary>
        /// 取出堆中最小的元素
        /// </summary>
        /// <returns></returns>
        public T ExtractMin()
        {
            var ret = FindMin();
            data.Swap(0, data.GetSize() - 1);
            data.RemoveLast();
            SiftDown(0);

            return ret;
        }

        private void SiftDown(int k)
        {
            while (LeftChild(k) < data.GetSize())
            {
                // 得到k左右孩最小的那个
                var j = LeftChild(k);
                if (j + 1 < data.GetSize() && data.Get(j + 1).CompareTo(data.Get(j)) < 0)
                {
                    j = RightChild(k);
                }
                // 没有违反堆的性质，k比左右孩子中最小的还小
                if (data.Get(k).CompareTo(data.Get(j)) <= 0)
                {
                    break;
                }
                // 违反了堆性质，k需要下沉
                data.Swap(k, j);
                k = j;
            }
        }

        /// <summary>
        /// 取出堆中最小元素，并且替换成元素e
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public T Replace(T e)
        {
            var ret = FindMin();
            data.Set(0, e);
            SiftDown(0);
            return ret;
        }
    }
}
