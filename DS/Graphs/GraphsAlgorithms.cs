using System;
using System.Collections.Generic;

namespace DS.Graphs
{
    public static class GraphsAlgorithms
    {
        public static IDictionary<int, ICollection<int>> BuildUndirectedAdjacencyList(int[][] edgeList)
        {
            var map = new Dictionary<int, ICollection<int>>();

            foreach (var pair in edgeList)
            {
                map.TryAdd(pair[0], new HashSet<int>());
                map.TryAdd(pair[1], new HashSet<int>());
            }

            foreach (var pair in edgeList)
            {
                map[pair[0]].Add(pair[1]);
                map[pair[1]].Add(pair[0]);
            }

            return map;
        }

        public static void DFS(IDictionary<int, ICollection<int>> adjacencyList, bool[] visited, int at)
        {
            if (visited[at]) return;

            visited[at] = true;
            Console.Write($"{at} ");
            
            var list = adjacencyList[at];
            foreach (var item in list)
            {
                DFS(adjacencyList, visited, item);
            }
        }
    }
}