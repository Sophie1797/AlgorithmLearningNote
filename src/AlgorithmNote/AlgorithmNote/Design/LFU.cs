using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cache
{
    /// <summary>
    /// "最不经常使用"缓存算法
    /// </summary>
    public class LFUCache
    {
        public int Cap;
        public LinkedList<LFUNode> lfu = new LinkedList<LFUNode>();
        public Dictionary<int, LinkedListNode<LFUNode>> map = new Dictionary<int, LinkedListNode<LFUNode>>();

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
                var tail = lfu.Last;
                map.Remove(tail.Value.Key);
                lfu.RemoveLast();
            }
            //3.直接插入到列表last, then update, add to map also
            node = new LinkedListNode<LFUNode>(new LFUNode(key, value, 1));
            lfu.AddLast(node);
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

            // 1. remove node from current place
            lfu.Remove(node);

            // 2. find the last previous node which is more frequent
            while (pre != null && node.Value.Count >= pre.Value.Count)
            {
                pre = pre.Previous;
            }

            // 3. Add node after this previous node
            if (pre == null)
            {
                lfu.AddFirst(node);
            }
            else
            {
                lfu.AddAfter(pre, node);
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
}
