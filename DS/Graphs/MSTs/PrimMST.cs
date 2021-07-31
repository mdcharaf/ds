using System;
using System.Collections.Generic;
using DS.DataStructures;

namespace DS.Graphs.MSTs
{
    public class PrimMST
    {
        public Vertex[] GetMST(int[][] graph, int start = 0)
        {
            // Initialize Vertices Array
            var vertices = new Vertex[graph.Length];
            for (int i = 0; i < graph.Length; i++)
            {
                vertices[i] = new Vertex {Val = i};
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
                vertex.IsProcessed = true;

                for (int v = 0; v < graph[u].Length; v++)
                {
                    var distance = graph[u][v];
                    var neighbor = vertices[v];
                    
                    if (distance > 0 && !neighbor.IsProcessed && distance < neighbor.Key)
                    {
                        neighbor.Parent = u;
                        neighbor.Key = distance;
                        
                        queue.UpdatePriority(neighbor, neighbor.Key);
                    }
                }
            }

            return vertices;
        }

        public void Test()
        {
            var adjacencyMatrix = new[]
            { new[] { 0,0,0,3,12 },
                new int[] { 0,0,2,5,0 },
                new int[] { 0,2,0,3,7 },
                new int[] { 3,5,3,0,0 },
                new int[] { 12,0,7,0,0 } };

            var vertices = GetMST(adjacencyMatrix);
            //printing results
            int totalWeight = 0;
            foreach (Vertex u in vertices)
            {
                if (u.Parent >= 0)
                {
                    Console.WriteLine("Vertex {0} to Vertex {1} weight is: {2}", u.Val, u.Parent, u.Key);
                    totalWeight += u.Key;
                }
            }
            Console.WriteLine("Total Weight: {0}", totalWeight);
            Console.ReadLine();
        }
    }
}