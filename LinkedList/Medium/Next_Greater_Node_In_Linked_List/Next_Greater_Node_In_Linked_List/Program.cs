using System.Collections.Generic;

namespace Next_Greater_Node_In_Linked_List
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var head = new ListNode(2);
            head.next = new ListNode(1);
            head.next.next = new ListNode(5);
            head.next.next.next = new ListNode(6);

            var result = NextLargerNodes(head);
        }

        private static int[] NextLargerNodes(ListNode head)
        {
            // Transform the linked list to a list 
            var array = new List<int>();
            for (var node = head; node != null; node = node.next)
                array.Add(node.val);

            var result = new int[array.Count];
            var stack = new Stack<int>();

            for (int i = 0; i < array.Count; i++)
            {
                while (stack.Count != 0 && array[stack.Peek()] < array[i])
                    result[stack.Pop()] = array[i];
                stack.Push(i);
            }
            return result;
        }

        private class ListNode
        {
            public int val { get; set; }
            public ListNode next { get; set; }
            public ListNode(int x) { val = x; }
        }
    }
}
