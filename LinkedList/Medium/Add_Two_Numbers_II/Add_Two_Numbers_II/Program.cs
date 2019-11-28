using System.Collections.Generic;

namespace Add_Two_Numbers_II
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var l1 = new ListNode(7);
            l1.next = new ListNode(2);
            l1.next.next = new ListNode(4);
            l1.next.next.next = new ListNode(7);

            var l2 = new ListNode(5);
            l2.next = new ListNode(6);
            l2.next.next = new ListNode(4);

            var result = AddTwoNumbers(l1, l2);
        }

        private static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            var s1 = new Stack<int>();
            var s2 = new Stack<int>();

            while (l1 != null)
            {
                s1.Push(l1.val);
                l1 = l1.next;
            };
            while (l2 != null)
            {
                s2.Push(l2.val);
                l2 = l2.next;
            }

            int sum = 0;
            ListNode tail = new ListNode(0);
            while (s1.Count != 0 || s2.Count != 0)
            {
                if (s1.Count != 0)
                    sum += s1.Pop();
                if (s2.Count != 0)
                    sum += s2.Pop();
                tail.val = sum % 10;
                var head = new ListNode(sum / 10);
                head.next = tail;
                tail = head;
                sum /= 10;
            }

            return tail.val == 0 ? tail.next : tail;
        }

        private class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }
    }
}
