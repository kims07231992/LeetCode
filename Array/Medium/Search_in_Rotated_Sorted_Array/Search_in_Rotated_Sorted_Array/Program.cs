
namespace Search_in_Rotated_Sorted_Array
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var nums = new int[] { 4, 5, 6, 7, 0, 1, 2 };
            var target = 3;
            var result = Search(nums, target);
        }

        /// <summary>
        /// Time Complexity: O(logN) where N is length of nums
        /// Space Complexity: O(1)
        /// </summary>
        private static int Search(int[] nums, int target)
        {
            int left = 0;
            int right = nums.Length - 1;
            while (left < right)
            {
                int middle = (left + right) / 2;
                if (nums[middle] > nums[right])
                    left = middle + 1;
                else
                    right = middle;
            }

            int pad = left;
            left = 0;
            right = nums.Length - 1;
            while (left <= right)
            {
                int middle = (left + right) / 2;
                int actualMiddle = (middle + pad) % nums.Length;
                if (nums[actualMiddle] == target)
                    return actualMiddle;

                if (nums[actualMiddle] < target)
                    left = middle + 1;
                else
                    right = middle - 1;
            }

            return -1;
        }
    }
}
