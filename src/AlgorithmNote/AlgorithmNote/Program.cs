using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmNote
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = new int[] {5, 3, 6, 8, 4, 2};
            var heap = new MaxHeap<int>(nums);
            while (!heap.IsEmpty())
            {
                Console.WriteLine(heap.ExtractMax());
            }
        }
    }
}
