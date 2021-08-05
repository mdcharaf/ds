using System;
using DS._LeetCode.DP;
using DS._LeetCode.Graphs;
using DS._LeetCode.Recursion;
using DS.LeetCode.Problems;

namespace DS.LeetCode
{
    public class LeetCodeProgram
    {
        public static void Run()
        {
            var obj = new CheapestFlight();
            var edgeList = new[]
            {
                new[] {0, 1, 5},
                new[] {1, 2, 5},
                new[] {0, 3, 2},
                new[] {3, 1, 2},
                new[] {1, 4, 1},
                new[] {4, 2, 1},
            };

            var result = obj.FindCheapestPrice(5, edgeList, 0, 2, 2);

            Console.WriteLine(result);
        }
    }
}