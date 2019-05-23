using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgorithmNote;

namespace UnitTest
{
    [TestClass]
    public class QueueTest
    {
        [TestMethod]
        public void TestLoopQueue()
        {
            var queue = new LoopQueue<int>();
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

        [TestMethod]
        public void TestLinkedListQueue()
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
