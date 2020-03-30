using System;

namespace Remove_Nth_Node_From_End_of_List
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var n = 2;
            var head = new ListNode(1);
            head.next = new ListNode(2);
            head.next.next = new ListNode(3);
            head.next.next.next = new ListNode(4);
            head.next.next.next.next = new ListNode(5);

            var result = RemoveNthFromEnd(head, n);
        }

        /// <summary>
        /// Time Complexity: O(N) where N is number of nodes
        /// Space Complexity: O(1)
        /// </summary>
        private static ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            var p1 = head;
            var p2 = head;

            while (p1.next != null)
            {
                p1 = p1.next;
                n--;

                if (n < 0)
                    p2 = p2.next;
            }

            if (n == 1)
                return head.next;
            else
                p2.next = p2.next.next;

            return head;
        }

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }
    }
}
