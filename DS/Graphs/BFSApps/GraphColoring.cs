using System;
using System.Collections.Generic;

namespace DS.Graphs.BFSApps
{
    public class GraphColoring
    {
        public bool IsBipartite(IDictionary<int, IList<int>> graph) 
        {
            var colors = new int[graph.Count + 1];
            Array.Fill(colors, -1);
        
            foreach (var (vertex, _) in graph)
            {
                if (colors[vertex] == -1)
                {
                    colors[vertex] = 0;
                    if (!BFS(graph, colors, vertex))
                    {
                        return false;
                    }
                }
            }
        
            return true;
        }
        
        private bool BFS(IDictionary<int, IList<int>> graph, int[] colors, int start)
        {
            var queue = new Queue<int>();
            queue.Enqueue(start);
        
            while (queue.Count > 0)
            {
                var vertex = queue.Dequeue();
                var vertexColor = colors[vertex];
            
                foreach (var neighbor in graph[vertex])
                {
                    var neighborColor = colors[neighbor];
                
                    if (vertexColor == neighborColor)
                    {
                        return false;
                    }
                
                    // Unvisited
                    if (neighborColor == -1)
                    {
                        // Reverse Color
                        colors[neighbor] = 1 - vertexColor; 
                        queue.Enqueue(neighbor);
                    }
                }
            }
        
            return true;
        }
    }
}