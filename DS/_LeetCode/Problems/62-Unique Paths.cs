using System.Collections.Generic;

namespace DS.LeetCode.Problems
{
    public class Unique_PathsProblem
    {
        public int UniquePaths(int m, int n)
        {
            return CountPaths(m, n, new Dictionary<string, int>());
        }

        int CountPaths(int m, int n, IDictionary<string, int> memo)
        {
            if (m == 0 || n == 0) return 0;
            if (m == 1 || n == 1) return 1;
            
            var key = $"{m},{n}";
            if (memo.ContainsKey(key)) return memo[key];

            var result = CountPaths(m - 1, n, memo) + CountPaths(m, n - 1, memo);
            memo.Add(key, result);

            return result;
        }
    }
}