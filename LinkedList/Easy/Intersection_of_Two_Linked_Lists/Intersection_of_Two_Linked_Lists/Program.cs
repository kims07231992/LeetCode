
namespace Intersection_of_Two_Linked_Lists
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }
        private static void Run()
        {
            var headA = new ListNode(4);
            headA.next = new ListNode(1);
            headA.next.next = new ListNode(8);
            headA.next.next.next = new ListNode(4);

            var headB = new ListNode(5);
            headB.next = new ListNode(0);
            headA.next.next = new ListNode(1);
            headA.next.next.next = headA.next;

            var result = GetIntersectionNode(headA, headB);
        }

        /// <summary>
        /// Time Complexity: O(N + M) where N is number of nodes of a and M is b
        /// Space Complexity: O(1)
        /// </summary>
        private static ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            if (headA == null || headB == null)
                return null;

            var currentA = headA;
            var currentB = headB;
            while (currentA != currentB) // if a & b have different len, then we will stop the loop after second iteration
            {
                //for the end of first iteration, we just reset the pointer to the head of another linkedlist
                currentA = currentA == null 
                    ? headB 
                    : currentA.next;
                currentB = currentB == null 
                    ? headA 
                    : currentB.next;
            }

            return currentA;
        }

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }
    }
}
