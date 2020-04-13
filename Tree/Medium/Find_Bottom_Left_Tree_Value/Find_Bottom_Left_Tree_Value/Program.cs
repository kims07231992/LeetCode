using System.Collections.Generic;

namespace Find_Bottom_Left_Tree_Value
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }
        private static void Run()
        {
            var root = new TreeNode(2);
            root.left = new TreeNode(1);
            root.right = new TreeNode(3);

            var result = FindBottomLeftValue(root);
        }

        /// <summary>
        /// Time Complexity: O(N) where N number of nodes
        /// Space Complexity: O(N)
        /// </summary>
        private static int FindBottomLeftValue(TreeNode root)
        {
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                int n = queue.Count;
                for (int i = 0; i < n; i++)
                {
                    root = queue.Dequeue();
                    if (root.right != null)
                        queue.Enqueue(root.right);
                    if (root.left != null)
                        queue.Enqueue(root.left);

                }
            }

            return root.val;
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
