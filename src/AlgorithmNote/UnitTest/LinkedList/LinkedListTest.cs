using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgorithmNote;

namespace UnitTest
{
    [TestClass]
    public class LinkedListTest
    {
        [TestMethod]
        public void TestHeap()
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
    }
}
