using System;

namespace DS._LeetCode.DP
{
    public class MaximalSquareProblem
    {
        public int MaximalSquare(char[][] matrix)
        {
            if (matrix.Length == 0) return 0;

            var m = matrix.Length;
            var n = matrix[0].Length;
            var max = 0;
            var table = new int[m + 1, n + 1];

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i][j] == '0') continue;

                    var y = i + 1;
                    var x = j + 1;

                    var val1 = table[y - 1, x];
                    var val2 = table[y, x - 1];
                    var val3 = table[y - 1, x - 1];

                    table[y, x] = Math.Min(Math.Min(val1, val2), val3) + 1;
                    max = Math.Max(max, table[y, x]);
                }
            }

            return max * max;
        }
    }
}