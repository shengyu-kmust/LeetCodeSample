using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeSample
{
    public class TwoSum
    {
        public int[] Method1(int[] nums, int target)
        {
            var hash = new Hashtable();
            for (int i = 0; i < nums.Length; i++)
            {
                hash.Add(nums[i], i);
            }
            for (int i = 0; i < nums.Length; i++)
            {
                var needNum = target - nums[i];
                if (hash.ContainsKey(needNum))
                {
                    return new int[] { i, (int)hash[needNum] };
                }
            }
            return new int[] { };
        }

        public int[] Method2(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                var need = target - nums[i];
                for (int j = 0; j < nums.Length; j++)
                {
                    if (nums[j] == need)
                    {
                        return new int[] { i, j };
                    }
                }
            }
            return new int[] { };
        }
    }
}
