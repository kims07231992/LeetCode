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

            var current = root;
            var stack = new Stack<TreeNode>();
            while (current != null || stack.Count > 0)
            {
                while (current != null)
                {
                    stack.Push(current);
                    current = current.left;
                }

                current = stack.Pop();
                result.Add(current.val);

                current = current.right;
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
