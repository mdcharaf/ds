using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HackerRank.IvPrep.Graphs
{
    class MatrixSolution
    {
        static int MinTime(int[][] roads, int[] machines)
        {
            int minTime = 0;

            Array.Sort(roads, (x, y) => y[2].CompareTo(x[2]));

            int n = roads.Length + 1;

            var reds = new bool[n];
            foreach (var machine in machines)
            {
                reds[machine] = true;
            }

            var parents = new int[n];
            for (int i = 0; i < n; i++)
            {
                parents[i] = i;
            }

            var sizes = new int[n];
            for (int i = 0; i < sizes.Length; i++)
            {
                sizes[i] = 1;
            }

            foreach (var road in roads)
            {
                minTime += Union(road, parents, sizes, reds);
            }

            return minTime;
        }

        private static int Find(int p, int[] parents)
        {
            var root = p;
            while (root != parents[root])
            {
                root = parents[root];
            }

            // path compression
            while (p != root)
            {
                var parent = parents[p];
                parents[p] = root;
                p = parent;
            }

            return root;
        }

        static int Union(int[] road, int[] parents, int[] sizes, bool[] reds)
        {
            var root1 = Find(road[0], parents);
            var root2 = Find(road[1], parents);

            if (reds[root1] && reds[root2])
                return road[2];

            if (root1 != root2)
            {
                if (sizes[root1] > sizes[root2])
                {
                    parents[root2] = root1;
                    sizes[root1] += sizes[root2];
                }
                else
                {
                    parents[root1] = root2;
                    sizes[root2] += sizes[root1];
                }
            }

            reds[root1] |= reds[root2];
            reds[root2] |= reds[root1];

            return 0;
        }

        static void Main2(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            string[] nk = Console.ReadLine().Trim().Split(' ');

            int n = Convert.ToInt32(nk[0]);

            int k = Convert.ToInt32(nk[1]);

            int[][] roads = new int[n - 1][];

            for (int i = 0; i < n - 1; i++)
            {
                roads[i] = Array.ConvertAll(Console.ReadLine().Trim().Split(' '), roadsTemp => Convert.ToInt32(roadsTemp));
            }

            int[] machines = new int [k];

            for (int i = 0; i < k; i++)
            {
                int machinesItem = Convert.ToInt32(Console.ReadLine().Trim());
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