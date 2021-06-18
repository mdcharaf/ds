using System;
using DS._LeetCode.Recursion;
using DS.LeetCode.Problems;

namespace DS.LeetCode
{
    public class LeetCodeProgram
    {
        public static void Run()
        {
            var result = CombinationsProblem.Combine(4, 2);
            Console.WriteLine(result.Count);
        }
    }
}