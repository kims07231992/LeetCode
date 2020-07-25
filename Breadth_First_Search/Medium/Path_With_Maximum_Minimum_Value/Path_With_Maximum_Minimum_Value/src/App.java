import java.util.PriorityQueue;

public class App {
    public static void main(String[] args) {
        run();
    }

    private static void run() {
        int[][] A = new int[][] {
            new int[] { 5,4,5 },
            new int[] { 1,2,6 },
            new int[] { 7,4,6 }
        };
        int result = maximumMinimumPath(A);
    }

    /// <summary>
    /// Time Complexity: O(N*MlogN*M) where N is number of rows and M is number of columns
    /// Space Complexity: O(N*M) 
    /// </summary>
    private static int maximumMinimumPath(int[][] A) {
        int rows = A.length;
        int cols = A[0].length;
        boolean[][] visited = new boolean[rows][cols];
        PriorityQueue<int[]> pq = new PriorityQueue<int[]>((x, y) -> { return A[y[0]][y[1]] - A[x[0]][x[1]]; });
        pq.offer(new int[] { 0, 0 });
        int[][] dirs = new int[][] {
            new int[] { 0, 1 },
            new int[] { 1, 0 },
            new int[] { 0, -1 },
            new int[] { -1, 0 }
        };
        int min = A[0][0];
        while (!pq.isEmpty()) {
            int size = pq.size();
            for (int i = 0; i < size; i++) {
                int[] current = pq.poll();
                min = Math.min(min, A[current[0]][current[1]]);
                visited[current[0]][current[1]] = true; // visited

                // endpoint check
                if (current[0] == rows - 1 
                    && current[1] == cols - 1)
                    return min;
                
                for (int[] dir : dirs) {
                    int[] next = new int[] { current[0] + dir[0], current[1] + dir[1] };
                    if (next[0] < 0 || next[0] >= rows  // row boundary check
                        || next[1] < 0|| next[1] >= cols // col boundary check
                        || visited[next[0]][next[1]]) // already visited
                        continue;
                    
                    pq.offer(next);
                }
            }
        }
        
        return 0;
    }
}
