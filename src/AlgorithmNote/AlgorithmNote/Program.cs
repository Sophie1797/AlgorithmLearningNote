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
            var queue = new LinkedListQueue<int>();
            for (var i = 0; i < 10; i++)
            {
                queue.Enqueue(i);
                Console.WriteLine(queue);

                if (i % 3 == 2)
                {
                    queue.Dequeue();
                    Console.WriteLine(queue);
                }
            }
        }
    }
}
