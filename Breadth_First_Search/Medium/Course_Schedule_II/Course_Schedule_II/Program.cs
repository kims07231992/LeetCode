using System.Collections.Generic;
using System.Linq;

namespace Course_Schedule_II
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var numCourses = 2;
            var prerequisites = new int[][] { new int[] { 1, 0 } };

            var result = FindOrder(numCourses, prerequisites);
        }

        /// <summary>
        /// Time Complexity: O(V + E) where V is number of courses and E is number of prerequisites
        /// Space Complexity: O(V + E)
        /// </summary>
        private static int[] FindOrder(int numCourses, int[][] prerequisites)
        {
            var indegrees = new int[numCourses];
            var matrix = new List<int>[numCourses];
            for (int i = 0; i < prerequisites.Length; i++)
            {
                var course = prerequisites[i][0];
                var prerequisite = prerequisites[i][1];

                if (matrix[prerequisite] == null)
                    matrix[prerequisite] = new List<int> { course };
                else
                    matrix[prerequisite].Add(course);

                indegrees[course]++;
            }

            var result = new int[numCourses];
            var queue = new Queue<int>();
            for (int i = 0; i < numCourses; i++)
            {
                if (indegrees[i] == 0)
                    queue.Enqueue(i);
                result[i] = i;
            }

            int index = 0;
            while (queue.Count() > 0)
            {
                int count = queue.Count();
                for (int i = 0; i < count; i++)
                {
                    var course = queue.Dequeue();
                    result[index++] = course;

                    foreach (var adj in matrix[course] ?? Enumerable.Empty<int>())
                    {
                        if (--indegrees[adj] == 0)
                            queue.Enqueue(adj);
                    }
                }
            }

            return numCourses == index ? result : new int[0];
        }
    }
}
