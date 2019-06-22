# Stack
## Implement Stack
Use array: [ArrayStack.cs](https://github.com/Sophie1797/AlgorithmLearningNote/blob/master/src/AlgorithmNote/AlgorithmNote/Stack/ArrayStack.cs)
Use LinkedList: [LinkedListStack.cs](https://github.com/Sophie1797/AlgorithmLearningNote/blob/master/src/AlgorithmNote/AlgorithmNote/Stack/LinkedListStack.cs)
## Problem Summary
* **用栈逐个消除something**
    * [20. Valid Parentheses](https://leetcode.com/problems/valid-parentheses/)
    * [71. Simplify Path](https://leetcode.com/problems/simplify-path/)
    * [150. Evaluate Reverse Polish Notation](https://leetcode.com/problems/evaluate-reverse-polish-notation/)
    * [224. Basic Calculator](https://leetcode.com/problems/basic-calculator/)
    * [394. Decode String](https://leetcode.com/problems/decode-string/)
    * [456. 132 Pattern](https://leetcode.com/problems/132-pattern/)
    * [591. Tag Validator](https://leetcode.com/problems/tag-validator/)
    * [636. Exclusive Time of Functions](https://leetcode.com/problems/exclusive-time-of-functions/)
    * [682. Baseball Game](https://leetcode.com/problems/baseball-game/)
    * [726. Number of Atoms](https://leetcode.com/problems/number-of-atoms/)
    * [735. Asteroid Collision](https://leetcode.com/problems/asteroid-collision/)
    * [770. Basic Calculator IV](https://leetcode.com/problems/basic-calculator-iv/)
    * [844. Backspace String Compare](https://leetcode.com/problems/backspace-string-compare/)
    * [853. Car Fleet](https://leetcode.com/problems/car-fleet/)
    * [856. Score of Parentheses](https://leetcode.com/problems/score-of-parentheses/)
    * [880. Decoded String at Index](https://leetcode.com/problems/decoded-string-at-index/)
    * [907. Sum of Subarray Minimums](https://leetcode.com/problems/sum-of-subarray-minimums/)
    * [921. Minimum Add to Make Parentheses Valid](https://leetcode.com/problems/minimum-add-to-make-parentheses-valid/)
    * [946. Validate Stack Sequences](https://leetcode.com/problems/validate-stack-sequences/)
    * [975. Odd Even Jump](https://leetcode.com/problems/odd-even-jump/)
    * [1003. Check If Word Is Valid After Substitutions](https://leetcode.com/problems/check-if-word-is-valid-after-substitutions/)
    * [1021. Remove Outermost Parentheses](https://leetcode.com/problems/remove-outermost-parentheses/)
    * [1047. Remove All Adjacent Duplicates In String](https://leetcode.com/problems/remove-all-adjacent-duplicates-in-string/)
* **Next Greater Element**
    这类题一般可以转化为，求数组中每一个数右边比自己大的数字，思路为：遍历数组，栈中放的数字是还没有找到比自己大的数字的数字的下标，如果当前遍历到的数字大于栈顶所代表的数，那么栈顶所代表的数对应的答案就是当前遍历到的这个数字，然后就可以弹出了，所以栈中始种保持空或者金字塔一样的结构（栈从顶到底元素所代表的数字值递增）
    同理，栈中元素也可以一直保持从顶到低递减，用来求右边第一个比自己小的数字, Code: [OrderedStack.cs](https://github.com/Sophie1797/AlgorithmLearningNote/blob/master/src/AlgorithmNote/AlgorithmNote/Stack/OrderedStack.cs)
    * [496. Next Greater Element I](https://leetcode.com/problems/next-greater-element-i/)
    * [503. Next Greater Element II](https://leetcode.com/problems/next-greater-element-ii/)
    * [739. Daily Temperatures](https://leetcode.com/problems/daily-temperatures/)
    * [901. Online Stock Span](https://leetcode.com/problems/online-stock-span/)
    * [1019. Next Greater Node In Linked List](https://leetcode.com/problems/next-greater-node-in-linked-list/)
* **Design Stack**
    * [155. Min Stack](https://leetcode.com/problems/min-stack/), Code: [MinStack.cs](https://github.com/Sophie1797/AlgorithmLearningNote/blob/master/src/AlgorithmNote/AlgorithmNote/Stack/MinStack.cs)
    * [225. Implement Stack using Queues](https://leetcode.com/problems/implement-stack-using-queues/)
    * [232. Implement Queue using Stacks](https://leetcode.com/problems/implement-queue-using-stacks/)
    * [895. Maximum Frequency Stack](https://leetcode.com/problems/maximum-frequency-stack/), Code: [FreqStack.cs](https://github.com/Sophie1797/AlgorithmLearningNote/blob/master/src/AlgorithmNote/AlgorithmNote/Stack/FreqStack.cs)
* **Parse**
    * [385. Mini Parser](https://leetcode.com/problems/mini-parser/)
