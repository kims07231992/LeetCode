package app;

import java.util.*;

public class App {
    public static void main(String[] args) {
        run();
    }

    private static void run() {
        int rows = 4;
        int columns = 5;
        List<List<Integer>> grid = new ArrayList<List<Integer>>();
        grid.add(Arrays.asList(0, 1, 1, 0, 1));
        grid.add(Arrays.asList(0, 1, 0, 1, 0));
        grid.add(Arrays.asList(0, 0, 0, 0, 1));
        grid.add(Arrays.asList(0, 1, 0, 0, 0));
    
        int result = minHours(rows, columns, grid);
    }

    private static int[][] directions = { { 0, 1 }, { 1, 0 }, { 0, -1 }, { -1, 0 } };

    /// <summary>
    /// Time Complexity: O(M * N) where M is size of rows and N is size of columns
    /// Space Complexity: O(M * N)
    /// </summary>
    private static int minHours(int rows, int columns, List<List<Integer>> grid) {
        Queue<int[]> queue = new LinkedList<int[]>();
        for (int m = 0; m < rows; m++) {
            for (int n = 0; n < columns; n++)
            {
                if (grid.get(m).get(n) == 1) {
                    queue.offer(new int[] { m, n });
                }
            }
        }

        if (queue.isEmpty())
            return 0;

        int hours = -1;
        while (!queue.isEmpty()) {
            int count = queue.size();
            for (int i = 0; i < count; i++) {
                int[] zombie = queue.poll();
                for (int[] direction : directions) {
                    Visit(grid, queue, zombie[0] + direction[0], zombie[1] + direction[1]);
                }
            }
            hours++;
        }

        return hours;
    } 


    private static void Visit(List<List<Integer>> grid, Queue<int[]> queue, int m, int n) {
        if (m < 0 
            || m >= grid.size() 
            || n < 0 
            || n >= grid.get(m).size() 
            || grid.get(m).get(n) == 1)
            return;

        grid.get(m).set(n, 1); // seen
        queue.offer(new int[] { m, n });
    }
}