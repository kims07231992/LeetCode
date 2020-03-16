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
            var visited = new bool[n];
            var time = 0;

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
                CriticalConnections(result, adjLists, disc, low, visited, i, i, time);
            }

            return result;
        }

        private static void CriticalConnections(IList<IList<int>> result,
            List<int>[] adjLists, int[] disc, int[] low, bool[] visited, int u, int previous, int time)
        {
            disc[u] = low[u] = ++time;
            visited[u] = true;

            var adjList = adjLists[u];
            foreach (var v in adjList)
            {
                if (v == previous)
                {
                    continue;
                }

                if (!visited[v])
                {
                    CriticalConnections(result, adjLists, disc, low, visited, v, u, time);
                    low[u] = Math.Min(low[u], low[v]);
                    if (low[v] > disc[u])
                    {
                        result.Add(new List<int> { u, v });
                    }
                }
                else
                {
                    low[u] = Math.Min(low[u], disc[v]);
                }
            }
        }
    }
}
