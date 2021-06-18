using System.Collections.Generic;

namespace DS._LeetCode.Recursion
{
    public class CombinationsProblem
    {
        public static IList<IList<int>> Combine(int n, int k)
        {
            var arr = new int[n];

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = i + 1;
            }

            var res = CombinationsOf(arr, k, 0, 1);

            return res;
        }

        static IList<IList<int>> CombinationsOf(int[] arr, int k, int p, int depth)
        {
            if (depth > k) return new List<IList<int>> {new List<int>()};
            if (p >= arr.Length) return null;

            var result = new List<IList<int>>();

            for (int i = p; i < arr.Length; i++)
            {
                var el = arr[i];
                var combs = CombinationsOf(arr, k, i + 1, depth + 1);

                if (combs != null)
                {
                    foreach (var comb in combs)
                    {
                        comb.Insert(0, el);
                    }

                    result.AddRange(combs);
                }
            }

            return result;
        }
    }
}