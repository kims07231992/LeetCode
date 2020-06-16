
namespace Lowest_Common_Ancestor_of_a_BST
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
            var p = root.left;
            var q = root.left.right;

            var result = LowestCommonAncestor(root, p, q);
        }

        /// <summary>
        /// Time Complexity: O(N) where N is number of elements in BST
        /// Space Complexity: O(1)
        /// </summary>
        private static TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (p.val > q.val)
            {
                var temp = p;
                p = q;
                q = temp;
            }

            while (!(root.val >= p.val && root.val <= q.val))
            {
                if (root.val >= p.val)
                    root = root.left;
                else
                    root = root.right;
            }

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