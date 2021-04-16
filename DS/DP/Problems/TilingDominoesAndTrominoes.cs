using System;
using System.Collections.Generic;

namespace DS.DP.Problems
{
    // https://leetcode.com/problems/domino-and-tromino-tiling/
    public class TilingDominoesAndTrominoes
    {
        private const long Mod = 1000000007;

        public int NumTilings(int N)
        {
            var memo = new int?[N + 1, 4];

            var result = SolveTopBottom(0, N, true, true, memo);
            return result;
        }

        static int SolveTopBottom(int i, int n, bool t1, bool t2, int?[,] memo)
        {
            if (i == n)
                return 1;

            var state = GetState(t1, t2);
            if (memo[i, state].HasValue)
                return memo[i, state].Value;

            long count = 0;
            var t3 = i + 1 < n;
            var t4 = i + 1 < n;

            //  1 1
            //  1 0
            if (t1 && t2 && t3)
                count += SolveTopBottom(i + 1, n, false, true, memo);

            // 1 0 
            // 1 1
            if (t1 && t2 && t4)
                count += SolveTopBottom(i + 1, n, true, false, memo);

            // 1 1
            // 0 1
            if (t1 && !t2 && t3 && t4)
                count += SolveTopBottom(i + 1, n, false, false, memo);

            // 0 1
            // 1 1
            if (!t1 && t2 && t3 && t4)
                count += SolveTopBottom(i + 1, n, false, false, memo);

            // 1
            // 1
            if (t1 && t2)
                count += SolveTopBottom(i + 1, n, true, true, memo);

            // 1 1
            // 1 1
            if (t1 && t2 && t3 && t4)
                count += SolveTopBottom(i + 1, n, false, false, memo);

            if (t1 && !t2 && t3)
                count += SolveTopBottom(i + 1, n, false, true, memo);

            if (!t1 && t2 && t4)
                count += SolveTopBottom(i + 1, n, true, false, memo);

            if (!t1 && !t2)
                count += SolveTopBottom(i + 1, n, true, true, memo);

            memo[i, state] = (int?) (count % Mod);
            return memo[i, state].Value;
        }

        static int GetState(bool t1, bool t2)
        {
            var state = 0;

            if (t1) state += 1;
            if (t2) state += 2;

            return state;
        }

        public static void Main2(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var obj = new TilingDominoesAndTrominoes();
            var result = obj.NumTilings(n);
            
            Console.WriteLine(result);
        }
    }
}