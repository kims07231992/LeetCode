using System;

namespace Compare_Version_Numbers
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var version1 = "01";
            var version2 = "1";
            var result = CompareVersion(version1, version2);
        }

        /// <summary>
        /// Time Complexity: O(N) where N is version that has more digits
        /// Space Complexity: O(N+M) where N number of digits in version1 and M is number of digits in version2
        /// </summary>
        private static int CompareVersion(string version1, string version2)
        {
            var v1 = version1.Split(".");
            var v2 = version2.Split(".");
            var length = Math.Min(v1.Length, v2.Length);
            for (int i = 0; i < length; i++)
            {
                var num1 = i < v1.Length ? Convert.ToInt32(v1[i]) : 0;
                var num2 = i < v2.Length ? Convert.ToInt32(v2[i]) : 0;
                var compare = num1.CompareTo(num2);
                if (compare != 0)
                    return compare;
            }

            return 0;
        }
    }
}
