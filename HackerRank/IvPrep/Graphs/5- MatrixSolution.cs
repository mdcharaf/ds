using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HackerRank.IvPrep.Graphs
{
    class MatrixSolution
    {
        class Edge
        {
            public int Node { get; set; }
            public int Time { get; set; }
        }

        static int MinTime(int[][] roads, int[] machines)
        {
            var time = 0;

            // 1 - Build Graph
            var graph = BuildGraph(roads);
            var machinesMap = machines.ToDictionary(x => x, x => x);
            var visitedMachines = new bool[roads.Length + 1];
            var destroyedRoads = new Dictionary<string, object>();

            // 2- Loop through cities that have machines and find the sum of min time to destroy the roads between this
            // city and each other city that has machine 
            foreach (var city in graph)
            {
                if (!machinesMap.ContainsKey(city.Key))
                    continue;

                var timeToDestroy = FindShortestPathToMachines(graph, city.Key, visitedMachines, machinesMap);
                visitedMachines[city.Key] = true;

                time += timeToDestroy;
            }

            return time;
        }

        private static int FindShortestPathToMachines(
            IDictionary<int, IList<Edge>> graph,
            int start,
            bool[] visitedMachines,
            IDictionary<int, int> machinesMap)
        {
            var minTime = 0;
            var queue = new Queue<int>();
            queue.Enqueue(start);


            var visited = new bool[graph.Count];
            visited[start] = true;

            var times = new int[graph.Count];
            for (int i = 0; i < times.Length; i++)
            {
                times[i] = 0;
            }

            // Traverse and calculate the min time between start node and each other machine node
            while (queue.Count != 0)
            {
                var pivot = queue.Dequeue();

                foreach (var neighbor in graph[pivot])
                {
                    // if Edge is visited in the current rotation of machine city is already processed then skip
                    if (visited[neighbor.Node] || visitedMachines[neighbor.Node])
                        continue;

                    visited[neighbor.Node] = true;

                    // Calculate time to visit neighbor
                    if (times[pivot] == 0)
                    {
                        times[neighbor.Node] = neighbor.Time;
                    }
                    else
                    {
                        times[neighbor.Node] = Math.Min(times[pivot], neighbor.Time);
                    }

                    // If node is a machine then stop traversing this node's cities
                    if (pivot == start || !machinesMap.ContainsKey(neighbor.Node))
                    {
                        queue.Enqueue(neighbor.Node);
                    }
                }
            }

            // Summing the min time from start point to each machine node
            for (int i = 0; i < times.Length; i++)
            {
                minTime += times[i];
            }

            return minTime;
        }

        static IDictionary<int, IList<Edge>> BuildGraph(int[][] roads)
        {
            var graph = new Dictionary<int, IList<Edge>>();

            for (int i = 0; i <= roads.Length; i++)
            {
                graph.Add(i, new List<Edge>());
            }

            foreach (var road in roads)
            {
                var city1 = road[0];
                var city2 = road[1];
                var time = road[2];

                graph[city1].Add(new Edge {Node = city2, Time = time});
                graph[city2].Add(new Edge {Node = city1, Time = time});
            }

            return graph;
        }

        static void Main2(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            string[] nk = Console.ReadLine().Split(' ');

            int n = Convert.ToInt32(nk[0]);

            int k = Convert.ToInt32(nk[1]);

            int[][] roads = new int[n - 1][];

            for (int i = 0; i < n - 1; i++)
            {
                roads[i] = Array.ConvertAll(Console.ReadLine().Split(' '), roadsTemp => Convert.ToInt32(roadsTemp));
            }

            int[] machines = new int [k];

            for (int i = 0; i < k; i++)
            {
                int machinesItem = Convert.ToInt32(Console.ReadLine());
                machines[i] = machinesItem;
            }

            int result = MinTime(roads, machines);

            textWriter.WriteLine(result);

            textWriter.Flush();
            textWriter.Close();
        }

        public static void Debug()
        {
            // TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            string[] nk = Console.ReadLine().TrimEnd().Split(' ');

            int n = Convert.ToInt32(nk[0]);

            int k = Convert.ToInt32(nk[1]);

            int[][] roads = new int[n - 1][];

            for (int i = 0; i < n - 1; i++)
            {
                roads[i] = Array.ConvertAll(Console.ReadLine().TrimEnd().Split(' '),
                    roadsTemp => Convert.ToInt32(roadsTemp));
            }

            int[] machines = new int [k];

            for (int i = 0; i < k; i++)
            {
                int machinesItem = Convert.ToInt32(Console.ReadLine().TrimEnd());
                machines[i] = machinesItem;
            }

            int result = MinTime(roads, machines);

            // textWriter.WriteLine(result);
            Console.WriteLine(result);

            // textWriter.Flush();
            // textWriter.Close();
        }
    }
}