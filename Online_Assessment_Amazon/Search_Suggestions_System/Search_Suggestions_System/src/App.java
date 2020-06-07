import java.util.*;

public class App {
    public static void main(String[] args) {
        run();
    }

    public static void run() {
        String[] products = new String[] { "bags", "baggage", "banner", "box", "cloths" };
        String searchWord = "bags";

        List<List<String>> result = suggestedProducts(products, searchWord);
    }

    /// <summary>
    /// Time Complexity: O(NlogN + LlogN) => O((N+L)logN) where N is number of products and L is length of searchword
    /// Space Complexity: O(logN + L) => Quicksort + subList
    /// It needs to multiply L when we include string comparison in the operations
    /// </summary>
    public static List<List<String>> suggestedProducts(String[] products, String searchWord) {
        List<List<String>> result = new ArrayList<List<String>>();
        TreeMap<String, Integer> map = new TreeMap<String, Integer>();
        Arrays.sort(products); // sort by lexicographically
        List<String> productsList = Arrays.asList(products);

        for (int i = 0; i < products.length; i++) {
            map.put(products[i], i); // key: product, value: index
        }

        String keyword = "";
        for (char letter : searchWord.toCharArray()) {
            keyword += letter;
            String ceiling = map.ceilingKey(keyword); // >= keyword
            String floor = map.floorKey(keyword + "~"); // <= keyword

            if (ceiling == null || floor == null) {
                // add an empty result when there isn't any matching product
                result.add(new ArrayList<String>());
            } else {
                // add from 3 products from ceiling
                Integer from = map.get(ceiling);
                Integer to = Math.min(map.get(ceiling) + 3, map.get(floor) + 1);
                result.add(productsList.subList(from, to));
            }
        }

        return result;
    }
}
