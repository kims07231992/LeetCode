import java.util.PriorityQueue;

public class App {
    public static void main(String[] args) {
        run();
    }

    public static void run() {
        MedianFinder medianFinder = new MedianFinder();
        medianFinder.addNum(1);
        medianFinder.addNum(2);
        medianFinder.findMedian(); // 1.5
        medianFinder.addNum(3);
        medianFinder.findMedian(); // 2.0
    }

    public static class MedianFinder {
        private PriorityQueue<Integer> minHeap;
        private PriorityQueue<Integer> maxHeap;
        
        public MedianFinder() {
            minHeap = new PriorityQueue<Integer>();
            maxHeap = new PriorityQueue<Integer>((x, y) -> { return y - x; });
        }
        
        /// <summary>
        /// Time Complexity: O(logN) where N is number of total elements in heaps
        /// </summary>
        public void addNum(int num) {
            minHeap.offer(num);
            maxHeap.offer(minHeap.poll());
            if (minHeap.size() < maxHeap.size()) { // odd
                minHeap.offer(maxHeap.poll());
            }
        }
        
        /// <summary>
        /// Time Complexity: O(1)
        /// </summary>
        public double findMedian() {
            return minHeap.size() > maxHeap.size()
                ? minHeap.peek() // odd
                : (double)(minHeap.peek() + maxHeap.peek()) / 2; // even
        }
    }
}
