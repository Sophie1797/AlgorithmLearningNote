using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgorithmNote;

namespace UnitTest
{
    [TestClass]
    class BubbleSortTest
    {
        [TestMethod]
        public void TestBubbleSort()
        {
            var n = 100000;
            var arr = GenerateTestCase(n);

            var stopwatch = new Stopwatch();
            stopwatch.Start();
            BasicSort<int>.BubbleSort(arr, n);
            stopwatch.Stop();
            var time = stopwatch.ElapsedMilliseconds / 1000;
            Console.WriteLine("BubbleSort in {0} minutes, {1} seconds", time / 60, time % 60);
            Console.WriteLine(ValidSortResult(arr, true));

            stopwatch.Start();
            BasicSort<int>.BubbleSort_Slow(arr, n);
            stopwatch.Stop();
            time = stopwatch.ElapsedMilliseconds / 1000;
            Console.WriteLine("BubbleSort_Slow in {0} minutes, {1} seconds", time / 60, time % 60);
            Console.WriteLine(ValidSortResult(arr, true));
        }

        static int[] GenerateTestCase(int n)
        {
            var res = new int[n];
            var random = new Random();
            for (var i = 0; i < n; i++)
            {
                res[i] = random.Next();
            }

            return res;
        }

        static bool ValidSortResult(int[] arr, bool greater)
        {
            if (greater)
            {
                for (var i = 0; i < arr.Length - 1; i++)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        return false;
                    }
                }
            }
            else
            {
                for (var i = 0; i < arr.Length - 1; i++)
                {
                    if (arr[i] < arr[i + 1])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
