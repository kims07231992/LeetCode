
namespace Merge_Two_Sorted_Lists
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var l1 = new ListNode(1);
            l1.next = new ListNode(2);
            l1.next.next = new ListNode(4);

            var l2 = new ListNode(1);
            l2.next = new ListNode(3);
            l2.next.next = new ListNode(4);

            var result = MergeTwoLists(l1, l2);
        }

        /// <summary>
        /// Time Complexity: O(N + M) where N is length of l1 M is length of l2
        /// Space Complexity: O(1)
        /// </summary>
        private static ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            var dummy = new ListNode(0);
            var current = dummy;
            while (l1 != null && l2 != null)
            {
                if (l1.val <= l2.val)
                {
                    current.next = l1;
                    l1 = l1.next;
                }
                else
                {
                    current.next = l2;
                    l2 = l2.next;
                }
                current = current.next;
            }
            current.next = l1 != null ? l1 : l2;

            return dummy.next;
        }

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }
    }
}
