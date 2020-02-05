
namespace Populating_Next_Right_Pointers
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }
        
        private static void Run()
        {
            var root = new Node(1);
            root.left = new Node(2);
            root.right = new Node(3);

            var result = Connect(root);
        }

        private static Node Connect(Node root)
        {
            RecursiveConnect(root);

            return root;
        }

        /// <summary>
        /// Time Complexity: O(N) where N is number of elements of given tree
        /// Space Complexity: O(logN)
        /// </summary>
        private static void RecursiveConnect(Node node)
        {
            // given that tree is perfect binary tree,
            // it only requires to check parent and one child
            if (node?.left == null)
                return;

            node.left.next = node.right;
            node.right.next = node.next?.left;

            RecursiveConnect(node.left);
            RecursiveConnect(node.right);
        }

        public class Node
        {
            public int val;
            public Node left;
            public Node right;
            public Node next;

            public Node() { }

            public Node(int _val)
            {
                val = _val;
            }

            public Node(int _val, Node _left, Node _right, Node _next)
            {
                val = _val;
                left = _left;
                right = _right;
                next = _next;
            }
        }
    }
}
