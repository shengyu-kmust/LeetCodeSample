using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.Tests
{
    public class TreeProgram
    {
        public void BTreeDFS(BTree tree, List<int> paths)
        {
            if (tree == null)
            {
                return;
            }
            paths.Add(tree.Val);
            BTreeDFS(tree.Left, paths);
            BTreeDFS(tree.Right, paths);
        }

        public void Dfs(Tree node, List<int> paths)
        {
            paths.Add(node.Val);
            if (node.Childs != null && node.Childs.Count > 0)
            {
                foreach (var child in node.Childs)
                {
                    Dfs(node, paths);
                }
            }
        }

        public void Bfs(Tree node, List<int> paths)
        {
            paths.Add(node.Val);
            if (node.Childs != null && node.Childs.Count > 0)
            {
                foreach (var child in node.Childs)
                {
                    Dfs(node, paths);
                }
            }
        }
        public class Tree
        {
            public Tree(int val)
            {
                this.Val = val;
            }
            public int Val { get; set; }
            public List<Tree> Childs { get; set; }
        }

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

        /// <summary>
        /// 创建深度为4的全完二叉树
        /// </summary>
        /// <returns></returns>
        public BTree BuildTestBTree()
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
}
