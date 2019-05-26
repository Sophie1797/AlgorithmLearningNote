using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmNote
{
    public class BubbleSort<T> where T : IComparable
    {
        /// <summary>
        /// 优化后的bubble sort
        /// </summary>
        public static void Sort(T[] arr, int n)
        {
            var swapped = true;
            //注意i的范围
            for (var i = 0; swapped && i < n - 1; i++)
            {
                swapped = false;
                //注意j的范围
                for (var j = 0; j < n - i - 1; j++)
                {
                    if (arr[j + 1].CompareTo(arr[j]) < 0)
                    {
                        var temp = arr[j + 1];
                        arr[j + 1] = arr[j];
                        arr[j] = temp;
                        swapped = true;
                    }
                }
            }
        }

        /// <summary>
        /// 没有经过优化的bubble sort
        /// </summary>
        public static void Sort_Slow(T[] arr, int n)
        {
            //注意i的范围
            for (var i = 0; i < n - 1; i++)
            {
                //注意j的范围
                for (var j = 0; j < n - i - 1; j++)
                {
                    if (arr[j + 1].CompareTo(arr[j]) < 0)
                    {
                        var temp = arr[j + 1];
                        arr[j + 1] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
        }
    }
}
