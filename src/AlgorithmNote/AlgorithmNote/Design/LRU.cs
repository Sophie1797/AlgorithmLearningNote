using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cache
{
    /// <summary>
    /// "最近最少使用"缓存算法
    /// </summary>
    public class LRUCache
    {
        public LinkedList<Tuple<int, int>> lru = new LinkedList<Tuple<int, int>>();
        public Dictionary<int, LinkedListNode<Tuple<int, int>>> map = new Dictionary<int, LinkedListNode<Tuple<int, int>>>();
        public int Cap;

        public LRUCache(int capacity)
        {
            Cap = capacity;
        }

        public int Get(int key)
        {
            LinkedListNode<Tuple<int, int>> node;
            if(map.TryGetValue(key, out node))
            {
                UpdateOrder(node);
                return node.Value.Item2;
            }
            return -1;
        }

        public void Put(int key, int value)
        {
            LinkedListNode<Tuple<int, int>> node;
            if (map.TryGetValue(key, out node))
            {
                node.Value = new Tuple<int, int>(key, value);
                UpdateOrder(node);
                return;
            }
            if (Cap == map.Count)
            {
                var tail = lru.Last;
                map.Remove(tail.Value.Item1);
                lru.RemoveLast();
            }
            node = new LinkedListNode<Tuple<int, int>>(new Tuple<int, int>(key, value));
            lru.AddFirst(node);
            map.Add(key, node);
        }

        private void UpdateOrder(LinkedListNode<Tuple<int, int>> node)
        {
            lru.Remove(node);
            lru.AddFirst(node);
        }
    }
}
