using System;

namespace Median_of_Two_Sorted_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var nums1 = new int[] { 1, 2 };
            var nums2 = new int[] { 3, 4 };

            var result = FindMedianSortedArrays(nums1, nums2);
        }

        public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            var mergedNum = new int[nums1.Length + nums2.Length];
            Array.Copy(nums1, 0, mergedNum, 0, nums1.Length);
            Array.Copy(nums2, 0, mergedNum, nums1.Length, nums2.Length);

            MergeSort(mergedNum, new int[mergedNum.Length], 0, mergedNum.Length - 1);

            bool isEven = (mergedNum.Length & 1) == 0;
            if (isEven)
            {
                int medianIndex = mergedNum.Length / 2 - 1;
                return (double)(mergedNum[medianIndex] + mergedNum[medianIndex + 1]) / 2;
            }
            else
            {
                int medianIndex = mergedNum.Length / 2;
                return mergedNum[medianIndex];
            }
        }

        private static void MergeSort(int[] array, int[] temp, int leftStart, int rightEnd)
        {
            if (leftStart >= rightEnd)
                return;

            int middle = (leftStart + rightEnd) / 2;
            MergeSort(array, temp, leftStart, middle);
            MergeSort(array, temp, middle + 1, rightEnd);
            MergeHalves(array, temp, leftStart, rightEnd);
        }

        private static void MergeHalves(int[] array, int[] temp, int leftStart, int rightEnd)
        {
            int leftEnd = (rightEnd + leftStart) / 2;
            int rightStart = leftEnd + 1;
            int size = rightEnd - leftStart + 1;

            int left = leftStart;
            int right = rightStart;
            int index = leftStart;

            while (left <= leftEnd && right <= rightEnd)
            {
                if (array[left] <= array[right])
                {
                    temp[index] = array[left];
                    left++;
                }
                else
                {
                    temp[index] = array[right];
                    right++;
                }
                index++;
            }

            Array.Copy(array, left, temp, index, leftEnd - left + 1);
            Array.Copy(array, right, temp, index, rightEnd - right + 1);
            Array.Copy(temp, leftStart, array, leftStart, size);
        }
    }
}
