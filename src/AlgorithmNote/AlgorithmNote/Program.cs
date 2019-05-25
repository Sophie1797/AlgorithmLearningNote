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
            var bst = new BST<int>();
            var nums = new int[] {5, 3, 6, 8, 4, 2};
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
