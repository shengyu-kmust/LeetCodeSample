using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeSample
{
    #region 数据结构生成类
    public static class DataStructures
    {
        /// <summary>
        /// 创建深度为4的全完二叉树
        ///                1
        ///
        ///        2              3
        ///
        ///   4        5        6        7
        ///
        ///8   9   10   11   12   13   14   15
        ///先：1 2 4 8 9 5 10 11 3 6 12 13 7 14 15
        ///中：8 4 9 2 10 5 11 1 12 6 13 3 14 7 15 
        ///后：8 9 4 10 11 5 2 12 13 6 14 15 7 3 1
        /// </summary>
        /// <returns></returns>

        public static BTree BuildTestBTree()
        {
            var allBtree = Enumerable.Range(1, 15).Select(a => new BTree(a)).ToList();
            for (int i = 0; i <= 6; i++)
            {
                allBtree[i].Left = allBtree[i * 2 + 1];
                allBtree[i].Right = allBtree[i * 2 + 2];
            }
            return allBtree[0];
        }

        /// <summary>
        /// [3,9,20,null,null,15,7]，
        ///         3
        ///       9   20
        ///          15  7
        /// 
        /// </summary>
        /// <returns></returns>
        public static BTree BuildTestBTree1()
        {
            var root = new BTree(3)
            {
                Left = new BTree(9),
                Right = new BTree(20) {
                    Left = new BTree(15), 
                    Right = new BTree(7) 
                }
            };
            return root;
        }

        #region 链表
        public static ListNode GeneratorListNode(int[] nums)
        {
            ListNode result = null;
            ListNode currentNode = null;
            for (int i = 0; i < nums.Length; i++)
            {
                var temp = new ListNode(nums[i]);
                if (result == null)
                {
                    result = temp;
                    currentNode = result;
                }
                else
                {
                    currentNode.Next = temp;
                    currentNode = temp;
                }
            }
            return result;
        }


        #endregion


        #region 图
        /// <summary>
        /// 用于计算最短路径，6个节点
        /// </summary>
        /// <returns></returns>
        public static int[,] BuildGraph1()
        {
            var paths = new int[6, 6];
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    if (i==j)
                    {
                        paths[i, j] = 0;
                    }
                    else
                    {
                        paths[i, j] = int.MaxValue;
                    }
                }
            }
            paths[0, 1] = 1;
            paths[0, 2] = 12;
            paths[1, 3] = 3;
            paths[1, 2] = 9;
            paths[2, 4] = 5;
            paths[3, 2] = 4;
            paths[3, 4] = 13;
            paths[3, 5] = 15;
            paths[4, 5] = 4;
            return paths;
        }
        #endregion
    }

    #endregion
    #region 树
    /// <summary>
    /// 树
    /// </summary>
    public class Tree
    {
        public Tree(int val)
        {
            this.Val = val;
        }
     
        public int Val { get; set; }
        public List<Tree> Childs { get; set; }
    }
    /// <summary>
    /// 二叉树
    /// </summary>
    public class BTree
    {
        public BTree(int val)
        {
            this.Val = val;
        }
        public BTree(int val, BTree Left, BTree Right)
        {
            this.Val = val;
            this.Left = Left;
            this.Right = Right;
        }

        public int Val { get; set; }
        public BTree Left { get; set; }
        public BTree Right { get; set; }
    }
    #endregion

    #region 链表
    public class ListNode
    {
        public ListNode(int val)
        {
            Val = val;
        }
        public int Val { get; set; }
        public ListNode Next { get; set; }
        public ListNode Before { get; set; }
        public override string ToString()
        {
            if (this == null)
            {
                return "";
            }
            else
            {
                var vals = new List<int>();
                for (ListNode current = this; current != null; current = current.Next)
                {
                    vals.Add(current.Val);
                }
                return string.Join(",", vals);
            }
        }
    }

    #endregion

   
}
