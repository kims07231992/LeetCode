package app;

import java.util.*;

public class App {
    public static void main(String[] args) {
        run();
    }

    private static void run() {
        int numToys = 6;
        int topToys = 2;
        String[] toys = { "elmo", "elsa", "legos", "drone", "tablet", "warcraft" };
        int numQuotes = 6;
        String[] quotes = {
        "Elmo is the hottest of the season! Elmo will be on every kid's wishlist!",
        "The new Elmo dolls are super high quality",
        "Expect the Elsa dolls to be very popular this year, Elsa!",
        "Elsa and Elmo are the toys I'll be buying for my kids, Elsa is good",
        "For parents of older kids, look into buying them a drone",
        "Warcraft is slowly rising in popularity ahead of the holiday season"
        };

        List<String> result = topNBuzzwords(numToys, topToys, toys, numQuotes, quotes);
    }

    /// <summary>
    /// Time Complexity: O(Q + NlogK) where Q is number of quotes, N is number of numToys, and K is topToys
    /// Space Complexity: O(N + K)
    /// </summary>
    private static List<String> topNBuzzwords(int numToys, int topToys, String[] toys, int numQuotes, String[] quotes) {
        Map<String, int[]> freq = new HashMap<String, int[]>();
        for (String toy : toys) {
            freq.put(toy, new int[]{ 0, 0 }); // 0: total counts of frequencies  1: total counts of frequencies per quote
        }
    
        for (String quote : quotes) {
            Set<String> used = new HashSet<String>();
            String[] words = quote.toLowerCase().split(" ");
            for (String word : words) {
                if (!freq.containsKey(word)) {
                    continue;
                }

                int[] nums = freq.get(word);

                nums[0]++;
                if (!used.contains(word)) {
                    used.add(word);
                    nums[1]++;
                }
            }
        }
    
        PriorityQueue<String> pq = new PriorityQueue<>((t1, t2) -> {
            if (freq.get(t1)[0] != freq.get(t2)[0]) { // compare total counts of frequencies
                return freq.get(t1)[0] - freq.get(t2)[0];
            }

            if (freq.get(t1)[1] != freq.get(t2)[1]) { // compare total counts of frequencies per quote
                return freq.get(t1)[1] - freq.get(t2)[1];
            }

            return t2.compareTo(t1);
        });
    
        if (topToys > numToys) {
            for (String toy : freq.keySet()) {
                if (freq.get(toy)[0] > 0) { // total counts of frequencies > 0
                    pq.add(toy);
                }
            }
        } else {
            for (String toy : toys) {
                pq.add(toy);

                if (pq.size() > topToys) {
                    pq.poll();
                }
            }
        }
    
        List<String> result = new ArrayList<>();
        while (!pq.isEmpty()) {
            result.add(pq.poll());
        }
    
        Collections.reverse(result);
    
        return result;
    }
}