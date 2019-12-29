using System;
using System.Collections.Generic;
using System.Linq;

namespace Group_the_People_Given_the_Group_Size
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var groupSizes = new int[] { 3, 3, 3, 3, 3, 1, 3 };
            var result = GroupThePeople(groupSizes);
        }

        /// <summary>
        /// Time Complexity: O(N) where N is length of nums
        /// Space Complexity => X
        /// </summary>
        private static IList<IList<int>> GroupThePeople(int[] groupSizes)
        {
            var groupDictionary = new Dictionary<int, List<int>>();
            var result = new List<List<int>>();

            for (int i = 0; i < groupSizes.Count(); i++)
            {
                int size = groupSizes[i];
                if (groupDictionary.ContainsKey(size))
                {
                    groupDictionary[size].Add(i);
                }
                else
                {
                    groupDictionary.Add(size, new List<int>() { i });
                }

                if (groupDictionary[size].Count() == size)
                {
                    result.Add(groupDictionary[size]);
                    groupDictionary[size] = null;
                    groupDictionary[size] = new List<int>();
                }
            }

            return result.ToArray();
        }
    }
}
