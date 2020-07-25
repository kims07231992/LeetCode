using System;
using System.Collections.Generic;

namespace Binary_Tree_Zigzag_Level_Order_Traversal
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

            var result = ZigzagLevelOrder(root);
        }

        /// <summary>
        /// Time Complexity: O(N) where N is number of nodes in tree
        /// Space Complexity: O(N)
        /// </summary>
        private static IList<IList<int>> ZigzagLevelOrder(TreeNode root)
        {
            var result = new List<IList<int>>();

            if (root == null)
                return result;

            var isLeft = true;
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                var n = queue.Count;
                var levelElements = new List<int>();
                for (int i = 0; i < n; i++)
                {
                    var node = queue.Dequeue();
                    if (isLeft)
                    {
                        levelElements.Add(node.val);
                    }
                    else
                    {
                        levelElements.Insert(0, node.val);
                    }

                    if (node.left != null)
                    {
                        queue.Enqueue(node.left);
                    }

                    if (node.right != null)
                    {
                        queue.Enqueue(node.right);
                    }
                }

                result.Add(levelElements);
                isLeft = !isLeft;
            }

            return result;
        }

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }
    }
}
