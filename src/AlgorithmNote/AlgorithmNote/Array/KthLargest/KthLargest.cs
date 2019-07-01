using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmNote
{
    public class KthLargest
    {
        /// <summary>
        /// 215. 数组中的第K个最大元素
        /// </summary>
        public class KthLargestInArray
        {
            public int FindKthLargest(int[] nums, int k)
            {
                var lo = 0; var hi = nums.Length - 1;
                return Find(nums, k, lo, hi);
            }

            public int Find(int[] nums, int k, int lo, int hi)
            {
                var pivot = Partition(nums, lo, hi);
                if (pivot + 1 == k)
                {
                    return nums[k - 1];
                }
                else if (pivot + 1 < k)
                {
                    return Find(nums, k, pivot + 1, hi);
                }
                else
                {
                    return Find(nums, k, lo, pivot - 1);
                }
            }

            public int Partition(int[] nums, int lo, int hi)
            {
                var mid = nums[lo];
                while (lo < hi)
                {
                    while (lo < hi && nums[hi] < mid)
                    {
                        hi--;
                    }
                    nums[lo] = nums[hi];
                    while (lo < hi && nums[lo] >= mid)
                    {
                        lo++;
                    }
                    nums[hi] = nums[lo];
                }
                nums[lo] = mid;
                return lo;
            }
        }

        /// <summary>
        /// 973. 最接近原点的 K 个点
        /// </summary>
        public class KthClosestPoints
        {
            public int[][] KClosest(int[][] points, int K)
            {
                int l = 0, r = points.Length - 1;
                while (l <= r)
                {
                    int mid = quickpivot(points, l, r);
                    if (mid == K)
                        break;
                    if (mid < K)
                        l = mid + 1;
                    else
                        r = mid - 1;
                }
                int[][] res = new int[K][];
                for (int i = 0; i < K; i++)
                    res[i] = points[i];
                return res;
            }

            public int quickpivot(int[][] points, int l, int r)
            {
                int[] pivot = points[l];
                while (l < r)
                {
                    while (l < r && compare(points[r], pivot) >= 0) r--;
                    points[l] = points[r];
                    while (l < r && compare(pivot, points[l]) >= 0) l++;
                    points[r] = points[l];
                }
                points[l] = pivot;
                return l;
            }

            public int compare(int[] a, int[] b)
            {
                return (a[0] * a[0] + a[1] * a[1]) - (b[0] * b[0] + b[1] * b[1]);
            }
        }
    }
}
