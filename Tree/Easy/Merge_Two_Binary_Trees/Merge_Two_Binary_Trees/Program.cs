
namespace Merge_Two_Binary_Trees
{

    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var t1 = new TreeNode(3);
            t1.left = new TreeNode(9);
            t1.right = new TreeNode(20);
            t1.right.left = new TreeNode(15);
            t1.right.right = new TreeNode(7);

            var t2 = new TreeNode(3);
            t2.left = new TreeNode(9);
            t2.right = new TreeNode(20);

            var result = MergeTrees(t1, t2);
        }

        /// <summary>
        /// Time Complexity: O(M + N) where M is number of t1's nodes and N is number of t2's nodes
        /// Space Complexity: O(M + N)
        /// </summary>
        private static TreeNode MergeTrees(TreeNode t1, TreeNode t2)
        {
            if (t1 != null && t2 != null)
            {
                t1.val += t2.val;
                t1.left = MergeTrees(t1.left, t2.left);
                t1.right = MergeTrees(t1.right, t2.right);
                return t1;
            }
            else if (t1 == null)
            {
                return t2;
            }
            else
            {
                return t1;
            }
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
