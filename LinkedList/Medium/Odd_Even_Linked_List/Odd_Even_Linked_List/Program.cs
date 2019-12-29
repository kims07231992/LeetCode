
namespace Odd_Even_Linked_List
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var head = new ListNode(0);
            head.next = new ListNode(1);
            head.next.next = new ListNode(2);
            head.next.next.next = new ListNode(3);
            head.next.next.next.next = new ListNode(4);
            head.next.next.next.next.next = new ListNode(5);

            var result = OddEvenList(head);
        }

        /// <summary>
        /// Time Complexity: O(N) => where N is number of nodes
        /// Space Complexity: O(0) => algorithm doesn't creat any new node
        /// </summary>
        private static ListNode OddEvenList(ListNode head)
        {
            if (head == null)
                return null;

            var oddNode = head;
            var evenNode = head.next;
            var evenNodeHead = evenNode;
            while (evenNode != null && evenNode.next != null)
            {
                oddNode.next = oddNode.next.next;
                evenNode.next = evenNode.next.next;
                oddNode = oddNode.next;
                evenNode = evenNode.next;
            }
            oddNode.next = evenNodeHead;

            return head;
        }

        private class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }
    }
}
