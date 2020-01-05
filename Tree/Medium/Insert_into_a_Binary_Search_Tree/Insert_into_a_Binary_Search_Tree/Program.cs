using System;

namespace Insert_into_a_Binary_Search_Tree
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var root = new TreeNode(4);
            root.left = new TreeNode(2);
            root.right = new TreeNode(7);
            root.left.left = new TreeNode(1);
            root.left.right = new TreeNode(3);

            InsertIntoBST(root, 5);
        }

        private static TreeNode InsertIntoBST(TreeNode root, int val)
        {
            InsertNodeIteratively(root, val);
            // InsertNodeRecursively(root, val);

            return root;
        }

        private static void InsertNodeIteratively(TreeNode node, int val)
        {
            while (node != null)
            {
                if (node.val == val) // this instance is equal to value.
                {
                    throw new ArgumentException();
                }
                else if (node.val > val) // this instance is less than value.
                {
                    if (node.left == null)
                    {
                        node.left = new TreeNode(val);
                        return;
                    }
                    else
                    {
                        node = node.left;
                    }
                }
                else // this instance is greater than value.
                {
                    if (node.right == null)
                    {
                        node.right = new TreeNode(val);
                        return;
                    }
                    else
                    {
                        node = node.right;
                    }
                }
            }
        }

        private static void InsertNodeRecursively(TreeNode node, int val)
        {
            if (node.val == val) // this instance is equal to value.
            {
                throw new ArgumentException();
            }
            else if (node.val > val) // this instance is less than value.
            {
                if (node.left == null)
                {
                    node.left = new TreeNode(val);
                }
                else
                {
                    InsertNodeRecursively(node.left, val);
                }
            }
            else // this instance is greater than value.
            {
                if (node.right == null)
                {
                    node.right = new TreeNode(val);
                }
                else
                {
                    InsertNodeRecursively(node.right, val);
                }
            }
        }

        private class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }
    }
}
