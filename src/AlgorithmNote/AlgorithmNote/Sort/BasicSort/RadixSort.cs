using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmNote
{
    public class RadixSort<T> where T : IComparable
    {
        //基数排序(Radix Sort)是桶排序的扩展,它的基本思想是：将整数按位数切割成不同的数字，然后按每个位数分别比较。
        //具体做法是：将所有待比较数值统一为同样的数位长度，数位较短的数前面补零。然后，从最低位开始，依次进行一次排序。这样从最低位排序一直到最高位排序完成以后, 数列就变成一个有序序列
        public static void Sort(int[] a, int n)
        {
            var exp = 0;    // 指数。当对数组按各位进行排序时，exp=1；按十位进行排序时，exp=10；...
            var max = a.Max();    // 数组a中的最大值

            // 从个位开始，对数组a按"指数"进行排序
            for (exp = 1; max / exp > 0; exp *= 10)
                CountSort(a, n, exp);
        }

        public static void CountSort(int[] a, int n, int exp)
        {
            var output = new int[n];
            var buckets = new int[10];
            var i = 0;

            // 将数据出现的次数存储在buckets[]中
            for (i = 0; i < n; i++)
                buckets[(a[i] / exp) % 10]++;

            // 更改buckets[i]。目的是让更改后的buckets[i]的值，是该数据在output[]中的位置。
            for (i = 1; i < 10; i++)
                buckets[i] += buckets[i - 1];

            // 将数据存储到临时数组output[]中
            // 十位数同为3时先把上一次排好序的个位数大的那个放好，放在较靠后位置上，所以从后向前遍历
            for (i = a.Length - 1; i >= 0; i--)
            {
                output[buckets[(a[i] / exp) % 10] - 1] = a[i];
                buckets[(a[i] / exp) % 10]--;
            }

            // 将排序好的数据赋值给a[]
            for (i = 0; i < n; i++)
                a[i] = output[i];
        }
    }
}
