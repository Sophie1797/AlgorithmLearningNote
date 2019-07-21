using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgorithmNote.Tree.BasicTree;

namespace AlgorithmNote
{
    public class NumberSum
    {
        /// <summary>
        /// https://leetcode-cn.com/problems/two-sum/
        /// </summary>
        public int[] TwoSumI(int[] nums, int target)
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
        /// https://leetcode-cn.com/problems/two-sum-ii-input-array-is-sorted/
        /// </summary>
        public int[] TwoSumII(int[] numbers, int target)
        {
            int l = 0; int r = numbers.Length - 1;
            while (l < r)
            {
                if (numbers[l] + numbers[r] == target)
                {
                    return new int[] { l + 1, r + 1 };
                }
                if (numbers[l] + numbers[r] > target)
                {
                    r--;
                }
                else
                {
                    l++;
                }
            }
            return null;
        }

        /// <summary>
        /// https://leetcode-cn.com/problems/two-sum-iii-data-structure-design/
        /// </summary>
        public class TwoSum
        {
            List<int> nums = new List<int>();
            /** Initialize your data structure here. */
            public TwoSum() { }

            /** Add the number to an internal data structure.. */
            public void Add(int number)
            {
                nums.Add(number);
            }

            /** Find if there exists any pair of numbers which sum is equal to the value. */
            public bool Find(int target)
            {
                var map = new Dictionary<int, int>();
                for (var i = 0; i < nums.Count; i++)
                {
                    if (map.ContainsKey(target - nums[i]))
                    {
                        return true;
                    }
                    if (!map.ContainsKey(nums[i]))
                    {
                        map.Add(nums[i], i);
                    }
                }
                return false;
            }
        }

        /// <summary>
        /// https://leetcode-cn.com/problems/two-sum-iv-input-is-a-bst/
        /// </summary>
        public class TwoSumIV
        {
            public HashSet<int> map = new HashSet<int>();
            public bool FindTarget(TreeNode root, int k)
            {
                if (root == null) return false;
                if (map.Contains(root.val)) return true;
                else
                {
                    map.Add(k - root.val);
                }
                var left = FindTarget(root.left, k);
                var right = FindTarget(root.right, k);
                return left || right;
            }
        }

        /// <summary>
        /// https://leetcode-cn.com/problems/two-sum-less-than-k/
        /// </summary>
        public int TwoSumLessThanK(int[] A, int K)
        {
            Array.Sort(A);
            int left = 0;
            int right = A.Length - 1;
            int max = 0;
            while (left < right)
            {
                if (A[left] + A[right] >= K)
                {
                    right--;
                }
                else
                {
                    max = Math.Max(max, A[left] + A[right]);
                    left++;
                }
            }
            return (max == 0) ? -1 : max;
        }

        /// <summary>
        /// https://leetcode-cn.com/problems/3sum/
        /// </summary>
        public IList<IList<int>> ThreeSum(int[] nums)
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

        /// <summary>
        /// https://leetcode-cn.com/problems/3sum-smaller/
        /// </summary>
        public class ThreeSumSmallerSolution
        {
            public int ThreeSumSmaller(int[] nums, int target)
            {
                Array.Sort(nums);
                int sum = 0;
                for (int i = 0; i < nums.Length - 2; i++)
                {
                    sum += twoSumSmaller(nums, i + 1, target - nums[i]);
                }
                return sum;
            }

            private int twoSumSmaller(int[] nums, int startIndex, int target)
            {
                int sum = 0;
                int left = startIndex;
                int right = nums.Length - 1;
                while (left < right)
                {
                    if (nums[left] + nums[right] < target)
                    {
                        sum += right - left;
                        left++;
                    }
                    else
                    {
                        right--;
                    }
                }
                return sum;
            }
        }

        /// <summary>
        /// https://leetcode-cn.com/problems/3sum-closest/
        /// </summary>
        public int ThreeSumClosest(int[] nums, int target)
        {
            Array.Sort(nums);
            var res = nums[0] + nums[1] + nums[nums.Length - 1];
            for (var i = 0; i < nums.Length - 2; i++)
            {
                var start = i + 1;
                var end = nums.Length - 1;
                while (start < end)
                {
                    var sum = nums[i] + nums[start] + nums[end];
                    if (sum > target)
                    {
                        end--;
                    }
                    else
                    {
                        start++;
                    }
                    if (Math.Abs(sum - target) < Math.Abs(res - target))
                    {
                        res = sum;
                    }
                }
            }
            return res;
        }

        /// <summary>
        /// https://leetcode-cn.com/problems/4sum/
        /// </summary>
        public IList<IList<int>> FourSum(int[] nums, int target)
        {
            var res = new List<IList<int>>();
            if (nums == null || nums.Length == 0)
            {
                return res;
            }

            Array.Sort(nums);
            var map = new Dictionary<string, List<int>>();
            for (var i = 0; i < nums.Length - 3; i++)
            {
                if (i > 0 && nums[i] == nums[i - 1])
                {//same as last time
                    continue;
                }
                if (nums[i] + nums[nums.Length - 3] + nums[nums.Length - 1] + nums[nums.Length - 2] < target)
                {
                    continue;
                }
                for (var j = i + 1; j < nums.Length - 2; j++)
                {
                    if (j > i + 1 && nums[j] == nums[j - 1])
                    {
                        continue;
                    }
                    ////---------------------extra-------------------------------------------------------
                    if (nums[i] + nums[j] + nums[j + 1] + nums[j + 2] > target)
                    {
                        break;
                    }
                    //---------------------end extra---------------------------------------------------
                    var left = j + 1;
                    var right = nums.Length - 1;
                    while (left < right)
                    {
                        if (nums[left] + nums[right] < target - nums[i] - nums[j])
                        {
                            left++;
                        }
                        else if (nums[left] + nums[right] > target - nums[i] - nums[j])
                        {
                            right--;
                        }
                        else
                        {
                            if (!map.ContainsKey("" + nums[i] + nums[j] + nums[left] + nums[right]))
                            {
                                map.Add("" + nums[i] + nums[j] + nums[left] + nums[right], new List<int> { nums[i], nums[j], nums[left], nums[right] });
                            }
                            left++;
                            right--;
                        }
                    }
                }
            }
            res.AddRange(map.Values.ToList());
            return res;
        }

        /// <summary>
        /// https://leetcode-cn.com/problems/subarray-sum-equals-k/
        /// </summary>
        public int SubarraySum(int[] nums, int k)
        {
            //这儿map用来记录sum[0:i]的值的出现次数
            var sum2count = new Dictionary<int, int>();

            int ret = 0;
            int sum = 0;//指上图中sum[0:j]
            int key;
            sum2count.Add(0, 1);
            foreach (var v in nums)
            {
                sum += v;
                key = sum - k;//指上图中sum[0:i]
                if (sum2count.ContainsKey(key))//说明sum[i:j]的值就是k
                    ret += sum2count[key];

                if (!sum2count.ContainsKey(sum))
                    sum2count.Add(sum, 1);
                else
                    ++sum2count[sum];
            }
            return ret;
        }

        /// <summary>
        /// https://leetcode-cn.com/problems/subarray-product-less-than-k/
        /// </summary>
        public int NumSubarrayProductLessThanK(int[] nums, int k)
        {
            if (k <= 1) return 0;
            int prod = 1, ans = 0, left = 0;
            for (int right = 0; right < nums.Length; right++)
            {
                prod *= nums[right];
                while (prod >= k)
                    prod /= nums[left++];
                ans += right - left + 1;
            }
            return ans;
        }
    }
}
