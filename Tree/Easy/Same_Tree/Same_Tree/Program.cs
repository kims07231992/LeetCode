using System.Collections.Generic;

namespace Same_Tree
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var p = new TreeNode(1);
            p.left = new TreeNode(1);
            var q = new TreeNode(1);
            q.right = new TreeNode(1);

            var result = IsSameTreeIterative(p, q);
        }

        /// <summary>
        /// Time Complexity: O(N) where N is Min(N, M)
        /// Space Complexity: O(N)
        /// </summary>
        public static bool IsSameTreeIterative(TreeNode p, TreeNode q)
        {
            var queueP = new Queue<TreeNode>();
            var queueQ = new Queue<TreeNode>();
            queueP.Enqueue(p);
            queueQ.Enqueue(q);
            while (queueP.Count > 0 && queueQ.Count > 0)
            {
                p = queueP.Dequeue();
                q = queueQ.Dequeue();
                if (p == null && q == null)
                    continue;
                else if (p == null || q == null)
                    return false;
                else if (p.val != q.val)
                    return false;

                queueP.Enqueue(p.left);
                queueP.Enqueue(p.right);
                queueQ.Enqueue(q.left);
                queueQ.Enqueue(q.right);
            }

            return queueP.Count == queueQ.Count;
        }

        /// <summary>
        /// Time Complexity: O(N) where N is Min(N, M)
        /// Space Complexity: O(N)
        /// </summary>
        private static bool IsSameTreeRecursive(TreeNode p, TreeNode q)
        {
            if (p == null && q == null)
                return true;
            else if (p == null || q == null)
                return false;
            else if (p.val != q.val)
                return false;

            return IsSameTreeRecursive(p.left, q.left) 
                && IsSameTreeRecursive(p.right, q.right);
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
