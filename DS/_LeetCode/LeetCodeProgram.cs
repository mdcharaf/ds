using System;
using DS.LeetCode.Problems;

namespace DS.LeetCode
{
    public class LeetCodeProgram
    {
        public static void Run()
        {
            var nums = new int[] {0, 4, 3, 0};
            int target = 0;
            var result = TwoSumProblem.TwoSum(nums, target);
            
            Console.WriteLine($"{result[0]},{result[1]}");
        }
    }
}