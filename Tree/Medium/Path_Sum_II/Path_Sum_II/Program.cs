using System.Collections.Generic;

namespace Path_Sum_II
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
            var sum = 3;

            var result = PathSum(root, sum);
        }

        /// <summary>
        /// Time Complexity: O(N) where N is number of nodes in binary tree
        /// Space Complexity: O(N)
        /// if we need to include result as space, leaf nodes = (N-1)/2, height = h = logN => O((N-1)/2 * logN) = O(NlogN)
        /// </summary>
        private static IList<IList<int>> PathSum(TreeNode root, int sum)
        {
            var result = new List<System.Collections.Generic.IList<int>>();
            PathSum(root, sum, new List<int>(), result);

            return result;
        }

        private static void PathSum(TreeNode root, int sum, List<int> path, List<IList<int>> result)
        {
            if (root == null)
                return;

            path.Add(root.val);
            if (root.val == sum && root.left == null && root.right == null)
            {
                result.Add(new List<int>(path));
            }
            else
            {
                PathSum(root.left, sum - root.val, path, result);
                PathSum(root.right, sum - root.val, path, result);
            }
            path.RemoveAt(path.Count - 1);
        }

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }
    }
}
