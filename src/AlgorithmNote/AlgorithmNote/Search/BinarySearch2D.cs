using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmNote
{
    public class BinarySearch2D
    {
        /// <summary>
        /// 74. 搜索二维矩阵
        /// 每行中的整数从左到右按升序排列， 且每行的第一个整数大于前一行的最后一个整数。
        /// 输入:
        /// matrix = [
        /// [1,   3,  5,  7],
        /// [10, 11, 16, 20],
        /// [23, 30, 34, 50]]
        /// target = 3
        /// 输出: true
        /// </summary>
        public bool SearchMatrix(int[,] matrix, int target)
        {
            if (matrix.Length == 0) return false;
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int l = 0, r = m * n - 1;
            while (l <= r)
            {
                int mid = (l + r) >> 1;
                if (matrix[mid / m, mid % m] == target)
                    return true;
                else if (matrix[mid / m, mid % m] < target)
                    l = mid + 1;
                else
                    r = mid - 1;
            }
            return false;
        }

        /// <summary>
        /// 240. 搜索二维矩阵 II
        /// 每行的元素从左到右升序排，每列的元素从上到下升序排列。不保证上一行最后一个小于当前行第一个
        /// eg. 矩阵 matrix 如下：
        /// [
        /// [1,   4,  7, 11, 15],
        /// [2,   5,  8, 12, 19],
        /// [3,   6,  9, 16, 22],
        /// [10, 13, 14, 17, 24],
        /// [18, 21, 23, 26, 30]]
        /// 给定 target = 5，返回 true。
        /// 给定 target = 20，返回 false。
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public bool SearchMatrix2(int[,] matrix, int target)
        {
            if (matrix.Length == 0) return false;
            int m = matrix.GetLength(0) - 1, n = matrix.GetLength(1) - 1;
            if (target < matrix[0, 0] || target > matrix[m, n]) return false;
            var x1 = 0; var y1 = n; var x2 = 0; var y2 = m;
            while (y1 >= 0 && x2 <= m)
            {
                var midC = Index1(matrix, target, x2, x1, y1);
                //Console.WriteLine(midC);
                if (matrix[x2, midC] == target) return true;
                var midR = Index2(matrix, target, midC, x2, y2);
                //Console.WriteLine(midR);
                if (matrix[midR, midC] == target) return true;
                y1 = midC - 1; x2 = midR;
            }
            return false;
        }

        public int Index2(int[,] matrix, int target, int midC, int lo, int hi)
        {
            while (lo < hi)
            {
                int mid = lo + ((hi - lo) >> 1);
                if (matrix[mid, midC] < target) lo = mid + 1;
                else hi = mid;
            }

            return lo;
        }

        public int Index1(int[,] matrix, int target, int row, int lo, int hi)
        {
            while (lo < hi)
            {
                int mid = lo + ((hi - lo) >> 1);
                //Console.WriteLine(lo+" "+hi+" "+mid);
                if (matrix[row, mid] <= target) lo = mid + 1;
                else hi = mid;
            }
            if (lo != 0 && matrix[row, lo] > target) lo = lo - 1;
            return lo;
        }

        /// <summary>
        /// 378. 有序矩阵中第K小的元素
        /// 给定一个 n x n 矩阵，其中每行和每列元素均按升序排序，找到矩阵中第k小的元素。
        /// matrix = [
        /// [ 1,  5,  9],
        /// [10, 11, 13],
        /// [12, 13, 15]
        /// ],
        /// k = 8, 返回 13。
        /// </summary>
        public int KthSmallest(int[,] matrix, int k)
        {
            if (matrix.Length == 0) return -1;
            var n = matrix.GetLength(0);
            var lo = matrix[0, 0]; var hi = matrix[n - 1, n - 1]; var mid = 0;
            while (lo < hi)
            {
                mid = lo + (hi - lo) / 2;
                int num = 0;
                for (int i = 0; i < n; i++)
                {
                    int pos = UpperBound(matrix, 0, n - 1, mid, i);
                    //Console.WriteLine(pos+","+mid+","+i);
                    num += pos;
                }
                if (num < k) lo = mid + 1;
                else hi = mid;
            }
            return lo;
        }

        public int UpperBound(int[,] matrix, int lo, int hi, int target, int row)
        {
            while (lo < hi)
            {
                int mid = lo + ((hi - lo) / 2);
                if (matrix[row, mid] <= target) lo = mid + 1;
                else hi = mid;
            }
            //Console.WriteLine(matrix[row,lo]);
            return matrix[row, lo] > target ? lo : lo + 1;
        }
    }
}
