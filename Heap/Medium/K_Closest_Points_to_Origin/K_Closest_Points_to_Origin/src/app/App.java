package app;

import java.util.PriorityQueue;

public class App {
    public static void main(String[] args) {
        run();
    }

    private static void run() {
        int[][] matrix = new int[][] { { 3, 3 }, { 5, -1 }, { -2, 4 } };
        int K = 2;
        int result = kthSmallest(matrix, K);
    }

    /// <summary>
    /// Time Complexity: O(NlogZ) where Z is Min(N, K)
    /// Space Complexity: O(K)
    /// </summary>
    private static int kthSmallest(int[][] matrix, int k) {
        int n = matrix.length;
        PriorityQueue<Integer> pq = new PriorityQueue<Integer>((x, y) -> y - x);
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < Math.min(n, k); j++) {
                pq.offer(matrix[i][j]);
                
                if (pq.size() > k)
                    pq.poll();
            }
        }
        
        return pq.peek();
    }
}