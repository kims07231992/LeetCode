
namespace Convert_Sorted_List_to_Binary_Search_Tree
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
            head.next.next.next.next.next.next = new ListNode(6);

            var result = SortedListToBST(head);
        }

        /// <summary>
        /// Time Complexity: O(NlogN) where N is number of elements of linked list
        /// at level 0, work = n
        /// at level 1, work = n / 2 + n / 2 = n
        /// at level 2, work = n / 4 + n / 4 + n / 4 + n / 4 = n
        /// logN times for N
        /// Space Complexity: O(logN)
        /// </summary>
        private static TreeNode SortedListToBST(ListNode head)
        {
            if (head == null)
                return null;

            return ToBST(head, null);
        }

        private static TreeNode ToBST(ListNode head, ListNode tail)
        {
            if (head == tail)
                return null;

            var slow = head;
            var fast = head;
            while (fast != tail && fast.next != tail)
            {
                fast = fast.next.next;
                slow = slow.next;
            }

            var node = new TreeNode(slow.val);
            node.left = ToBST(head, slow);
            node.right = ToBST(slow.next, tail);
            return node;
        }

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }
    }
}
