using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgorithmNote;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class TwoSumTest
    {
        [TestMethod]
        public void TestGetTwoSum()
        {
            var nums = new int[] { 2, 7, 11, 15 };
            var target = 9;
            var expected = new int[] {0, 1};
            var twoSum = new TwoSum();
            var res = twoSum.GetTwoSum(nums, target);
            Assert.AreEqual(res.Length, expected.Length);
            var correct = true;
            for (var i = 0; i < res.Length; i++)
            {
                if (res[i] != expected[i])
                {
                    correct = false;
                }
            }
            Assert.AreEqual(true, correct);
        }

        [TestMethod]
        public void TestGetTwoSumInSortedArray()
        {
            var nums = new int[] { 2, 7, 11, 15 };
            var target = 9;
            var expected = new int[] { 1, 2 };
            var twoSum = new TwoSum();
            var res = twoSum.GetTwoSumInSortedArray(nums, target);
            Assert.AreEqual(res.Length, expected.Length);
            var correct = true;
            for (var i = 0; i < res.Length; i++)
            {
                if (res[i] != expected[i])
                {
                    correct = false;
                }
            }
            Assert.AreEqual(true, correct);
        }
    }
}
