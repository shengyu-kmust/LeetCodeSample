using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeSample
{
    /// <summary>
    /// 位运算相关
    /// </summary>
    public static class BitProgram
    {
        /// <summary>
        /// 位1的个数
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 编写一个函数，输入是一个无符号整数（以二进制串的形式），返回其二进制表达式中数字位数为 '1' 的个数（也被称为汉明重量）。
        /// </remarks>
        public static int Method_191(int num)
        {
            var bitOneNums = 0;
            while (num > 0)
            {
                if ((num & 1) == 1)
                {
                    bitOneNums++;
                }
                num = num >> 1;
            }
            return bitOneNums;
        }
    }
}
