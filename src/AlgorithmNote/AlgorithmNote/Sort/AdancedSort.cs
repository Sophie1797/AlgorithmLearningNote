using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmNote
{
    public class AdancedSort
    {
        /// <summary>
        /// 经典Color Sort，三个指针，分别指向左，中，右
        /// 75. Sort Colors https://leetcode.com/problems/sort-colors/
        /// </summary>
        /// <param name="nums"></param>
        public void SortColors(int[] nums)
        {
            var n = nums.Length;
            //左边来的mid都经历过所以只可能是01右边来的就不清楚了所以得呆在原地别动
            var i = 0; var m = 0; var j = n - 1;
            while (m < n && m <= j)
            {
                if (nums[m] == 0)
                {
                    Swap(nums, i, m);
                    m++;
                    i++;
                }
                else if (nums[m] == 2)
                {
                    Swap(nums, m, j);
                    //m++;
                    j--;
                }
                else m++;
            }
        }

        private void Swap(int[] nums, int i, int j)
        {
            if (i == j) return;
            var temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }
    }
}
