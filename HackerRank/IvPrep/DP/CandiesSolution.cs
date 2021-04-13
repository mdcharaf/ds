using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HackerRank.IvPrep.DP
{
    class Candiessolution
    {
        // Complete the candies function below.
        static long Candies(int n, int[] arr)
        {
            var ranks = new int[n];

            for (int i = 0; i < arr.Length; i++)
            {
                ranks[i] = Rank(arr, ranks, i);
            }

            var result = ranks.Sum();
            return result;
        }

        static int Rank(int[] arr, int[] ranks, int i)
        {
            var previousRank = i - 1 >= 0 ? ranks[i - 1] : 0;

            if (i + 1 < arr.Length && arr[i] >= arr[i + 1])
            {
                var nextRank = Rank(arr, ranks, i + 1);

                // if (arr[i] == arr[i + 1])
                // {
                //     if (nextRank > previousRank)
                //         return nextRank;
                //
                //     return previousRank + 1;
                // }

                return Math.Max(previousRank, Rank(arr, ranks, i + 1)) + 1;
            }

            if (i - 1 >= 0 && arr[i] >= arr[i - 1])
            {
                // if (arr[i] == arr[i - 1])
                //     return previousRank;
                
                return previousRank + 1;
            }

            return 1;
        }


        public static void RunMain()
        {
            // TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int n = Convert.ToInt32(Console.ReadLine());

            int[] arr = new int [n];

            for (int i = 0; i < n; i++)
            {
                int arrItem = Convert.ToInt32(Console.ReadLine());
                arr[i] = arrItem;
            }

            long result = Candies(n, arr);

            Console.WriteLine(result);
        }

        static void Main2(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int n = Convert.ToInt32(Console.ReadLine());

            int[] arr = new int [n];

            for (int i = 0; i < n; i++)
            {
                int arrItem = Convert.ToInt32(Console.ReadLine());
                arr[i] = arrItem;
            }

            long result = Candies(n, arr);

            textWriter.WriteLine(result);

            textWriter.Flush();
            textWriter.Close();
        }
    }
}