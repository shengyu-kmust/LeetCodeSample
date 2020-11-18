using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace LeetCodeSample
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(new int[] {9,8,7,6,5,4,3,2,1 })]
        [InlineData(new int[] { 3,4,1,2,9,8,6,7,5 })]
        public void Test1(int[] nums)
        {
            var result = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            
            Assert.True(nums.SequenceEqual(result));
            
        }
        
    }
}
