using System;
using System.Collections.Generic;

namespace Boundary_Traversal_Of_Binary_Tree
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
            root.right.left = new TreeNode(6);
            root.left.right.left = new TreeNode(7);
            root.left.right.right = new TreeNode(8);
            root.right.left.left = new TreeNode(9);
            root.right.left.right = new TreeNode(10);

            var result = BoundaryOfBinaryTree(root);
        }

        /// <summary>
        /// Time Complexity: O(N) where N is number of nodes
        /// Space Complexity: O(N)
        /// </summary>
        private static IList<int> BoundaryOfBinaryTree(TreeNode root)
        {
            var result = new List<int>();
            if (root == null)
                return result;

            result.Add(root.val);
            TraverseLeft(result, root.left);
            TraverseBottom(result, root.left);
            TraverseBottom(result, root.right);
            TraverseRight(result, root.right);

            return result;
        }

        private static void TraverseLeft(List<int> result, TreeNode root)
        {
            if (root == null)
                return;

            if (root.left == null && root.right == null)
                return;

            result.Add(root.val);
            if (root.left != null)
            {
                TraverseLeft(result, root.left);
            }
            else
            {
                TraverseLeft(result, root.right);
            }
        }

        private static void TraverseBottom(List<int> result, TreeNode root)
        {
            if (root == null)
                return;

            if (root.left == null && root.right == null)
            {
                result.Add(root.val);
            }
            else
            {
                TraverseBottom(result, root.left);
                TraverseBottom(result, root.right);
            }
        }

        private static void TraverseRight(List<int> result, TreeNode root)
        {
            if (root == null)
                return;

            if (root.left == null && root.right == null)
                return;

            if (root.right != null)
            {
                TraverseRight(result, root.right);
            }
            else
            {
                TraverseRight(result, root.left);
            }
            result.Add(root.val);
        }

        public class TreeNode
        {
            public TreeNode left;
            public TreeNode right;
            public int val;

            public TreeNode(int val)
            {
                this.val = val;
            }
        }
    }
}
