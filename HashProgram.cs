using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeSample
{
    public static class HashProgram
    {
        #region 字典，哈希
        /// <summary>
        /// 两数之和
        /// </summary>
        /// <param name="nums">一组数</param>
        /// <param name="target">目标和值</param>
        /// <returns></returns>
        public static int[] Method_1(int[] nums, int target)
        {
            var dic = new Dictionary<int, int>();//key为value，value为index
            for (int i = 0; i < nums.Length; i++)
            {
                dic.Add(nums[i], i);
            }
            for (int i = 0; i < nums.Length; i++)
            {
                if (dic.ContainsKey(target - nums[i]))
                {
                    return new int[] { dic[target - nums[i]], dic[nums[i]] };
                }
            }
            return null;
        }
        #endregion

        /// <summary>
        /// 给定一个字符串，请你找出其中不含有重复字符的 最长子串 的长度。
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int Method_3(String s)
        {
            // 哈希集合，记录每个字符是否出现过
            HashSet<char> occ = new HashSet<char>();
            int n = s.Length;
            // 右指针，初始值为 -1，相当于我们在字符串的左边界的左侧，还没有开始移动
            int rk = -1, ans = 0;
            for (int i = 0; i < n; ++i)
            {
                if (i != 0)
                {
                    // 左指针向右移动一格，移除一个字符
                    occ.Remove(s[i - 1]);
                }
                while (rk + 1 < n && !occ.Contains(s[rk + 1]))
                {
                    // 不断地移动右指针
                    occ.Add(s[rk + 1]);
                    ++rk;
                }
                // 第 i 到 rk 个字符是一个极长的无重复字符子串
                ans = Math.Max(ans, rk - i + 1);
            }
            return ans;
        }

    }
}
