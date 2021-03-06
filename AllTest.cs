﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace LeetCodeSample
{
  
    public class AllTest
    {
        [Theory]
        [InlineData(new int[] { 1, 3, 5, 11, 2, 6, 77 }, 9)]
        public void TwoSum_Test(int[] nums, int target)
        {
            var twoNum = new TwoSum();
            Assert.Equal<int[]>(new int[] { 1, 5 }, twoNum.Method1(nums, target));
            Assert.Equal<int[]>(new int[] { 1, 5 }, twoNum.Method2(nums, target));
        }

        [Theory]
        [InlineData(new int[] { 9, 8, 7, 6, 5, 4, 3, 2, 1 })]
        [InlineData(new int[] { 3, 4, 1, 2, 9, 8, 6, 7, 5 })]
        public void Sort_Test(int[] nums)
        {
            var result = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var sort = new Sort();
            //sort.Method1(nums);
            Assert.True(nums.SequenceEqual(result));

        }

        #region 位运算
        [Theory]
        [InlineData(2,1)]
        [InlineData(3,2)]
        [InlineData(11,3)]
        [InlineData(1989, 7)]
        public void Method_191_Test(int num,int res)
        {
            Assert.Equal(res,BitProgram.Method_191(num));
        }
        #endregion
        [Theory]
        [InlineData(new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 },6)]
        public void Method_53_Test(int[] nums,int res)
        {
            Assert.Equal(res, DynamicProgramming.Method_53(nums));
        }

        #region 堆栈
        [Theory]
        [InlineData("()[]{}",true)]
        [InlineData("([)]", false)]
        public void Method_20_Test(string s,bool res)
        {
            Stack<int> a;
            
            Assert.Equal(res, QueueStackProgram.Method_20(s));
        }
        #endregion


        [Fact]
       public void Test()
        {
            try
            {
                var list = new List<int> { 1, 3, 5, 7, 9, 2, 4, 6, 8 };
                Sort(list);
                //Sort.QuickSort(list, 0, list.Length - 1);
            }
            catch (Exception ex)
            {
                var a = ex;
            }
         
        }

        public void Sort(List<int> list)
        {
            // 0,1,2...9
            var len = list.Count;
            int tmpMaxIndex,tmp;

            for(var i = len - 1; i >=1; i--)
            {
                // i为本次循环要设置的最大值
                tmpMaxIndex = 0;
                for(var j = 0; j <= i; j++)
                {
                    if(list[j]>=list[tmpMaxIndex])
                    {
                        tmpMaxIndex = j;
                    }
                }
                tmp = list[tmpMaxIndex];
                list[tmpMaxIndex] = list[i];
                list[i] = tmp;
            }

        }
    }
}
