using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmNote
{
    public class MergeSort<T> where T : IComparable
    {
        public static void Sort(T[] arr, int l, int r)
        {
            //注意是闭区间
            if (l >= r) return;
            int mid = (l + r) / 2;
            Sort(arr, l, mid);
            Sort(arr, mid + 1, r);
            Merge(arr, l, mid, mid + 1, r);
        }

        public static void Sort(T[] arr, int n)
        {
            //step为组内元素个数，step/2是左子区间元素个数
            for (var step = 2; step / 2 < n; step *= 2)
            {
                for (var i = 0; i < n; i += step)
                {
                    var mid = i + step / 2 - 1;
                    Merge(arr, i, mid, mid + 1, Math.Min(i + step - 1, n - 1));
                }
            }
        }

        public static T[] Merge(T[] arr, int l1, int r1, int l2, int r2)
        {
            var res = new T[arr.Length];
            var i = l1; var j = l2; var k = 0;
            while (i <= r1 && j <= r2)
            {
                if (arr[i].CompareTo(arr[j]) < 0)
                    res[k++] = arr[i++];
                else
                    res[k++] = arr[j++];
            }
            //注意多出来的串的处理
            while (i <= r1) res[k++] = arr[i++];
            while (j <= r2) res[k++] = arr[j++];
            //注意copy数组的范围
            for (i = 0; i < k; i++) arr[l1 + i] = res[i];
            return res;
        }
    }
}
