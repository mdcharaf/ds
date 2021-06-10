using System;
using DS.CodeSignal.IvPrep.DPBasic;
using DS.CodeSignal.IvPrep.Trees;

namespace DS.CodeSignal
{
    public class CodeSignalProgram
    {
        public static void Run()
        {
            var arr = new[] {1, 3, 1, 100, 101};

            var result = HouseRobberProblem.HouseRobbers(arr);
            
            Console.WriteLine(result);
        }
    }
}