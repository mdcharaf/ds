using System;
using System.Collections.Generic;

namespace DS.Graphs
{
    public class BFS
    {
        public int[] BreadthFirstTraverse(IDictionary<int, IList<int>> graph, bool[] visited, int[] parents, int start)
        {
            var queue = new Queue<int>();
            queue.Enqueue(start);
            visited[start] = true;
            Array.Fill(parents, -1);
            

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                // Process Node

                foreach (var neighbor in graph[node])
                {
                    if (!visited[neighbor])
                    {
                        visited[neighbor] = true;
                        queue.Enqueue(neighbor);
                        parents[neighbor] = node;
                    }
                }
            }

            return parents;
        }
    }
}