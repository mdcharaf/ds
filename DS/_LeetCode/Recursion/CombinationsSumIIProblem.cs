using System;
using System.Collections.Generic;

namespace DS._LeetCode.Recursion
{
    public class CombinationsSumIIProblem
    {
        public static IList<IList<int>> CombinationSum2(int[] candidates, int target)
        {
            Array.Sort(candidates);
            var result = GetCombinations(candidates, target, 0);

            return result;
        }

        static IList<IList<int>> GetCombinations(int[] arr, int target, int p)
        {
            if (target < 0) return null;
            if (target == 0) return new List<IList<int>> {new List<int>()};


            var combinations = new List<IList<int>>();
            for (int i = p; i < arr.Length; i++)
            {
                if (i > p && arr[i] == arr[i - 1]) continue;
                var number = arr[i];
                var remainder = target - number;

                var remainderCombinations = GetCombinations(arr, remainder, i + 1);

                if (remainderCombinations != null)
                {
                    foreach (var comb in remainderCombinations)
                    {
                        comb.Insert(0, number);
                    }

                    combinations.AddRange(remainderCombinations);
                }
            }

            return combinations;
        }
    }
}