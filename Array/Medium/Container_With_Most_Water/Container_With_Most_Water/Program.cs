using System;

namespace Container_With_Most_Water
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var height = new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 };
            var result = MaxArea(height);
        }

        /// <summary>
        /// Time Complexity: O(N) where N is length of heights
        /// Space Complexity: O(1)
        /// </summary>
        private static int MaxArea(int[] height)
        {
            if (height == null || height.Length < 2)
                return 0;

            int area = 0;
            int left = 0;
            int right = height.Length - 1;
            while (left < right)
            {
                area = Math.Max(area, (right - left) * Math.Min(height[left], height[right]));
                if (height[left] < height[right])
                {
                    left++;
                }
                else
                {
                    right--;
                }
            }

            return area;
        }
    }
}
