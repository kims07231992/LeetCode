package app;

import java.util.*;

public class App {
    public static void main(String[] args) {
        int k = 2;
        String[] keywords = { "anacell", "betacellular", "cetracular", "deltacellular", "eurocell" };
        String[] reviews = { "I love anacell Best services; Best services provided by anacell",
                "betacellular has great services", "deltacellular provides much better services than betacellular",
                "cetracular is worse than anacell", "Betacellular is better than deltacellular.", };

        List<String> result = solve(k, keywords, reviews);
    }

    /// <summary>
    /// Time Complexity: O(N + MlogK) where N is number of keywords and M is number of words in reivews and K is k
    /// Space Complexity: O(N)
    /// </summary>
    private static List<String> solve(int k, String[] keywords, String[] reviews) {
        List<String> result = new ArrayList<String>();
        HashSet<String> keywordSet = new HashSet<String>();
        HashMap<String, Integer> reviewMap = new HashMap<String, Integer>();

        for (String keyword : keywords) {
            keywordSet.add(keyword);
        }

        for (String review : reviews) {
            String[] words = review.split(" ");
            HashSet<String> wordSet = new HashSet<String>();
            for (String word : words) {
                word = word.toLowerCase();
                if (keywordSet.contains(word) && !wordSet.contains(word)) {
                    if (reviewMap.containsKey(word)) {
                        reviewMap.put(word, reviewMap.get(word) + 1);
                    } else {
                        reviewMap.put(word, 1);
                    }
                    wordSet.add(word);
                }
            }
        }

        PriorityQueue<String> pq = new PriorityQueue<String>((x, y) -> {
            Integer xCount = reviewMap.get(x);
            Integer yCount = reviewMap.get(y);

            if (xCount != yCount)
                return  xCount - yCount;
            else
                return y.compareTo(x);
        });

        reviewMap.forEach((key, value) -> {
            pq.offer(key);
            if (pq.size() > k)
                pq.poll();
        });

        while (!pq.isEmpty())
            result.add(0, pq.poll());

        return result;
    }
}