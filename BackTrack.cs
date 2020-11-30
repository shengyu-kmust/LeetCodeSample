using System;
using System.Collections.Generic;

namespace LeetCodeSample
{
    /// <summary>
    /// 回溯算法
    /// </summary>
    public static class BackTrack
    {
        #region n皇后问题
        #region 我的递归方法

        /// <summary>
        /// 8-92种，4-2种
        /// </summary>
        /// <param name="q"></param>
        /// <param name="n"></param>
        /// <param name="row"></param>
        /// <param name="res"></param>
        public static void NQueueRecursion(int[] q, int n, int row, List<int[]> res)
        {
            if (row == n)
            {
                var temp = new int[q.Length];
                q.CopyTo(temp, 0);
                res.Add(temp);
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    q[row] = i;
                    if (NQueueRecursionIsOk(q, row))
                    {
                        NQueueRecursion(q, n, row + 1, res);
                    }
                }
            }
        }

        public static bool NQueueRecursionIsOk(int[] q, int row)
        {
            for (int i = 0; i < row; i++)
            {
                if (q[i] == q[row] || Math.Abs(q[i] - q[row]) == Math.Abs(i - row))
                {
                    return false;
                }
            }
            return true;
        }
        #endregion

        #endregion

        #region 正则表达式匹配 
        /*
         
         给你一个字符串 s 和一个字符规律 p，请你来实现一个支持 '.' 和 '*' 的正则表达式匹配。
        '.' 匹配任意单个字符
        '*' 匹配零个或多个前面的那一个元素
        所谓匹配，是要涵盖 整个 字符串 s的，而不是部分字符串。
         */
        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public bool IsMatch(string s, string p)
        {


        }
        #endregion
    }
}
