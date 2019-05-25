using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmNote
{
    public class BST<T> where T:IComparable<T>
    {
        private class Node
        {
            public T e;
            public Node left;
            public Node right;

            public Node(T e)
            {
                this.e = e;
            }
        }

        private Node root;
        private int size;

        public int GetSize()
        {
            return size;
        }

        public bool IsEmpty()
        {
            return size == 0;
        }

        /// <summary>
        /// 向二分搜索树中添加新的元素
        /// </summary>
        /// <param name="e"></param>
        public void Add(T e)
        {
            root = Add(root, e);
        }

        private Node Add(Node node, T e)
        {
            if (node == null)
            {
                size++;
                return new Node(e);
            }

            if (e.CompareTo(node.e) < 0)
            {
                node.left = Add(node.left, e);
            }
            else if (e.CompareTo(node.e) > 0)
            {
                node.right = Add(node.right, e);
            }

            return node;
        }

        /// <summary>
        /// 查看二分搜索树中是否包含元素e
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public bool Contains(T e)
        {
            return Contains(root, e);
        }

        private bool Contains(Node node, T e)
        {
            if (node == null)
            {
                return false;
            }
            if (node.e.Equals(e))
            {
                return true;
            }
            if (e.CompareTo(node.e) < 0)
            {
                return Contains(node.left, e);
            }
            else
            {
                return Contains(node.right, e);
            }
        }

        /// <summary>
        /// 二分搜索树的前序遍历
        /// </summary>
        public void PreOrder()
        {
            PreOrder(root);
        }

        private void PreOrder(Node node)
        {
            if (node == null)
            {
                return;
            }

            Console.WriteLine(node.e);
            PreOrder(node.left);
            PreOrder(node.right);
        }

        public void PreOrderNR()
        {
            var stack = new Stack<Node>();
            stack.Push(root);
            while(stack.Count!=0)
            {
                var cur = stack.Pop();
                Console.WriteLine(cur.e);
                if (cur.right != null)
                {
                    stack.Push(cur.right);
                }
                if (cur.left != null)
                {
                    stack.Push(cur.left);
                }
            }
        }
        
        /// <summary>
        /// 二分搜索树的中序遍历
        /// </summary>
        public void InOrder()
        {
            InOrder(root);
        }

        private void InOrder(Node node)
        {
            if (node == null)
            {
                return;
            }

            InOrder(node.left);
            Console.WriteLine(node.e);
            InOrder(node.right);
        }

        public void InOrderNR()
        {
            var stack = new Stack<Node>();
            var p = root;
            while (stack.Count != 0 || p != null)
            {
                while (p != null)
                {
                    stack.Push(p);
                    p = p.left;
                }

                p = stack.Pop();
                Console.WriteLine(p.e);
                p = p.right;
            }
        }

        /// <summary>
        /// 二分搜索树的后序遍历
        /// </summary>
        public void PostOrder()
        {
            PostOrder(root);
        }

        private void PostOrder(Node node)
        {
            if (node == null)
            {
                return;
            }

            PostOrder(node.left);
            PostOrder(node.right);
            Console.WriteLine(node.e);
        }

        public void PostOrderNR()
        {
            var stack = new Stack<Node>();
            if (root == null) return;

            var cur = root;
            while (stack.Count != 0 || cur != null)
            {
                if (cur != null)
                {
                    stack.Push(cur);
                    cur = cur.left;
                    //visit left first
                }
                else
                {
                    var node = stack.Peek().right; // left has done, check whether we have right side unvisited
                    if (node == null)
                    { //right side is null, no need to visit, so pop out the node, we can add to list
                        node = stack.Pop();
                        Console.WriteLine(node.e);
                        while (stack.Count != 0 && stack.Peek().right == node)
                        {
                            node = stack.Pop();
                            Console.WriteLine(node.e); // right side has done
                        }
                    }
                    else
                    {
                        cur = node;//deal with right side
                    }
                }
            }
        }

        public void LevelOrder()
        {
            var queue = new Queue<Node>();
            queue.Enqueue(root);
            while (queue.Count != 0)
            {
                var cur = queue.Dequeue();
                Console.WriteLine(cur.e);
                if (cur.left != null)
                {
                    queue.Enqueue(cur.left);
                }
                if (cur.right != null)
                {
                    queue.Enqueue(cur.right);
                }
            }
        }
    }
}

