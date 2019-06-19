using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgorithmNote;

namespace UnitTest
{
    [TestClass]
    public class KMPTest
    {
        [TestMethod]
        public void TestKMPNextArray()
        {
            var s = "ababaab";
            var kmp = new KMP();
            var arr = kmp.GetNextArr(s);
            var expected = new int[] {-1, -1, 0, 1, 2, 0, 1};
            var success = true;
            Assert.AreEqual(expected.Length, arr.Length);
            for (var i = 0; i < arr.Length; i++)
            {
                if (arr[i] != expected[i])
                {
                    success = false;
                }
            }
            Assert.AreEqual(true, success);
        }
    }
}
