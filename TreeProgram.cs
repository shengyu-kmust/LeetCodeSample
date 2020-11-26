using System.Collections.Generic;

namespace LeetCodeSample
{
    public class TreeProgram
    {
        #region 遍历
        #region 递归遍历，DFS遍历，即先，中，后序遍历
        public List<int> RecursionBefore(BTree tree, List<int> paths)
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
        public List<int> RecursionMiddle(BTree tree, List<int> paths)
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

        public List<int> RecursionAfter(BTree tree, List<int> paths)
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
        public void IterationBefore(BTree tree, out List<int> paths)
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
        public void IterationMiddle(BTree tree, out List<int> paths)
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
        public void IterationAfter(BTree tree, out List<int> paths)
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
        public void IterationAll(BTree tree, out List<int> paths, string beforeMiddleAfter)
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

                // 先序、中序、后序的入栈
                if (beforeMiddleAfter == "after" && addRootToStack)
                {
                    stack.Push(root); //后序逻辑
                }
                if (right != null)
                {
                    stack.Push(right);
                }
                if (beforeMiddleAfter == "middle" && addRootToStack)
                {
                    stack.Push(root); //中序逻辑
                }
                if (left != null)
                {
                    stack.Push(left);
                }
                if (beforeMiddleAfter == "before" && addRootToStack)
                {
                    stack.Push(root); //先序逻辑
                }
            }
        }
        #endregion

        #region BFS遍历
        public List<int> BFS(BTree tree)
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
        public void BFSInternal(List<BTree> trees, List<int> visitedNodes)
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
        #endregion
    }
}
