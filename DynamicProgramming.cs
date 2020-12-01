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
            // 动态方程 dp[i]=min(dp[i],dp[i-k]+1); k in coins
            // 初始化最小动态方程
            var dp = new int[amount + 1];
            Array.Fill(dp, int.MaxValue);
            for (int i = 0; i < coins.Length && coins[i] <= amount; i++)
            {
                dp[coins[i]] = 1;
            }

            // 动态方程计算
            for (var i = 1; i <= amount; i++)
            {
                for (var j = 0; j < coins.Length; j++)
                {
                    var k = coins[j];
                    if (i - k > 0)
                    {
                        dp[i] = Math.Min(dp[i], dp[i - k] == int.MaxValue ? int.MaxValue : dp[i - k] + 1);
                    }
                }
            }
            return dp[amount] == int.MaxValue ? -1 : dp[amount];
        }
        #endregion

        #region 字符串

        /// <summary>
        /// 通配符匹配
        /// </summary>
        /// <param name="val"></param>
        /// <param name="reg"></param>
        /// <returns></returns>
        /// <remarks>
        ///  给定一个字符串 (s) 和一个字符模式 (p) ，实现一个支持 '?' 和 '*' 的通配符匹配。
        /// </remarks>
        public static bool Method_44(string s, string p)
        {

            // dp[i,j]表示s的前i个字符和p的前j个字符的匹配结果
            // 即有如下逻辑
            // 当p[j-1] == '*'：dp[i, j] = dp[i - 1, j - 1] && s[i-1] == p[j-1];
            // 当p[j-1] == '?'：dp[i, j] = dp[i - 1, j - 1]; 
            // 当p[j-1]为正常字符时：dp[i, j] = dp[i, j - 1] || dp[i - 1, j];
            var dp = new bool[s.Length + 1, p.Length + 1];
            dp[0, 0] = true;
            for (var i = 1; i <= s.Length; i++)
            {
                for (var j = 1; j <= p.Length; j++)
                {
                    if (p[j - 1] == '*')
                    {
                        dp[i, j] = dp[i, j - 1] || dp[i - 1, j];
                    }
                    else if (p[j - 1] == '?')
                    {
                        dp[i, j] = dp[i - 1, j - 1];
                    }
                    else
                    {
                        dp[i, j] = dp[i - 1, j - 1] && s[i - 1] == p[j - 1];
                    }
                }
            }
            return dp[s.Length, p.Length];
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

        #region 最长回文串
        public static string Method_5_2(String s)
        {
            if (s == null || s.Length < 1)
            {
                return "";
            }
            int start = 0, end = 0;
            for (int i = 0; i < s.Length; i++)
            {
                int len1 = Method_5_2_Internal(s, i, i);
                int len2 = Method_5_2_Internal(s, i, i + 1);
                int len = Math.Max(len1, len2);
                if (len > end - start)
                {
                    start = i - (len - 1) / 2;
                    end = i + len / 2;
                }
            }
            return s.Substring(start, end + 1);
        }

        public static int Method_5_2_Internal(String s, int left, int right)
        {
            while (left >= 0 && right < s.Length && s[left] == s[right])
            {
                --left;
                ++right;
            }
            return right - left - 1;
        }
        /// <summary>
        /// 最长回文串
        /// </summary>
        public static string Method_5(string s)
        {
            int n = s.Length;
            bool[,] dp = new bool[n, n];
            string ans = "";
            for (int l = 0; l < n; ++l)
            {
                for (int i = 0; i + l < n; ++i)
                {
                    int j = i + l;
                    if (l == 0)
                    {
                        dp[i, j] = true;
                    }
                    else if (l == 1)
                    {
                        dp[i, j] = (s[i] == s[j]);
                    }
                    else
                    {
                        dp[i, j] = (s[i] == s[j] && dp[i + 1, j - 1]);
                    }
                    if (dp[i, j] && l + 1 > ans.Length)
                    {
                        ans = s.Substring(i, i + l + 1);
                    }
                }
            }
            return ans;
        }
        #endregion

        #endregion

        
        /// <summary>
        /// 爬楼梯
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int Method_70(int n)
        {
            // dp[n]=min(dp[n-1]+1,dp[n-2]+1)
            if (n <= 2)
            {
                return 1;
            }
            var dp = new int[n + 1];
            dp[1] = 1;
            dp[2] = 1;

            for (var i = 3; i < n + 1; i++)
            {
                dp[i] = Math.Min(dp[i - 1] + 1, dp[i - 2] + 1);
            }
            return dp[n];
        }
        
    }
}
