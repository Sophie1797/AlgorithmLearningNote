using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmNote
{
    public class RemoveElements
    {
        /// <summary>
        /// 283. 移动零
        /// </summary>
        public void MoveZeroes(int[] nums)
        {
            var k = 0;
            for (var i = 0; i < nums.Length; i++)
            {
                if (nums[i] != 0)
                {
                    nums[k++] = nums[i];
                }
            }
            while (k < nums.Length)
            {
                nums[k++] = 0;
            }
        }

        /// <summary>
        /// 27. 移除元素
        /// </summary>
        public int RemoveElement(int[] nums, int val)
        {
            var k = 0;
            for (var i = 0; i < nums.Length; i++)
            {
                if (nums[i] != val)
                {
                    nums[k++] = nums[i];
                }
            }
            return k;
        }

        /// <summary>
        /// 26. 删除排序数组中的重复项
        /// </summary>
        public int RemoveDuplicates(int[] nums)
        {
            var k = 0;
            for (var i = 0; i < nums.Length; i++)
            {
                //注意是跟k-1比较，判断k是否小于1
                if (k < 1 || nums[i] != nums[k - 1])
                {
                    nums[k++] = nums[i];
                }
            }
            return k;
        }

        /// <summary>
        /// 80. 删除排序数组中的重复项 II
        /// </summary>
        public int RemoveDuplicatesII(int[] nums)
        {
            var k = 0;
            for (var i = 0; i < nums.Length; i++)
            {
                //注意是跟k-2比较，判断k是否小于2
                if (k < 2 || nums[i] > nums[k - 2])
                {
                    nums[k++] = nums[i];
                }
            }
            return k;
        }
    }
}
