
namespace XOR_Queries_of_a_Subarray
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var arr = new int[] { 1, 3, 4, 8 };
            var queries = new int[arr.Length][];
            queries[0] = new int[] { 0, 1 };
            queries[1] = new int[] { 1, 2 };
            queries[2] = new int[] { 0, 3 };
            queries[3] = new int[] { 3, 3 };

            var result = XorQueries(arr, queries);
        }

        /// <summary>
        /// Time Complexity: O(N + M) where N is length of given array queries and M is length of given array arr
        /// Space Complexity: O(M)
        /// </summary>
        private static int[] XorQueries(int[] arr, int[][] queries)
        {
            var n = arr.Length;
            for (int i = 1; i < n; i++)
                arr[i] = arr[i - 1] ^ arr[i];

            var m = queries.Length;
            var result = new int[m];
            for (int i = 0; i < m; i++)
            {
                int leftIndex = queries[i][0];
                int rightIndex = queries[i][1];
                result[i] = leftIndex == 0 // start from zero index case
                    ? arr[rightIndex] 
                    : arr[leftIndex - 1] ^ arr[rightIndex]; // applying xor doulbe times returns original value
            }

            return result;
        }
    }
}
