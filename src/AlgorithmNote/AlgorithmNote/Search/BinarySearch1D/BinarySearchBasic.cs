using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmNote
{
    public class BinarySearch1D
    {
        public static int BinarySearch(int[] nums, int left, int right, int target)
        {
            while (left <= right)
            {
                var mid = (left + right) / 2;
                if (nums[mid] == target)
                {
                    return mid;
                }
                else if (target > nums[mid])
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }
            return -1;
        }

        public static int LowerBound(int[] nums, int left, int right, int target)
        {//初始值应该传入0，n
            while (left < right)
            {
                var mid = (left + right) / 2;
                if (nums[mid] >= target)
                {
                    right = mid;
                }
                else
                {
                    left = mid + 1;
                }
            }
            return left;
        }

        public static int UpperBound(int[] nums, int left, int right, int target)
        {
            while (left < right)
            {
                var mid = (left + right) / 2;
                if (nums[mid] > target)
                {
                    right = mid;
                }
                else
                {
                    left = mid + 1;
                }
            }
            return left;
        }

        /// <summary>
        /// 34. 在排序数组中查找元素的第一个和最后一个位置
        /// 示例 1:
        /// 输入: nums = [5,7,7,8,8,10], target = 8
        /// 输出: [3,4]
        /// 示例 2:
        /// 输入: nums = [5,7,7,8,8,10], target = 6
        /// 输出: [-1,-1]
        /// </summary>
        public int[] SearchRange(int[] nums, int target)
        {
            int[] res = new int[] { -1, -1 };
            if (nums.Length == 0) return res;
            var first = Find(nums, target, true);
            if (first == nums.Length || nums[first] != target)
            {
                return res;
            }
            res[0] = first;
            var second = Find(nums, target, false);
            if (nums[second] > target)
            {
                second--;
            }
            res[1] = second;

            return res;
        }

        public int Find(int[] nums, int target, bool first)
        {
            var lo = 0;
            var hi = nums.Length - 1;
            while (lo < hi)
            {
                int mid = lo + (hi - lo) / 2;
                if (nums[mid] > target || (first && nums[mid] == target))
                {
                    hi = mid;
                }
                else
                {
                    lo = mid + 1;
                }
            }
            return lo;
        }


    }
}
