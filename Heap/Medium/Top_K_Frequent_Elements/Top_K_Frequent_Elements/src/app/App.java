package app;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.PriorityQueue;

public class App {
    public static void main(String[] args) {
        run();
    }

    private static void run() {
        int[] nums = new int[] { 1, 1, 1, 2, 2, 3 };
        int k = 2;
        List<Integer> result = topKFrequent(nums, k);
    }

    /// <summary>
    /// Time Complexity: O(NlogK) where N is length of nums and K is k
    /// Space Complexity: O(N)
    /// </summary>
    private static List<Integer> topKFrequent(int[] nums, int k) {
        List<Integer> result = new ArrayList<Integer>();
        HashMap<Integer, Integer> map = new HashMap<Integer, Integer>();
        for (int num : nums) {
            if (map.containsKey(num)) {
                map.put(num, map.get(num) + 1);
            } else {
                map.put(num, 1);
            }
        }
        
        PriorityQueue<Integer> pq = new PriorityQueue<Integer>((x, y) -> map.get(x) - map.get(y));
        map.forEach((key, value) -> {
            pq.offer(key);
            if (pq.size() > k) {
                pq.poll();
            }
        });
        
        while (!pq.isEmpty() && k > 0) {
            result.add(0, pq.poll());
        }
        
        return result;
    }
}