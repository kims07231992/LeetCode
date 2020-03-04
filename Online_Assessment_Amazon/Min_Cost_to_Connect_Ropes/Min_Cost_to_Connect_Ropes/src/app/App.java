package app;

import java.util.PriorityQueue;

public class App {
    public static void main(String[] args) {
        run();
    }

    private static void run() {
        int[] ropes = new int[] { 20, 4, 8, 2 };
        int result = MinCostToConnectRopes(ropes);
    }

    /// <summary>
    /// Time Complexity: O(NlogN) where N is number of ropes
    /// Space Complexity: O(N)
    /// </summary>
    private static int MinCostToConnectRopes(int[] ropes) {
        if (ropes == null)
            return 0;

        PriorityQueue<Integer> pq = new PriorityQueue<Integer>();
        for (int i = 0; i < ropes.length; i++) {
            pq.offer(ropes[i]);
        }

        int cost = 0;
        while (pq.size() > 1) {
            int temp = pq.poll() + pq.poll();
            cost += temp;
            pq.offer(temp);
        }

        return cost;
    }
}