
namespace Path_Sum
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var sum = -5;
            var root = new TreeNode(-2);
            root.left = null;
            root.right = new TreeNode(-3);

            var result = HasPathSum(root, sum);
        }

        /// <summary>
        /// Time Complexity: O(N) where N is number of nodes
        /// Space Complexity: O(logN)
        /// </summary>
        private static bool HasPathSum(TreeNode root, int sum)
        {
            return HasPathSumRecursive(root, sum);
        }

        private static bool HasPathSumRecursive(TreeNode node, int sum)
        {
            if (node == null)
                return false;

            if (node.val == sum && node.left == null && node.right == null)
                return true;

            return HasPathSumRecursive(node.left, sum - node.val) || HasPathSumRecursive(node.right, sum - node.val);
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
