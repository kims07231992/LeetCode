
namespace Swap_Nodes_in_Pairs
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var head = new ListNode(1);
            head.next = new ListNode(2);
            head.next.next = new ListNode(3);
            head.next.next.next = new ListNode(4);

            var result = SwapPairs(head);
        }

        /// <summary>
        /// Time Complexity: O(N) where N is length of nodes
        /// Space Complexity => X
        /// </summary>
        private static ListNode SwapPairs(ListNode head)
        {
            var result = head?.next == null
                ? head
                : head.next;

            var current = head;
            while (current?.next != null)
            {
                var temp = current.next;
                current.next = current.next.next;
                temp.next = current;

                current = current.next; // move pointer

                // link previous node to swapped node
                if (current?.next != null)
                    temp.next.next = current.next;
            }

            return result;
        }

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }
    }
}
