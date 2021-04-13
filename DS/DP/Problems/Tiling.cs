using System.Collections.Generic;

namespace DS.DP
{
    // How many ways can you tile a board of length 5 with red tiles of length 1 and blue tiles of length 2?
    public class Tiling
    {
        // Recursive solution using memoization
        public int SolveRecursively(int n, IDictionary<int, int> memo = null)
        {
            memo ??= new Dictionary<int, int>();
            if (n < 0) return 0;
            if (n == 0) return 1;
            if (memo.ContainsKey(n)) return memo[n];

            var result =  SolveRecursively(n - 1, memo) + SolveRecursively(n - 2, memo);
            memo.Add(n, result);
            return result;
        }

        public int SolveDynamically(int n)
        {
            if (n == 0 || n == 1)
                return 1;

            var table = new int[n + 1];
            table[0] = 1;
            table[1] = 1;

            for (int i = 2; i <= n; i++)
            {
                table[i] = table[i - 1] + table[i - 2];
            }

            return table[n];
        }
        
    }
}