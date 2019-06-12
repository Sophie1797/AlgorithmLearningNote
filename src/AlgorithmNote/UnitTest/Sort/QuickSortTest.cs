using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgorithmNote;

namespace UnitTest
{
    [TestClass]
    class QuickSortTest: SortBaseTest
    {
        [TestMethod]
        public void TestQuickSort()
        {
            var i = 10000;
            var arr = GenerateTestCase(i);
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            QuickSort<int>.Sort(arr, 0, i - 1);
            stopwatch.Stop();
            var time = stopwatch.ElapsedMilliseconds;
            Console.WriteLine(time);

            stopwatch = new Stopwatch();
            stopwatch.Start();
            QuickSort<int>.Sort_Rand(arr, 0, i - 1);
            stopwatch.Stop();
            time = stopwatch.ElapsedMilliseconds;
            Console.WriteLine(time);

            stopwatch = new Stopwatch();
            stopwatch.Start();
            QuickSort<int>.Sort_3Ways(arr, 0, i - 1);
            stopwatch.Stop();
            time = stopwatch.ElapsedMilliseconds;
            Console.WriteLine(time);
        }
    }
}
