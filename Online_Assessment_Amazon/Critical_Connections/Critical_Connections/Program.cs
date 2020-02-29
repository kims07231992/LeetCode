using System;
using System.Collections.Generic;
using System.Linq;

namespace Critical_Connections
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var numNodes = 7;
            var numEdges = 7;
            var edges = new int[7][] {
                new int[] { 0, 1 },
                new int[] { 0, 2 },
                new int[] { 1, 3 },
                new int[] { 2, 3 },
                new int[] { 2, 5 },
                new int[] { 5, 6 },
                new int[] { 3, 4 }
            };

            var result = CriticalRouters(edges, numNodes, numEdges);
        }

        /// <summary>
        /// Time Complexity: O(V + E)
        /// Space Complexity: O(V)
        /// </summary>
        private static List<int> CriticalRouters(int[][] edges, int numNodes, int numEdges)
        {
            var result = new HashSet<int>();
            var adjLists = new List<int>[numNodes];
            var low = new int[numNodes];
            var disc = new int[numNodes];
            var parent = new int[numNodes];
            var visited = new bool[numNodes];

            for (int i = 0; i < numNodes; i++)
            {
                adjLists[i] = new List<int>();
            }

            foreach (var edge in edges)
            {
                var fromV = edge[0];
                var toV = edge[1];
                adjLists[fromV].Add(toV);
                adjLists[toV].Add(fromV);
            }

            SearchCriticalRouter(result, adjLists, low, disc, parent, visited, 0, 0, 0);

            return result.ToList();
        }

        private static void SearchCriticalRouter(HashSet<int> result, List<int>[] adjLists, int[] low,
            int[] disc, int[] parent,  bool[] visited, int time, int rootIndex, int currentIndex)
        {
            int children = 0;

            visited[currentIndex] = true;
            disc[currentIndex] = low[currentIndex] = ++time;

            var adjList = adjLists[currentIndex];
            foreach (var adjIndex in adjList)
            {
                if (!visited[adjIndex])
                {
                    children++;
                    parent[adjIndex] = currentIndex;

                    SearchCriticalRouter(result, adjLists, low, disc, parent, visited, time, rootIndex, adjIndex);

                    low[currentIndex] = Math.Min(low[currentIndex], low[adjIndex]);
                    if (currentIndex == rootIndex && children > 1)
                        result.Add(currentIndex);
                    else if (currentIndex != rootIndex && low[adjIndex] >= disc[currentIndex])
                        result.Add(currentIndex);
                }
                else if(parent[currentIndex] != adjIndex)
                {
                    low[currentIndex] = Math.Min(low[currentIndex], disc[adjIndex]);
                }
            }
        }
    }
}
