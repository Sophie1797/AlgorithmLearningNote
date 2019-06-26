using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmNote
{
    public class KMP
    {
        /// <summary>
        /// 28. 实现strStr()
        /// 在c#里面应该对应的是IndexOf()
        /// </summary>
        /// <param name="S">给定s</param>
        /// <param name="T">pattern</param>
        /// <returns>匹配的下标</returns>
        public int StrStr(string S, string T)
        {
            if (string.IsNullOrEmpty(T)) return 0;
            var next = GetNext(T);
            var i = 0; var j = 0;
            while (i < S.Length && j < T.Length)
            {
                if (j == -1 || S[i] == T[j])
                {
                    i++; j++;
                }
                else j = next[j];
            }
            if (j == T.Length) return i - j;
            return -1;
        }

        private int[] GetNext(string t)
        {
            var next = new int[t.Length];
            next[0] = -1;
            var i = 0; var j = -1;
            while (i < t.Length - 1)
            {
                if (j == -1 || t[i] == t[j])
                {
                    i++; j++;
                    next[i] = j;
                }
                else j = next[j];
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

