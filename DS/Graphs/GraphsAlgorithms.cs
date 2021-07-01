using System;
using System.Collections.Generic;

namespace DS.Graphs
{
    public static class GraphsAlgorithms
    {
        public static void DFS(IDictionary<int, ICollection<int>> graph, bool[] visited, int at)
        {
            if (visited[at]) return;

            visited[at] = true;
            Console.Write($"{at} ");
            
            var list = graph[at];
            foreach (var vertex in list)
            {
                DFS(graph, visited, vertex);
            }
        }
    }
}