
namespace Subtree_of_Another_Tree
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var s = new TreeNode(3);
            s.left = new TreeNode(4);
            s.right = new TreeNode(5);
            s.left.left = new TreeNode(1);
            s.left.right = new TreeNode(2);

            var t = new TreeNode(4);
            t.left = new TreeNode(1);
            t.right = new TreeNode(2);

            var result = IsSubtree(s, t);
        }

        /// <summary>
        /// Time Complexity: O(S) where S is number of nodes of given tree s
        /// Space Complexity: O(logS)
        /// </summary>
        private static bool IsSubtree(TreeNode s, TreeNode t)
        {
            if (s == null)
                return false;

            if (s.val == t.val)
                return IsSame(s, t) || IsSubtree(s.left, t) || IsSubtree(s.right, t);
            else
                return IsSubtree(s.left, t) || IsSubtree(s.right, t);
        }

        private static bool IsSame(TreeNode nodeA, TreeNode nodeB)
        {
            if (nodeA == null && nodeB == null)
                return true;

            if (nodeA == null || nodeB == null)
                return false;

            if (nodeA.val != nodeB.val)
                return false;

            return IsSame(nodeA.left, nodeB.left) && IsSame(nodeA.right, nodeB.right);
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
