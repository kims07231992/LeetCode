using System.Collections.Generic;

namespace Binary_Tree_Level_Order_Traversal
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

            var result = LevelOrder(root);
        }

        /// <summary>
        /// Time Complexity: O(N) where N is number of elements of given tree
        /// Space Complexity: O(N)
        /// </summary>
        public static IList<IList<int>> LevelOrder(TreeNode root)
        {
            if (root == null)
                return new List<IList<int>>() as IList<IList<int>>;

            var result = new List<IList<int>>();
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count != 0)
            {
                var level = new List<int>();
                var n = queue.Count;
                for (int i = 0; i < n; i++)
                {
                    var current = queue.Dequeue();
                    level.Add(current.val);

                    if (current.left != null)
                        queue.Enqueue(current.left);

                    if (current.right != null)
                        queue.Enqueue(current.right);
                }
                result.Add(level);
            }

            return result as IList<IList<int>>;
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
