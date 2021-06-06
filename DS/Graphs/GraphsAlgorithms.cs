using System;
using System.Collections.Generic;

namespace DS.Graphs
{
    public static class GraphsAlgorithms
    {
        public static IDictionary<int, ICollection<int>> BuildUndirectedAdjacencyList(int[][] edgeList)
        {
            var map = new Dictionary<int, ICollection<int>>();

            foreach (var edge in edgeList)
            {
                map.TryAdd(edge[0], new HashSet<int>());
                map.TryAdd(edge[1], new HashSet<int>());
            }

            foreach (var edge in edgeList)
            {
                map[edge[0]].Add(edge[1]);
                map[edge[1]].Add(edge[0]);
            }

            return map;
        }

        public static IDictionary<int, ICollection<int>> BuildDirectedAdjacencyList(int[][] edgeList)
        {
            var map = new Dictionary<int, ICollection<int>>();

            foreach (var edge in edgeList)
            {
                map.TryAdd(edge[0], new List<int>());
            }
            
            foreach (var edge in edgeList)
            {
                map[edge[0]].Add(edge[1]);
            }

            return map;
        }

        public static void DFS(IDictionary<int, ICollection<int>> adjacencyList, bool[] visited, int at)
        {
            if (visited[at]) return;

            visited[at] = true;
            Console.Write($"{at} ");
            
            var list = adjacencyList[at];
            foreach (var vertex in list)
            {
                DFS(adjacencyList, visited, vertex);
            }
        }
    }
}