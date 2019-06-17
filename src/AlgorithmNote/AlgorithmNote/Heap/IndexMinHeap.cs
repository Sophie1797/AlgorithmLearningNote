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
    public class IndexMinHeap<T> where T : IComparable
    {
        private T[] data;// 最小索引堆中的数据
        private int[] indexes;// 最小索引堆中的索引, indexes[x] = i 表示索引i在x的位置
        private int[] reverse;// 最小索引堆中的反向索引, reverse[i] = x 表示索引i在x的位置
        private int count;// 记录索引堆中的元素个数
        private int capacity;

        // 构造函数, 构造一个空堆, 可容纳capacity个元素
        public IndexMinHeap(int capacity)
        {
            data = new T[capacity + 1];
            indexes = new int[capacity + 1];
            reverse = new int[capacity + 1];

            this.capacity = capacity;
        }

        // 返回索引堆中的元素个数
        public int Size()
        {
            return count;
        }

        // 返回一个布尔值, 表示索引堆中是否为空
        public bool IsEmpty()
        {
            return count == 0;
        }

        // 向最小索引堆中插入一个新的元素, 新元素的索引为i, 元素为T
        // 传入的i对用户而言,是从0索引的
        public void Insert(int i, T T)
        {
            // 再插入一个新元素前,还需要保证索引i所在的位置是没有元素的。
            if (count + 1 > capacity || i + 1 < 1 || i + 1 > capacity || Contain(i))
            {
                throw new ArgumentException("Wrong argument");
            }            

            i += 1;
            data[i] = T;
            indexes[count + 1] = i;
            reverse[i] = count + 1;
            count++;

            ShiftUp(count);
        }

        // 从最小索引堆中取出堆顶元素, 即索引堆中所存储的最小数据
        public T ExtractMin()
        {
            if (count <= 0)
            {
                throw new ArgumentException("Wrong count value");
            }

            T ret = data[indexes[1]];
            SwapIndexes(1, count);
            reverse[indexes[count]] = 0;
            count--;
            ShiftDown(1);

            return ret;
        }

        // 从最小索引堆中取出堆顶元素的索引
        public int ExtractMinIndex()
        {
            if (count <= 0)
            {
                throw new ArgumentException("Wrong count value");
            }

            int ret = indexes[1] - 1;
            SwapIndexes(1, count);
            reverse[indexes[count]] = 0;
            count--;
            ShiftDown(1);

            return ret;
        }

        // 获取最小索引堆中的堆顶元素
        public T GetMin()
        {
            if (count <= 0)
            {
                throw new ArgumentException("Wrong count value");
            }

            return data[indexes[1]];
        }

        // 获取最小索引堆中的堆顶元素的索引
        public int GetMinIndex()
        {
            if (count <= 0)
            {
                throw new ArgumentException("Wrong count value");
            }

            return indexes[1] - 1;
        }

        // 看索引i所在的位置是否存在元素
        bool Contain(int i)
        {
            if (i + 1 < 1 || i + 1 > capacity)
            {
                throw new ArgumentException("Value out of range!");
            }

            return reverse[i + 1] != 0;
        }

        // 获取最小索引堆中索引为i的元素
        public T GetT(int i)
        {
            if (!Contain(i))
            {
                throw new ArgumentException("There is no value in index i");
            }

            return data[i + 1];
        }

        // 将最小索引堆中索引为i的元素修改为newT
        public void Change(int i, T newT)
        {
            if (!Contain(i))
            {
                throw new ArgumentException("There is no value in index i");
            }

            i += 1;
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
            while (k > 1 && data[indexes[k / 2]].CompareTo(data[indexes[k]]) > 0)
            {
                SwapIndexes(k, k / 2);
                k /= 2;
            }
        }

        // 索引堆中, 数据之间的比较根据data的大小进行比较, 但实际操作的是索引
        private void ShiftDown(int k)
        {
            while (2 * k <= count)
            {
                int j = 2 * k;
                if (j + 1 <= count && data[indexes[j + 1]].CompareTo(data[indexes[j]]) < 0)
                    j++;

                if (data[indexes[k]].CompareTo(data[indexes[j]]) <= 0)
                    break;

                SwapIndexes(k, j);
                k = j;
            }
        }
    }
}
