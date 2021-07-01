using System;
using System.Collections.Generic;

namespace DS.Graphs
{
    public class TopologicalSort
    {
        public IEnumerable<int> Sort(IDictionary<int, IList<int>> graph) 
        {
            // Build Graph
            var state = new int[graph.Count];
            var result = new List<int>();
        
            // Implement Topological Sort
            foreach (var (node, _) in graph)
            {
                if (!DFS(graph, node, state, result))
                {
                    return Array.Empty<int>();
                }
            }
        
            return result.ToArray();
        }
    
        private bool DFS(
            IDictionary<int, IList<int>> graph, int node, int[] state, IList<int> result)
        {
            // If visited then return true
            if (state[node] == 2) return true;
        
            // return false if the current state is busy
            if (state[node] == 1) return false;
        
            state[node] = 1;
        
            foreach (var neighbor in graph[node])
            {
                if (!DFS(graph, neighbor, state, result))
                {
                    return false;
                }
            }
        
            // Mark node as visited
            result.Add(node);
            state[node] = 2;
            return true;
        }
    }
}