
namespace Construct_BST_from_Preorder_Traversal
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var preorder = new int[] { 8, 5, 1, 7, 10, 12 };
            BstFromPreorder(preorder);
        }

        /// <summary>
        /// Time Complexity: O(N) where N is length of given array
        /// Space Complexity: O(N)
        /// </summary>
        public static TreeNode BstFromPreorder(int[] preorder)
        {
            var index = 0;
            return RecursiveBstFromPreorder(preorder, int.MaxValue, ref index);
        }

        private static TreeNode RecursiveBstFromPreorder(int[] preorder, int bound, ref int index)
        {
            if (index == preorder.Length || preorder[index] > bound)
                return null;

            var root = new TreeNode(preorder[index++]);
            root.left = RecursiveBstFromPreorder(preorder, root.val, ref index);
            root.right = RecursiveBstFromPreorder(preorder, bound, ref index);

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
