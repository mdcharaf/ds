using System;
using System.Collections.Generic;
using System.IO;

namespace HackerRank.IvPrep.Graphs
{
    public class NearestCloneSolution
    {
        static int FindShortest(int graphNodes, int[] graphFrom, int[] graphTo, long[] colors, int selectedColor)
        {
            int shortestPath = -1;

            // 1- Build your graph
            var graph = BuildGraph(graphNodes, graphFrom, graphTo);

            // 2- Loop through the graph and take each point that matches the color as a start point
            foreach (var node in graph)
            {
                if (colors[node.Key - 1] != selectedColor)
                    continue;

                // 3- Inspect neighbors until you find the match color graph
                var path = BFS(graph, node.Key, colors, selectedColor);

                // 4- Choose the shortest path
                if (shortestPath == -1)
                {
                    shortestPath = path;
                }
                else if (path < shortestPath)
                {
                    shortestPath = path;
                }
            }

            return shortestPath;
        }

        static int BFS(IDictionary<int, IList<int>> graph, int start, long[] colors, int selectedColor)
        {
            var queue = new Queue<int>();
            queue.Enqueue(start);

            var distances = new int[graph.Count + 1];
            for (int i = 0; i < distances.Length; i++)
            {
                distances[i] = -1;
            }
            distances[start] = 0;

            int shortestPath = -1;
            while (queue.Count != 0)
            {
                var node = queue.Dequeue();
                foreach (var neighbor in graph[node])
                {
                    // If not visited
                    if (distances[neighbor] == -1)
                    {
                        // Visit
                        distances[neighbor] = distances[node] + 1;
                        // Check the color
                        if (colors[neighbor - 1] == selectedColor)
                        {
                            shortestPath = distances[neighbor];
                            break;
                        }

                        queue.Enqueue(neighbor);
                    }
                }
            }

            return shortestPath;
        }

        static IDictionary<int, IList<int>> BuildGraph(
            int nodesSize,
            int[] sourceEdges,
            int[] destEdges)
        {
            var graph = new Dictionary<int, IList<int>>();
            for (int i = 1; i <= nodesSize; i++)
            {
                graph.Add(i, new List<int>());
            }

            for (int i = 0; i < sourceEdges.Length; i++)
            {
                int sourceEdge = sourceEdges[i];
                int destEdge = destEdges[i];

                graph[sourceEdge].Add(destEdge);
                graph[destEdge].Add(sourceEdge);
            }

            return graph;
        }

        public static void Debug()
        {
            // TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);
        
            string[] graphNodesEdges = Console.ReadLine().Split(' ');
            int graphNodes = Convert.ToInt32(graphNodesEdges[0]);
            int graphEdges = Convert.ToInt32(graphNodesEdges[1]);
        
            int[] graphFrom = new int[graphEdges];
            int[] graphTo = new int[graphEdges];
        
            for (int i = 0; i < graphEdges; i++)
            {
                string[] graphFromTo = Console.ReadLine().Split(' ');
                graphFrom[i] = Convert.ToInt32(graphFromTo[0]);
                graphTo[i] = Convert.ToInt32(graphFromTo[1]);
            }

            long[] ids = Array.ConvertAll
                (
                Console.ReadLine().TrimEnd().Split(' '),
                idsTemp => Convert.ToInt64(idsTemp));
            int selectedColor = Convert.ToInt32(Console.ReadLine());
        
            int ans = FindShortest(graphNodes, graphFrom, graphTo, ids, selectedColor);
            // int ans = 0;
        
            Console.WriteLine(ans);
        
            // textWriter.Flush();
            // textWriter.Close();
        }
        
    }
}