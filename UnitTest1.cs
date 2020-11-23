using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace LeetCodeSample
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(new int[] { 9, 8, 7, 6, 5, 4, 3, 2, 1 })]
        [InlineData(new int[] { 3, 4, 1, 2, 9, 8, 6, 7, 5 })]
        public void Test1(int[] nums)
        {
            var result = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            Assert.True(nums.SequenceEqual(result));
        }

        public void Test()
        {

        }
        #region ������ַ���
        /// <summary>
        /// ����һ������ nums����дһ������������ 0 �ƶ��������ĩβ��ͬʱ���ַ���Ԫ�ص����˳��
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
        /// ����-�Ƴ�Ԫ��
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        [Fact]
        public void Method_27()
        {
            //ʾ�� 
            //���� nums = [0, 1, 2, 2, 3, 0, 4, 2], val = 2,
            //����Ӧ�÷����µĳ��� 5, ���� nums �е�ǰ���Ԫ��Ϊ 0, 1, 3, 0, 4��
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
        /// ��ת�ַ���
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
        #region ����
        /// <summary>
        /// ɾ�������еĽڵ�
        /// </summary>
        [Fact]
        public void Method_237()
        {
            //���дһ��������ʹ�����ɾ��ĳ�������и����ģ���ĩβ���ڵ㡣���뺯����Ψһ����Ϊ Ҫ��ɾ���Ľڵ� ��
            // ���룺head = [4, 5, 1, 9], node = 5
            //�����[4,1,9]
            //���ͣ�������������ֵΪ 5 �ĵڶ����ڵ㣬��ô�ڵ�������ĺ���֮�󣬸�����Ӧ��Ϊ 4-> 1-> 9.
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
            //���дһ��������ʹ�����ɾ��ĳ�������и����ģ���ĩβ���ڵ㡣���뺯����Ψһ����Ϊ Ҫ��ɾ���Ľڵ� ��
            // ���룺head = [4, 5, 1, 9], node = 5
            //�����[4,1,9]
            //���ͣ�������������ֵΪ 5 �ĵڶ����ڵ㣬��ô�ڵ�������ĺ���֮�󣬸�����Ӧ��Ϊ 4-> 1-> 9.
            var node = DataStructures.GeneratorListNode(new int[] { 4, 5, 1, 9 });
            var deleteNode = node.Next;
            deleteNode.Val = deleteNode.Next.Val;
            deleteNode.Next = deleteNode.Next.Next;
            Assert.Equal(node.ToString(), "4,1,9");
            
        }
        #endregion


        #region ��
        /// <summary>
        /// ���������-�ݹ�
        /// </summary>
        [Fact]
        public void Method_104()
        {
            var root = DataStructures.BuildTestBTree1();
            var dept=Method_104_Private(root);
            Assert.Equal(dept, 3);
        }
        public int Method_104_Private(BTree root)
        {
            if (root.Left == null && root.Right == null)
            {
                return 1;
            }
            return 1 + Math.Max(Method_104_Private(root.Left), Method_104_Private(root.Right));
        }
        #endregion

        #region �ֵ䣬��ϣ
        /// <summary>
        /// ����֮��
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] Method_1(int[] nums, int target)
        {
            var dic = new Dictionary<int, int>();//keyΪvalue��valueΪindex
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
