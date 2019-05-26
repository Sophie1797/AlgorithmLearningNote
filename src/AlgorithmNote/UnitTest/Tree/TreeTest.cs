using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgorithmNote;

namespace UnitTest
{
    [TestClass]
    public class TreeTest
    {
        [TestMethod]
        public void TestBasicTree()
        {
            var bst = new BST<int>();
            var nums = new int[] { 5, 3, 6, 8, 4, 2 };
            foreach (var num in nums)
            {
                bst.Add(num);
            }
            Console.WriteLine("PreOrder:");
            bst.PreOrder();
            Console.WriteLine("PreOrderNR:");
            bst.PreOrderNR();
            //Console.WriteLine("InOrder:");
            //bst.InOrder();
            //Console.WriteLine("PostOrder:");
            //bst.PostOrder();
        }
    }
}
