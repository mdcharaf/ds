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
            // var arr = new[] {"hot", "dot", "dog", "lot", "log", "cog"};
            // var result = WordLadderProblem.LadderLength("hit", "cog", arr);
            var arr = new[] {"hot", "dog", "dot"};
            var result = WordLadderProblem.LadderLength("hot", "dog", arr);
            
            Console.WriteLine(result);
        }
    }
}