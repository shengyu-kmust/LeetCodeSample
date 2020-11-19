using System;

namespace LeetCodeSample
{
    public class DynamicProgramming
    {
        #region 斐波那契数列
        /// <summary>
        /// 动态规则，转入n+1，返回fn(n)结果
        /// </summary>
        /// <returns></returns>
        public int FibonacciDP1(int n)
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
        public int FibonacciRecursion(int n)
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
        public int CoinsDp1(int[] coins, int amount)
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
    }
}
