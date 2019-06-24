using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmNote.Graph
{
    public class UnionFind
    {
        private int[] parent;
        private int[] rank;

        public int Count { get; private set; }

        public UnionFind(int size)
        {
            parent = new int[size];
            rank = new int[size];
            for (var i = 0; i < size; i++)
            {
                parent[i] = i;
                rank[i] = 1;
            }
            Count = size;
        }

        public int GetSize()
        {
            return parent.Length;
        }

        /// <summary>
        /// 查找元素p所对应的集合编号
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        private int Find(int p)
        {
            if (p < 0 && p >= parent.Length)
            {
                throw new ArgumentException("p is out of bound.");
            }

            while (p != parent[p])
            {
                parent[p] = parent[parent[p]];
                p = parent[p];
                //不用更新rank，因为rank低的依旧低，只是用来表示一个大概的排名作为union的参考
            }

            return p;
        }

        /// <summary>
        /// 查看元素p, q是否属于一个集合
        /// </summary>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        public bool IsConnected(int p, int q)
        {
            return Find(p) == Find(q);
        }

        public void UnionElements(int p, int q)
        {
            var pRoot = Find(p);
            var qRoot = Find(q);
            if (pRoot == qRoot)
            {
                return;
            }

            if (rank[pRoot] < rank[qRoot])
            {
                parent[pRoot] = qRoot;
            }
            else
            {
                parent[qRoot] = pRoot;
                if (rank[pRoot] == rank[qRoot])
                {
                    rank[pRoot]++;
                }
            }

            Count--;
        }
    }


}
