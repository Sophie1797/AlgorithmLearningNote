using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmNote
{
    /// <summary>
    /// 895. 最大频率栈
    /// 实现 FreqStack，模拟类似栈的数据结构的操作的一个类。
    /// 有两个函数：
    /// push(int x)，将整数 x推入栈中。
    /// pop()，它移除并返回栈中出现最频繁的元素。
    /// 如果最频繁的元素不只一个，则移除并返回最接近栈顶的元素。
    /// in: ["FreqStack","push","push","push","push","push","push","pop","pop","pop","pop"]
    /// out: [[],[5],[7],[5],[7],[4],[5],[],[],[],[]]
    /// </summary>
    public class FreqStack
    {
        // 依据输入，来做汇总统计（同一个输入值，汇总到一起）
        Dictionary<int, int> inputCount = new Dictionary<int, int>();

        // 依据出现的次数，来做汇总统计（同一个出现数量，汇总到一起）
        Dictionary<int, Stack<int>> freqCount = new Dictionary<int, Stack<int>>();

        // 目前维护的输入中，出现的最大次数
        int maxCount = 0;

        public FreqStack()
        { }

        public void Push(int x)
        {
            if (!inputCount.ContainsKey(x)) inputCount[x] = 0;
            inputCount[x]++;

            int freqAmount = inputCount[x];

            if (freqAmount > maxCount) maxCount = freqAmount;

            if (!freqCount.ContainsKey(freqAmount)) freqCount[freqAmount] = new Stack<int>();
            freqCount[freqAmount].Push(x);
        }

        public int Pop()
        {
            var forReturn = freqCount[maxCount].Pop();

            if (!freqCount[maxCount].Any()) maxCount--;

            inputCount[forReturn]--;
            if (inputCount[forReturn] == 0) inputCount.Remove(forReturn);

            return forReturn;
        }
    }
}
