using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace LeetCodeSample
{
    public class OtherTest
    {
       
        #region 数组和字符串
        /// <summary>
        /// 给定一个数组 nums，编写一个函数将所有 0 移动到数组的末尾，同时保持非零元素的相对顺序。
        /// </summary>
        [Theory]
        [InlineData(new int[] { 0, 1, 0, 3, 12 })]
        public void Method_283(int[] nums)
        {
            int j = -1;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != 0)
                {
                    j++;
                    nums[j] = nums[i];
                }
            }
            for (int i = j + 1; i < nums.Length; i++)
            {
                nums[i] = 0;
            }
            Assert.Equal("1,3,12,0,0", string.Join(",", nums.ToList()));

        }

        /// <summary>
        /// 数组-移除元素
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        [Fact]
        public void Method_27()
        {
            //示例 
            //给定 nums = [0, 1, 2, 2, 3, 0, 4, 2], val = 2,
            //函数应该返回新的长度 5, 并且 nums 中的前五个元素为 0, 1, 3, 0, 4。
            var nums = new int[] { 0, 1, 2, 2, 3, 0, 4, 2 };
            var removeVal = 2;
            var maxIndex = -1;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i]!=removeVal)
                {
                    maxIndex++;
                    nums[maxIndex] = nums[i];
                }
            }
            Assert.True(maxIndex + 1 == 5);
            Assert.Equal(string.Join(",", nums.Take(5).ToList()), "0,1,3,0,4");

        }

        /// <summary>
        /// 反转字符串
        /// </summary>
        [Theory]
        [InlineData(new char[] { 'a','b','c','d' })]
        public void Method_344(char[] s)
        {
            for (int i = 0; (i+1) <= (s.Length - i - 1); i++)
            {
                var temp = s[i];
                s[i] = s[s.Length - i - 1];
                s[s.Length - i - 1] = temp;
            }
            Assert.Equal(string.Join(",", s), "d,c,b,a");
        }
        #endregion
        #region 链表
        /// <summary>
        /// 删除链表中的节点
        /// </summary>
        [Fact]
        public void Method_237()
        {
            //请编写一个函数，使其可以删除某个链表中给定的（非末尾）节点。传入函数的唯一参数为 要被删除的节点 。
            // 输入：head = [4, 5, 1, 9], node = 5
            //输出：[4,1,9]
            //解释：给定你链表中值为 5 的第二个节点，那么在调用了你的函数之后，该链表应变为 4-> 1-> 9.
            var node = DataStructures.GeneratorListNode(new int[] { 4, 5, 1, 9 });
            for (ListNode current = node; current != null; current = current.Next)
            {
                if (current.Next != null && current.Next.Val == 5)
                {
                    current.Next = current.Next.Next;
                }
            }
            Assert.Equal(node.ToString(), "4,1,9");
        }
        [Fact]
        public void Method_237_1()
        {
            //请编写一个函数，使其可以删除某个链表中给定的（非末尾）节点。传入函数的唯一参数为 要被删除的节点 。
            // 输入：head = [4, 5, 1, 9], node = 5
            //输出：[4,1,9]
            //解释：给定你链表中值为 5 的第二个节点，那么在调用了你的函数之后，该链表应变为 4-> 1-> 9.
            var node = DataStructures.GeneratorListNode(new int[] { 4, 5, 1, 9 });
            var deleteNode = node.Next;
            deleteNode.Val = deleteNode.Next.Val;
            deleteNode.Next = deleteNode.Next.Next;
            Assert.Equal(node.ToString(), "4,1,9");
            
        }
        #endregion


    }

}
