using System;
using System.Collections.Generic;
using System.Linq;

namespace HackerRank.IvPrep.Graphs
{
    public class ShortestReachSolution
    {
        static int[] BFS(IDictionary<int, IList<int>> graph, int start, int distance)
        {
            var queue = new Queue<int>();
            queue.Enqueue(start);

            var distances = new int[graph.Count + 1];
            for (int i = 0; i < distances.Length; i++)
            {
                distances[i] = -1;
            }

            distances[start] = 0;

            while (queue.Count != 0)
            {
                var node = queue.Dequeue();

                foreach (var neighbor in graph[node])
                {
                    if (distances[neighbor] == -1)
                    {
                        distances[neighbor] = distances[node] + distance;
                        queue.Enqueue(neighbor);
                    }
                }
            }

            return distances;
        }

        static IDictionary<int, IList<int>> InitializeGraph(int n)
        {
            var graph = new Dictionary<int, IList<int>>();

            for (int i = 1; i <= n; i++)
            {
                graph.Add(i, new List<int>());
            }

            return graph;
        }

        public static void Debug()
        {
            var q = int.Parse(Console.ReadLine());

            for (int i = 0; i < q; i++)
            {
                var nm = Console.ReadLine().TrimEnd().Split(' ');
                int n = int.Parse(nm[0]);
                int m = int.Parse(nm[1]);

                var graph = InitializeGraph(n);

                for (int j = 0; j < m; j++)
                {
                    var edges = Console.ReadLine().TrimEnd().Split(' ');
                    var node1 = int.Parse(edges[0]);
                    var node2 = int.Parse(edges[1]);

                    graph[node1].Add(node2);
                    graph[node2].Add(node1);
                }

                int start = int.Parse(Console.ReadLine());
                var distances = BFS(graph, start, 6);
                var result = new List<int>();
                for (int j = 1; j < distances.Length; j++)
                {
                    if (j == start)
                        continue;
                    result.Add(distances[j]);
                }

                Console.WriteLine(string.Join(" ", result));
            }
        }
    }
}