package app;

import java.util.Arrays;
import java.util.PriorityQueue;

public class App {
    public static void main(String[] args) {
        run();
    }

    private static void run() {
        int[][] intervals = new int[][] { { 0, 30 }, { 5, 10 }, { 15, 20 } };
        int result = minMeetingRooms(intervals);
    }

    /// <summary>
    /// Time Complexity: O(NlogN) where N is length of intervals
    /// Space Complexity: O(N)
    /// </summary>
    private static int minMeetingRooms(int[][] intervals) {
        if (intervals == null || intervals.length == 0)
            return 0;
        
        Arrays.sort(intervals, (x, y) -> x[0] - y[0]);
        
        PriorityQueue<int[]> pq = new PriorityQueue<int[]>((x, y) -> x[1] - y[1]);
        pq.offer(intervals[0]);
        
        for (int i = 1; i < intervals.length; i++) {
            int[] interval = pq.poll();
            
            if (interval[1] <= intervals[i][0]) {
                interval[1] = intervals[i][1];
            } else {
                pq.offer(intervals[i]);
            }
            
            pq.offer(interval);
        }
        
        return pq.size();
    }
}