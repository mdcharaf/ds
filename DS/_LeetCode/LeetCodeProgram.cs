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
            var grid = new[]
            {
                new[] {'1', '1', '1'},
                new[] {'0', '1', '0'},
                new[] {'1', '1', '1'},
            };

            var result = NumberOfIslandsProblem.NumIslands(grid);
            
            Console.WriteLine(result);
        }
    }
}