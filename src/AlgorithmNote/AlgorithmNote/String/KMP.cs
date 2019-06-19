using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmNote
{
    public class KMP
    {
        public int[] GetNextArr(string s)
        {
            // 每次求出next[i]时，总是让j指向next[i]
            int j = -1;
            int n = s.Length;
            // next[i]表示使子串s[0..i]的前缀s[0..k]等于后缀s[i-k..i]的最大的k
            int[] next = new int[n];
            // i为0的话，next[i]肯定是-1
            next[0] = -1;
            // i表示以i为结尾
            for(var i = 1; i < n; i++)
            {
                while (j != -1 && s[i] != s[j + 1])
                {
                    j = next[j];
                }

                if (s[i] == s[j + 1])
                {
                    j++;
                }

                next[i] = j;
            }
            return next;
        }

        public int[] GetNextValArr(string s)
        {
            int j = -1;
            int n = s.Length;
            // nextval的含义应该理解为当模式串pattern的i+1位失配时，i应当回退到的最佳位置
            int[] nextval = new int[n];
            nextval[0] = -1;
            for (var i = 1; i < n; i++)
            {
                while (j != -1 && s[i] != s[j + 1])
                {
                    j = nextval[j];
                }

                if (s[i] == s[j + 1])
                {
                    j++;
                }

                if (j != -1 && s[i + 1] == s[j + 1])//优化部分: 从上到下分析，从下到上写代码，动归
                {
                    nextval[i] = nextval[j];
                }
                else//优化部分--end
                {
                    nextval[i] = j;
                }
            }
            return nextval;
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

