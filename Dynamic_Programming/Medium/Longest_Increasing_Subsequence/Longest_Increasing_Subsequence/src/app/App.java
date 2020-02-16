package app;

import java.util.*;

public class App {
    public static void main(String[] args) {
        run();
    }

    private static void run()
    {
        int[] nums = { 10, 9, 2, 5, 3, 7, 101, 18};
        int result = lengthOfLIS(nums);
    }

    /// <summary>
    /// Time Complexity: O(N ^ 2) where N is length of array nums
    /// Space Complexity: O(N)
    /// </summary>
    private static int lengthOfLIS(int[] nums) {
        if (nums == null || nums.length == 0)
            return 0;

        int n = nums.length;
        int[] subsequence = new int[n];
        Arrays.fill(subsequence, 1);
        
        int max = 1;
        for (int i = 1; i < n; i++)
        {
            for (int j = 0; j < i; j++)
            {
                if (nums[j] < nums[i])
                {
                    subsequence[i] = Math.max(subsequence[i], subsequence[j] + 1);
                } 
            }
            max = Math.max(max, subsequence[i]);
        }
        
        return max;
    }
}