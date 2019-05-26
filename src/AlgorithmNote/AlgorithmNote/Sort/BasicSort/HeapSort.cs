using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmNote
{
    public class HeapSort<T> where T : IComparable
    {
        public static void Sort(T[] arr)
        {
            var heap = new MaxHeap<T>(arr);
            var i = 0;
            while (!heap.IsEmpty())
            {
                arr[i++] = heap.ExtractMax();
            }
        }
    }
}
