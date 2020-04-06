
namespace Palindrome_Linked_List
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
            head.next.next.next = new ListNode(3);
            head.next.next.next.next = new ListNode(2);
            head.next.next.next.next.next = new ListNode(1);

            var result = IsPalindrome(head);
        }

        /// <summary>
        /// Time Complexity: O(N) where N is number of nodes
        /// Space Complexity: O(1)
        /// </summary>
        private static bool IsPalindrome(ListNode head)
        {
            var fast = head;
            var slow = head;
            while (fast?.next != null)
            {
                fast = fast.next.next;
                slow = slow.next;
            }

            if (fast != null) // odd nodes: let right half smaller
            {
                slow = slow.next;
            }

            ListNode prev = null;
            while (slow != null)
            {
                var next = slow.next;
                slow.next = prev;
                prev = slow;
                slow = next;
            }
            slow = prev;
            fast = head;

            while (slow != null)
            {
                if (fast.val != slow.val)
                    return false;

                fast = fast.next;
                slow = slow.next;
            }

            return true;
        }

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }
    }
}
