
namespace Lowest_Common_Ancestor_of_a_Binary_Tree
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
            root.left = new TreeNode(5);
            root.right = new TreeNode(1);
            root.left.left = new TreeNode(6);

            var result = LowestCommonAncestor(root, root.left, root.right);
        }

        /// <summary>
        /// Time Complexity: O(N) where N is number of elements from given tree
        /// Space Complexity: O(N)
        /// </summary>
        private static TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null || root == p || root == q)
                return root;

            var left = LowestCommonAncestor(root.left, p, q);
            var right = LowestCommonAncestor(root.right, p, q);

            if (left == null)
                return right;
            else if (right == null)
                return left;
            else
                return root;
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
