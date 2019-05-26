using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmNote
{
    public class BucketSort<T> where T : IComparable
    {
        public static void Sort(int[] arr)
        {
            if (arr == null || arr.Length < 2)
            {
                return;
            }
            //常用写法
            var max = arr.Concat(new[] { int.MinValue }).Max();

            var bucket = new int[max + 1];

            foreach (var t in arr)
            {
                //桶数组此下标有数据，数值就加一
                bucket[t]++;
            }

            var k = 0;

            for (var j = 0; j < bucket.Length; j++)
            {
                while (bucket[j] != 0)
                {
                    arr[k++] = j;
                    bucket[j]--;
                }
            }
        }
    }
}
