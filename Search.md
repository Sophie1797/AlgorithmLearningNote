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

## DFS
### Problem Summary
* DFS in Tree
基本就是树的preOrder, inOrder, postOrder遍历, 在树那章已经有总结，本章主要关注图


## BFS
### Problem Summary
* BFS in Tree
基本就是树的levelOrder遍历, 在树那章已经有总结，本章主要关注图
* 从外围向内
    * [310. Minimum Height Trees](https://leetcode.com/problems/minimum-height-trees/)