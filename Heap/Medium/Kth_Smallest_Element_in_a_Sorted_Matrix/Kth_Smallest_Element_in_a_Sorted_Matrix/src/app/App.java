package app;

import java.util.PriorityQueue;

public class App {
    public static void main(String[] args)  {
        run();
    }

    private static void run() {
        int[][] matrix= new int[][] { 
            { 1,  5,  9 },
            { 10, 11, 13 },
            { 12, 13, 15 }
        };
        int k = 8;
        int result = kthSmallest(matrix, k);
    }

    /// <summary>
    /// Time Complexity: O(NlogK) where N is size of matrix and K is given integer k
    /// Space Complexity: O(N)
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