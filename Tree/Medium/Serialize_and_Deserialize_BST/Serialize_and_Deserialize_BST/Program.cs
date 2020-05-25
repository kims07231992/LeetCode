using System;
using System.Collections.Generic;
using System.Text;

namespace Serialize_and_Deserialize_BST
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var root = new TreeNode(2);
            root.left = new TreeNode(1);
            root.right = new TreeNode(3);

            var codec = new Codec();
            var serializedData = codec.serialize(root);
            var deserializedData = codec.deserialize(serializedData);
        }

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }

        public class Codec
        {
            /// <summary>
            /// Encodes a tree to a single string.
            /// Time Complexity: O(N) where N is number of nodes in BST
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

            /// <summary>
            /// Decodes your encoded data to tree.
            /// Time Complexity: O(N) where N is number of nodes in BST
            /// Space Complexity: O(N)
            /// </summary>
            public TreeNode deserialize(string data)
            {
                var queue = new Queue<string>(data.Split(""));
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
    }
}