using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmNote
{
    /// <summary>
    /// 顺序栈，栈中元素始终保持有序
    /// </summary>
    public class OrderedStack
    {
        /// <summary>
        /// 496. 下一个更大元素 I
        /// 输入: nums1 = [4,1,2], nums2 = [1,3,4,2].
        /// 输出: [-1,3,-1]
        /// /// </summary>
        public int[] NextGreaterElement(int[] findNums, int[] nums)
        {
            var map = new Dictionary<int, int>();
            var stack = new Stack<int>();
            foreach (int num in nums)
            {
                while (stack.Count != 0 && stack.Peek() < num)
                    map.Add(stack.Pop(), num);
                stack.Push(num);
            }
            for (int i = 0; i < findNums.Length; i++)
                findNums[i] = map.ContainsKey(findNums[i]) ? map[findNums[i]] : -1;
            return findNums;
        }

        /// <summary>
        /// 503. 下一个更大元素 II
        /// 输入: [1,2,1]
        /// 输出: [2,-1,2]
        /// </summary>
        public int[] NextGreaterElements(int[] input)
        {
            var len = input.Length;
            var res = new int[len];
            var stack = new Stack<int>();
            for (var i = 0; i < len; i++)
            {
                res[i] = -1;
            }
            for (var i = 0; i < 2 * len; i++)
            {
                while (stack.Count != 0 && input[stack.Peek()] < input[i % len])
                {
                    var index = stack.Pop();
                    res[index] = input[i % len];
                }
                stack.Push(i % len);
            }
            return res;
        }

        /// <summary>
        /// 739. 每日温度
        /// 根据每日气温列表，生成一个列表，对应位置的输入是需要再等待多久温度才会升高的天数。
        /// 如果之后都不会升高，请输入 0 来代替。
        /// 例如，给定一个列表 temperatures = [73, 74, 75, 71, 69, 72, 76, 73]，
        /// 你的输出应该是 [1, 1, 4, 2, 1, 1, 0, 0]。
        /// </summary>
        public int[] DailyTemperatures(int[] T)
        {
            var n = T.Length;
            var res = new int[n];
            var stack = new Stack<int>();
            for (var i = n - 1; i >= 0; i--)
            {
                while (stack.Count != 0 && T[stack.Peek()] <= T[i])
                {
                    stack.Pop();
                }
                res[i] = stack.Count == 0 ? 0 : stack.Peek() - i;
                stack.Push(i);
            }
            return res;
        }

        /// <summary>
        /// 901. 股票价格跨度
        /// 编写一个 StockSpanner 类，它收集某些股票的每日报价，并返回该股票当日价格的跨度。
        /// 今天股票价格的跨度被定义为股票价格小于或等于今天价格的最大连续日数
        /// （从今天开始往回数，包括今天）。
        /// in: ["StockSpanner","next","next","next","next","next","next","next"]
        /// out: [[],[100],[80],[60],[70],[60],[75],[85]]
        /// </summary>
        public class StockSpanner
        {
            public Stack<int> prices;
            public Stack<int> weight;
            public StockSpanner()
            {
                prices = new Stack<int>();
                weight = new Stack<int>();
            }

            public int Next(int price)
            {
                int w = 1;
                while (prices.Count != 0 && prices.Peek() <= price)
                {
                    prices.Pop();
                    w += weight.Pop();
                }
                prices.Push(price);
                weight.Push(w);
                return w;
            }
        }

        //84. 柱状图中最大的矩形
        public int LargestRectangleArea(int[] heights)
        {
            if ((heights == null) || (heights.Length == 0)) return 0;
            var N = heights.Length;
            int[] s = new int[N + 1];
            int i, top = 0, hi, area = 0;
            s[0] = -1;
            for (i = 0; i < N; i++)
            {
                hi = heights[i];
                while ((top > 0) && (heights[s[top]] > hi))
                {
                    area = Math.Max(area, heights[s[top]] * (i - s[top - 1] - 1));
                    top--;
                }
                s[++top] = i;
            }
            while (top > 0)
            {
                area = Math.Max(area, heights[s[top]] * (N - s[top - 1] - 1));
                top--;
            }
            return area;
        }
    }
}
