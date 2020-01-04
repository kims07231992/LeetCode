using System.Collections.Generic;

namespace Deepest_Leaves_Sum
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
            root.right = new TreeNode(3);
            root.left.left = new TreeNode(4);
            root.left.right = new TreeNode(5);
            root.right.right = new TreeNode(6);
            root.left.left.left = new TreeNode(7);
            root.right.right.right = new TreeNode(8);

            var result = DeepestLeavesSum(root);
        }

        /// <summary>
        /// Time Complexity: O(N) where N is number of nodes
        /// Space Complexity: O(N)
        /// </summary>
        public static int DeepestLeavesSum(TreeNode root)
        {
            var sum = 0;
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count != 0)
            {
                sum = 0;
                for (int i = queue.Count - 1; i >= 0; i--)
                {
                    var node = queue.Dequeue();
                    sum += node.val;

                    if (node.left != null)
                        queue.Enqueue(node.left);

                    if (node.right != null)
                        queue.Enqueue(node.right);
                }
            }

            return sum;
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
