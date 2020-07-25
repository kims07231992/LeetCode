using System;
using System.Collections.Generic;
using System.Text;

namespace Serialize_and_Deserialize_Binary_Tree
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
            root.right.left = new TreeNode(4);
            root.right.right = new TreeNode(5);
        }

        /// <summary>
        /// Time Complexity: O(N) where N is number of nodes
        /// Space Complexity: O(N) 
        /// </summary>
        public class Codec
        {

            // Encodes a tree to a single string.
            /// <summary>
            /// Time Complexity: O(N) where N is number of nodes
            /// Space Complexity: O(N) 
            /// </summary>
            public string serialize(TreeNode root)
            {
                var sb = new StringBuilder();
                serialize(root, sb);

                return sb.ToString();
            }

            private void serialize(TreeNode root, StringBuilder sb)
            {
                if (root == null)
                {
                    sb.Append("#,");
                }
                else
                {
                    sb.Append($"{root.val},");
                    serialize(root.left, sb);
                    serialize(root.right, sb);
                }
            }

            // Decodes your encoded data to tree.
            /// <summary>
            /// Time Complexity: O(N) where N is number of nodes
            /// Space Complexity: O(N) 
            /// </summary>
            public TreeNode deserialize(string data)
            {
                var queue = new Queue<string>(data.Split(","));
                return deserialize(queue);
            }

            private TreeNode deserialize(Queue<string> queue)
            {
                string s = queue.Dequeue();
                if (s == "#")
                    return null;

                var root = new TreeNode(Convert.ToInt32(s));
                root.left = deserialize(queue);
                root.right = deserialize(queue);

                return root;
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
