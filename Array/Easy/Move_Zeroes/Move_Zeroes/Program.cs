
namespace Move_Zeroes
{

    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var nums = new int[] { 0, 1, 0, 3, 12 };
            MoveZeroes(nums);
        }

        /// <summary>
        /// Time Complexity: O(N) where N is length of nums
        /// Space Complexity: O(1)
        /// </summary>
        private static void MoveZeroes(int[] nums)
        {

            int spaceCount = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != 0)
                    nums[spaceCount++] = nums[i];
            }

            for (int j = spaceCount; j < nums.Length; j++)
            {
                nums[j] = 0;
            }
        }
    }
}
