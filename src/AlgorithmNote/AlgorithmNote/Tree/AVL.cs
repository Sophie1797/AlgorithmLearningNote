using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmNote
{
    public class AVL
    {
        public int GetHeight(AVLTreeNode node)
        {
            if (node == null) return 0;
            return node.Height;
        }

        public int GetBalanceFator(AVLTreeNode node)
        {
            return GetHeight(node.Left) - GetHeight(node.Right);
        }

        public void UpdateHeight(AVLTreeNode node)
        {
            node.Height = Math.Max(GetHeight(node.Left), GetHeight(node.Right)) + 1;
        }

        public AVLTreeNode Search(AVLTreeNode root, int x)
        {
            if (root == null) return null;
            if (x == root.Value) return root;
            else if (x < root.Value) return Search(root.Left, x);
            else return Search(root.Right, x);
        }

        public void L(AVLTreeNode root)
        {
            var temp = root.Right;
            root.Right = temp.Left;
            temp.Left = root;
            UpdateHeight(root);
            UpdateHeight(temp);
            root = temp;
        }

        public void R(AVLTreeNode root)
        {
            var temp = root.Left;
            root.Left = temp.Right;
            temp.Right = root;
            UpdateHeight(root);
            UpdateHeight(temp);
            root = temp;
        }

        public void Insert(AVLTreeNode root, int x)
        {
            if (root == null)
            {
                var node = new AVLTreeNode(x);
                return;
            }
            if (x < root.Value)
            {
                Insert(root.Left, x);
                UpdateHeight(root);
                if (GetBalanceFator(root) == 2)
                {
                    if (GetBalanceFator(root.Left) == 1)
                    {
                        R(root);
                    }
                    else if (GetBalanceFator(root.Left) == -1)
                    {
                        L(root.Left);
                        R(root);
                    }
                }
            }
            else
            {
                Insert(root.Right, x);
                UpdateHeight(root);
                if (GetBalanceFator(root) == -2)
                {
                    if (GetBalanceFator(root.Right) == 1)
                    {
                        R(root.Right);
                        L(root);
                    }
                    else if (GetBalanceFator(root.Right) == -1)
                    {
                        L(root);
                    }
                }
            }
        }

        public AVLTreeNode Create(int[] data, int n)
        {
            AVLTreeNode root = null;
            for (var i = 0; i < n; i++)
            {
                Insert(root, data[i]);
            }
            return root;
        }
    }

    public class AVLTreeNode
    {
        public int Value { get; set; }
        public int Height { get; set; }
        public AVLTreeNode Left { get; set; }
        public AVLTreeNode Right { get; set; }

        public AVLTreeNode(int v)
        {
            Value = v;
            Height++;
            var list = new List<int>();
        }
    }
}
