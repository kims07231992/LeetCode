using System.Collections.Generic;
using System.Linq;

namespace Course_Schedule
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static  void Run()
        {
            var numCourses = 2;
            var prerequisites = new int[][] 
            {
                new int[] { 1, 0 },
                new int[] { 0, 1 }
            };

            var result = CanFinish(numCourses, prerequisites);
        }

        /// <summary>
        /// Time Complexity: O(V + E) where V is number of courses and E is number of prerequisites
        /// Space Complexity: O(V + E)
        /// </summary>
        public static bool CanFinish(int numCourses, int[][] prerequisites)
        {
            if (prerequisites == null || prerequisites.Length < 1)
                return true;

            var matrix = new List<int>[numCourses]; // prerequisite -> [course1, course2, ...]
            var indegrees = new int[numCourses];
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

            var queue = new Queue<int>();
            for (int i = 0; i < numCourses; i++)
            {
                if (indegrees[i] == 0) // course doesn't have prerequisite
                    queue.Enqueue(i);
            }

            int count = 0;
            while (queue.Count() > 0)
            {
                int i = queue.Count();
                for (int k = 0; k < i; k++)
                {
                    var course = queue.Dequeue();
                    count++;
                    foreach (var adjacent in matrix[course] ?? Enumerable.Empty<int>())
                    {
                        if (--indegrees[adjacent] == 0) // course doesn't have prerequisite
                            queue.Enqueue(adjacent);
                    }
                }
            }

            // count cannot be greater than numCourses
            // if count is less than numCourses, that means,
            // some of courses are not able to fulfill the prerequisites
            return numCourses == count;
        }
    }
}
