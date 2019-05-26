using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cache
{
    public class LFUCache
    {
        public int Cap;
        public LinkedList<LFUNode> lru = new LinkedList<LFUNode>();
        public Dictionary<int, LinkedListNode<LFUNode>> map = new Dictionary<int, LinkedListNode<LFUNode>>();
        public Dictionary<int, int> frequent = new Dictionary<int, int>();

        public LFUCache(int capacity)
        {
            Cap = capacity;
        }

        public int Get(int key)
        {
            //Console.WriteLine("get: " + key);
            LinkedListNode<LFUNode> node;
            if (map.TryGetValue(key, out node))
            {
                node.Value.Count++;
                UpdateOrder(node);
                return node.Value.Value;
            }
            return -1;
        }

        public void Put(int key, int value)
        {
            //Console.WriteLine(key);
            //1.如果key位置有值就把原值覆盖了然后调整到列表头
            LinkedListNode<LFUNode> node;
            if (map.TryGetValue(key, out node))
            {
                node.Value = new LFUNode(key, value, node.Value.Count + 1);
                UpdateOrder(node);
                return;
            }
            //2.如果key位置没有值但是满了，把最后一个挪出去
            if (Cap == map.Count)
            {
                if (Cap == 0) return;
                var tail = lru.Last;
                map.Remove(tail.Value.Key);
                lru.RemoveLast();
            }
            //3.直接插入到列表last,then update
            node = new LinkedListNode<LFUNode>(new LFUNode(key, value, 1));
            lru.AddLast(node);
            UpdateOrder(node);
            map.Add(key, node);
        }

        private void UpdateOrder(LinkedListNode<LFUNode> node)
        {
            var pre = node.Previous;
            if (pre == null)
            {
                return;
            }
            lru.Remove(node);
            while (pre != null && node.Value.Count >= pre.Value.Count)
            {
                pre = pre.Previous;
            }
            if (pre == null)
            {
                lru.AddFirst(node);
            }
            else
            {
                lru.AddAfter(pre, node);
            }
        }
    }

    public class LFUNode
    {
        public int Key { get; set; }
        public int Value { get; set; }
        public int Count { get; set; }

        public LFUNode(int k, int v, int c)
        {
            Key = k;
            Value = v;
            Count = c;
        }
    }
}
