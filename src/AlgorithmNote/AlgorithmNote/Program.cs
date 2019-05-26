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
            for (var i = 0; i < 1000000; i++)
            {
                var arr = GenerateTestCase(i);
                var stopwatch = new Stopwatch();
                stopwatch.Start();
                BubbleSort<int>.Sort(arr, i);
                stopwatch.Stop();
                var time = stopwatch.ElapsedMilliseconds / 1000;
                Console.WriteLine("BubbleSort in {0} minutes, {1} seconds", time / 60, time % 60);
                
            }
            
        }

        public static int[] GenerateTestCase(int n)
        {
            var res = new int[n];
            var random = new Random();
            for (var i = 0; i < n; i++)
            {
                res[i] = random.Next();
            }

            return res;
        }
    }
}
