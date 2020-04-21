using System;
using System.Collections.Generic;

namespace Critical_Connections_in_a_Network
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var n = 4;
            var connections = new List<IList<int>>
            {
                new List<int> { 0, 1 },
                new List<int> { 1, 2 },
                new List<int> { 2, 0 },
                new List<int> { 1, 3 }
            };
            var result = CriticalConnections(n, connections);
        }

        /// <summary>
        /// Time Complexity: O(V + E) where V is n and E is length of connections
        /// Space Complexity: O(V + E)
        /// </summary>
        private static IList<IList<int>> CriticalConnections(int n, IList<IList<int>> connections)
        {
            var result = new List<IList<int>>();
            var adjLists = new List<int>[n];
            var disc = new int[n];
            var low = new int[n];
            var parent = new int[n];
            var visited = new bool[n];

            for (int i = 0; i < n; i++)
            {
                adjLists[i] = new List<int>();
            }

            for (int i = 0; i < connections.Count; i++)
            {
                int from = connections[i][0];
                int to = connections[i][1];
                adjLists[from].Add(to);
                adjLists[to].Add(from);
            }

            for (int i = 0; i < n; i++)
            {
                CriticalConnections(result, adjLists, disc, low, parent, visited, i, 0);
            }

            return result;
        }

        private static void CriticalConnections(IList<IList<int>> result, List<int>[] adjLists, int[] disc, int[] low, int[] parent, bool[] visited, int currentIndex, int time)
        {
            disc[currentIndex] = low[currentIndex] = ++time;
            visited[currentIndex] = true;

            var adjList = adjLists[currentIndex];
            foreach (var adjIndex in adjList)
            {
                if (parent[currentIndex] == adjIndex)
                {
                    continue; // reversed way, ignore
                }

                if (!visited[adjIndex])
                {
                    parent[adjIndex] = currentIndex;
                    CriticalConnections(result, adjLists, disc, low, parent, visited, adjIndex, time);
                    low[currentIndex] = Math.Min(low[currentIndex], low[adjIndex]);

                    if (disc[currentIndex] < low[adjIndex]) // there is no path for current vertex to reach back to adjacent vertex or previous vertices
                    {
                        result.Add(new List<int> { currentIndex, adjIndex });
                    }
                }
                else // if current vertex discovered and is not parent of adjacent vertex, update low[current]
                {
                    low[currentIndex] = Math.Min(low[currentIndex], disc[adjIndex]);
                }
            }
        }
    }
}
