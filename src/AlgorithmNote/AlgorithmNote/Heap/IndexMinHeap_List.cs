using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmNote
{
    /// <summary>
    /// Index heap可以追踪每一个元素的下标
    /// </summary>
    public class IndexMinHeap_List<T> where T : IComparable
    {
        private List<T> data;// 最小索引堆中的数据
        private List<int> indexes;// 记录数据最开始的下标，下标入堆
        private List<int> reverse;// 最小索引堆中的反向索引, reverse[i] = x 表示索引i在x的位置
        private int capacity;

        // 构造函数, 构造一个空堆, 可容纳capacity个元素
        public IndexMinHeap_List(int capacity)
        {
            data = new List<T>(capacity + 1);
            indexes = new List<int>(capacity + 1);
            reverse = new List<int>(capacity + 1);

            this.capacity = capacity;
        }

        // 返回索引堆中的元素个数
        public int Size()
        {
            return data.Count;
        }

        // 返回一个布尔值, 表示索引堆中是否为空
        public bool IsEmpty()
        {
            return data.Count == 0;
        }

        // 向最小索引堆中插入一个新的元素
        public void Add(T T)
        {
            if (data.Count + 1 > capacity)
            {
                throw new ArgumentException("Wrong argument");
            }

            data.Add(T);
            indexes.Add(data.Count - 1);
            reverse.Add(data.Count - 1);

            ShiftUp(indexes.Count - 1);
        }

        // 从最小索引堆中取出堆顶元素, 即索引堆中所存储的最小数据
        public T ExtractMin()
        {
            if (indexes.Count <= 0)
            {
                throw new ArgumentException("Wrong count value");
            }

            T ret = data[indexes[0]];
            SwapIndexes(0, indexes.Count - 1);
            reverse[indexes.Last()] = -1;
            indexes.RemoveAt(indexes.Count - 1);
            ShiftDown(0);

            return ret;
        }

        // 从最小索引堆中取出堆顶元素的索引
        public int ExtractMinIndex()
        {
            if (indexes.Count <= 0)
            {
                throw new ArgumentException("Wrong count value");
            }

            int ret = indexes[0];
            SwapIndexes(0, indexes.Count - 1);
            reverse[indexes.Last()] = -1;
            indexes.RemoveAt(indexes.Count - 1);
            ShiftDown(0);

            return ret;
        }

        // 获取最小索引堆中的堆顶元素
        public T GetMin()
        {
            if (indexes.Count <= 0)
            {
                throw new ArgumentException("Wrong count value");
            }

            return data[indexes[0]];
        }

        // 获取最小索引堆中的堆顶元素的索引
        public int GetMinIndex()
        {
            if (indexes.Count <= 0)
            {
                throw new ArgumentException("Wrong count value");
            }

            return indexes[0];
        }

        // 看索引i所在的位置是否存在元素
        bool Contain(int i)
        {
            if (i + 1 < 1 || i + 1 > reverse.Count)
            {
                throw new ArgumentException("Value out of range!");
            }

            return reverse[i] != -1;
        }

        // 获取最小索引堆中索引为i的元素
        public T GetT(int i)
        {
            if (!Contain(i))
            {
                throw new ArgumentException("There is no value in index i");
            }

            return data[i];
        }

        // 将最小索引堆中索引为i的元素修改为newT
        public void Change(int i, T newT)
        {
            if (!Contain(i))
            {
                throw new ArgumentException("There is no value in index i");
            }

            data[i] = newT;

            // 有了 reverse 之后,
            // 我们可以非常简单的通过reverse直接定位索引i在indexes中的位置
            ShiftUp(reverse[i]);
            ShiftDown(reverse[i]);
        }

        // 交换索引堆中的索引i和j
        // 由于有了反向索引reverse数组，
        // indexes数组发生改变以后， 相应的就需要维护reverse数组
        private void SwapIndexes(int i, int j)
        {
            int t = indexes[i];
            indexes[i] = indexes[j];
            indexes[j] = t;

            reverse[indexes[i]] = i;
            reverse[indexes[j]] = j;
        }

        //********************
        //* 最小索引堆核心辅助函数
        //********************

        // 索引堆中, 数据之间的比较根据data的大小进行比较, 但实际操作的是索引
        private void ShiftUp(int k)
        {
            while (k > 0 && data[indexes[(k - 1) / 2]].CompareTo(data[indexes[k]]) > 0)
            {
                SwapIndexes(k, (k - 1) / 2);
                k = (k - 1) / 2;
            }
        }

        // 索引堆中, 数据之间的比较根据data的大小进行比较, 但实际操作的是索引
        private void ShiftDown(int k)
        {
            while (2 * (k + 1) - 1 < indexes.Count)
            {
                int j = 2 * (k + 1) - 1;
                if (j + 1 < indexes.Count && data[indexes[j + 1]].CompareTo(data[indexes[j]]) < 0)
                    j++;

                if (data[indexes[k]].CompareTo(data[indexes[j]]) <= 0)
                    break;

                SwapIndexes(k, j);
                k = j;
            }
        }
    }
}
