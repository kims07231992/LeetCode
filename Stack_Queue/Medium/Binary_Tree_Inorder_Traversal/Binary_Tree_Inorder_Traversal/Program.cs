using System.Collections.Generic;

namespace Binary_Tree_Inorder_Traversal
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var root = new TreeNode(1);
            root.right = new TreeNode(2);
            root.right.left = new TreeNode(3);

            var resultOfRecursiveInorderTraversal = RecursiveInorderTraversal(root);
            var resultOfIterativeInorderTraversal = IterativeInorderTraversal(root);
        }

        /// <summary>
        /// Time Complexity: O(N) where N is number of nodes
        /// Space Complexity: O(N)
        /// </summary>
        private static IList<int> RecursiveInorderTraversal(TreeNode root)
        {
            var result = new List<int>();
            RecursiveInorderTraversal(root, result);

            return result;
        }

        private static void RecursiveInorderTraversal(TreeNode node, IList<int> result)
        {
            if (node == null)
                return;

            RecursiveInorderTraversal(node.left, result);
            result.Add(node.val);
            RecursiveInorderTraversal(node.right, result);
        }

        /// <summary>
        /// Time Complexity: O(N) where N is number of nodes
        /// Space Complexity: O(N)
        /// </summary>
        private static IList<int> IterativeInorderTraversal(TreeNode root)
        {
            var result = new List<int>();
            if (root == null)
                return result;

            var stack = new Stack<TreeNode>();
            stack.Push(root);
            while (stack.Count != 0)
            {
                var node = stack.Peek();
                if (node.left != null)
                {
                    stack.Push(node.left);
                    node.left = null;
                }
                else if (node.right != null)
                {
                    result.Add(stack.Pop().val);
                    stack.Push(node.right);
                    node.right = null;
                }
                else
                {
                    result.Add(stack.Pop().val);
                }
            }

            return result;
        }

        private class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }
    }
}
