
namespace Copy_List_with_Random_Pointer
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            // [[7,null],[13,0],[11,4],[10,2],[1,0]]
            var head = new Node(7);
            head.next = new Node(13);
            head.next.next = new Node(11);
            head.next.next.next = new Node(10);
            head.next.next.next.next = new Node(1);
            head.random = null;
            head.next.random = head;
            head.next.next.random = head.next.next.next.next;
            head.next.next.next.random = head.next.next;
            head.next.next.next.next.random = head;

            var result = CopyRandomList(head);
        }

        /// <summary>
        /// Time Complexity: O(N) where N is number of nodes
        /// Space Complexity: O(N)
        /// </summary>
        public static Node CopyRandomList(Node head)
        {
            if (head == null)
                return null;

            var current = head;
            while (current != null)
            {
                var next = current.next;
                var copy = new Node(current.val);
                copy.next = next;
                current.next = copy;
                current = next;
            }

            current = head;
            while (current != null)
            {
                current.next.random = current.random?.next;
                current = current.next.next;
            }

            current = head;
            var copyDummy = new Node(0);
            var copyCurrent = copyDummy;
            while (current != null)
            {
                var next = current.next.next;
                var copy = current.next;
                copyCurrent.next = copy;
                copyCurrent = copy;

                current.next = next;

                current = next;
            }

            return copyDummy.next;
        }

        public class Node
        {
            public int val;
            public Node next;
            public Node random;

            public Node(int _val)
            {
                val = _val;
                next = null;
                random = null;
            }
        }
    }
}
