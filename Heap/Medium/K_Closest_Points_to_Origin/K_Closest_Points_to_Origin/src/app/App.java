package app;

import java.util.PriorityQueue;

public class App {
    public static void main(String[] args) {
        run();
    }

    private static void run() {
        int[][] points = new int[][] { { 3, 3 }, { 5, -1 }, { -2, 4 } };
        int K = 2;
        int[][] result = kClosest(points, K);
    }

    /// <summary>
    /// Time Complexity: O(NlogK) where N is size of given integer num and K is given integer K
    /// Space Complexity: O(N)
    /// </summary>
    private static int[][] kClosest(int[][] points, int K) {        
        int[][] result = new int[K][];
        PriorityQueue<int[]> pq = new PriorityQueue<int[]> // max Heap
            ((p1, p2) -> p2[0] * p2[0] + p2[1] * p2[1] - p1[0] * p1[0] - p1[1] * p1[1]);
    
        for (int i = 0; i < points.length; i++) {            
            pq.offer(points[i]);
            
            if (pq.size() > K)
                pq.poll();
        }
        
        for (int i = 0; i < K; i++) {
            result[i] = pq.poll();
        }
        
        return result;
    }
}