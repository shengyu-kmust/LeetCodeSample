using System;

namespace LeetCodeSample
{
    public static class DynamicProgramming
    {
        #region 斐波那契数列
        /// <summary>
        /// 动态规则，转入n+1，返回fn(n)结果
        /// </summary>
        /// <returns></returns>
        public static int FibonacciDP1(int n)
        {
            var dp = new int[n];
            dp[0] = 0;
            dp[1] = 1;
            for (int i = 2; i < n; i++)
            {
                dp[i] = dp[i - 1] + dp[i - 2];
            }
            return dp[n - 1];
        }

        /// <summary>
        /// 递归，n>40会卡死
        /// </summary>
        /// <returns></returns>
        public static int FibonacciRecursion(int n)
        {
            if (n == 0)
            {
                return 0;
            }
            if (n == 1)
            {
                return 1;
            }
            return FibonacciRecursion(n - 1) + FibonacciRecursion(n - 2);
        }
        #endregion

        #region 货币
        /// <summary>
        /// 零钱兑换
        /// </summary>
        /// <param name="coins"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public static int CoinsDp1(int[] coins, int amount)
        {
            var dp = new int[amount + 1];
            for (int j = 0; j < amount + 1; j++)
            {
                dp[j] = int.MaxValue - 1;
            }
            // 能确定的初始值
            for (int i = 0; i < coins.Length; i++)
            {
                if (coins[i] < amount + 1)
                {
                    dp[coins[i]] = 1;
                }
            }

            // 
            for (int i = 0; i < coins.Length; i++)
            {
                for (int j = 0; j < amount + 1; j++)
                {
                    if (j + coins[i] < amount + 1)
                    {
                        dp[j + coins[i]] = Math.Min(dp[j + coins[i]], dp[j] + 1);//动态规划状态方程
                    }
                }
            }
            return dp[amount] == int.MaxValue - 1 ? -1 : dp[amount];
        }
        #endregion

        #region 字符串

        /// <summary>
        /// 通配符匹配
        /// </summary>
        /// <param name="val"></param>
        /// <param name="reg"></param>
        /// <returns></returns>
        public static bool Method_44(string val, string reg)
        {
            int valLen = val.Length;
            int regLen = reg.Length;
            bool[,] dp = new bool[valLen + 1, regLen + 1];
            dp[0, 0] = true;
            for (int i = 1; i <= regLen; ++i)
            {
                if (reg[i - 1] == '*')
                {
                    dp[0, i] = true;
                }
            }
            for (int i = 1; i <= valLen; ++i)
            {
                for (int j = 1; j <= regLen; ++j)
                {
                    if (reg[j - 1] == '*')
                    {
                        dp[i, j] = dp[i, j - 1] || dp[i - 1, j];
                    }
                    else if (reg[j - 1] == '?' || val[i - 1] == reg[j - 1])
                    {
                        dp[i, j] = dp[i - 1, j - 1];
                    }
                }
            }
            return dp[valLen, regLen];
        }

        /// <summary>
        /// 最大子序和 
        /// </summary>
        /// <returns></returns>
        public static int Method_53(int[] nums)
        {
            // todo 最大子序和
            //给定一个整数数组 nums ，找到一个具有最大和的连续子数组（子数组最少包含一个元素），返回其最大和。
            // 如输入[-2,1,-3,4,-1,2,1,-5,4] 输出: 6
            // dp[n]=Math(dp[n-1],dp[n-1]+nums[n-2])

            #region 解法一
            //int pre = 0, maxAns = nums[0];
            //for (int x : nums)
            //{
            //    pre = Math.max(pre + x, x);
            //    maxAns = Math.max(maxAns, pre);
            //}
            //return maxAns;
            #endregion
            #region 解二，动态规划
            //int n = nums.length;
            //if (n == 0) return 0;
            ////定义dp数组，dp数组中的每个值dp[i]代表着以nums[i]为结尾的最大子序和
            //int[] dp = new int[n];
            ////以nums[0]结尾的最大子序和就是nums[0]
            //dp[0] = nums[0];
            ////遍历，通过状态转移方程求得dp[i]的最大子序和
            //for (int i = 1; i < n; ++i)
            //{
            //    //dp[i]的最大子序和要么是自成一派最大，要么就是当前值加上前面i - 1个数的最大子序和
            //    dp[i] = Math.max(nums[i], nums[i] + dp[i - 1]);
            //}

            ////遍历dp数组，求得dp数组中的最大值，就是该题的答案
            //int res = Integer.MIN_VALUE;
            //for (int j = 0; j < dp.length; ++j)
            //{
            //    res = Math.max(res, dp[j]);
            //}
            //return res;
            #endregion
            // 1、初始化dp表
            var len = nums.Length;
            int[] dp = new int[len];
            dp[1] = nums[0];



            for (int i=2; i <= len; i++)
            {
                dp[i] = Math.Max(dp[i - 1], dp[i - 1] + nums[i - 1]);
            }
            return dp[len];

        }
        #endregion
    }
}
