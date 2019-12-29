
namespace Split_Linked_List_in_Parts
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var root = new ListNode(1);
            root.next = new ListNode(2);
            root.next.next = new ListNode(3);
            root.next.next.next = new ListNode(4);
            root.next.next.next.next = new ListNode(5);
            var k = 3;

            var result = splitListToParts(root, k);
        }

        /// <summary>
        /// Time Complexity: O(N) where N is length of nodes
        /// Space Complexity => X
        /// </summary>
        private static ListNode[] splitListToParts(ListNode root, int k)
        {
            var parts = new ListNode[k];
            int count = 0;

            var current = root;
            while (current != null)
            {
                count++;
                current = current.next;
            }

            int quotient = count / k, remainder = count % k;
            ListNode node = root, previous = null;
            for (int i = 0; node != null && i < k; i++, remainder--)
            {
                parts[i] = node;
                for (int j = 0; j < quotient + (remainder > 0 ? 1 : 0); j++)
                {
                    previous = node;
                    node = node.next;
                }
                previous.next = null;
            }

            return parts;
        }

        private class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }
    }
}
