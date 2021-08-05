using System;
using System.Collections.Generic;
using DS.DataStructures;

namespace DS.Graphs.ShortestPaths
{
    public class DijkstraShortestPath
    {
        public Vertex[] GetShortestPath(int[][] graph, int start)
        {
            // Initialize Single Source
            var vertices = new Vertex[graph.Length];

            for (int i = 0; i < vertices.Length; i++)
            {
                vertices[i] = new Vertex() {Val = i};
            }

            vertices[start].Distance = 0;

            // Initialize PQ
            var queue = new PriorityQueue<Vertex>();
            foreach (var vertex in vertices)
            {
                queue.Enqueue(vertex.Distance, vertex);
            }

            // Implement Logic
            while (queue.Count > 0)
            {
                var vertex = queue.Dequeue();
                var u = vertex.Val;

                vertex.IsProcessed = true;

                for (int v = 0; v < graph[u].Length; v++)
                {
                    var distance = graph[u][v];
                    var neighbor = vertices[v];

                    if (distance > 0 && !neighbor.IsProcessed)
                    {
                        // Relax
                        if (neighbor.Distance > vertex.Distance + distance)
                        {
                            neighbor.Distance = vertex.Distance + distance;
                            neighbor.Parent = vertex;

                            queue.UpdatePriority(neighbor, neighbor.Distance);
                        }
                        //
                    }
                }
            }

            return vertices;
        }

        public int[] GetShortestPath2(int n, int[][] graph, int start)
        {
            // Initialize Single Source
            var distances = new int[n];
            Array.Fill(distances, int.MaxValue);
            distances[start] = 0;

            var parents = new int[n];
            Array.Fill(parents, -1);

            // Initialize Priority Queue
            var queue = new PriorityQueue<int>();
            for (int i = 0; i < distances.Length; i++)
            {
                queue.Enqueue(distances[i], i);
            }

            // Greedy Calculate Shortest Distance
            var visited = new bool[n];

            while (queue.Count > 0)
            {
                var u = queue.Dequeue();
                visited[u] = true;

                for (int v = 0; v < graph[u].Length; v++)
                {
                    // Relax
                    try
                    {
                        if (graph[u][v] > 0 && !visited[v] && distances[v] > checked(distances[u] + graph[u][v]))
                        {
                            distances[v] = distances[u] + graph[u][v];
                            parents[v] = u;
                            //
                            queue.UpdatePriority(v, distances[v]);
                        }
                    }
                    catch (OverflowException)
                    {
                    }
                }
            }

            return distances;
        }


        public void Test()
        {
            int[][] adjacencyMatrix = new int[][]
            {
                new int[] {0, 0, 0, 3, 12},
                new int[] {0, 0, 2, 0, 0},
                new int[] {0, 0, 0, 0, 0},
                new int[] {0, 5, 3, 0, 0},
                new int[] {0, 0, 7, 0, 0}
            };

            // adjacencyMatrix = new int[][]
            // {
            //     new int[] {0, 0, 0, 2, 10},
            //     new int[] {0, 0, 3, 0, 3},
            //     new int[] {0, 0, 0, 0, 0},
            //     new int[] {0, 1, 0, 0, 0},
            //     new int[] {0, 1, 0, 0, 0},
            // };

            //calling dijkstra  algorithm
            // var vertices = GetShortestPath(adjacencyMatrix, 0);
            var result = GetShortestPath2(adjacencyMatrix.Length, adjacencyMatrix, 0);

            //printing distance
            Console.ReadLine();
        }
    }
}