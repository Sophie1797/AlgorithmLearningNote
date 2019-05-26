using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringBase
{
    public class BigNumOperation
    {
        public int[] PlusOne(int[] digits)
        {
            int c = 1;
            for (var i = digits.Length - 1; i >= 0; i--)
            {
                digits[i + 1] += (c + digits[i]) % 10;
                c = (c + digits[i]) / 10;
            }
            if (c == 1)
            {
                return new int[] { 1 }.Concat(digits).ToArray();
            }
            else
            {
                return digits;
            }
        }

        public string AddBinary(string a, string b)
        {
            var s = "";
            int i = a.Length - 1;
            int j = b.Length - 1;
            int c = 0;
            while (i >= 0 || j >= 0 || c == 1)
            {
                c += i >= 0 ? a[i--] - '0' : 0;
                c += j >= 0 ? b[j--] - '0' : 0;
                s = c % 2 + s;
                c /= 2;
            }
            return s;
        }

        public string AddStrings(string a, string b)
        {
            string s = "";
            int c = 0, i = a.Length - 1, j = b.Length - 1;
            while (i >= 0 || j >= 0 || c == 1)
            {
                c += i >= 0 ? a[i--] - '0' : 0;
                c += j >= 0 ? b[j--] - '0' : 0;
                s = c % 10 + s;//取最后一位
                c /= 10;
            }
            return s;
        }

        public string MinusStrings(string a, string b)
        {
            string s = "";
            int c = 0, i = a.Length - 1, j = b.Length - 1;
            while (i >= 0 || j >= 0 || c == 1)
            {
                var big = a[i] - '0' - c;
                var small = j >= 0 ? b[j] - '0' : 0;
                c = 0;
                if (big < small)
                {
                    big = big + 10;
                    c = 1;
                }
                s = (big - small) + s;
                i--;j--;
            }
            var nonZ = 0;
            while (nonZ < s.Length - 1 && s[nonZ] == '0') nonZ++;
            return s.Substring(nonZ);
        }

        public string MultiplyStrings(string num1, string num2)
        {
            var n = num1.Length; var m = num2.Length;
            if (n == 0 && m == 0) return "";
            var pos = new int[m + n];
            for (var i = m - 1; i >= 0; i--)
            {
                for (var j = n - 1; j >= 0; j--)
                {
                    var mul = (num1[j] - '0') * (num2[i] - '0');
                    var p1 = i + j; var p2 = i + j + 1;
                    var sum = pos[p2] + mul;
                    pos[p1] += sum / 10;//注意+=
                    pos[p2] = sum % 10;
                }
            }
            var res = string.Concat(pos.Select(t => t + ""));
            int nonZ = 0;
            while (nonZ < res.Length - 1 && res[nonZ] == '0') nonZ++;
            return res.Substring(nonZ);
        }
    }
}

