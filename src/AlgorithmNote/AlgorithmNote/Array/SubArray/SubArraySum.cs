using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmNote
{
    public class SubArraySum
    {
        public int MaxSubArray(int[] nums)
        {
            if (nums.Length == 0) return 0;
            var dp = nums[0];
            var max = dp;
            for (var i = 1; i < nums.Length; i++)
            {
                dp = Math.Max(nums[i], dp + nums[i]);
                max = Math.Max(dp, max);
            }
            return max;
        }
    }
}
