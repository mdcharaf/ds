using System;
using System.Collections.Generic;
using DS.DataStructures;

namespace DS.Graphs.MSTs
{
    public class PrimMST
    {
        public (Vertex[], double) GetMST(int n, int[][] graph, int start = 0)
        {
            var minSum = 0;
            
            // Initialize Vertices Array
            var vertices = new Vertex[n];
            for (int i = 0; i < n; i++)
            {
                vertices[i] = new Vertex {Val = i, Key = int.MaxValue, Parent = -1, IsProcessed = false };
            }

            vertices[start].Key = 0;
            
            // Initialize PQ
            var queue = new PriorityQueue<Vertex>();
            foreach (var vertex in vertices)
            {
                queue.Enqueue(vertex.Key, vertex);
            }
            
            // Loop and update distances
            while (queue.Count > 0)
            {
                var vertex = queue.Dequeue();
                var u = vertex.Val;

                for (int v = 0; v < graph[u].Length; v++)
                {
                    var distance = graph[u][v];
                    var neighbor = vertices[v];
                    
                    if (distance > 0 && !neighbor.IsProcessed && distance < neighbor.Key)
                    {
                        neighbor.Parent = u;
                        neighbor.Key = distance;
                        minSum += distance;
                        
                        queue.UpdatePriority(neighbor, neighbor.Key);
                    }
                }
            }

            return (vertices, minSum);
        }
    }
}