
namespace Rotate_List
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var k = 2;
            var head = new ListNode(1);
            head.next = new ListNode(2);
            head.next.next = new ListNode(3);
            head.next.next.next = new ListNode(4);
            head.next.next.next.next = new ListNode(5);

            var result = RotateRight(head, k);
        }

        /// <summary>
        /// Time Complexity: O(N) where N is number of given nodes
        /// Space Complexity: O(1)
        /// </summary>
        private static ListNode RotateRight(ListNode head, int k)
        {
            if (head?.next == null)
                return head;

            var currentTail = head;
            var count = 1;
            while (currentTail.next != null)
            {
                currentTail = currentTail.next;
                count++;
            }

            var currentHeadBeforeIndex = count - (k % count) - 1;
            var currentHeadBefore = head;
            for (int i = 0; i < currentHeadBeforeIndex; i++)
                currentHeadBefore = currentHeadBefore.next;

            currentTail.next = head;
            var newHead = currentHeadBefore.next;
            currentHeadBefore.next = null;

            return newHead;
        }

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }
    }
}
