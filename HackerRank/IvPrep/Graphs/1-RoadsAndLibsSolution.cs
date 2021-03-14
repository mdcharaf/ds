using System;
using System.IO;

namespace HackerRank.IvPrep.Graphs
{
    public class RoadsAndLibsSolution
    {
        private static long RoadsAndLibraries(int n, long clib, long croad, int[][] cities)
        {
            if (clib < croad)
            {
                return clib * n;
            }

            var roadmap = InitializeRoadmap(n);
            var sz = InitializeSizes(n);
            long cost = 0;

            foreach (var pair in cities)
            {
                int p = pair[0];
                int q = pair[1];
                BuildRoad(roadmap, sz, p, q, ref cost, clib, croad);
            }

            // Build libs for isolated cities
            for (int i = 1; i <= n; i++)
            {
                // if root city
                if (i == roadmap[i])
                {
                    cost += clib;
                }
            }

            return cost;
        }

        private static int[] InitializeRoadmap(int n)
        {
            var roadmap = new int[n + 1];

            for (int i = 1; i <= n; i++)
            {
                roadmap[i] = i;
            }

            return roadmap;
        }

        private static int[] InitializeSizes(int n)
        {
            var sz = new int[n + 1];

            for (int i = 1; i <= n; i++)
            {
                sz[i] = 1;
            }

            return sz;
        }

        private static bool[] InitializeCitiesLibs(int n)
        {
             var libs = new bool[n + 1];
 
             for (int i = 1; i <= n; i++)
             {
                 libs[i] = false;
             }
 
             return libs;           
        }

        private static int FindRoot(int[] roadmap, int p)
        {
            var root = p;
            while (root != roadmap[root])
            {
                root = roadmap[root];
            }

            // path compression
            while (p != root)
            {
                var parent = roadmap[p];
                roadmap[p] = root;
                p = parent;
            }

            return root;
        }

        private static void BuildRoad(
            int[] roadmap, 
            int[] sz, 
            int p, 
            int q, 
            ref long cost, 
            long clib,
            long croad)
        {
            var root1 = FindRoot(roadmap, p);
            var root2 = FindRoot(roadmap, q);

            if (root1 == root2)
            {
                return;
            }

            if (sz[root1] < sz[root2])
            {
                sz[root2] += sz[root1];
                roadmap[root1] = root2;
            }
            else
            {
                sz[root1] += sz[root2];
                roadmap[root2] = root1;
            }

            cost += croad;
        }

        public static void Debug()
        {
             // TextWriter textWriter = new StreamWriter(Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);
 
             var q = Convert.ToInt32(Console.ReadLine());
 
             for (var qItr = 0; qItr < q; qItr++)
             {
                 var nmC_libC_road = Console.ReadLine().Split(' ');
 
                 var n = Convert.ToInt32(nmC_libC_road[0]);
 
                 var m = Convert.ToInt32(nmC_libC_road[1]);
 
                 var c_lib = Convert.ToInt32(nmC_libC_road[2]);
 
                 var c_road = Convert.ToInt32(nmC_libC_road[3]);
 
                 var cities = new int[m][];
 
                 for (var i = 0; i < m; i++)
                     cities[i] = Array.ConvertAll(Console.ReadLine().Split(' '), citiesTemp => Convert.ToInt32(citiesTemp));
 
                 var result = RoadsAndLibraries(n, c_lib, c_road, cities);
 
                 // textWriter.WriteLine(result);
                 Console.WriteLine(result);
             }
 
             // textWriter.Flush();
             // textWriter.Close();           
        }

        public static void Run()
        {
            TextWriter textWriter = new StreamWriter(Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            var q = Convert.ToInt32(Console.ReadLine());

            for (var qItr = 0; qItr < q; qItr++)
            {
                var nmC_libC_road = Console.ReadLine().Split(' ');

                var n = Convert.ToInt32(nmC_libC_road[0]);

                var m = Convert.ToInt32(nmC_libC_road[1]);

                var c_lib = Convert.ToInt32(nmC_libC_road[2]);

                var c_road = Convert.ToInt32(nmC_libC_road[3]);

                var cities = new int[m][];

                for (var i = 0; i < m; i++)
                    cities[i] = Array.ConvertAll(Console.ReadLine().Split(' '), citiesTemp => Convert.ToInt32(citiesTemp));

                var result = RoadsAndLibraries(n, c_lib, c_road, cities);

                textWriter.WriteLine(result);
            }

            textWriter.Flush();
            textWriter.Close();
        }
    }
}