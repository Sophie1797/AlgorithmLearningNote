# Heap
堆是**完全二叉树**，可以用**数组**存储，下标从1开始。如果需要实现修改和删除操作，需要实现一个index heap，即额外用一个数组id[]记录堆中位置为i的元素是第几个插入的，pos[]记录第i个插入的元素在堆中的位置。
* **对于节点i：**

  左儿子：i * 2，

  右儿子：i * 2 + 1，

  父亲：i/2

* **维持堆的性质的两个核心函数为：**

  siftUp(i):上浮节点

  siftDown():下沉节点

* **堆中的操作：**

  插入：在插入个值value时，将它加入堆的最底层，然后让它上浮

  删除堆顶：将堆顶与最后一个元素交换，然后让它下沉

  修改：先利用pos数组找到它当前在堆中的位置，然后修改，然后分别up和down

  删除堆中元素：先将它修改为无穷大（xiao)，然后让它上浮到堆顶，然后删除堆顶

## Implement Heap
[MaxHeap.cs](https://github.com/Sophie1797/AlgorithmLearningNote/blob/master/src/AlgorithmNote/AlgorithmNote/Heap/MaxHeap.cs)

[MinHeap.cs](https://github.com/Sophie1797/AlgorithmLearningNote/blob/master/src/AlgorithmNote/AlgorithmNote/Heap/MinHeap.cs)

[IndexMinHeap.cs](https://github.com/Sophie1797/AlgorithmLearningNote/blob/master/src/AlgorithmNote/AlgorithmNote/Heap/IndexMinHeap.cs)

