
namespace Add_Two_Numbers
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
            l1.next = new ListNode(8);

            var l2 = new ListNode(0);

            var result = AddTwoNumbers(l1, l2);
        }

        /// <summary>
        /// Time Complexity: O(M + N) where M is length of l1 and N is length of l2
        /// Space Complexity: O(M + N)
        /// </summary>
        private static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            var dummy = new ListNode(0);
            var current = dummy;
            var sum = 0;

            while (l1 != null || l2 != null)
            {
                if (l1 != null)
                {
                    sum += l1.val;
                    l1 = l1.next;
                }

                if (l2 != null)
                {
                    sum += l2.val;
                    l2 = l2.next;
                }

                current.next = new ListNode(sum % 10);
                current = current.next;
                sum /= 10;
            }

            if (sum > 0)
                current.next = new ListNode(1);

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
