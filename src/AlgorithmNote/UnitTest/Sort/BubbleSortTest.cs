using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgorithmNote;

namespace UnitTest
{
    [TestClass]
    class BubbleSortTest: SortBaseTest
    {
        [TestMethod]
        public void TestBubbleSort()
        {
            var n = 100000;
            var arr = GenerateTestCase(n);

            var stopwatch = new Stopwatch();
            stopwatch.Start();
            BubbleSort<int>.Sort(arr, n);
            stopwatch.Stop();
            var time = stopwatch.ElapsedMilliseconds / 1000;
            Console.WriteLine("BubbleSort in {0} minutes, {1} seconds", time / 60, time % 60);
            Console.WriteLine(ValidSortResult(arr, true));

            stopwatch.Start();
            BubbleSort<int>.Sort_Slow(arr, n);
            stopwatch.Stop();
            time = stopwatch.ElapsedMilliseconds / 1000;
            Console.WriteLine("BubbleSort_Slow in {0} minutes, {1} seconds", time / 60, time % 60);
            Console.WriteLine(ValidSortResult(arr, true));
        }
    }
}
