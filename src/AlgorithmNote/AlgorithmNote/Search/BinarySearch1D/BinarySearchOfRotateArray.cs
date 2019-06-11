using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmNote.Search.BinarySearch1D
{
    public class BinarySearchOfRotateArray
    {
        /// <summary>
        /// 153. 寻找旋转排序数组中的最小值
        /// 数组中没有重复值
        /// </summary>
        public int FindMin(int[] nums)
        {
            int l = 0; int r = nums.Length - 1;
            while (l < r)
            {
                int mid = l + (r - l) / 2;
                if (nums[mid] <= nums[r])
                {//rotated array问题，关键在于分开讨论mid扎在那边
                    r = mid;
                }
                else if (nums[mid] >= nums[l])
                {
                    if (nums[mid] > nums[r]) l = mid + 1;
                    else return nums[l];//整个数组全部有序
                }
            }
            return nums[r];
        }

        /// <summary>
        /// 154. 寻找旋转排序数组中的最小值 II
        /// 数组中有重复值
        /// </summary>
        public int FindMin2(int[] nums)
        {
            int l = 0; int r = nums.Length - 1;
            //和1不同在于，两端有重复元素，分别trim掉两端的重复元素就可以复用1
            while (r > 0 && nums[r] == nums[r - 1]) r--;
            while (l < nums.Length - 1 && nums[l] == nums[l + 1]) l++;
            while (l < r)
            {
                int mid = l + (r - l) / 2;
                if (nums[mid] <= nums[r])
                {//rotated array问题，关键在于分开讨论mid扎在那边
                    r = mid;
                }
                else if (nums[mid] >= nums[l])
                {
                    if (nums[mid] > nums[r]) l = mid + 1;
                    else return nums[l];
                }
            }
            return nums[l];
        }

        /// <summary>
        /// 33. 搜索旋转排序数组
        /// 在rotate sorted array中二分查找一个数target
        /// 数组中没有重复值
        /// </summary>
        public int Search(int[] nums, int target)
        {
            int l = 0; int r = nums.Length - 1;
            while (l <= r)
            {
                int mid = l + (r - l) / 2;
                if (target == nums[mid]) return mid;
                if (nums[mid] >= nums[l])
                {
                    if (target < nums[mid] && target >= nums[l])
                    {
                        r = mid - 1;
                    }
                    else
                    {
                        l = mid + 1;
                    }
                }
                else if (nums[mid] <= nums[r])
                {//注意等于号
                    if (target > nums[mid] && target <= nums[r])
                    {
                        l = mid + 1;
                    }
                    else
                    {
                        r = mid - 1;
                    }
                }
            }
            return -1;
        }

        /// <summary>
        /// 81. 搜索旋转排序数组 II   
        /// 在rotate sorted array中二分查找一个数target
        /// 数组中有重复值
        /// </summary>
        public bool Search2(int[] nums, int target)
        {
            if (nums == null || nums.Length == 0) return false;
            int l = 0; int r = nums.Length - 1;
            while (r > 0 && nums[r] == nums[r - 1]) r--;
            while (l < nums.Length - 1 && nums[l] == nums[l + 1]) l++;
            if (l > r && target == nums[l]) return true;
            while (l <= r)
            {
                int mid = l + (r - l) / 2;
                if (target == nums[mid]) return true;
                if (nums[mid] >= nums[l])
                {
                    if (target < nums[mid] && target >= nums[l])
                    {
                        r = mid - 1;
                    }
                    else
                    {
                        l = mid + 1;
                    }
                }
                else if (nums[mid] <= nums[r])
                {//注意等于号
                    if (target > nums[mid] && target <= nums[r])
                    {
                        l = mid + 1;
                    }
                    else
                    {
                        r = mid - 1;
                    }
                }
            }
            return false;
        }
    }
}
