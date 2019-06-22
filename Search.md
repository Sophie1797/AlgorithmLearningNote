# Search
## Binary Searh
* Search in 1D sorted array
    一般有以下几类：
    1. 找第一个满足条件的
    2. 找最后一个满足条件的
    3. 找恰好满足条件的
    [704. Binary Search](https://leetcode.com/problems/binary-search/)
* Search in rotate sorted array
    * [153. 寻找旋转排序数组中的最小值](https://leetcode-cn.com/problems/find-minimum-in-rotated-sorted-array/)
    * [154. 寻找旋转排序数组中的最小值 II](https://leetcode-cn.com/problems/find-minimum-in-rotated-sorted-array-ii/)
    * [33. 搜索旋转排序数组](https://leetcode-cn.com/problems/search-in-rotated-sorted-array/)
    * [81. 搜索旋转排序数组 II](https://leetcode-cn.com/problems/search-in-rotated-sorted-array-ii/)
* Search in 2D sorted array
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

* 求连通分量
一般这类问题可以用BFS也可以用DFS，DFS的递归代码看起来更美观简洁。此问题也可以用并查集解决。
    * [733. 图像渲染](https://leetcode-cn.com/problems/flood-fill/)
    * [130. 被围绕的区域](https://leetcode-cn.com/problems/surrounded-regions/)

* 查看图中是否有环以及拓扑排序
这种类型题的dfs一般需要结合color数组，在遍历的时候顺便着色，着色规则查看[Graph.md](https://github.com/Sophie1797/AlgorithmLearningNote/blob/master/Graph.md#concept)
    * [207. 课程表](https://leetcode-cn.com/problems/course-schedule/)
    * [210. 课程表 II](https://leetcode-cn.com/problems/course-schedule-ii/submissions/)
    * [261. 以图判树](https://leetcode-cn.com/problems/graph-valid-tree/)

* 查看图是否是二分图
    * [785. 判断二分图](https://leetcode-cn.com/problems/is-graph-bipartite/)
    * [886. 可能的二分法](https://leetcode-cn.com/problems/possible-bipartition/)


### BFS
#### Problem Summary
* BFS in Tree
基本就是树的levelOrder遍历, 在树那章已经有总结，树一般只进行一次BFS，但是图很多情况下是进行N次BFS
* 从外围向内
    * [310. Minimum Height Trees](https://leetcode.com/problems/minimum-height-trees/)
* 求最短路
    * [994. 腐烂的橘子](https://leetcode-cn.com/problems/rotting-oranges/)


### BFS & DFS Problem Summary
* 迷宫系列
    * [490. The Maze](https://leetcode-cn.com/problems/the-maze/)
    * [505. The Maze II](https://leetcode-cn.com/problems/the-maze-ii/)
    * [499. The Maze III](https://leetcode-cn.com/problems/the-maze-iii/)
    * [1036. Escape a Large Maze](https://leetcode-cn.com/problems/escape-a-large-maze/)

* 词语接龙系列
    * [127. Word Ladder](https://leetcode.com/problems/word-ladder/)
    * [126. Word Ladder II](https://leetcode.com/problems/word-ladder-ii/)
