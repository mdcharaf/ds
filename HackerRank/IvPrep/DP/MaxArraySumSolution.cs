using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace HackerRank.IvPrep.DP
{
    // https://www.hackerrank.com/challenges/max-array-sum?h_l=interview&playlist_slugs%5B%5D=interview-preparation-kit&playlist_slugs%5B%5D=dynamic-programming
    class MaxArraySumSolution
    {
        static long MaxSubsetSum(int[] arr)
        {
            return MaxSubsetSum2(arr);
        }
        
        static long MaxSubsetSum2(int[] arr)
        {
            var table = new int[arr.Length];

            table[0] = arr[0];
            table[1] = Math.Max(arr[0], arr[1]);
            for (int i = 2; i < arr.Length; i++)
            {
                var sum = arr[i] + table[i - 2];
                table[i] = Math.Max(Math.Max(arr[i], sum), table[i - 1]);
            }

            return table[arr.Length - 1];
        }

        public static void RunMain()
        {
            // var memo = new Dictionary<int, long>();
            // var res = MaxSubsetSum(new[] {3, 7, 4, 6, 5});
            // // Console.WriteLine(res);

            int n = Convert.ToInt32(Console.ReadLine());
            
            int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp))
                ;
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var res = MaxSubsetSum(arr); 
            stopwatch.Stop();
            
            Console.WriteLine(res);
            Console.WriteLine(stopwatch.Elapsed.TotalSeconds);
        }

        static void Main2(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int n = Convert.ToInt32(Console.ReadLine());

            int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp))
                ;
            var res = MaxSubsetSum(arr);

            textWriter.WriteLine(res);

            textWriter.Flush();
            textWriter.Close();
        }
    }
}