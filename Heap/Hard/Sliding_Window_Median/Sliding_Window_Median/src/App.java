import java.util.PriorityQueue;

public class App {
    public static void main(String[] args) {
        run();
    }

    private static void run() {
        int[] nums = new int[] { 1,3,-1,-3,5,3,6,7 };
        int k = 3;

        double[] result = medianSlidingWindow(nums, k);
    }

    /// <summary>
    /// Time Complexity: O(N*K) where N is number of elements in nums and K is given K
    /// This is not O(NlogK) since remove in PriorityQueue takes linear time
    /// Space Complexity: O(K)
    /// </summary>
    private static double[] medianSlidingWindow(int[] nums, int k) {
        int n = nums.length;
        double[] result = new double[n - k + 1];
        PriorityQueue<Integer> maxHeap = new PriorityQueue<Integer>((x, y) -> { return y.compareTo(x); });
        PriorityQueue<Integer> minHeap = new PriorityQueue<Integer>();
        for (int i = 0; i < n; i++) {           
            maxHeap.offer(nums[i]);
            minHeap.offer(maxHeap.poll());
            if (maxHeap.size() < minHeap.size())
                maxHeap.offer(minHeap.poll());
        
            int resultIndex = i - k + 1;
            if (i >= k - 1) {
                result[resultIndex] = (k & 1) == 0
                    ? (double)((long)maxHeap.peek() + (long)minHeap.peek()) / 2 // even
                    : maxHeap.peek(); // odd

                int oldNum = nums[resultIndex];
                if (maxHeap.peek() >= oldNum) {
                    maxHeap.remove(oldNum);
                } else {
                    minHeap.remove(oldNum);
                }
            }
        }
        
        return result;
    }
}
