using System.Collections.Generic;

namespace LeetCodeSample
{
    public  static class TreeProgram
    {
        #region 遍历
        #region DFS遍历
        #region 递归遍历，DFS遍历，即先，中，后序遍历
        public static List<int> RecursionBefore(BTree tree, List<int> paths)
        {
            paths.Add(tree.Val);
            if (tree.Left != null)
            {
                RecursionBefore(tree.Left, paths);
            }
            if (tree.Right != null)
            {
                RecursionBefore(tree.Right, paths);
            }
            return paths;
        }
        public static List<int> RecursionMiddle(BTree tree, List<int> paths)
        {
            if (tree.Left != null)
            {
                RecursionMiddle(tree.Left, paths);
            }
            paths.Add(tree.Val);
            if (tree.Right != null)
            {
                RecursionMiddle(tree.Right, paths);
            }
            return paths;
        }

        public static List<int> RecursionAfter(BTree tree, List<int> paths)
        {
            if (tree.Left != null)
            {
                RecursionAfter(tree.Left, paths);
            }
            if (tree.Right != null)
            {
                RecursionAfter(tree.Right, paths);
            }
            paths.Add(tree.Val);
            return paths;
        }
        #endregion
        #region 用栈做迭代
        /// <summary>
        /// 先序迭代
        /// </summary>
        /// <param name="tree"></param>
        /// <param name="paths"></param>
        public static void IterationBefore(BTree tree, out List<int> paths)
        {
            // 出栈：根，左，右
            // 入栈：右，左，根
            paths = new List<int>();
            var stack = new Stack<BTree>();
            stack.Push(tree);
            while (stack.Count > 0)
            {
                var outTree = stack.Pop();
                paths.Add(outTree.Val);
                if (outTree.Right != null)
                {
                    stack.Push(outTree.Right);
                }
                if (outTree.Left != null)
                {
                    stack.Push(outTree.Left);
                }
            }
        }
        /// <summary>
        /// 中序迭代
        /// </summary>
        /// <param name="tree"></param>
        /// <param name="paths"></param>
        public static void IterationMiddle(BTree tree, out List<int> paths)
        {
            // 出栈：左，根，右
            // 入栈：右，根，左
            paths = new List<int>();
            var stack = new Stack<BTree>();
            stack.Push(tree);
            while (stack.Count > 0)
            {
                // 将树从栈里提出，并剪成根、左、右三个树
                var root = stack.Pop();// 根树   
                var left = root.Left; // 左树
                var right = root.Right;// 右树
                root.Left = null;//剪掉左
                root.Right = null;//剪掉左
                bool addRootToStack;//根是否要入栈

                if (left == null && right == null)
                {
                    // 当从栈里取出的树的左/右树为空是，直接读取此节点，并不再入栈
                    paths.Add(root.Val);
                    addRootToStack = false;
                }
                else
                {
                    // 否则将此根节点放入到栈
                    addRootToStack = true;
                }
                if (right != null)
                {
                    stack.Push(right);
                }
                if (addRootToStack)
                {
                    stack.Push(root);
                }
                if (left != null)
                {
                    stack.Push(left);
                }
            }
        }
        /// <summary>
        /// 后序迭代
        /// </summary>
        /// <param name="tree"></param>
        /// <param name="paths"></param>
        public static void IterationAfter(BTree tree, out List<int> paths)
        {
            // 出栈：左，右，根
            // 入栈：根，右，左
            paths = new List<int>();
            var stack = new Stack<BTree>();
            stack.Push(tree);
            while (stack.Count > 0)
            {
                // 将树从栈里提出，并剪成根、左、右三个树
                var root = stack.Pop();// 根树   
                var left = root.Left; // 左树
                var right = root.Right;// 右树
                root.Left = null;//剪掉左
                root.Right = null;//剪掉左
                bool addRootToStack;//根是否要入栈

                if (left == null && right == null)
                {
                    // 当从栈里取出的树的左/右树为空是，直接读取此节点，并不再入栈
                    paths.Add(root.Val);
                    addRootToStack = false;
                }
                else
                {
                    // 否则将此根节点放入到栈
                    addRootToStack = true;
                }
                if (addRootToStack)
                {
                    stack.Push(root);
                }
                if (right != null)
                {
                    stack.Push(right);
                }
                if (left != null)
                {
                    stack.Push(left);
                }
            }
        }

        /// <summary>
        /// 先、中、后序迭代的通用方法
        /// </summary>
        /// <param name="tree"></param>
        /// <param name="paths"></param>
        /// <param name="beforeMiddleAfter"></param>
        public static void IterationAll(BTree tree, out List<int> paths, string beforeMiddleAfter)
        {
            // 先序：出栈：根，左，右 入栈：右，左，根
            // 中序：出栈：左，根，右 入栈：右，根，左
            // 后序：出栈：左，右，根 入栈：根，右，左
            paths = new List<int>();
            var stack = new Stack<BTree>();
            stack.Push(tree);
            while (stack.Count > 0)
            {
                // 将树从栈里提出，并剪成根、左、右三个树
                var root = stack.Pop();// 根树   
                var left = root.Left; // 左树
                var right = root.Right;// 右树
                root.Left = null;//剪掉左
                root.Right = null;//剪掉左

                if (left == null && right == null)
                {
                    // 当从栈里取出的树的左/右树为空是，直接读取此节点，并不再入栈
                    paths.Add(root.Val);
                    continue;
                }

                // 先序、中序、后序的入栈
                if (beforeMiddleAfter == "after")
                {
                    stack.Push(root); //后序逻辑
                }
                if (right != null)
                {
                    stack.Push(right);
                }
                if (beforeMiddleAfter == "middle")
                {
                    stack.Push(root); //中序逻辑
                }
                if (left != null)
                {
                    stack.Push(left);
                }
                if (beforeMiddleAfter == "before")
                {
                    stack.Push(root); //先序逻辑
                }
            }
        }
        #endregion
        #endregion


        #region BFS遍历
        #region 递归
        public static List<int> BFS(BTree tree)
        {
            var visitedNodes = new List<int>();
            if (tree == null)
            {
                return visitedNodes;
            }
            visitedNodes.Add(tree.Val);
            BFSInternal(new List<BTree> { tree.Left, tree.Right }, visitedNodes);
            return visitedNodes;
        }
        public static void BFSInternal(List<BTree> trees, List<int> visitedNodes)
        {
            var nextTrees = new List<BTree>();
            foreach (var tree in trees)
            {
                visitedNodes.Add(tree.Val);
                if (tree.Left != null)
                {
                    nextTrees.Add(tree.Left);
                }
                if (tree.Right != null)
                {
                    nextTrees.Add(tree.Right);
                }
            }
            if (trees.Count > 1)
            {
                BFSInternal(nextTrees, visitedNodes);
            }
        }

        #endregion
        #region 迭代

        /// <summary>
        /// 用queue结构来迭代
        /// </summary>
        /// <param name="tree"></param>
        /// <returns></returns>
        public static List<int> BFSTreeIteration(BTree tree)
        {
            var queue = new Queue<BTree>();
            queue.Enqueue(tree);
            var res = new List<int>();
            while (queue.Count > 0)
            {
                var tmp = queue.Dequeue();
                res.Add(tmp.Val);
                if (tmp.Left != null)
                {
                    queue.Enqueue(tmp.Left);
                }
                if (tmp.Right != null)
                {
                    queue.Enqueue(tmp.Right);
                }
            }
            return res;

        }
        #endregion

        #endregion
        #endregion

        #region 其它

        /// <summary>
        /// 验证是否为二叉搜索树
        /// </summary>
        /// <param name="tree"></param>
        /// <returns></returns>
        public static bool Method_98(BTree tree)
        {
            #region 方法一
            //class Solution
            //{
            //    public boolean isValidBST(TreeNode root)
            //    {
            //        return helper(root, null, null);
            //    }

            //    public boolean helper(TreeNode node, Integer lower, Integer upper)
            //    {
            //        if (node == null)
            //        {
            //            return true;
            //        }

            //        int val = node.val;
            //        if (lower != null && val <= lower)
            //        {
            //            return false;
            //        }
            //        if (upper != null && val >= upper)
            //        {
            //            return false;
            //        }

            //        if (!helper(node.right, val, upper))
            //        {
            //            return false;
            //        }
            //        if (!helper(node.left, lower, val))
            //        {
            //            return false;
            //        }
            //        return true;
            //    }
            //}


            #endregion
            #region 方法二
        //class Solution
        //{
        //    public boolean isValidBST(TreeNode root)
        //    {
        //        Deque<TreeNode> stack = new LinkedList<TreeNode>();
        //        double inorder = -Double.MAX_VALUE;

        //        while (!stack.isEmpty() || root != null)
        //        {
        //            while (root != null)
        //            {
        //                stack.push(root);
        //                root = root.left;
        //            }
        //            root = stack.pop();
        //            // 如果中序遍历得到的节点的值小于等于前一个 inorder，说明不是二叉搜索树
        //            if (root.val <= inorder)
        //            {
        //                return false;
        //            }
        //            inorder = root.val;
        //            root = root.right;
        //        }
        //        return true;
        //    }
        //}

       
            #endregion
            return false;
        }
        #endregion
    }
}
