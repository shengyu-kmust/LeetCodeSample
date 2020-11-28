using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeSample
{
    /// <summary>
    /// 数组相关
    /// </summary>
    public static class ArrayProgram
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="m"></param>
        /// <param name="nums2"></param>
        /// <param name="n"></param>
        public static void Method_88(int[] nums1, int m, int[] nums2, int n)
        {
            /*
             给你两个有序整数数组 nums1 和 nums2，请你将 nums2 合并到 nums1 中，使 nums1 成为一个有序数组。
            说明：
            初始化 nums1 和 nums2 的元素数量分别为 m 和 n 。
            你可以假设 nums1 有足够的空间（空间大小大于或等于 m +n）来保存 nums2 中的元素。
             */
            // 复制nums1到新的空间，并对nums1,nums2从小到大指针遍历
            // 在nums1基础上，对nums1,nums2从大到小遍历，放到nums1上
            #region 方法一
            int i = m-1;
            int j = n-1;
            int current = nums1.Length - 1;
            while (i>=0 ||j >=0)
            {
                if (i<0)
                {
                    nums1[current] = nums2[j];
                    j--;
                    continue;
                }
                if (j<0)
                {
                    nums1[current] = nums2[i];
                    i--;
                    continue;
                }
                if (nums1[i]>nums2[j])
                {
                    nums2[current] = nums1[i];
                    i--;
                }
                else
                {
                    nums2[current] = nums1[j];
                    j--;
                }

            }
            #endregion
            #region 方法二
            //// Make a copy of nums1.
            //int[] nums1_copy = new int[m];
            //System.arraycopy(nums1, 0, nums1_copy, 0, m);

            //// Two get pointers for nums1_copy and nums2.
            //int p1 = 0;
            //int p2 = 0;

            //// Set pointer for nums1
            //int p = 0;

            //// Compare elements from nums1_copy and nums2
            //// and add the smallest one into nums1.
            //while ((p1 < m) && (p2 < n))
            //    nums1[p++] = (nums1_copy[p1] < nums2[p2]) ? nums1_copy[p1++] : nums2[p2++];

            //// if there are still elements to add
            //if (p1 < m)
            //    System.arraycopy(nums1_copy, p1, nums1, p1 + p2, m + n - p1 - p2);
            //if (p2 < n)
            //    System.arraycopy(nums2, p2, nums1, p1 + p2, m + n - p1 - p2);

            #endregion
        }
    }
}
