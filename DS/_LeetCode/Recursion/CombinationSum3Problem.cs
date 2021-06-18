using System.Collections.Generic;

namespace DS._LeetCode.Recursion
{
    public class CombinationSum3Problem
    {
        public IList<IList<int>> CombinationSum3(int k, int n)
        {
            var arr = new int[9];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = i + 1;
            }

            return GetCombinations(arr, n, k, 0, 0);
        }

        static IList<IList<int>> GetCombinations(int[] arr, int target, int k, int p, int level)
        {
            if (level > k || target < 0) return new List<IList<int>>();
            if (target == 0 && level == k)
                return new List<IList<int>> {new List<int>()};

            var combinations = new List<IList<int>>();

            for (int i = p; i < arr.Length; i++)
            {
                var number = arr[i];
                var remainder = target - number;
                var remainderCombs =
                    GetCombinations(arr, remainder, k, i + 1, level + 1);

                foreach (var comb in remainderCombs)
                {
                    comb.Insert(0, number);

                    combinations.Add(comb);
                }
            }

            return combinations;
        }
    }
}