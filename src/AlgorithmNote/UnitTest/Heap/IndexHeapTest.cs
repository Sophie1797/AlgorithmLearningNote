using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgorithmNote;

namespace UnitTest
{
    [TestClass]
    public class IndexHeapTest
    {
        [TestMethod]
        public void TestIndexMinHeap()
        {
            int n = 1000000;
            Random random = new Random();
            var heap = new IndexMinHeap<int>(n);
            for (int i = 0; i < n; i++)
                heap.Add((int)(random.Next() * n));

            var arr = new int[n];
            for (var i = 0; i < n; i++)
            {
                arr[i] = heap.ExtractMin();
            }

            var success = true;
            for (var i = 1; i < n; i++)
            {
                if (arr[i - 1] > arr[i])
                {
                    success = false;
                }
            }

            Assert.AreEqual(true, success);
        }
        
        [TestMethod]
        public void TestIndexMinHeap_List()
        {
            int n = 1000000;
            Random random = new Random(111);
            var heap = new IndexMinHeap_List<int>(n);
            for (int i = 0; i < n; i++)
                heap.Add(random.Next(1000000));

            var arr = new int[n];
            for (var i = 0; i < n; i++)
            {
                arr[i] = heap.ExtractMin();
            }

            var success = true;
            for (var i = 1; i < n; i++)
            {
                if (arr[i - 1] > arr[i])
                {
                    success = false;
                }
            }

            Assert.AreEqual(true, success);
        }
    }
}
