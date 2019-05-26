using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmNote.Tree
{
    public class SegmentTree
    {
        public int[] tree;
        public int n = 0;
        public SegmentTree(int[] nums)
        {
            if (nums.Length > 0)
            {
                n = nums.Length;
                tree = new int[n * 2];
                BuildTree(nums);
            }
        }

        public void Update(int pos, int val)
        {
            pos += n;
            tree[pos] = val;
            while (pos > 0)
            {
                var left = pos;
                var right = pos;
                if (pos % 2 == 0)
                {
                    right = pos + 1;
                }
                else
                {
                    left = pos - 1;
                }
                tree[left / 2] = tree[left] + tree[right];
                pos /= 2;//be its father
            }
        }

        public int SumRange(int l, int r)
        {
            l += n;
            r += n;
            var sum = 0;
            while (l <= r)
            {
                if (l % 2 == 1)
                {
                    sum += tree[l];
                    l++;
                }
                if (r % 2 == 0)
                {
                    sum += tree[r];
                    r--;
                }
                l /= 2;
                r /= 2;
            }
            return sum;
        }

        private void BuildTree(int[] nums)
        {
            for (int i = n, j = 0; i < 2 * n; i++, j++)
            {
                tree[i] = nums[j];
            }
            for (var i = n - 1; i > 0; --i)
            {
                tree[i] = tree[i * 2] + tree[i * 2 + 1];
            }
        }
    }

}
