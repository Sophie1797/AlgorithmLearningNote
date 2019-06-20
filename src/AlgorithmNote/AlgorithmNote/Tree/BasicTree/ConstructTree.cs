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
        public TreeNode ConstructFromPrePost(int[] pre, int[] post)
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
            root.left = ConstructFromPrePost(prel, postl);
            var prer = new int[N - L - 1];
            var postr = new int[N - L - 1];
            Array.Copy(pre, L + 1, prer, 0, N - L - 1);
            Array.Copy(post, L, postr, 0, N - L - 1);
            root.right = ConstructFromPrePost(prer, postr);
            return root;
        }
    }
}
