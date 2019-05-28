using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmNote
{
    class Program
    {
        static void Main(string[] args)
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

        public static int[] GenerateTestCase(int n)
        {
            var res = new int[n];
            var random = new Random(111);
            for (var i = 0; i < n; i++)
            {
                res[i] = random.Next(20);
            }

            return res;
        }

        public static int[] GenerateSortedTestCase(int n)
        {
            var res = new int[n];
            var random = new Random(111);
            for (var i = 0; i < n; i++)
            {
                res[i] = random.Next();
            }
            Array.Sort(res);

            return res;
        }
    }
}
