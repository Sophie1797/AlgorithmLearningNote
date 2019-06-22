using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmNote.Tree.BasicTree
{
    public class ConstructTree
    {
        /// <summary>
        /// 889. 根据前序和后序遍历构造二叉树
        /// 注意，是普通二叉树，不是BST
        /// </summary>
        public class ConstructTreeFromPrePost
        {
            Dictionary<int, int> preDict = new Dictionary<int, int>();
            Dictionary<int, int> postDict = new Dictionary<int, int>();
            public TreeNode ConstructFromPrePost(int[] preorder, int[] postorder)
            {
                for (var i = 0; i < preorder.Length; i++)
                    preDict[preorder[i]] = i;

                for (var i = 0; i < postorder.Length; i++)
                    postDict[postorder[i]] = i;

                return helper(preorder, postorder, 0, postorder.Length - 1);
            }

            public TreeNode helper(int[] preorder, int[] postorder, int left, int right)
            {
                //Console.WriteLine(left+"  "+right+"  ");
                if (left > right)
                    return null;

                var root = new TreeNode(preorder[left]);

                if (left == right)
                    return root;

                var r = postDict[root.val] - 1;
                if (r < 0 || r >= postorder.Length) return root;
                var l = preDict[postorder[r]];

                root.left = helper(preorder, postorder, left + 1, l - 1);
                root.right = helper(preorder, postorder, l, right);

                return root;
            }

            
            public TreeNode ConstructFromPrePost2(int[] pre, int[] post)
            {
                int N = pre.Length;
                if (N == 0) return null;
                TreeNode root = new TreeNode(pre[0]);
                if (N == 1) return root;

                int L = 0;
                for (int i = 0; i < N; ++i)
                    if (post[i] == pre[1])
                        L = i + 1;

                var prel = new int[L];
                var postl = new int[L];
                Array.Copy(pre, 1, prel, 0, L);
                Array.Copy(post, 0, postl, 0, L);
                root.left = ConstructFromPrePost2(prel, postl);
                var prer = new int[N - L - 1];
                var postr = new int[N - L - 1];
                Array.Copy(pre, L + 1, prer, 0, N - L - 1);
                Array.Copy(post, L, postr, 0, N - L - 1);
                root.right = ConstructFromPrePost(prer, postr);
                return root;
            }
        }
        

        /// <summary>
        /// 105. 从前序与中序遍历序列构造二叉树
        /// </summary>
        public class ConstructTreeFromPreIn
        {
            int offset = 0;
            Dictionary<int, int> dict = new Dictionary<int, int>();
            public TreeNode BuildTree(int[] preorder, int[] inorder)
            {
                for (var i=0;i<inorder.Length;i++)
                {
                    dict[inorder[i]] = i;
                }

                return helper(preorder, inorder, 0, inorder.Length);
            }

            private TreeNode helper(int[] preorder, int[] inorder, int left, int right)
            {
                if (left == right)
                    return null;
                var rootVal = preorder[offset];
                var root = new TreeNode(rootVal);

                var index = dict[rootVal];

                offset++;
                root.left = helper(preorder, inorder, left, index);
                root.right = helper(preorder, inorder, index + 1, right);
                return root;
            }
        }

        /// <summary>
        /// 106. 从中序与后序遍历序列构造二叉树
        /// </summary>
        public class ConstructTreeFromPostIn
        {
            int offset = 0;
            Dictionary<int, int> dict = new Dictionary<int, int>();
            public TreeNode BuildTree(int[] inorder, int[] postorder)
            {
                for (var i = 0; i < inorder.Length; i++)
                {
                    dict[inorder[i]] = i;
                }
                offset = postorder.Length - 1;

                return helper(postorder, inorder, 0, inorder.Length);
            }

            private TreeNode helper(int[] postorder, int[] inorder, int left, int right)
            {
                if (left == right)
                    return null;
                var rootVal = postorder[offset];
                var root = new TreeNode(rootVal);

                var index = dict[rootVal];

                offset--;

                root.right = helper(postorder, inorder, index + 1, right);
                root.left = helper(postorder, inorder, left, index);

                return root;
            }
        }

        /// <summary>
        /// 1008. 先序遍历构造二叉树
        /// </summary>
        public class ConstructBstFromPreorder
        {
            public TreeNode BstFromPreorder(int[] preorder)
            {
                return helper(preorder, 0, preorder.Length - 1);
            }

            public TreeNode helper(int[] preorder, int left, int right)
            {
                if (left > right) return null;

                var root = new TreeNode(preorder[left]);
                if (left == right) return root;

                var k = Find(preorder, root.val, left + 1, right);

                root.left = helper(preorder, left + 1, k - 1);
                root.right = helper(preorder, k, right);
                return root;
            }

            public int Find(int[] arr, int target, int lo, int hi)
            {
                if (lo < 0 || lo >= arr.Length) return lo;
                while (lo < hi)
                {
                    int mid = lo + (hi - lo) / 2;
                    if (target <= arr[mid])
                    {
                        hi = mid;
                    }
                    else
                    {
                        lo = mid + 1;
                    }
                }
                if (arr[lo] >= target)
                {
                    return lo;
                }
                else
                {
                    return hi + 1;
                }
            }
        }

        /// <summary>
        /// 108. Convert Sorted Array to Binary Search Tree
        /// </summary>
        public class ConvertSortedArrayToBST
        {
            public TreeNode SortedArrayToBST(int[] nums)
            {
                return ToBST(nums, 0, nums.Length - 1);
            }

            public TreeNode ToBST(int[] nums, int start, int end)
            {
                if (start > end) return null;
                var mid = (start + end) / 2;
                var root = new TreeNode(nums[mid]);
                root.left = ToBST(nums, start, mid - 1);
                root.right = ToBST(nums, mid + 1, end);
                return root;
            }
        }
    }
}
