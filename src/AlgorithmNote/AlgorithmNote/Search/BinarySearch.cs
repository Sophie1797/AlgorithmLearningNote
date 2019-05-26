using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmNote.Search
{
    public class BinarySearcher1D
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
    }
}
