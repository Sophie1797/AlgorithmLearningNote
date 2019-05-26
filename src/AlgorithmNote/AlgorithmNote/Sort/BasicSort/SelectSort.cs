using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmNote
{
    public class SelectSort<T> where T : IComparable
    {
        public static void Sort(T[] arr, int n)
        {
            for (var i = 0; i < n; i++)
            {
                //找出[i, n)区间里面值最小的格的下标
                var min = i;
                for (var j = i + 1; j < n; j++)
                {
                    if (arr[j].CompareTo(arr[min]) < 0) min = j;
                }

                var temp = arr[i];
                arr[i] = arr[min];
                arr[min] = temp;
            }
        }
    }
}
