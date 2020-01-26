using System.Collections.Generic;

namespace Binary_Tree_Right_Side_View
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
            root.left.right = new TreeNode(5);
            root.right.right = new TreeNode(4);

            var result = RightSideView(root);
        }

        /// <summary>
        /// Time Complexity: O(N) where N number of given nodes
        /// Space Complexity: O(N)
        /// </summary>
        private static IList<int> RightSideView(TreeNode root)
        {
            var result = new List<int>();
            if (root == null)
                return result;

            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count != 0)
            {
                int n = queue.Count - 1;
                for (int i = 0; i <= n; i++)
                {
                    var node = queue.Dequeue();
                    if (node.left != null)
                        queue.Enqueue(node.left);
                    if (node.right != null)
                        queue.Enqueue(node.right);

                    if (i == n)
                        result.Add(node.val);
                }
            }

            return result;
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
