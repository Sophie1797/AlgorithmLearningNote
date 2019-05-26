using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmNote
{
    public class SortBasic
    {
        #region 1. Insert Sort
        public void InsertSort(int[] arr, int n)
        {
            for (var i = 1; i < n; i++)
            {
                var temp = arr[i];
                //把i位置元素空出来，拎出去存着
                var j = i;
                //从i位置开始复制前一个的值
                while (j > 0 && temp < arr[j - 1])
                {
                    arr[j] = arr[j - 1];
                    j--;
                }
                //插牌
                arr[j] = temp;
            }
        }
        #endregion

        #region 2. Select Sort
        public void SelectSort(int[] arr, int n)
        {
            for (var i = 0; i < n; i++)
            {
                //找出后面数里面值最小的格的下标
                var min = i;
                for (var j = i + 1; j < n; j++)
                {
                    if (arr[j] < arr[min]) min = j;
                }

                var temp = arr[i];
                arr[i] = arr[min];
                arr[min] = temp;
            }
        }
        #endregion

        #region 3. Bubble Sort
        public void BubbleSort(int[] arr, int n)
        {
            //注意i的范围
            for (var i = 0; i < n - 1; i++)
            {
                //注意j的范围
                for (var j = 0; j < n - i - 1; j++)
                {
                    if (arr[j + 1] < arr[j])
                    {
                        var temp = arr[j + 1];
                        arr[j + 1] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
        }
        #endregion

        #region 4. Merge Sort
        public void MergeSort(int[] arr, int l, int r)
        {
            //注意是闭区间
            if (l >= r) return;
            int mid = (l + r) / 2;
            MergeSort(arr, l, mid);
            MergeSort(arr, mid + 1, r);
            Merge(arr, l, mid, mid + 1, r);
        }

        public void MergeSort(int[] arr, int n)
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

        public int[] Merge(int[] arr, int l1, int r1, int l2, int r2)
        {
            var res = new int[arr.Length];
            var i = l1; var j = l2; var k = 0;
            while (i <= r1 && j <= r2)
            {
                if (arr[i] < arr[j])
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
        #endregion

        #region 5. Quick Sort
        public void QuickSort(int[] arr, int left, int right)
        {
            if (left >= right) return;
            var pos = Partirion(arr, left, right);
            //注意是pos-1
            QuickSort(arr, left, pos - 1);
            QuickSort(arr, pos + 1, right);
        }

        public int Partirion(int[] arr, int left, int right)
        {
            var mid = arr[left];
            while (left < right)
            {
                while (left < right && arr[right] > mid) right--;
                arr[left] = arr[right];
                while (left < right && arr[left] <= mid) left++;
                arr[right] = arr[left];
            }

            arr[left] = mid;
            return left;
        }
        #endregion

        #region 6. Bucket Sort
        public void BucketSort(int[] arr)
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
        #endregion

        #region 7. Radix Sort
        //基数排序(Radix Sort)是桶排序的扩展,它的基本思想是：将整数按位数切割成不同的数字，然后按每个位数分别比较。
        //具体做法是：将所有待比较数值统一为同样的数位长度，数位较短的数前面补零。然后，从最低位开始，依次进行一次排序。这样从最低位排序一直到最高位排序完成以后, 数列就变成一个有序序列
        public void RadixSort(int[] a, int n)
        {
            var exp = 0;    // 指数。当对数组按各位进行排序时，exp=1；按十位进行排序时，exp=10；...
            var max = a.Max();    // 数组a中的最大值

            // 从个位开始，对数组a按"指数"进行排序
            for (exp = 1; max / exp > 0; exp *= 10)
                CountSort(a, n, exp);
        }

        public void CountSort(int[] a, int n, int exp)
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
            for (i = a.Length-1; i >=0; i--)
            {
                output[buckets[(a[i] / exp) % 10] - 1] = a[i];
                buckets[(a[i] / exp) % 10]--;
            }

            // 将排序好的数据赋值给a[]
            for (i = 0; i < n; i++)
                a[i] = output[i];
        }
        #endregion

        #region 8. Heap Sort
        public void HeapSort(int[] arr)
        {
            var heap = new MaxHeap<int>(arr);
            var i = 0;
            while (!heap.IsEmpty())
            {
                arr[i++] = heap.ExtractMax();
            }
        }
        #endregion

        #region 9. Shell Sort
        public void ShellSort(int[] arr)
        {

        }
        #endregion

        #region 10. 外部排序

        

        #endregion

        private void Swap(int[] arr, int i, int j)
        {
            var temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }
}


