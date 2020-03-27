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
        String[] words = new String[] { "i", "love", "leetcode", "i", "love", "coding" };
        int k = 2;
        List<String> result = topKFrequent(words, k);
    }

    /// <summary>
    /// Time Complexity: O(NlogK) where N is number of words and K is k
    /// Space Complexity: O(N)
    /// </summary>
    private static List<String> topKFrequent(String[] words, int k) {
        List<String> result = new ArrayList<String>();
        HashMap<String, Integer> map = new HashMap<String, Integer>();
        for (String word : words) {
            if (map.containsKey(word)) {
                map.put(word, map.get(word) + 1);
            } else {
                map.put(word, 1);
            }
        }
        
        PriorityQueue<String> pq = new PriorityQueue<String>((x, y) -> {
            Integer countX = map.get(x);
            Integer countY = map.get(y);
            if (countX == countY) {
                return y.compareTo(x);
            } else {
                return countX.compareTo(countY);
            }
        });

        map.forEach((key, value) -> {
            pq.offer(key);
            if (pq.size() > k)
                pq.poll();
        });
        
        for (int i = 0; i < k; i++) {
            result.add(0, pq.poll());
        }

        return result;
    }
}