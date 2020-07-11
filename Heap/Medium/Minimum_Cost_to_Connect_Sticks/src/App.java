import java.util.PriorityQueue;

public class App {
    public static void main(String[] args) throws Exception {
        run();
    }

    private static void run() {
        int[] sticks = new int[] { 1, 8, 3, 5 };
        int result = connectSticks(sticks);
    }

    /// <summary>
    /// Time Complexity: O(NlogN) where N is number of elements in sticks 
    /// Space Complexity: O(N)
    /// </summary>
    public static int connectSticks(int[] sticks) {
        PriorityQueue<Integer> pq = new PriorityQueue<Integer>();
        for (int i = 0; i < sticks.length; i++) {
            pq.offer(sticks[i]);
        }
        
        int total = 0;
        while (pq.size() > 1) {
            Integer cost = pq.poll() + pq.poll();
            total += cost;
            pq.offer(cost);
        }
            
        return total;
    }
}
