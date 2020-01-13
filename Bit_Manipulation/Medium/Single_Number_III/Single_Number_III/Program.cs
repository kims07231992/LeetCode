
namespace Single_Number_III
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var nums = new int[] { 1, 2, 1, 3, 2, 5 };
            var result = SingleNumber(nums);
        }

        /// <summary>
        /// Time Complexity: O(N) where N is size of given array nums
        /// Space Complexity: O(1)
        /// </summary>
        private static int[] SingleNumber(int[] nums)
        {
            int diff = 0;
            foreach (int num in nums)
            {
                diff ^= num; // only unrepeated a, b will be remained
            }

            diff &= -diff; // get its last set bit

            var result = new int[2];
            foreach (int num in nums)
            {
                if ((num & diff) == 0)
                {
                    result[0] ^= num;
                }
                else
                {
                    result[1] ^= num;
                }
            }

            return result;
        }
    }
}
