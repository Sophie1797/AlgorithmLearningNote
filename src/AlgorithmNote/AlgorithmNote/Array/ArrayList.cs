using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmNote
{
    public class ArrayList<T>
    {
        // 数据数组
        private T[] data;
        // 数组中元素的个数
        private int size;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="capacity">数组容量</param>
        public ArrayList(int capacity)
        {
            data = new T[capacity];
            size = 0;
        }

        /// <summary>
        /// 无参构造函数，默认容量为10
        /// </summary>
        public ArrayList()
        {
            data = new T[10];
            size = 0;
        }

        public ArrayList(T[] arr)
        {
            size = arr.Length;
            data = new T[size];
            Array.Copy(arr, data, size);
        }

        /// <summary>
        /// 获取数组中的元素个数
        /// </summary>
        /// <returns></returns>
        public int GetSize()
        {
            return size;
        }

        /// <summary>
        /// 获取数组的容量
        /// </summary>
        /// <returns></returns>
        public int GetCapacity()
        {
            return data.Length;
        }

        /// <summary>
        /// 返回数组是否为空
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return size == 0;
        }

        /// <summary>
        /// 在所有元素后添加一个新元素
        /// </summary>
        /// <param name="e"></param>
        public void AddLast(T e)
        {
            Add(size, e);
        }

        /// <summary>
        /// 在所有元素前添加一个新元素
        /// </summary>
        /// <param name="e"></param>
        public void AddFirst(T e)
        {
            Add(0, e);
        }

        /// <summary>
        /// 在第index个位置插入一个新元素e
        /// </summary>
        /// <param name="index"></param>
        /// <param name="e"></param>
        public void Add(int index, T e)
        {
            if (index < 0 || index > size)
            {
                throw new IndexOutOfRangeException("Add failed. Require index >= 0 and index <= size.");
            }

            if (size == data.Length)
            {
                Resize(2 * data.Length);
            }

            for (var i = size - 1; i >= index; i--)
            {
                data[i + 1] = data[i];
            }

            data[index] = e;
            size++;
        }

        /// <summary>
        /// 获取index索引位置的元素
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T Get(int index)
        {
            if (index < 0 || index >= size)
            {
                throw new IndexOutOfRangeException("Get failed. Index is illegal.");
            }

            return data[index];
        }

        /// <summary>
        /// 获取第一个位置的元素
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T GetFirst()
        {
            return Get(0);
        }

        /// <summary>
        /// 获取最后一个位置的元素
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T GetLast()
        {
            return Get(size - 1);
        }

        /// <summary>
        /// 修改index位置的元素为e
        /// </summary>
        /// <param name="index"></param>
        /// <param name="e"></param>
        public void Set(int index, T e)
        {
            if (index < 0 || index >= size)
            {
                throw new IndexOutOfRangeException("Set failed. Index is illegal.");
            }

            data[index] = e;
        }

        /// <summary>
        /// 查找数组中是否有元素e
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public bool Contains(T e)
        {
            for (var i = 0; i < size; i++)
            {
                if (data[i].Equals(e))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 查找数组中元素e所在的索引，如果不存在元素e，则返回-1
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public int Find(T e)
        {
            for (var i = 0; i < size; i++)
            {
                if (data[i].Equals(e))
                {
                    return i;
                }
            }

            return -1;
        }

        /// <summary>
        /// 从数组中删除index位置的元素，返回删除的元素
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T Remove(int index)
        {
            if (index < 0 || index >= size)
            {
                throw new IndexOutOfRangeException("Remove failed. Index is illegal.");
            }

            var ret = data[index];
            for (var i = index + 1; i < size; i++)
            {
                data[i - 1] = data[i];
            }

            size--;
            data[size] = default(T); // loitering objects != memory leak

            if (size == data.Length / 2)
            {
                Resize(data.Length / 2);
            }
            return ret;
        }

        /// <summary>
        /// 从数组中删除第一个元素，返回删除的元素
        /// </summary>
        /// <returns></returns>
        public T RemoveFirst()
        {
            return Remove(0);
        }

        /// <summary>
        /// 从数组中删除最后一个元素，返回删除的元素
        /// </summary>
        /// <returns></returns>
        public T RemoveLast()
        {
            return Remove(size - 1);
        }

        /// <summary>
        /// 从数组中删除元素e
        /// </summary>
        /// <param name="e"></param>
        public bool RemoveElement(T e)
        {
            var index = Find(e);
            if (index == -1)
            {
                return false;
            }
                
            Remove(index);
            return true;

        }

        public void Swap(int i, int j)
        {
            if (i < 0 || i >= size || j < 0 || j >= size)
            {
                throw new ArgumentException("Index is illegal.");
            }

            var t = data[i];
            data[i] = data[j];
            data[j] = t;
        }

        public override string ToString()
        {
            var res = new StringBuilder();
            res.Append($"Array: size = {size}, capacity = {data.Length}\n");
            res.Append('[');
            for (var i = 0; i < size; i++)
            {
                res.Append(data[i]);
                if (i != size - 1)
                {
                    res.Append(", ");
                }
            }

            res.Append(']');
            return res.ToString();
        }

        private void Resize(int newCapacity)
        {
            var newData = new T[newCapacity];
            for (var i = 0; i < size; i++)
            {
                newData[i] = data[i];
            }

            data = newData;
        }
    }
}
