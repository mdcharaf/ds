using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HackerRank.IvPrep.DP
{
    class MaxArraySumSolution
    {
        static long MaxSubsetSum(int[] arr)
        {
            var memo = new Dictionary<int, long>();
            var arr2 = new[] {0, 0}.Concat(arr).ToArray();

            var result = MaxSubsetSum(arr2, 0, memo);

            return result;
        }

        static long MaxSubsetSum(int[] arr, int p, IDictionary<int, long> memo)
        {
            var subArrayLength = arr.Length - p;
            
            if (subArrayLength <= 0) return 0;
            if (subArrayLength <= 2)
                return arr[p];

            if (memo.ContainsKey(p))
                return memo[p];

            var result = long.MinValue;

            for (int i = p + 2; i < arr.Length; i++)
            {
                var maxSum = arr[p] + MaxSubsetSum(arr, i, memo);

                if (maxSum > result)
                    result = maxSum;
            }

            memo.Add(p, result);
            return result;
        }

        public static void RunMain()
        {
            var memo = new Dictionary<int, long>();
            var res = MaxSubsetSum(new[] {3, 7, 4, 6, 5});
            // Console.WriteLine(res);

            // int n = Convert.ToInt32(Console.ReadLine());
            //
            // int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp))
            //     ;
            // int res = MaxSubsetSum(arr);
            //
            // Console.WriteLine(res);
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