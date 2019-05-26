using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmNote
{
    public class QuickSort<T> where T : IComparable
    {
        public static void Sort(T[] arr, int left, int right)
        {
            if (left >= right) return;
            var pos = Partirion(arr, left, right);
            //注意是pos-1
            Sort(arr, left, pos - 1);
            Sort(arr, pos + 1, right);
        }

        public static int Partirion(T[] arr, int left, int right)
        {
            var mid = arr[left];
            while (left < right)
            {
                while (left < right && arr[right].CompareTo(mid) > 0) right--;
                arr[left] = arr[right];
                while (left < right && arr[left].CompareTo(mid) <= 0) left++;
                arr[right] = arr[left];
            }

            arr[left] = mid;
            return left;
        }
    }
}
