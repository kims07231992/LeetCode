package app;

import java.util.ArrayList;
import java.util.PriorityQueue;

public class App {
    public static void main(String[] args) {
        run();
    }

    private static void run() {
        ArrayList<int[]> a = new ArrayList<int[]>();
        a.add(new int[] { 1, 3 });
        a.add(new int[] { 2, 5 });
        a.add(new int[] { 3, 7 });
        a.add(new int[] { 4, 10 });
        ArrayList<int[]> b = new ArrayList<int[]>();
        b.add(new int[] { 1, 2 });
        b.add(new int[] { 2, 3 });
        b.add(new int[] { 3, 4 });
        b.add(new int[] { 4, 5 });
        int target = 10;

        ArrayList<int[]> result = optimalUtilization(a, b, target);
    }

    /// <summary>
    /// Time Complexity: O(M*NlogM*N) where M is length of a and b N is length of b
    /// Space Complexity: O(M*N)
    /// </summary>
    private static ArrayList<int[]> optimalUtilization(ArrayList<int[]> a, ArrayList<int[]> b, int target) {
        ArrayList<int[]> result = new ArrayList<int[]>();
        
        if (a == null || a.size()== 0)
            return result;
        if (b == null || b.size() == 0)
            return result;

        PriorityQueue<Tuple> pq = new PriorityQueue<Tuple>((x, y) -> y.value - x.value);
        for (int[] elementA : a) {
            for (int[] elementB : b) {
                int valueA = elementA[1];
                int valueB = elementB[1];
                if (valueA + valueB <= target) {
                    pq.offer(new Tuple(valueA + valueB, elementA[0], elementB[0]));
                }
            }
        }

        if (pq.size() == 0 )
            return result;

        int opt = pq.peek().value;
        while (!pq.isEmpty()) {
            Tuple temp = pq.poll();
            if (temp.value == opt)
                result.add(temp.keys);
        }

        return result;
    }

    public static class Tuple
    {
        public int value;
        public int[] keys;

        public Tuple(int value, int key1, int key2) {
            this.value = value;
            this.keys = new int[] { key1, key2 };
        }
    }
}