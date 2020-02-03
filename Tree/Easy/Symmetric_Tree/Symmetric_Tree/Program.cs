using System.Collections.Generic;

namespace Symmetric_Tree
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
            root.left = new TreeNode(2);
            root.right = new TreeNode(2);
            root.left.right = new TreeNode(3);
            root.right.right = new TreeNode(3);

            var result = IsSymmetricIterative(root);
        }

        /// <summary>
        /// Time Complexity: O(N) where N is number of elements of given tree
        /// Space Complexity: O(N)
        /// </summary>
        private static bool IsSymmetricIterative(TreeNode root)
        {
            if (root == null)
                return true;
            else if (root.left == null || root.right == null)
                return root.left == root.right;

            var stack = new Stack<TreeNode>();
            stack.Push(root.left);
            stack.Push(root.right);

            while (stack.Count != 0)
            {
                var right = stack.Pop();
                var left = stack.Pop();
                if (right.val != left.val)
                    return false;

                if (left.left != null)
                {
                    if (right.right == null)
                        return false;

                    stack.Push(left.left);
                    stack.Push(right.right);
                }
                else if (right.right != null)
                {
                    return false;
                }

                if (left.right != null)
                {
                    if (right.left == null)
                        return false;

                    stack.Push(left.right);
                    stack.Push(right.left);
                }
                else if (right.left != null)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Time Complexity: O(N) where N is number of elements of given tree
        /// Space Complexity: O(N)
        /// </summary>
        public static bool IsSymmetricRecursive(TreeNode root)
        {
            return root == null || IsSymmetricRecursive(root.left, root.right);
        }

        private static bool IsSymmetricRecursive(TreeNode left, TreeNode right)
        {
            if (left == null || right == null)
                return left == right;

            if (left.val != right.val)
                return false;

            return IsSymmetricRecursive(left.left, right.right) 
                && IsSymmetricRecursive(left.right, right.left);
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
