
namespace Merge_Sorted_Array
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var nums1 = new int[] { 1, 2, 3, 0, 0, 0 };
            var m = 3;
            var nums2 = new int[] { 2, 5, 6 };
            var n = 3;

            Merge(nums1, m, nums2, n);
        }

        /// <summary>
        /// Time Complexity: O(N + M) 
        /// Space Complexity: O(1)
        /// </summary>
        private static void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            int i = m - 1;
            int j = n - 1;
            while (i >= 0 && j >= 0)
            {
                int lastIndex = i + j + 1;
                if (nums1[i] >= nums2[j])
                {
                    nums1[lastIndex] = nums1[i--];
                }
                else
                {
                    nums1[lastIndex] = nums2[j--];
                }
            }

            while (j >= 0)
            {
                nums1[j] = nums2[j--];
            }
        }
    }
}
