using System;
using System.Collections.Generic;

namespace DS.CodeSignal.IvPrep.DPBasic
{
    public class HouseRobberProblem
    {
        public static int HouseRobbers(int[] numbers)
        {
            var maxSum = MaxSum(numbers, 0, new Dictionary<int, int>());
            return maxSum;
        }

        static int MaxSum(int[] numbers, int p, IDictionary<int, int> memo)
        {
            if (p >= numbers.Length) return 0;
            if (memo.ContainsKey(p)) return memo[p];

            var maxSum = int.MinValue;
            for (int i = p; i < numbers.Length; i++)
            {
                var sum = numbers[i] + MaxSum(numbers, i + 2, memo);
                maxSum = Math.Max(maxSum, sum);
            }

            memo.Add(p, maxSum);
            return maxSum;
        }
    }
}