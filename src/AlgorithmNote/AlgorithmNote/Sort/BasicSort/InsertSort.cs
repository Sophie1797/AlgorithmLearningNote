using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmNote
{
    public class InsertSort<T> where T : IComparable
    {
        // 数组近乎有序的时候，效率特别高
        public static void Sort(T[] arr, int n)
        {
            for (var i = 1; i < n; i++)
            {
                var temp = arr[i];
                //把i位置元素空出来，拎出去存着
                var j = i;
                //从i位置开始复制前一个的值
                while (j > 0 && temp.CompareTo(arr[j - 1]) < 0)
                {
                    arr[j] = arr[j - 1];
                    j--;
                }
                //插牌
                arr[j] = temp;
            }
        }
    }
}
