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
    }
}
