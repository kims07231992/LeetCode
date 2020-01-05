
namespace Maximum_Binary_Tree
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var nums = new int[] { 3, 2, 1, 6, 0, 5 };
            var result = ConstructMaximumBinaryTree(nums);
        }

        /// <summary>
        /// Time Complexity: O(N^2) where N length of given array
        /// Space Complexity: O(N)
        /// </summary>
        private static TreeNode ConstructMaximumBinaryTree(int[] nums)
        {
            return ConstructTreeNode(nums, 0, nums.Length);
        }

        private static TreeNode ConstructTreeNode(int[] nums, int left, int right)
        {
            if (left == right)
                return null;

            int maxIndex = GetMaxIndex(nums, left, right);
            var root = new TreeNode(nums[maxIndex]);
            root.left = ConstructTreeNode(nums, left, maxIndex);
            root.right = ConstructTreeNode(nums, maxIndex + 1, right);

            return root;
        }

        private static int GetMaxIndex(int[] nums, int left, int right)
        {
            int maxIndex = left;
            for (int i = left; i < right; i++)
            {
                if (nums[maxIndex] < nums[i])
                    maxIndex = i;
            }

            return maxIndex;
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
