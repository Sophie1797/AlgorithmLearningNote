using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmNote
{
    public class MergeArray
    {
        /// <summary>
        /// 88. 合并两个有序数组
        /// </summary>
        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            var i = m - 1; var j = n - 1; var k = m + n - 1;
            while (i >= 0 && j >= 0)
            {
                if (nums1[i] > nums2[j])
                {
                    nums1[k--] = nums1[i--];
                }
                else
                {
                    nums1[k--] = nums2[j--];
                }
            }
            while (j >= 0)
            {
                nums1[k--] = nums2[j--];
            }
        }
    }
}
