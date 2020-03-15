using System;

namespace Trapping_Rain_Water
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var height = new int[] { 0, 1, 2, 0 };
            var result = Trap(height);
        }

        /// <summary>
        /// Time Complexity: O(N) where N is number of elements in height
        /// Space Complexity: O(1)
        /// </summary>
        private static int Trap(int[] height)
        {
            if (height == null || height.Length == 0)
                return 0;

            int water = 0;
            int leftMax = int.MinValue;
            int rightMax = int.MinValue;
            int leftIndex = 0;
            int rightIndex = height.Length - 1;
            while (leftIndex <= rightIndex)
            {
                leftMax = Math.Max(leftMax, height[leftIndex]);
                rightMax = Math.Max(rightMax, height[rightIndex]);
                if (leftMax < rightMax) // right side standard case
                {
                    water += leftMax - height[leftIndex]; // area = left wall - current wall
                    leftIndex++;
                }
                else // left side standard case
                {
                    water += rightMax - height[rightIndex]; // area = right wall - current wall
                    rightIndex--;
                }
            }

            return water;
        }
    }
}
