using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmNote
{
    public class TrapWater
    {
        /// <summary>
        /// 11. 盛最多水的容器
        /// 竖线
        /// </summary>
        public int MaxArea(int[] height)
        {
            var maxArea = 0;
            var l = 0;
            var r = height.Length - 1;
            while (l < r)
            {
                maxArea = Math.Max(maxArea, Math.Min(height[l], height[r]) * (r - l));
                if (height[l] < height[r])
                    l++;
                else
                    r--;
            }
            return maxArea;
        }

        /// <summary>
        /// 42. 接雨水
        /// 二维块
        /// </summary>
        public int Trap(int[] height)
        {
            int left = 0, right = height.Length - 1;
            int ans = 0;
            int left_max = 0, right_max = 0;
            while (left < right)
            {
                if (height[left] < height[right])
                {
                    if (height[left] >= left_max)
                    {
                        left_max = height[left];
                    }
                    else
                    {
                        ans += (left_max - height[left]);
                    }
                    ++left;
                }
                else
                {
                    if (height[right] >= right_max)
                    {
                        right_max = height[right];
                    }
                    else
                    {
                        ans += (right_max - height[right]);
                    }
                    --right;
                }
            }
            return ans;
        }
    }
}
