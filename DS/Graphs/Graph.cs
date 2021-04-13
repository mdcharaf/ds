using System;
using System.Collections.Generic;

namespace DS.Algos
{
    public class Graph
    {
        private readonly IDictionary<int, IList<int>> _graph;

        public Graph()
        {
            _graph = new Dictionary<int, IList<int>>();
        }

        public IDictionary<int, IList<int>> BuildGraph(int n, int[][] edgeList)
        {
            for (int i = 1; i <= n; i++)
            {
                _graph.Add(i, new List<int>());
            }
            
            foreach (var pair in edgeList)
            {
                _graph[pair[0]].Add(pair[1]);
                _graph[pair[1]].Add(pair[0]);
            }

            return _graph;
        }

        public int[] BFS(int start)
        {
            var queue = new Queue<int>();
            queue.Enqueue(start);

            var distances = new int[_graph.Count];
            Array.Fill(distances, -1);
            distances[start] = 0;

            while (queue.Count != 0)
            {
                var node = queue.Dequeue();
                foreach (var neighbor in _graph[node])
                {
                    // Not visited
                    if (distances[neighbor] == -1)
                    {
                        // Visit
                        distances[neighbor] = distances[node] + 1;
                        queue.Enqueue(neighbor);
                    }
                }
            }

            return distances;
        }
    }
}