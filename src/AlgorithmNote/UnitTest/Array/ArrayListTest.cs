using System;
using AlgorithmNote;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class ArrayListTest
    {
        [TestMethod]
        public void TestArrayList()
        {
            var arr = new ArrayList<int>(20);
            for (var i = 0; i < 10; i++)
            {
                arr.AddLast(i);
            }
            Console.WriteLine(arr);
            arr.Add(1, 100);
            Console.WriteLine(arr);
            arr.AddFirst(-1);
            Console.WriteLine(arr);
            arr.Remove(2);
            Console.WriteLine(arr);
            arr.RemoveElement(4);
            Console.WriteLine(arr);
            arr.RemoveFirst();
            Console.WriteLine(arr);
        }
    }
}
