using System.Collections.Generic;
using System.Linq;

namespace Maximum_Level_Sum_of_a_Binary_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            // [1,7,0,7,-8,null,null]
            var root = new TreeNode(1);
            root.left = new TreeNode(7);
            root.right = new TreeNode(0);
            root.left.left = new TreeNode(7);
            root.left.right = new TreeNode(-8);

            var resultOfBFS = MaxLevelSumBFS(root);
            var resultOfDFS = MaxLevelSumDFS(root);
        }

        /// <summary>
        /// Time Complexity: O(N) where N is number of given nodes
        /// Space Complexity: O(N)
        /// </summary>
        public static int MaxLevelSumBFS(TreeNode root)
        {
            var maxSum = root.val;
            var maxLevel = 1;
            var level = 1;
            var queue = new Queue<TreeNode>();

            queue.Enqueue(root);
            while (queue.Count != 0)
            {
                int sum = 0;
                int n = queue.Count;
                for (int i = 0; i < n; i++)
                {
                    var node = queue.Dequeue();
                    sum += node.val;

                    if (node.left != null)
                        queue.Enqueue(node.left);

                    if (node.right != null)
                        queue.Enqueue(node.right);
                }
                if (maxSum < sum)
                {
                    maxSum = sum;
                    maxLevel = level;
                }
                level++;
            }

            return maxLevel;
        }

        /// <summary>
        /// Time Complexity: O(N) where N is number of given nodes
        /// Space Complexity: O(N)
        /// </summary>
        private static int MaxLevelSumDFS(TreeNode root)
        {
            var dfsMap = new List<int>();
            MaxLevelSumDFS(root, dfsMap, 0);

            return 1 + dfsMap // get index(level) of max element
                .Select((value, index) => new { Value = value, Index = index })
                .Aggregate((a, b) => (a.Value > b.Value) ? a : b)
                .Index;
        }

        private static void MaxLevelSumDFS(TreeNode node, List<int> dfsMap, int level)
        {
            if (node == null)
                return;

            if (dfsMap.Count == level)
                dfsMap.Add(node.val); // never reach this level before, add first value.
            else
                dfsMap[level] += node.val; // reached the level before, accumulate current value to old value.

            MaxLevelSumDFS(node.left, dfsMap, level + 1);
            MaxLevelSumDFS(node.right, dfsMap, level + 1);
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
