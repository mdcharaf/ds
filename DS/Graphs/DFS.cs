using System;
using System.Collections.Generic;

namespace DS.Graphs
{
    public class DFS
    {
        public void DFSTraverse<T>(IDictionary<T, IList<T>> adjacencyList, IDictionary<T, bool> visited, T at)
        {
            if (visited[at]) return;

            visited[at] = true;
            Console.Write($"{at} ");

            var neighbors = adjacencyList[at];
            foreach (var neighbor in neighbors)
            {
                DFSTraverse(adjacencyList, visited, neighbor);
            }
        }
    }
}