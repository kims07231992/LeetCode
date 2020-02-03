using System.Collections.Generic;

namespace Validate_Binary_Search_Tree
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var root = new TreeNode(5);
            root.left = new TreeNode(3);
            root.right = new TreeNode(8);
            root.left.left = new TreeNode(2);
            root.left.right = new TreeNode(4);
            root.left.left.left = new TreeNode(1);
            root.right.right = new TreeNode(9);

            var result = IsValidBSTIterative(root);
        }

        /// <summary>
        /// Time Complexity: O(N) where N is number of elements of given tree
        /// Space Complexity: O(N)
        /// </summary>
        private static bool IsValidBSTIterative(TreeNode root)
        {
            if (root == null)
                return true;

            var stack = new Stack<TreeNode>();
            var queue = new Queue<int>();
            var current = root;
            while (current != null || stack.Count != 0)
            {
                while (current != null)
                {
                    stack.Push(current);
                    current = current.left;
                }

                current = stack.Pop();
                if (queue.Count == 0)
                    queue.Enqueue(current.val);
                else if (queue.Dequeue() >= current.val)
                    return false;
                else
                    queue.Enqueue(current.val);

                current = current.right;
            }

            return true;
        }

        /// <summary>
        /// Time Complexity: O(N) where N is number of elements of given tree
        /// Space Complexity: O(N)
        /// </summary>
        private static bool IsValidBSTRecursive(TreeNode root)
        {
            if (root == null)
                return true;

            var nodeValues = new List<int>();
            IsValidBSTRecursive(root, nodeValues);
            int value = nodeValues[0];
            for (int i = 1; i < nodeValues.Count; i++)
            {
                if (value >= nodeValues[i])
                    return false;

                value = nodeValues[i];
            }

            return true;
        }

        private static void IsValidBSTRecursive(TreeNode node, List<int> nodeValues)
        {
            if (node == null)
                return;

            if (node.left != null)
            {
                IsValidBSTRecursive(node.left, nodeValues);
            }

            nodeValues.Add(node.val);

            if (node.right != null)
            {
                IsValidBSTRecursive(node.right, nodeValues);
            }
        }

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }
    }
}
