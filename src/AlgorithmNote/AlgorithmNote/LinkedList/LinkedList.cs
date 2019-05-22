using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmNote
{
    public class LinkedList<T>
    {
        private class Node
        {
            public T e;
            public Node next;

            public Node() { }

            public Node(T e, Node next = null)
            {
                this.e = e;
                this.next = next;
            }

            public override string ToString()
            {
                return e.ToString();
            }
        }

        private Node dummyHead;
        private int size;

        public LinkedList()
        {
            dummyHead = new Node();
        }

        /// <summary>
        /// 获取链表中的元素个数
        /// </summary>
        /// <returns></returns>
        public int GetSize()
        {
            return size;
        }

        /// <summary>
        /// 返回链表是否为空
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return size == 0;
        }

        /// <summary>
        /// 在链表的index(0-based)位置添加新的元素e
        /// </summary>
        /// <param name="index"></param>
        /// <param name="e"></param>
        public void Add(int index, T e)
        {
            if (index < 0 || index > size)
            {
                throw new ArgumentException("Add failed. Illegal index.");
            }

            var prev = dummyHead;
            for (var i = 0; i < index; i++)
            {
                prev = prev.next;
            }

            prev.next = new Node(e, prev.next);
            size++;
        }

        /// <summary>
        /// 在链表头添加元素
        /// </summary>
        /// <param name="e"></param>
        public void AddFirst(T e)
        {
            Add(0, e);
        }

        /// <summary>
        /// 在链表末尾添加新的元素e
        /// </summary>
        /// <param name="e"></param>
        public void AddLast(T e)
        {
            Add(size, e);
        }

        /// <summary>
        /// 获取链表的索引为index的元素
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T Get(int index)
        {
            if (index < 0 || index >= size)
            {
                throw new ArgumentException("Get failed. Illegal index.");
            }

            var cur = dummyHead.next;
            for (var i = 0; i < index; i++)
            {
                cur = cur.next;
            }

            return cur.e;
        }

        /// <summary>
        /// 获取链表中第一个元素
        /// </summary>
        /// <returns></returns>
        public T GetFirst()
        {
            return Get(0);
        }

        /// <summary>
        /// 获取链表中最后一个元素
        /// </summary>
        /// <returns></returns>
        public T GetLast()
        {
            return Get(size - 1);
        }

        /// <summary>
        /// 修改链表中索引为index的元素
        /// </summary>
        /// <param name="index"></param>
        /// <param name="e"></param>
        public void Set(int index, T e)
        {
            if (index < 0 || index >= size)
            {
                throw new ArgumentException("Set failed. Illegal index.");
            }

            var cur = dummyHead.next;
            for (var i = 0; i < index; i++)
            {
                cur = cur.next;
            }

            cur.e = e;
        }

        /// <summary>
        /// 查找链表中是否有元素e
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public bool Contains(T e)
        {
            var cur = dummyHead.next;
            while (cur != null)
            {
                if (cur.e.Equals(e))
                {
                    return true;
                }

                cur = cur.next;
            }

            return false;
        }

        /// <summary>
        /// 从链表中删除索引为index的结点
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T Remove(int index)
        {
            if (index < 0 || index >= size)
            {
                throw new ArgumentException("Remove failed. Illegal index.");
            }

            var prev = dummyHead;
            for (var i = 0; i < index; i++)
            {
                prev = prev.next;
            }

            var retNode = prev.next;
            prev.next = retNode.next;
            retNode.next = null;
            size--;

            return retNode.e;
        }

        /// <summary>
        /// 删除链表中第一个节点
        /// </summary>
        /// <returns></returns>
        public T RemoveFirst()
        {
            return Remove(0);
        }

        /// <summary>
        /// 删除链表中最后一个节点
        /// </summary>
        /// <returns></returns>
        public T RemoveLast()
        {
            return Remove(size - 1);
        }

        public override string ToString()
        {
            var res = new StringBuilder();
            var cur = dummyHead.next;
            while (cur != null)
            {
                res.Append(cur + "->");
                cur = cur.next;
            }

            res.Append("NULL");

            return res.ToString();
        }
    }
}
