
namespace Linked_List_Cycle
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }
        private static void Run()
        {
            var head = new ListNode(3);
            head.next = new ListNode(2);
            head.next.next = new ListNode(0);
            head.next.next.next = new ListNode(-4);
            head.next.next.next.next = head.next;

            var result = HasCycle(head);
        }

        /// <summary>
        /// Time Complexity: O(N) where N is number of nodes
        /// Space Complexity: O(1)
        /// </summary>
        private static bool HasCycle(ListNode head)
        {
            var current = head;
            var visited = new ListNode(0);
            while (current != null // reach to tail
                && current != visited) // visited
            {
                var prev = current;
                current = current.next;
                prev.next = visited; // disconnect
            }

            return current == visited;
        }

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x)
            {
                val = x;
                next = null;
            }
        }
    }
}
