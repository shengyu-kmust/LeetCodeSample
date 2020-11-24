using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeSample
{
    /// <summary>
    /// 贪婪算法
    /// </summary>
    public class GreedyProgram
    {
        /// <summary>
        /// 换酒问题
        /// </summary>
        /// <param name="full"></param>
        /// <param name="empty"></param>
        /// <param name="change"></param>
        /// <param name="dri"></param>
        public void Method_1518(int full, int empty, int change, ref int dri)
        {
            if (full == 0 && empty < change)
            {
                return;
            }
            dri = dri + full;
            empty = full + empty;
            full = empty / change;
            empty = empty % change;
            TT(full, empty, change, ref dri);
        }
    }
}
