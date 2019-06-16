using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgorithmNote;

namespace UnitTest
{
    [TestClass]
    public class HeapTest
    {
        [TestMethod]
        public void TestMaxHeap()
        {
            int n = 1000000;
            MaxHeap<int> heap = new MaxHeap<int>();
            Random random = new Random();
            for (var i = 0; i < n; i++)
            {
                heap.Add(random.Next(int.MaxValue));
            }

            var arr = new int[n];
            for (var i = 0; i < n; i++)
            {
                arr[i] = heap.ExtractMax();
            }

            for (var i = 1; i < n; i++)
            {
                if (arr[i - 1] < arr[i])
                {
                    throw new ArgumentException("Error");
                }
            }

            Console.WriteLine("Test Success");
        }

        [TestMethod]
        public void TestMinHeap()
        {
            int n = 1000000;
            var heap = new MinHeap<int>();
            Random random = new Random();
            for (var i = 0; i < n; i++)
            {
                heap.Add(random.Next(int.MaxValue));
            }

            var arr = new int[n];
            for (var i = 0; i < n; i++)
            {
                arr[i] = heap.ExtractMin();
            }

            for (var i = 1; i < n; i++)
            {
                if (arr[i - 1] > arr[i])
                {
                    throw new ArgumentException("Error");
                }
            }

            Console.WriteLine("Test Success");
        }
    }
}
