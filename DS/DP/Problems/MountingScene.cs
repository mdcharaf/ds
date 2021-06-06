using System;
using System.Collections.Generic;

namespace DS.DP.Problems
{
    // https://open.kattis.com/problems/scenes
    public class MountingScene
    {
        private const int Mod = 1000000007;

        static long GetScenesCount(int n, int width, int height)
        {
            long ribbonSquares = Math.Min(n, height * width);
            var memo = new long?[width + 1, n + 1];

            long plainScenes = ribbonSquares / width + 1;
            var totalScenes = CountScenes(1, n, width, height, memo);

            var result = (totalScenes - plainScenes + Mod) % Mod;

            return result;
        }

        static long CountScenes(int w, int n, int width, int height, long?[,] memo)
        {
            if (n < 0) return 0;
            if (w > width) return 1;
            if (memo[w, n].HasValue) return memo[w, n].Value;

            long sum = 0;
            for (int h = 0; h <= height; h++) // note that here you want to tile 0 
            {
                sum += CountScenes(w + 1, n - h, width, height, memo);
            }

            memo[w, n] = sum % Mod;
            return memo[w, n].Value;
        }

        public static void Main2(string[] args)
        {
            var nwh = Console.ReadLine().Split(' ');

            var n = int.Parse(nwh[0]);
            var w = int.Parse(nwh[1]);
            var h = int.Parse(nwh[2]);

            var result = GetScenesCount(n, w, h);

            Console.WriteLine(result);
        }
    }
}