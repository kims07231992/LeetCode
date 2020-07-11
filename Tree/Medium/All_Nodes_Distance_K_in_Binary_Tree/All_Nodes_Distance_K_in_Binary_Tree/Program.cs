using System.Collections.Generic;

namespace All_Nodes_Distance_K_in_Binary_Tree
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
            root.left.right = new TreeNode(2);
            root.right.left = new TreeNode(0);
            root.right.right = new TreeNode(8);
            root.left.right.left = new TreeNode(7);
            root.left.right.right = new TreeNode(4);
            var K = 5;

            var result = DistanceK(root, root.left.right.left, K);
        }

        /// <summary>
        /// Time Complexity: O(N) where N is number of elements in binary tree
        /// Space Complexity: O(N)
        /// </summary>
        private static IList<int> DistanceK(TreeNode root, TreeNode target, int K)
        {
            var result = new List<int>();
            var map = new Dictionary<TreeNode, int>();
            Search(root, target, map);
            Traverse(result, map, root, target, K, map[root]);

            return result;
        }

        private static void Search(TreeNode root, TreeNode target, Dictionary<TreeNode, int> map)
        {
            if (root == null)
                return;

            if (root == target)
            {
                map.Add(root, 0);
            }

            Search(root.left, target, map);
            if (map.ContainsKey(root.left)) // to only map the path for target
            {
                map.Add(root, map[root.left] + 1);
                return;
            }

            Search(root.right, target, map);
            if (map.ContainsKey(root.right)) // to only map the path for target
            {
                map.Add(root, map[root.right] + 1);
                return;
            }
        }

        private static void Traverse(List<int> result, Dictionary<TreeNode, int> map, TreeNode root, TreeNode target, int K, int length)
        {
            if (root == null)
                return;

            // node that is included from the path to target
            // value in map is equal to distance from target
            // it covers the case where path to target is not from root node
            if (map.ContainsKey(root))
                length = map[root];

            if (length == K)
                result.Add(root.val);

            Traverse(result, map, root.left, target, K, length + 1);
            Traverse(result, map, root.right, target, K, length + 1);
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
