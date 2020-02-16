package app;

import java.util.*;

public class App {
    public static void main(String[] args) {
        run();
    }

    private static void run()
    {
        int numCourses = 5;
        int[][] prerequisites = { { 1, 0 }, { 2, 1 }, { 3, 2 }, { 4, 3 } };
        boolean result = canFinish(numCourses, prerequisites);
    }

    /// <summary>
    /// Time Complexity: O(V^2)
    /// Space Complexity: O(E + V)
    /// </summary>
    private static boolean canFinish(int numCourses, int[][] prerequisites) {
        int[][] matrix = new int[numCourses][numCourses]; // i -> j
        int[] indegree = new int[numCourses];
        
        for (int i = 0; i < prerequisites.length; i++) {
            int course = prerequisites[i][0];
            int prerequisite = prerequisites[i][1];
            if (matrix[prerequisite][course] == 0) // check duplicate case
                indegree[course]++;
            matrix[prerequisite][course] = 1;
        }
        
        Queue<Integer> queue = new LinkedList();
        for (int i=0; i< indegree.length; i++) {
            if (indegree[i] == 0) // course without prerequisite
                queue.offer(i);
        }
        
        int count = 0;
        while (!queue.isEmpty()) {
            int course = queue.poll();
            count++;
            for (int i=0; i < numCourses; i++) {
                if (matrix[course][i] != 0) { // course -> i relationship
                    if (--indegree[i] == 0) // prerequisite fulfilled course
                        queue.offer(i);
                }
            }
        }

        return count == numCourses;
    }
}