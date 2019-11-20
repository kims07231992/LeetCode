using System.Collections.Generic;

namespace Pancake_Sorting
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var input = new int[] { 3, 2, 4, 1 };
            var output = PancakeSort(input);
        }
            
        private static IList<int> PancakeSort(int[] A)
        {
            var result = new List<int>();
            for (int key = A.Length; key > 0; key--)
            {
                for (int index = key - 1; index >= 0; index--)
                {
                    if (key == A[index])
                    {
                        Reverse(A, index);
                        result.Add(index + 1);
                        Reverse(A, key - 1);
                        result.Add(key);
                    }
                }
            }

            return result;
        }

        private static void Reverse(int[] A, int k)
        {
            for (int i = 0, j = k; i < j; i++, j--)
            {
                int temp = A[i];
                A[i] = A[j];
                A[j] = temp;
            }
        }
    }
}
