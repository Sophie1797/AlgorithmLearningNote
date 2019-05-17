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
