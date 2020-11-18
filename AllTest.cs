using System;
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
            sort.Method1(nums);
            Assert.True(nums.SequenceEqual(result));

        }
    }
}
