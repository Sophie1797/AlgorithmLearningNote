using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmNote.Stack
{
    /// <summary>
    /// 155. Min Stack
    /// 设计一个支持 push，pop，top 操作，并能在常数时间内检索到最小元素的栈。
    /// push(x)-- 将元素 x 推入栈中。
    /// pop()-- 删除栈顶的元素。
    /// top()-- 获取栈顶元素。
    /// getMin() -- 检索栈中的最小元素。
    /// input: ["MinStack","push","push","push","getMin","pop","top","getMin"]
    /// output: [[],[-2],[0],[-3],[],[],[],[]]
    /// </summary>
    public class MinStack
    {
        public Stack<int> stack { get; set; }
        public int min = int.MaxValue;
        /** initialize your data structure here. */
        public MinStack()
        {
            stack = new Stack<int>();
        }

        public void Push(int x)
        {
            stack.Push(x);
            if (x < min) min = x;
        }

        public void Pop()
        {
            var top = stack.Pop();
            if (top == min) min = stack.Count == 0 ? int.MaxValue : stack.Min();
        }

        public int Top()
        {
            return stack.Peek();
        }

        public int GetMin()
        {
            return min;
        }
    }
}
