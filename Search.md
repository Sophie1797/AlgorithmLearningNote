# Search
## Binary Searh
* Search in 1D array
    一般有以下几类：
    1. 找第一个满足条件的
    2. 找最后一个满足条件的
    3. 找恰好满足条件的
    [704. Binary Search](https://leetcode.com/problems/binary-search/)
* Search in 2D array
    一般分类：
    1. 保证每一行的上一行最后一个元素小/大于当前行第一个元素
    [74. Search a 2D Matrix](https://leetcode.com/problems/search-a-2d-matrix/)
    2. 不保证上述条件，只保证从左到右，从上到下有序
    [240. Search a 2D Matrix II](https://leetcode.com/problems/search-a-2d-matrix-ii/)

## BFS & DFS
这两种方法一般可以同时适用一道题，有时候题目并不是给出传统意义上的图论中的图，需要自己把问题抽象为图的形状

### DFS
#### Problem Summary
* DFS in Tree
    基本就是树的preOrder, inOrder, postOrder遍历, 在树那章已经有总结
* 寻找可达的范围
    * []()
* 求连通块
一般这类问题也可以用并查集解决，eg. flood fill


### BFS
#### Problem Summary
* BFS in Tree
基本就是树的levelOrder遍历, 在树那章已经有总结
* 从外围向内
    * [310. Minimum Height Trees](https://leetcode.com/problems/minimum-height-trees/)
* 求最短路


### BFS & DFS Problem Summary
* 迷宫系列
    * [490. The Maze](https://leetcode-cn.com/problems/the-maze/)
    * [505. The Maze II](https://leetcode-cn.com/problems/the-maze-ii/)
    * [499. The Maze III](https://leetcode-cn.com/problems/the-maze-iii/)
    * [1036. Escape a Large Maze](https://leetcode-cn.com/problems/escape-a-large-maze/)

* 词语接龙系列
    * [127. Word Ladder](https://leetcode.com/problems/word-ladder/)
    * [126. Word Ladder II](https://leetcode.com/problems/word-ladder-ii/)
