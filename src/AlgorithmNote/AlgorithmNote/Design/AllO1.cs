using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmNote
{
    public class AllOne
    {
        private class Node
        {
            public int value;
            public string key;
        }

        private Dictionary<string, LinkedListNode<Node>> _dict = new Dictionary<string, LinkedListNode<Node>>();
        private System.Collections.Generic.LinkedList<Node> _list = new System.Collections.Generic.LinkedList<Node>();

        /** Initialize your data structure here. */
        public AllOne()
        {
        }

        /** Inserts a new key <Key> with value 1. Or increments an existing key by 1. */
        public void Inc(string key)
        {
            if (_dict.ContainsKey(key))
            {
                var ln = _dict[key];
                ln.Value.value++;
                if (ln.Previous != null && ln.Previous.Value.value < ln.Value.value)
                {
                    var p = ln.Previous;
                    _list.Remove(ln);
                    while (p.Previous != null && p.Previous.Value.value < ln.Value.value)
                    {
                        p = p.Previous;
                    }

                    _list.AddBefore(p, ln);
                }
            }
            else
            {
                _dict[key] = _list.AddLast(new Node() { key = key, value = 1 });
            }
        }

        /** Decrements an existing key by 1. If Key's value is 1, remove it from the data structure. */
        public void Dec(string key)
        {
            if (!_dict.ContainsKey(key))
            {
                return;
            }

            var ln = _dict[key];
            ln.Value.value--;
            if (ln.Value.value == 0)
            {
                _dict.Remove(key);
                _list.Remove(ln);
            }
            if (ln.Next != null && ln.Next.Value.value > ln.Value.value)
            {
                var n = ln.Next;
                _list.Remove(ln);
                while (n.Next != null && n.Next.Value.value > ln.Value.value)
                {
                    n = n.Next;
                }

                _list.AddAfter(n, ln);
            }
        }

        /** Returns one of the keys with maximal value. */
        public string GetMaxKey()
        {
            return _list.First?.Value.key ?? string.Empty;
        }

        /** Returns one of the keys with Minimal value. */
        public string GetMinKey()
        {
            return _list.Last?.Value.key ?? string.Empty;
        }
    }

    /**
     * Your AllOne object will be instantiated and called as such:
     * AllOne obj = new AllOne();
     * obj.Inc(key);
     * obj.Dec(key);
     * string param_3 = obj.GetMaxKey();
     * string param_4 = obj.GetMinKey();
     */
}
