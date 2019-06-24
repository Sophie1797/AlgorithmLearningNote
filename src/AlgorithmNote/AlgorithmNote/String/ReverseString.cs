using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmNote.String
{
    public class StringReverse
    {
        /// <summary>
        /// 344. 反转字符串
        /// </summary>
        public void ReverseString(char[] s)
        {
            var i = 0; var j = s.Length - 1;
            while (i < j)
            {
                var temp = s[i];
                s[i] = s[j];
                s[j] = temp;
                i++; j--;
            }
        }

        /// <summary>
        /// 541. 反转字符串 II
        /// 2k个一组，翻转每组前k个
        /// 不满k个的组全部翻转，介于k和2k之间的组翻转前k个
        /// </summary>
        public string ReverseStr(string s, int k)
        {
            var res = s.ToArray();
            var i = 0;
            while (i < s.Length)
            {
                var l = i;
                var r = i + k - 1;
                if (r >= s.Length)
                {
                    r = s.Length - 1;//如果r到了数组边界，令r等于最后一个元素下标
                }
                while (l < r)
                {
                    var t = res[l];
                    res[l] = res[r];
                    res[r] = t;
                    l++; r--;
                }
                i += k * 2;
            }
            return new string(res);
        }
    }

    /// <summary>
    /// 151. 翻转字符串里的单词
    /// </summary>
    public class WordsReverseI
    {
        public string ReverseWords(string s)
        {
            var list = s.Split(' ').Where(t => t != "").ToList();
            list.Reverse();
            return string.Join(" ", list);
        }
    }


    /// <summary>
    /// 186. 翻转字符串里的单词 II
    /// </summary>
    public class WordsReverseII
    {
        public void ReverseWords(char[] str)
        {
            var i = 0; var j = str.Length - 1;
            Swap(str, i, j);
            i = 0; j = 0;
            while (j < str.Length)
            {//每个单词
                while (j < str.Length && str[j] != ' ')
                {//每个单词内部
                    j++;
                }
                Swap(str, i, j - 1);
                i = j + 1; j = i;
            }
        }

        public void Swap(char[] str, int i, int j)
        {
            while (i < j)
            {
                var temp = str[i];
                str[i] = str[j];
                str[j] = temp;
                i++; j--;
            }
        }
    }

    /// <summary>
    /// 557. 反转字符串中的单词 III
    /// </summary>
    public class WordsReverseIII
    {
        public string ReverseWords(string s)
        {
            var arr = s.ToArray();
            var i = 0; var j = 0;
            while (i < s.Length)
            {
                while (j < s.Length && arr[j] != ' ')
                {
                    j++;
                }
                Swap(arr, i, j - 1);
                i = j + 1; j = i;
            }
            return new string(arr);
        }

        public void Swap(char[] str, int i, int j)
        {
            while (i < j)
            {
                var temp = str[i];
                str[i] = str[j];
                str[j] = temp;
                i++; j--;
            }
        }
    }
}
