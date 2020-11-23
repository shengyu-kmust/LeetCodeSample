using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeSample
{
    /// <summary>
    /// 回溯算法
    /// </summary>
    public  class BackTrack
    {
        #region 递归

        public List<List<String>> solveNQueens(int n)
        {
            List<List<String>> solutions = new List<List<String>>();
            int[] queens = new int[n];
            Array.Fill(queens, -1);
            HashSet<int> columns = new HashSet<int>();
            HashSet<int> diagonals1 = new HashSet<int>();
            HashSet<int> diagonals2 = new HashSet<int>();
            backtrack(solutions, queens, n, 0, columns, diagonals1, diagonals2);
            return solutions;
        }

        public void backtrack(List<List<String>> solutions, int[] queens, int n, int row, HashSet<int> columns, HashSet<int> diagonals1, HashSet<int> diagonals2)
        {
            if (row == n)
            {
                List<String> board = generateBoard(queens, n);
                solutions.Add(board);
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    if (columns.Contains(i))
                    {
                        continue;
                    }
                    int diagonal1 = row - i;
                    if (diagonals1.Contains(diagonal1))
                    {
                        continue;
                    }
                    int diagonal2 = row + i;
                    if (diagonals2.Contains(diagonal2))
                    {
                        continue;
                    }
                    queens[row] = i;
                    columns.Add(i);
                    diagonals1.Add(diagonal1);
                    diagonals2.Add(diagonal2);
                    backtrack(solutions, queens, n, row + 1, columns, diagonals1, diagonals2);
                    queens[row] = -1;
                    columns.Remove(i);
                    diagonals1.Remove(diagonal1);
                    diagonals2.Remove(diagonal2);
                }
            }
        }

        public List<String> generateBoard(int[] queens, int n)
        {
            List<String> board = new List<String>();
            for (int i = 0; i < n; i++)
            {
                char[] row = new char[n];
                Array.Fill(row, '.');
                row[queens[i]] = 'Q';
                board.Add(new String(row));
            }
            return board;
        }
        #endregion

        #region 我的递归方法

        /// <summary>
        /// 8-92种，4-2种
        /// </summary>
        /// <param name="q"></param>
        /// <param name="n"></param>
        /// <param name="row"></param>
        /// <param name="res"></param>
        public void BackTrack1(int[] q, int n, int row, List<string> res)
        {
            if (row == n)
            {
                res.Add(string.Join(",", q.ToList()));
                //Array.Fill(q, -1);
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    q[row] = i;
                    if (IsOk(q, row))
                    {
                        BackTrack1(q, n, row + 1, res);
                    }
                    else
                    {
                        q[row] = -1;
                    }
                }
            }
        }

        public bool IsOk(int[] q, int row)
        {
            for (int i = 0; i <= row; i++)
            {
                for (int j = 0; j <= row; j++)
                {
                    if ((i != j && q[i] != -1 && q[j] != -1))
                    {
                        if (Math.Abs(i - j) == Math.Abs(q[i] - q[j])
                            || q[i] == q[j]
                            )
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }
        #endregion
        #region 方法二

        //bool is_ok(int row)
        //{            //判断设置的皇后是否在同一行，同一列，或者同一斜线上
        //    for (int j = 0; j < row; j++)
        //    {
        //        if (queen[row] == queen[j] || row - queen[row] == j - queen[j] || row + queen[row] == j + queen[j])
        //            return false;
        //    }
        //    return true;
        //}
        //void back_tracking(int row = 0)    //算法函数，从第0行开始遍历
        //{
        //    if (row == n)
        //        t++;               //判断若遍历完成，就进行计数     
        //    for (int col = 0; col < n; col++)     //遍历棋盘每一列
        //    {
        //        queen[row] = col;           //将皇后的位置记录在数组
        //        if (is_ok(row))             //判断皇后的位置是否有冲突
        //            back_tracking(row + 1);   //递归，计算下一个皇后的位置
        //    }
        //}
        #endregion

    }
}
