using System.Collections.Generic;
using System.Linq;

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
        public int Val { get; set; }
        public BTree Left { get; set; }
        public BTree Right { get; set; }
    }
    #endregion

    #region 链表
    public class ListNode
    {
        public int Val { get; set; }
        public ListNode Next { get; set; }
    }
    #endregion
}
