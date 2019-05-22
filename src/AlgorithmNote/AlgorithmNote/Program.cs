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
