
namespace Rectangle_Overlap
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }
        private static void Run()
        {
            var rec1 = new int[] { 0, 0, 2, 2 };
            var rec2 = new int[] { 1, 1, 3, 3 };
            var result = IsRectangleOverlap(rec1, rec2);
        }

        /// <summary>
        /// Time Complexity: O(1)
        /// Space Complexity: O(1)
        /// </summary>
        private static bool IsRectangleOverlap(int[] rec1, int[] rec2)
        {
            return rec1[0] < rec2[2]
                && rec1[2] > rec2[0]
                && rec1[1] < rec2[3]
                && rec1[3] > rec2[1];
        }
    }
}
