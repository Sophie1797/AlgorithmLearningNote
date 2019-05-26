using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringBase
{
    public class KMP
    {
        public int[] GetNextArr(string s)
        {
            int j = -1;
            int n = s.Length;
            int[] next = new int[n];
            next[0] = -1;
            for(var i = 1; i < n; i++)
            {
                while (j != -1 && s[i] != s[j + 1])
                {
                    j = next[j];
                }
                if (s[i] == s[j + 1]) j++;
                next[i] = j;
            }
            return next;
        }

        public int[] GetNextArrModified(string s)
        {
            int j = -1;
            int n = s.Length;
            int[] next = new int[n];
            next[0] = -1;
            for (var i = 1; i < n; i++)
            {
                while (j != -1 && s[i] != s[j + 1])
                {
                    j = next[j];
                }
                if (s[i] == s[j + 1]) j++;
                if (j != -1 && s[i + 1] == s[j + 1])//优化部分: 从上到下分析，从下到上写代码，动归
                {
                    next[i] = next[j];
                }
                else//优化部分--end
                {
                    next[i] = j;
                }
            }
            return next;
        }

        public bool IsMatch(string s, string p)
        {
            if (p == "") return true;
            if (s == "") return false;
            int j = -1;
            var next = GetNextArr(p);
            for(var i = 0; i < s.Length; i++)
            {
                while (j != -1 && s[i] != p[j + 1])
                {
                    j = next[j];
                }
                if (s[i] == p[j + 1]) j++;
                if (j == p.Length - 1) return true;
            }
            return false;
        }

        public int CountMatchTimes(string s, string p)
        {
            if (p == "") return 1;
            if (s == "") return 0;
            int j = -1;
            int count = 0;
            var next = GetNextArr(p);
            for (var i = 0; i < s.Length; i++)
            {
                while (j != -1 && s[i] != p[j + 1])
                {
                    j = next[j];
                }
                if (s[i] == p[j + 1]) j++;
                if (j == p.Length - 1)
                {
                    count++;
                    j = next[j];
                }
            }
            return count;
        }
    }
}

