using System.Collections.Generic;

namespace DS.Graphs.DFSApps
{
    public class SCC
    {
        /// <summary>
        /// Kosaraju's Algorithm for finding SCCs
        /// </summary>
        /// <param name="graph"></param>
        /// <returns> List of strongly connected components in a graph</returns>
        public IList<IList<int>> FindSCCs(IDictionary<int, IList<int>> graph)
        {
            var result = new List<IList<int>>();
            
            // Holds vertices in reverse order
            var stack = new Stack<int>();

            // Holds visited vertices
            var visited = new HashSet<int>();


            // 1- Sort Vertices in Topological Order
            foreach (var (vertex, _) in graph)
            {
                if (!visited.Contains(vertex))
                {
                    DFSGraph(graph, visited, stack, vertex);
                }
            }

            // 2- Reverse Graph
            var reversedGraph = ReverseGraph(graph);

            // 3- Do DFS based off vertex finish time in decreasing order on the reversed graph
            visited.Clear();
            while (stack.Count > 0)
            {
                var vertex = stack.Pop();
                var components = new List<int>();
                
                if (!visited.Contains(vertex))
                {
                    DFSReverseGraph(reversedGraph, visited, components, vertex);
                }
                
                result.Add(components);
            }

            return result;
        }

        private void DFSGraph(IDictionary<int, IList<int>> graph, HashSet<int> visited, Stack<int> stack, int vertex)
        {
            if (visited.Contains(vertex))
                return;

            visited.Add(vertex);

            foreach (var neighbor in graph[vertex])
            {
                DFSGraph(graph, visited, stack, neighbor);
            }

            stack.Push(vertex);
        }

        private void DFSReverseGraph(
            IDictionary<int, IList<int>> graph, 
            HashSet<int> visited, 
            IList<int> components,
            int vertex)
        {
            if (visited.Contains(vertex)) return;

            visited.Add(vertex);
            components.Add(vertex);

            foreach (var neighbor in graph[vertex])
            {
                DFSReverseGraph(graph, visited, components, neighbor);
            }
        }

        private IDictionary<int, IList<int>> ReverseGraph(IDictionary<int, IList<int>> graph)
        {
            var reversedGraph = new Dictionary<int, IList<int>>();

            foreach (var (v, neighbors) in graph)
            {
                foreach (var neighbor in neighbors)
                {
                    reversedGraph.TryAdd(neighbor, new List<int>());
                    reversedGraph[neighbor].Add(v);
                }
            }

            return reversedGraph;
        }
    }
}