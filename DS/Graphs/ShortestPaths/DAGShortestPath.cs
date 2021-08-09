using System;
using System.Collections.Generic;

namespace DS.Graphs.ShortestPaths
{
    public class DAGShortestPath
    {
        public int[] GetShortestPath(int[][] graph, int start)
        {
            var n = graph.Length;

            // Initialize A Single Source
            var distances = new int[n];
            Array.Fill(distances, int.MaxValue);
            distances[start] = 0;

            var parents = new int[n];
            Array.Fill(parents, -1);

            var sortedPath = TopologicalSort(graph);

            foreach (var u in sortedPath)
            {
                try
                {
                    for (int v = 0; v < n; v++)
                    {
                        if (graph[u][v] > 0 && checked(distances[v] > distances[u] + graph[u][v]))
                        {
                            distances[v] = distances[u] + graph[u][v];
                            parents[v] = u;
                        }
                    }
                }
                catch (OverflowException)
                {
                }
            }

            return distances;
        }

        private IList<int> TopologicalSort(int[][] graph)
        {
            var n = graph.Length;
            var vertices = new List<int>();
            var visited = new bool[n];

            for (int i = 0; i < n; i++)
            {
                if (!visited[i])
                {
                    Array.Fill(visited, false);
                    DFS(graph, visited, vertices, i);
                }
            }

            return vertices;
        }

        private void DFS(int[][] graph, bool[] visited, IList<int> result, int i)
        {
            if (visited[i]) return;

            visited[i] = true;

            for (int j = 0; j < graph.Length; j++)
            {
                if (graph[i][j] > 0)
                {
                    DFS(graph, visited, result, j);
                }
            }

            result.Add(i);
        }
    }
}