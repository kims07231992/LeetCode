using System.Collections.Generic;

namespace All_Elements_in_Two_Binary_Search_Trees
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var root1 = new TreeNode(2);
            root1.left = new TreeNode(1);
            root1.right = new TreeNode(4);

            var root2 = new TreeNode(1);
            root2.left = new TreeNode(0);
            root2.right = new TreeNode(3);

            var result = GetAllElements(root1, root2);
        }

        /// <summary>
        /// Time Complexity: O(N + M) where N is number of root1's nodes and M is root2's nodes
        /// Space Complexity: O(N + M)
        /// </summary>
        private static IList<int> GetAllElements(TreeNode root1, TreeNode root2)
        {
            var queue1 = new Queue<int>();
            var queue2 = new Queue<int>();
            TraverseInOrder(root1, queue1);
            TraverseInOrder(root2, queue2);

            return GetMergedQueues(queue1, queue2);
        }

        private static void TraverseInOrder(TreeNode node, Queue<int> queue)
        {
            if (node == null)
                return;

            TraverseInOrder(node.left, queue);
            queue.Enqueue(node.val);
            TraverseInOrder(node.right, queue);
        }

        private static IList<int> GetMergedQueues(Queue<int> queue1, Queue<int> queue2)
        {
            var result = new List<int>();
            while (queue1.Count != 0 || queue2.Count != 0)
            {
                if (queue1.Count == 0)
                {
                    result.Add(queue2.Dequeue());
                }
                else if (queue2.Count == 0)
                {
                    result.Add(queue1.Dequeue());
                }
                else
                {
                    result.Add(queue1.Peek() < queue2.Peek() 
                        ? queue1.Dequeue() 
                        : queue2.Dequeue());
                }
            }

            return result;
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
