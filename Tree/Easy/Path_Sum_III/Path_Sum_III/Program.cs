
namespace Path_Sum_III
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var sum = 8;
            var root = new TreeNode(10);
            root.left = new TreeNode(5);
            root.right = new TreeNode(-3);
            root.left.left = new TreeNode(3);
            root.left.right = new TreeNode(2);
            root.right.right = new TreeNode(11);

            var result = PathSum(root, sum);
        }

        /// <summary>
        /// Time Complexity: O(N^2) - not balanced tree + worst case, O(NlogN) - balanced tree + best case, where N number of nodes
        /// Space Complexity: O(N)
        /// </summary>
        private static int PathSum(TreeNode root, int sum)
        {
            if (root == null)
                return 0;

            return PathSumFrom(root, sum) 
                + PathSum(root.left, sum) 
                + PathSum(root.right, sum);
        }

        private static int PathSumFrom(TreeNode node, int sum)
        {
            if (node == null)
                return 0;

            return (node.val == sum ? 1 : 0)
                + PathSumFrom(node.left, sum - node.val) 
                + PathSumFrom(node.right, sum - node.val);
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
