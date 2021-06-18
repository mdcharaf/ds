using System;
using DS._LeetCode.DP;
using DS._LeetCode.Recursion;
using DS.LeetCode.Problems;

namespace DS.LeetCode
{
    public class LeetCodeProgram
    {
        public static void Run()
        {
            var arr = new[] {1, 2, 7, 6, 1, 5};
            var result = CombinationsSumIIProblem.CombinationSum2(arr, 8);
            Console.WriteLine(result.Count);
        }
    }
}