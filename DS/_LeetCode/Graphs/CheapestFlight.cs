using System;
using DS.DataStructures;

namespace DS._LeetCode.Graphs
{
    public class CheapestFlight
    {
        public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k)
        {
            // Build Graph
            var graph = BuildGraph(n, flights);

            // Initialize Single Source
            var distances = new int[n];
            var stops = new int[n];
            Array.Fill(distances, int.MaxValue);
            Array.Fill(stops, int.MaxValue);
            distances[src] = 0;
            stops[src] = 0;

            // Initialize PQ (vertex, cost, stops)
            var queue = new PriorityQueue<(int vertex, int cost, int stops)>();
            queue.Enqueue(0, (src, 0, 0));

            // Calculate Shortest Path Greedily
            while (queue.Count > 0)
            {
                var (u, uDistance, uStops) = queue.Dequeue();

                // Console.WriteLine($"{u}-{uDistance}-{uStops}");

                if (u == dst)
                {
                    return uDistance;
                }

                if (uStops > k)
                {
                    continue;
                }

                for (int v = 0; v < n; v++)
                {
                    try
                    {
                        if (graph[u][v] > 0)
                        {
                            var vDistance = uDistance + graph[u][v];

                            if (distances[v] > checked(uDistance + graph[u][v]))
                            {
                                distances[v] = vDistance;
                                queue.Enqueue(vDistance, (v, vDistance, uStops + 1));
                            }
                            else if (uStops < stops[v])
                            {
                                queue.Enqueue(vDistance, (v, vDistance, uStops + 1));
                            }

                            stops[v] = uStops;
                        }
                    }
                    catch (OverflowException)
                    {
                    }
                }
            }

            return -1;
        }

        void PrintArray<T>(T[] arr)
        {
            Console.WriteLine();
            foreach (var item in arr)
            {
                Console.Write($"{item},");
            }
        }

        int[][] BuildGraph(int n, int[][] edgeList)
        {
            var graph = new int[n][];
            for (int i = 0; i < graph.Length; i++)
            {
                graph[i] = new int[n];
            }

            foreach (var edge in edgeList)
            {
                graph[edge[0]][edge[1]] = edge[2];
            }

            // for (int i = 0 ; i < n; i++)
            // {
            //     Console.WriteLine();
            //     for (int j = 0; j < n; j++)
            //     {
            //         Console.Write($"{graph[i][j]} ");
            //     }
            // }

            return graph;
        }
    }
}