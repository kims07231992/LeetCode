using System;

namespace Maximum_Depth_of_Binary_Tree
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var root = new TreeNode(3);
            root.left = new TreeNode(9);
            root.right = new TreeNode(20);
            root.right.left = new TreeNode(15);
            root.right.right = new TreeNode(7);

            var result = MaxDepth(root);
        }

        /// <summary>
        /// Time Complexity: O(N) where N is number of nodes
        /// Space Complexity: O(N)
        /// </summary>
        private static int MaxDepth(TreeNode root)
        {
            return Traverse(root, 0);
        }

        private static int Traverse(TreeNode node, int level)
        {
            if (node == null)
                return level;
            else
                return Math.Max(Traverse(node.left, level + 1), Traverse(node.right, level + 1));
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
