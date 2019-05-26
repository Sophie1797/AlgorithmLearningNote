using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmNote
{
    public class AdancedSort
    {
        /// <summary>
        /// 经典Color Sort，三个指针，分别指向左，中，右
        /// 75. Sort Colors https://leetcode.com/problems/sort-colors/
        /// </summary>
        /// <param name="nums"></param>
        public void SortColors(int[] nums)
        {
            var n = nums.Length;
            //左边来的mid都经历过所以只可能是01右边来的就不清楚了所以得呆在原地别动
            var i = 0; var m = 0; var j = n - 1;
            while (m < n && m <= j)
            {
                if (nums[m] == 0)
                {
                    Swap(nums, i, m);
                    m++;
                    i++;
                }
                else if (nums[m] == 2)
                {
                    Swap(nums, m, j);
                    //m++;
                    j--;
                }
                else m++;
            }
        }

        private void Swap(int[] nums, int i, int j)
        {
            if (i == j) return;
            var temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }
    }

    /// <summary>
    /// Sort Function in C# Source Code
    /// </summary>
    public class SortSource
    {
        public void IntroSort(
            int[] keys,
            int lo,
            int hi,
            int depthLimit)
        {
            int num1;
            for (; hi > lo; hi = num1 - 1)
            {
                int num2 = hi - lo + 1;
                if (num2 <= 6)
                {
                    if (num2 == 1)
                        break;
                    if (num2 == 2)
                    {
                        SwapIfGreater(keys, lo, hi);
                        break;
                    }
                    if (num2 == 3)
                    {
                        SwapIfGreater(keys, lo, hi - 1);
                        SwapIfGreater(keys, lo, hi);
                        SwapIfGreater(keys, hi - 1, hi);
                        break;
                    }
                    InsertionSort(keys, lo, hi);
                    break;
                }
                if (depthLimit == 0)
                {
                    Heapsort(keys, lo, hi);
                    break;
                }
                --depthLimit;
                num1 = PickPivotAndPartition(keys, lo, hi);
                IntroSort(keys, num1 + 1, hi, depthLimit);
            }
        }


        private int PickPivotAndPartition(int[] keys, int lo, int hi)
        {
            int index = lo + (hi - lo) / 2;
            SwapIfGreater(keys, lo, index);
            SwapIfGreater(keys, lo, hi);
            SwapIfGreater(keys, index, hi);
            int key = keys[index];
            Swap(keys, index, hi - 1);
            int i = lo;
            int j = hi - 1;
            while (i < j)
            {
                do
                    ;
                while (keys[++i] < key);
                do
                    ;
                while (key < keys[--j]);
                if (i < j)
                    Swap(keys, i, j);
                else
                    break;
            }
            Swap(keys, i, hi - 1);
            return i;
        }

        private void Heapsort(int[] keys, int lo, int hi)
        {
            int n = hi - lo + 1;
            for (int i = n / 2; i >= 1; --i)
                DownHeap(keys, i, n, lo);
            for (int index = n; index > 1; --index)
            {
                Swap(keys, lo, lo + index - 1);
                DownHeap(keys, 1, index - 1, lo);
            }
        }

        private void DownHeap(int[] keys, int i, int n, int lo)
        {
            int key = keys[lo + i - 1];
            int num;
            for (; i <= n / 2; i = num)
            {
                num = 2 * i;
                if (num < n && keys[lo + num - 1] < keys[lo + num])
                    ++num;
                if (key < keys[lo + num - 1])
                    keys[lo + i - 1] = keys[lo + num - 1];
                else
                    break;
            }
            keys[lo + i - 1] = key;
        }

        private void InsertionSort(int[] keys, int lo, int hi)
        {
            for (int index1 = lo; index1 < hi; ++index1)
            {
                int index2 = index1;
                int key;
                for (key = keys[index1 + 1]; index2 >= lo && key < keys[index2]; --index2)
                    keys[index2 + 1] = keys[index2];
                keys[index2 + 1] = key;
            }
        }

        private void SwapIfGreater(int[] keys, int a, int b)
        {
            if (a == b || keys[a] <= keys[b])
                return;
            int key = keys[a];
            keys[a] = keys[b];
            keys[b] = key;
        }

        private void Swap(int[] a, int i, int j)
        {
            if (i == j)
                return;
            int obj = a[i];
            a[i] = a[j];
            a[j] = obj;
        }
    }
}
