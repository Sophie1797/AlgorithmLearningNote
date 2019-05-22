using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgorithmNote;

namespace UnitTest
{
    [TestClass]
    public class LinkedListTest
    {
        [TestMethod]
        public void TestLinkedList()
        {
            var list = new LinkedList<int>();
            for (var i = 0; i < 5; i++)
            {
                list.AddFirst(i);
                Console.WriteLine(list);
            }

            list.Add(2, 666);
            Console.WriteLine(list);

            list.Remove(2);
            Console.WriteLine(list);

            list.RemoveFirst();
            Console.WriteLine(list);

            list.RemoveLast();
            Console.WriteLine(list);
        }
    }
}
