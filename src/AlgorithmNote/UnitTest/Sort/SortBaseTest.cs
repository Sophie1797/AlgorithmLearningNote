using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    public class SortBaseTest
    {
        public static int[] GenerateTestCase(int n)
        {
            var res = new int[n];
            var random = new Random();
            for (var i = 0; i < n; i++)
            {
                res[i] = random.Next();
            }

            return res;
        }

        public static bool ValidSortResult(int[] arr, bool greater)
        {
            if (greater)
            {
                for (var i = 0; i < arr.Length - 1; i++)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        return false;
                    }
                }
            }
            else
            {
                for (var i = 0; i < arr.Length - 1; i++)
                {
                    if (arr[i] < arr[i + 1])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
