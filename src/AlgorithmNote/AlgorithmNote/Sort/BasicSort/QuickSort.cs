using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmNote
{
    public class QuickSort<T> where T : IComparable
    {
        public static void Sort(T[] arr, int left, int right)
        {
            if (left >= right) return;
            var pos = Partition(arr, left, right);
            //注意是pos-1
            Sort(arr, left, pos - 1);
            Sort(arr, pos + 1, right);
        }

        public static void Sort_Rand(T[] arr, int left, int right)
        {
            if (left >= right) return;
            var pos = Partition_Rand(arr, left, right);
            //注意是pos-1
            Sort(arr, left, pos - 1);
            Sort(arr, pos + 1, right);
        }

        public static void Sort_3Ways(T[] arr, int left, int right)
        {
            var rand = new Random();
            if (left > right)
            {
                return;
            }
            Swap(arr, left, rand.Next() % (right - left + 1) + left);
            var v = arr[left];
            var lt = left; // arr[l+1...lt] < v
            var gt = right + 1; // arr[gt...r] > v
            var i = left + 1; // arr[lt+1...i] == v
            while (i < gt)
            {
                if (arr[i].CompareTo(v) < 0)
                {
                    Swap(arr, i, lt + 1);
                    lt++;
                    i++;
                }
                else if (arr[i].CompareTo(v) > 0)
                {
                    Swap(arr, i, gt - 1);
                    gt--;
                    //从gt-1交换过来的元素还没有被处理，所以i不用动
                }
                else
                {
                    i++;
                }
            }

            Swap(arr, left, lt);
            Sort_3Ways(arr, left, lt - 1);
            Sort_3Ways(arr, gt, right);
        }

        public static int Partition(T[] arr, int left, int right)
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

        public static int Partition_Rand(T[] arr, int left, int right)
        {
            var rand = new Random();
            var mid = arr[rand.Next() % (right - left + 1) + left];
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

        private static void Swap(T[] arr, int x, int y)
        {
            if (x != y)
            {
                var temp = arr[x];
                arr[x] = arr[y];
                arr[y] = temp;
            }
        }
    }
}
