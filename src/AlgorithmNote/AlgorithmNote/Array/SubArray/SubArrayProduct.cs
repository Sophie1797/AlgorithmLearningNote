using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmNote
{
    public class SubArrayProduct
    {
        public int MaxProduct(int[] nums)
        {
            if (nums == null || nums.Length == 0) return 0;
            var dpPos = Math.Max(nums[0], 0);//直接用变量存dp阶段值
            var dpNeg = Math.Min(nums[0], 0);
            var max = nums[0];//因为题目要求至少包含一个数，所以此处应该赋值为nums[0]
            for (var i = 1; i < nums.Length; i++)
            {
                if (nums[i] >= 0)
                {
                    dpPos = Math.Max(dpPos * nums[i], nums[i]);
                    dpNeg = Math.Min(dpNeg * nums[i], nums[i]);
                }
                else
                {
                    var temp = dpPos;//注意此处，因为直接用变量存上一个状态，下一句会改掉本来的dpPos值，会影响到下下一句，所以先把dpPos原本的值拎出来
                    dpPos = Math.Max(dpNeg * nums[i], nums[i]);
                    dpNeg = Math.Min(temp * nums[i], nums[i]);
                }
                max = Math.Max(max, dpPos);
            }
            return max;
        }
    }
}
