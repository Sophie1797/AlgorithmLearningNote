
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmNote
{
    public class TwoSum
    {
        /// <summary>
        /// 1. 两数之和
        /// </summary>
        public int[] GetTwoSum(int[] nums, int target)
        {
            var map = new Dictionary<int, int>();
            for (var i = 0; i < nums.Length; i++)
            {
                if (map.ContainsKey(target - nums[i]))
                {
                    return new int[] { map[target - nums[i]], i };
                }
                if (!map.ContainsKey(nums[i]))
                {
                    map.Add(nums[i], i);
                }
            }
            return null;
        }

        /// <summary>
        /// 167. 两数之和 II - 输入有序数组
        /// 给定一个已按照升序排列 的有序数组，找到两个数使得它们相加之和等于目标数。
        /// </summary>
        /// <returns>下标值 index1 和 index2, 其中 index1必须小于 index2。</returns>
        public int[] GetTwoSumInSortedArray(int[] numbers, int target)
        {
            int l = 0; int r = numbers.Length - 1;
            while (l < r)
            {
                if (numbers[l] + numbers[r] == target)
                    break;
                if (numbers[l] + numbers[r] > target)
                    r--;
                else
                    l++;
            }
            return new int[] { l + 1, r + 1 };
        }


    }
}
