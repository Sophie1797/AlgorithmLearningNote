using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmNote
{
    public class ThreeSum
    {
        /// <summary>
        /// 15. 三数之和
        /// 给定一个包含 n 个整数的数组 nums，
        /// 判断 nums 中是否存在三个元素 a，b，c ，
        /// 使得 a + b + c = 0 ？找出所有满足条件且不重复的三元组。
        /// 答案中不可以包含重复的三元组。
        /// </summary>
        public IList<IList<int>> GetThreeSumList(int[] nums)
        {
            var res = new List<IList<int>>();
            if (nums == null || nums.Length < 3)
            {
                return res;
            }
            Array.Sort(nums);
            var map = new Dictionary<string, List<int>>();
            for (var i = 0; i < nums.Length - 2; i++)
            {
                //------cookie code---------------
                if (i >= 1 && nums[i] == nums[i - 1])
                {
                    continue;
                }
                //-------end-----------------------
                var j = i + 1;
                var k = nums.Length - 1;
                while (j < k)
                {
                    if (nums[j] + nums[k] > -nums[i])
                    {
                        k--;
                    }
                    else if (nums[j] + nums[k] < -nums[i])
                    {
                        j++;
                    }
                    else
                    {
                        if (!map.ContainsKey("" + nums[i] + nums[j] + nums[k]))
                        {
                            map.Add("" + nums[i] + nums[j] + nums[k], new List<int> { nums[i], nums[j], nums[k] });
                        }
                        //------cookie code---------------
                        while (j < k && nums[j] == nums[j + 1])
                        {
                            j++;
                        }
                        while (j < k && nums[k] == nums[k - 1])
                        {
                            k--;
                        }
                        //-------end-----------------------
                        k--;
                        j++;
                    }
                }
            }
            res.AddRange(map.Select(t => t.Value).ToList());
            return res;
        }
    }
}
