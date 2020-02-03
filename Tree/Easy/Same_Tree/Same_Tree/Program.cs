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

            var result = IsSameTree(p, q);
        }

        /// <summary>
        /// Time Complexity: O(P + Q) where P is number of elements of given tree p and Q is number of elements of given tree q
        /// Space Complexity: O(P + Q)
        /// </summary>
        public static bool IsSameTree(TreeNode p, TreeNode q)
        {
            var listP = new List<int>();
            var listQ = new List<int>();
            Traverse(p, listP);
            Traverse(q, listQ);

            if (listP.Count != listQ.Count)
                return false;

            for (int i = 0; i < listP.Count; i++)
                if (listP[i] != listQ[i])
                    return false;

            return true;
        }

        private static void Traverse(TreeNode node, List<int> list)
        {
            if (node == null)
                return;
            
            list.Add(node.val); // PreOrder

            if (node.left != null)
                Traverse(node.left, list);
            else
                list.Add(int.MinValue); // null
             
            if (node.right != null)
                Traverse(node.right, list);
            else
                list.Add(int.MinValue); // null
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
