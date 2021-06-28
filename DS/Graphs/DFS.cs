using System;
using System.Collections.Generic;

namespace DS.Graphs
{
    public class DFS
    {
        public static void Run<T>(IDictionary<T, IList<T>> adjacencyList, IDictionary<T, bool> visited, T at)
        {
            if (visited[at]) return;

            visited[at] = true;
            Console.Write($"{at} ");

            var list = adjacencyList[at];
            foreach (var vertex in list)
            {
                Run(adjacencyList, visited, vertex);
            }
        }
    }
}