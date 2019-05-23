using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmNote
{
    public class LinkedListQueue<T> : IQueue<T>
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

        private Node head, tail;
        private int size;

        public LinkedListQueue() { }

        public T Dequeue()
        {
            if (IsEmpty())
            {
                throw new ArgumentException("Cannot dequeue from an empty queue.");
            }

            var retNode = head;
            head = head.next;
            retNode.next = null;
            if (head == null)
            {
                tail = null;
            }

            size--;
            return retNode.e;
        }

        public void Enqueue(T e)
        {
            if (tail == null)
            {
                tail = new Node(e);
                head = tail;
            }
            else
            {
                tail.next = new Node(e);
                tail = tail.next;
            }

            size++;
        }

        public T GetFront()
        {
            if (IsEmpty())
            {
                throw new ArgumentException("Queue is empty.");
            }

            return head.e;
        }

        public int GetSize()
        {
            return size;
        }

        public bool IsEmpty()
        {
            return size == 0;
        }

        public override string ToString()
        {
            var res = new StringBuilder();
            res.Append("Queue: front ");

            var cur = head;
            while (cur != null)
            {
                res.Append(cur + "->");
                cur = cur.next;
            }

            res.Append("NULL tail");

            return res.ToString();
        }
    }
}
