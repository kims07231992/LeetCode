package app;

import java.util.PriorityQueue;

public class App {
    public static void main(String[] args) {
        run();
    }

    private static void run () {
        //[[1,4,5],[1,3,4],[2,6]]
        ListNode first = new ListNode(1);
        first.next = new ListNode(4);
        first.next.next = new ListNode(5);

        ListNode second = new ListNode(1);
        second.next = new ListNode(3);
        second.next.next = new ListNode(4);

        ListNode third = new ListNode(2);
        third.next = new ListNode(6);

        ListNode[] lists = new ListNode[] {
            first, second, third
        };

        ListNode result = mergeKLists(lists);
    }

    /// <summary>
    /// Time Complexity: O(NlogK) where N is total elements of given ListNode array lists and K is length of lists
    /// Space Complexity: O(K)
    /// </summary>
    private static ListNode mergeKLists(ListNode[] lists) {
        if (lists == null)
            return null;
        
        PriorityQueue<ListNode> pq = new PriorityQueue<ListNode>((x, y) -> x.val - y.val);
        for (int i = 0; i < lists.length; i++) {
            if (lists[i] != null)
                pq.offer(lists[i]);
        }
        
        if (pq.isEmpty())
            return null;
        
        ListNode head = pq.poll();
        ListNode current = head;
        while (!pq.isEmpty()) {
            if (current.next != null && current.next.val <= pq.peek().val) {
                current = current.next;
            } else {
                if (current.next != null)
                    pq.offer(current.next);

                current.next = pq.poll();
                current = current.next;
            }
        }

        return head;
    }

    public static class ListNode {
        int val;
        ListNode next;
        ListNode(int x) { val = x; }
    }
}