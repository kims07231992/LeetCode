package app;

import java.util.PriorityQueue;

public class App {
    public static void main(String[] args) {
        run();
    }

    private static void run() {
        int[] nums = new int[] { 3,2,3,1,2,4,5,5,6 };
        int k = 2;
        int result = findKthLargest(nums, k);
    }

    /// <summary>
    /// Time Complexity: O(NlogK) where N is size of nums and K is k
    /// Space Complexity: O(K)
    /// </summary>
    private static int findKthLargest(int[] nums, int k) {
        PriorityQueue<Integer> pq = new PriorityQueue<Integer>();

        for (int i = 0; i < nums.length; i++) {            
            pq.offer(nums[i]);
            
            if (pq.size() > k)
                pq.poll();
        }
        
        return pq.peek();
    }
}