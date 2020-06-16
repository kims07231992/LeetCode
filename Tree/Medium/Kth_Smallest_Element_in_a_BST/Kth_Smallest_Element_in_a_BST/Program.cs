using System.Collections.Generic;

namespace Kth_Smallest_Element_in_a_BST
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var root = new TreeNode(6);
            root.left = new TreeNode(2);
            root.right = new TreeNode(8);
            root.left.left = new TreeNode(0);
            root.left.right = new TreeNode(4);
            var k = 3;

            var iterativeResult = KthSmallestIterative(root, k);
            var recursiveResult = KthSmallestRecursive(root, k);
        }

        /// <summary>
        /// Time Complexity: O(N) where N is number of elements in BST
        /// Space Complexity: O(N)
        /// </summary>
        private static int KthSmallestIterative(TreeNode root, int k)
        {
            var stack = new Stack<TreeNode>();
            var current = root;
            while (root != null || stack.Count > 0)
            {
                while (current != null)
                {
                    stack.Push(current);
                    current = current.left;
                }

                current = stack.Pop();
                if (--k == 0)
                    return current.val;

                current = current.right;
            }

            return current.val;
        }

        /// <summary>
        /// Time Complexity: O(N) where N is number of elements in BST
        /// Space Complexity: O(N)
        /// </summary>
        private static int KthSmallestRecursive(TreeNode root, int k)
        {
            int result = 0;
            KthSmallestRecursive(root, ref k, ref result);

            return result;
        }

        private static void KthSmallestRecursive(TreeNode root, ref int k, ref int result)
        {
            if (root == null)
                return;

            KthSmallestRecursive(root.left, ref k, ref result);
            if (--k == 0)
            {
                result = root.val;
                return;
            }
            KthSmallestRecursive(root.right, ref k, ref result);
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
