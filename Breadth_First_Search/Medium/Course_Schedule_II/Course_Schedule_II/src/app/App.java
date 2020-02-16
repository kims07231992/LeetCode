package app;

import java.util.*;

public class App {
    public static void main(String[] args) {
        run();
    }

    private static void run() {
        int numCourses = 3;
        int[][] prerequisites = { { 1, 0 }, { 1, 2 }, { 0, 1 } };
        int[] result = findOrder(numCourses, prerequisites);
    }

    /// <summary>
    /// Time Complexity: O(V * E)
    /// Space Complexity: O(V)
    /// </summary>
    public static int[] findOrder(int numCourses, int[][] prerequisites) {
        if (numCourses == 0) 
            return null;

        int[] indegree = new int[numCourses];
        int[] result= new int[numCourses];
        for (int i = 0; i < prerequisites.length; i++)
            indegree[prerequisites[i][0]]++; // how many prerequisites are needed
    
        int index = 0;
        Queue<Integer> queue = new LinkedList<Integer>();
        for (int i = 0; i < numCourses; i++) 
            if (indegree[i] == 0) { // course that doesn't have prerequisite
                result[index++] = i;
                queue.offer(i);
            }
    
        while (!queue.isEmpty()) {
            int courseWithoutPrerequisite = queue.poll();
            for (int i = 0; i < prerequisites.length; i++)  {
                int course = prerequisites[i][0];
                int prerequisite = prerequisites[i][1];
                if (courseWithoutPrerequisite == prerequisite) {
                    indegree[course]--; 
                    if (indegree[course] == 0) {
                        result[index++] = course;
                        queue.offer(course);
                    }
                } 
            }
        }
    
        return index == numCourses ? result : new int[0];
    }
}